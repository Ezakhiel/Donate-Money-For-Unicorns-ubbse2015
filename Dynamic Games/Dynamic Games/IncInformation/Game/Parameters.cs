using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Games.IncInformation.Game
{
    public class Parameters
    {
        Random rnd = new Random();
        public int sorszam;
        public double winFactor;
        public double betFactor;
        public int style;

        public Parameters(int sorszam, double winF, double betF, int style)
        {
            this.sorszam = sorszam;
            this.winFactor = winF;
            this.betFactor = betF;
            this.style = style;
        }


        public Parameters(int sorszam)
        {
            this.sorszam = sorszam;
        }

        public void printParam()
        {
            (new FileRW()).writeToFile(this);
        }

        public Parameters getLatestParam(int i)
        {
            FileRW reader = new FileRW();
            int tmp = reader.countParams();
            Parameters tmpP = reader.readLineFromFile(tmp - i);
            this.sorszam = tmpP.sorszam;
            this.winFactor = tmpP.winFactor;
            this.betFactor = tmpP.betFactor;
            this.style = tmpP.style;
            return this;
        }

        public void generateParameters()
        {
            style = rnd.Next(1, 4);
            winFactor = rnd.NextDouble() * (140 - 60) + 60; // between 60% to 140%
            betFactor = rnd.NextDouble() * (40 - 10) + 10;
        }

        public Parameters crossMutate(Parameters father)
        {
            Parameters child = new Parameters(this.sorszam + 1);

            int inherit = rnd.Next(1,2);
            if (inherit == 1)
                child.winFactor = this.winFactor;
            else
                child.winFactor = father.winFactor;
            inherit = rnd.Next(1, 2);
            if (inherit == 1)
                child.betFactor = this.betFactor;
            else
                child.betFactor = father.betFactor;
            inherit = rnd.Next(1, 2);
            if (inherit == 1)
                child.style = this.style;
            else
                child.style = father.style;

            return child;
        }

        public void simpleMutation()
        {
            this.winFactor += rnd.NextDouble() * 20 - 10;
            this.betFactor += rnd.NextDouble() * 10 - 5;
            this.style = rnd.Next(1, 4);
            this.sorszam++;
        }
    }
}
