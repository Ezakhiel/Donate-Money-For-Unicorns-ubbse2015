using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Games
{
    class Rules
    {

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

                if (defNr >= (int)(neighborCont[i] * ruleParam / 100))
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

        public float MultFactGrows(int N, float multFact , int ruleParam, int coopPerc)
        {
            if (coopPerc >= ruleParam && (multFact+multFact*10/100)<N)
            {
                multFact += multFact * 10 / 100;
            }
            return multFact;
        }
    }
}
