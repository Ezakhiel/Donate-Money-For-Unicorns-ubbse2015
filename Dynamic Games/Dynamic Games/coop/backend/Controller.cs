using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dynamic_Games.coop.models;
using System.IO;

namespace Dynamic_Games.coop.backend
{
    class Controller
    {
        static Controller instance;
        EquilibriumCalculator calculator;

        private Controller(){
            calculator = new AnytimeAlgorithm();
        }

        public static Controller getInstance()
        {
            if (instance == null){
                instance = new Controller();
            }
            return instance;
        }

        public void init(string[] players, int[][] materials)
        {
            Player[] agents = new Player[players.Length];
            for (var i = 0; i < players.Length; i++)
            {
                agents[i] = new Player(new ValueFunction(players[i]), materials[i]);
                agents[i].Name = Player.prefix + (i + 1);
            }
            calculator.init(agents, materials[0].Length);
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

        public List<Coalition> getPartialResult(){
            return calculator.getPartialResult();
        }
    }
}
