using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Games
{
    class Rules
    {

        // The first rule
        public int[] NeighborsDecide(int N, int[,] checkMatrix, int[] colors, int ruleParam)
        {
            int[] neighborCont = new int[N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (checkMatrix[i, j] != 0)
                    {
                        neighborCont[i]++;
                    }
                }
            }

            int[] newColors = new int[N];
            for (int i = 0; i < N; i++)
            {
                int defNr = 0;
                for (int j = 0; j < N; j++)
                {

                    if (checkMatrix[i, j] != 0 && colors[j] == 1)
                    {
                        defNr++;
                    }
                }

                if (neighborCont[i] > 0 && defNr >= (int)(neighborCont[i] * ruleParam / 100))
                {
                    newColors[i] = 1;
                }
                else
                {
                    newColors[i] = colors[i];
                }
            }

            return newColors;
        }

        // The second tule - Part 1
        public float MultFactGrows(int N, float multFact , int ruleParam, int coopPerc)
        {
            if (coopPerc >= ruleParam && (multFact+multFact*10/100)<N)
            {
                multFact += multFact * 10 / 100;
            }
            return multFact;
        }

        // The second rule - Part 2
        public int[] SelflesnessMultFactGrows(int N, float pd, int c, float[] moneyArr, float[] investmentArr, int[] selflessness, int[] colors)
        {
            float moneyBefore = 0, investmentBefore = 0, counter = 0;
            for (int i = 0; i < 3; i++)
            {
                if (moneyArr[i] != -1)
                {
                    Console.WriteLine("MoneyArr[" + i + "] = " + moneyArr[i]);
                    moneyBefore += moneyArr[i];
                    investmentBefore += investmentArr[i];
                    counter++;
                }
            }

            moneyBefore /= counter; investmentBefore /= counter;
            Console.WriteLine("MoneyBefore: " + moneyBefore);

            int[] newColors = new int[N];
            Random rand = new Random();

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(i + ". selflesness: " + selflessness[i]);
            }

            int howSelflessIAm = 0;
            for (int i = 0; i < N; i++)
            {
                if (colors[i] == 1)
                {
                    howSelflessIAm = rand.Next(100);
                    Console.WriteLine(i + " - RED - How Selfless I Am: " + howSelflessIAm);
                    if (howSelflessIAm < selflessness[i] && pd < moneyBefore)
                    {
                        newColors[i] = 2;
                    }
                    else
                    {
                        newColors[i] = 1;
                    }
                }
                else
                {
                    howSelflessIAm = rand.Next(100);
                    Console.WriteLine(i + " - GREEN - How Selfless I Am: " + howSelflessIAm);
                    if (selflessness[i] > 91)
                    {
                        newColors[i] = 2;
                    }
                    else if (pd > c && howSelflessIAm < selflessness[i])
                    {
                        newColors[i] = 2;
                    }
                    else
                    {
                        newColors[i] = 1;
                    }
                }
            }
            return newColors;
        }

        // The third rule
        public int[] NeighborsAndSelflesness(int N, int c, float pd, int[,] checkMatrix, int[] colors, int ruleParam, int[] selflessness, float[] investmentArr, float[] moneyArr)
        {
            float moneyBefore = 0, investmentBefore = 0, counter = 0;
            for (int i = 0; i < 3; i++)
            {
                if (moneyArr[i] != -1)
                {
                    Console.WriteLine("MoneyArr[" + i + "] = " + moneyArr[i]);
                    moneyBefore += moneyArr[i];
                    investmentBefore += investmentArr[i];
                    counter++;
                }
            }

            moneyBefore /= counter; investmentBefore /= counter;
            Console.WriteLine("MoneyBefore: " + moneyBefore);

            Random rand = new Random();

            int[] neighborCont = new int[N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (checkMatrix[i, j] != 0)
                    {
                        neighborCont[i]++;
                    }
                }
            }

            int[] newColors = new int[N];
            int howSelflessIAm;
            for (int i = 0; i < N; i++)
            {
                int defNr = 0;
                for (int j = 0; j < N; j++)
                {

                    if (checkMatrix[i, j] != 0 && colors[j] == 1)
                    {
                        defNr++;
                    }
                }

                howSelflessIAm = rand.Next(100);
                if (colors[i] == 1)
                {
                    Console.WriteLine("PD: " + pd + " moneyBefore: " + moneyBefore);
                    howSelflessIAm = rand.Next(100);
                    if (pd < moneyBefore && howSelflessIAm < selflessness[i])
                    {
                        newColors[i] = 2;
                    }
                    else if(defNr >= (int)(neighborCont[i] * ruleParam / 100)){
                        newColors[i] = 1;
                    }
                    else if (howSelflessIAm < selflessness[i])
                    {
                        newColors[i] = 2;
                    }
                    else
                    {
                        newColors[i] = 1;
                    }
                }
                else
                {
                    if (howSelflessIAm > selflessness[i])
                    {
                        newColors[i] = 1;
                    }
                    else if (pd > c || defNr < (int)(neighborCont[i] * ruleParam / 100)) {
                        newColors[i] = 2;
                    }
                    else
                    {
                        newColors[i] = 1;
                    }
                }
            }

            return newColors;
        }
    }
}
