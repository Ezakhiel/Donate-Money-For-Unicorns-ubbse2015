using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Games.IncInformation.Game
{
    class FileRW
    {
        String path = "..\\..\\IncInformation\\Player\\gen.txt";
        String humanGame = "..\\..\\IncInformation\\Player\\bestAI.txt";
        StreamReader sr;
        public FileRW()
        {
            
        }

        public void writeToFile(Parameters p)
        {
            File.AppendAllText(path, p.sorszam + 
                                " " + p.winFactor +
                                " " + p.betFactor +
                                " " + p.style + Environment.NewLine);
        }

        public Parameters readLineFromFile(int i)
        {
            sr = new StreamReader(path);
            Parameters par = null;
            String line;
            String head;

            head = sr.ReadLine();
            line = head;
            bool broken = false;
            int actual = 0;
            String[] words;

            while (head != null)
            {
                if (actual == i)
                {
                    words = head.Split(' ');
                    par = new Parameters(Int32.Parse(words[0]), Double.Parse(words[1]), Double.Parse(words[2]), Int32.Parse(words[3]));
                    broken = true;
                    break;
                }
                line = head;
                head = sr.ReadLine();
                actual++;
            }

            if (!broken)
            {
                words = line.Split(' ');
                par = new Parameters(Int32.Parse(words[0]), Double.Parse(words[1]), Double.Parse(words[2]), Int32.Parse(words[3]));
            }

            sr.Close();
            //close the file
            

            return par;

        }

        public Parameters readFromLast()
        {
            sr = new StreamReader(path);
            String line;

            Parameters par = null;

            line = sr.ReadLine();
            int i = 0;
            String[] words;
            //Continue to read until you reach end of file
            while ((line != null) && (line != ""))
            {
                words = line.Split(' ');
                par = new Parameters(Int32.Parse(words[0]), Double.Parse(words[1]), Double.Parse(words[2]), Int32.Parse(words[3]));
                i++;
                if (i == 3) i = 0;
                line = sr.ReadLine();
            }

            //close the file
            sr.Close();

            return par;
        }

        public int countParams()
        {
            sr = new StreamReader(path);
            String line;
            line = sr.ReadLine();
            int i = 0;
            while (line != null)
            {
                i++;
                line = sr.ReadLine();
            }
            return i;
        }
        public List<Parameters> readAncestors()
        {

            sr = new StreamReader(path);
            String line;

            List<Parameters> list = new List<Parameters>(3);

            list.Add(new Parameters(0));
            list.Add(new Parameters(0));
            list.Add(new Parameters(0));

            line = sr.ReadLine();
            int i = 0;
            String[] words;
            //Continue to read until you reach end of file
            while (line != null)
            {
                words = line.Split(' ');
                list[i] = new Parameters(Int32.Parse(words[0]), Double.Parse(words[1]), Double.Parse(words[2]), Int32.Parse(words[3]));
                i++;
                if (i == 3) i = 0;
                line = sr.ReadLine();
            }

            //close the file
            sr.Close();

            return list;
        }
    }
}
