using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dynamic_Games.coop.models;
using System.IO;
using Dynamic_Games.Coop.Models;
using System.Threading;
using Dynamic_Games.Coop.Exceptions;

namespace Dynamic_Games.coop.backend
{
    class Controller
    {
        static Controller instance;
        EquilibriumCalculator calculator;
        Thread calculatorThread;

        private Controller(){}

        public static Controller getInstance()
        {
            if (instance == null){
                instance = new Controller();
            }
            return instance;
        }

        private void selectCalculator()
        {
            calculator = new AnytimeAlgorithm();
        }


        public void init(string[] players, int[][] materials)
        {
            Player[] agents = new Player[players.Length];
            if (players.Length != materials.Length)
            {
                throw new InputException("False number of materials or players");
            }
            int m = materials[0].Length;
            for (var i = 0; i < players.Length; i++)
            {
                if (materials[i].Length != m)
                {
                    throw new InputException("False materials");
                }
                agents[i] = new Player(new ValueFunction(players[i]), materials[i]);
                agents[i].Name = Player.prefix + (i + 1);
                agents[i].ValueFunction.getValue(agents[i].Materials);
            }

            selectCalculator();
            calculator.init(agents, materials[0].Length);
            calculatorThread = new Thread(calculator.start);
            calculatorThread.Start();
        }

        private void init(String filename)
        {
            try
            {
                using (TextReader reader = File.OpenText(filename))
                {
                    string text = reader.ReadLine();
                    string[] bits = text.Split(' ');
                    int n = int.Parse(bits[0]);
                    int m = int.Parse(bits[1]);
                    Player[] players = new Player[n];
                    for (var i = 0; i < n; i++)
                    {
                        players[i] = new Player();
                        players[i].Name = "P" + i;
                        text = reader.ReadLine();
                        players[i].ValueFunction = new ValueFunction(text);
                    }
                    for (var i = 0; i < n; i++)
                    {
                        text = reader.ReadLine();
                        bits = text.Split(' ');
                        var materials = new int[m];
                        for (var j = 0; j < m; j++)
                        {
                            materials[j] = int.Parse(bits[j]);
                        }
                        players[i].Materials = materials;
                    }

                    calculator.init(players, m);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void stop()
        {
            if (calculator != null)
            {
                calculator.RequestStop();
            }
        }

        public PartialResult getPartialResult(){
            List<Coalition> coalitions = calculator.getPartialResult();
            if (coalitions != null) // if there was result yet
            {
                List<string> coals = new List<string>();
                List<int> profits = new List<int>();

                foreach (var coalition in coalitions)
                {
                    coals.Add(coalition.ToString() + "    ");
                    profits.Add(Convert.ToInt32(coalition.getMaximumValue()));
                }

                PartialResult result = new PartialResult();
                result.Coalitions = coals;
                result.Profits = profits;
                result.End = false;
                return result;
            }
            else // if there was no result
            {
                if (!calculatorThread.IsAlive){ //if thread is done
                    PartialResult result = new PartialResult();
                    result.End = true;
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
