using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Games.NonCoops
{
    class NonCoopManager
    {

        public void generateGraph()
        {

        }

        // Generating the graph itself
        public Tuple<int[,], int[,]> GenerateGraph(int edgeNr, int N)
        {
            Random rand = new Random();
            int[,] checkMatrix = new int[N,N];
            int[,] graph = new int[edgeNr, 2];
            for (int i = 0; i < edgeNr; i++)
            {
                int to = rand.Next(N), from = rand.Next(N);
                while (to == from)
                {
                    to = rand.Next(N);
                }

                if (checkMatrix[from, to] == 0 && checkMatrix[to, from] == 0)
                {
                    checkMatrix[from, to] = 1;
                    checkMatrix[to, from] = 1;
                    graph[i, 0] = from;
                    graph[i, 1] = to;

                }
            }

            int counter = 0;
            for (int i = 0; i < N; i++)
            {
                counter = 0;
                for (int j = 0; j < N; j++)
                {
                    if (j != i && checkMatrix[i, j] == 0 && checkMatrix[j, i] == 0)
                    {
                        counter++;
                    }
                }
                if (counter == N)
                {
                    int to = rand.Next(N);
                    while (i == to)
                    {
                        to = rand.Next(N);
                    }
                    checkMatrix[i, to] = 1;
                    checkMatrix[to, i] = 1;
                    graph[i, 0] = i;
                    graph[i, 1] = to;

                }
            }
            return Tuple.Create(graph, checkMatrix);
        }

        // Deciding whether a player contributes or not in the beginning
        public int[] GenColors(int N, int nc, int nd)
        {
            Random rand = new Random();
            int[] colors = new int[N];
            for (int i = 0; i < N; i++)
            {
                if (nc == 0)
                {
                    nd--;
                    colors[i] = 1;
                }
                else if (nd == 0)
                {
                    nc--;
                    colors[i] = 2;
                }
                else
                {
                    if (rand.Next(2) == 0)
                    {
                        nd--;
                        colors[i] = 1;
                    }
                    else
                    {
                        nc--;
                        colors[i] = 2;
                    }

                }
            }
            return colors;
        }

        // Generate the selflesness factors
        public int[] GenSelflesnessFactors(int N)
        {
            Random rand = new Random();
            int[] selflesness = new int[N];
            for (int i = 0; i < N; i++)
            {
                selflesness[i] = rand.Next(100);
            }
            return selflesness;
        }

        // Recreating the graph, when a new player comes
        public Tuple<int[,], int[,]> AddPlayerGenGraph(int N, int edgeNr, int edgeNrTmp, int[,] graph, int[,] checkMatrix)
        {
            Random rand = new Random();
            int[,] tmpGraph = new int[edgeNrTmp, 2];
            int[,] tmpCheckMatrix = new int[N+1, N+1];

            for (int i = 0; i < edgeNr; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    tmpGraph[i, j] = graph[i, j];
                }
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    tmpCheckMatrix[i, j] = checkMatrix[i, j];
                }
            }

            N++;

            int from = N - 1, to;
            for (int i = edgeNr; i < edgeNrTmp; i++)
            {
                to = rand.Next(N);
                while (to == from)
                {
                    to = rand.Next(N);
                }

                if (tmpCheckMatrix[from, to] == 0 && tmpCheckMatrix[to, from] == 0)
                {
                    tmpCheckMatrix[from, to] = 1;
                    tmpCheckMatrix[to, from] = 1;
                    tmpGraph[i, 0] = from;
                    tmpGraph[i, 1] = to;

                }
            }

            return Tuple.Create(tmpGraph, tmpCheckMatrix);
        }

        // Generating the new players selflessness factor
        public int[] AddPlayerGenSelflesness(int N, int[] selflessness)
        {
            Random rand = new Random();
            int[] tmpSelflesness = new int[N];
            for (int i = 0; i < N - 1; i++)
            {
                tmpSelflesness[i] = selflessness[i];
            }

            tmpSelflesness[N - 1] = rand.Next(100);
            return tmpSelflesness;
        }

        // Counts neighbors
        public int NeighborCounter(int N, int playerId, int[,] checkMatrix)
        {
            int neighborNr = 0;
            for (int i = 0; i < N; i++)
            {
                if (checkMatrix[playerId, i] == 1)
                {
                    neighborNr++;
                }
            }
            return neighborNr;
        }

        // When we delete a player we recreate the graph
        public Tuple<int[,], int[,]> DelPlayerGenGraph(int edgeNrTmp, int N, int edgeNr, int playerId, int[,] graph, int[,] checkMatrix)
        {
            int[,] tmpGraph = new int[edgeNrTmp, 2];
            int[,] tmpCheckMatrix = new int[N - 1, N - 1];

            int counter = 0;
            for (int i = 0; i < edgeNr; i++)
            {
                if (graph[i, 1] != playerId && graph[i, 0] != playerId)
                {
                    if (graph[i, 1] > playerId)
                    {
                        graph[i, 1]--;
                    }
                    if (graph[i, 0] > playerId)
                    {
                        graph[i, 0]--;
                    }
                    tmpGraph[counter, 0] = graph[i, 0];
                    tmpGraph[counter, 1] = graph[i, 1];
                    counter++;
                }
            }
            return Tuple.Create(tmpGraph, tmpCheckMatrix);
        }

        // After a player leaves we recreate the colors array
        public int[] DelGenColors(int N, int playerId, int[] colors)
        {
            int[] tmpColors = new int[N];
            int counter = 0;
            for (int i = 0; i < N + 1; i++)
            {
                if (i != playerId)
                {
                    tmpColors[counter] = colors[i];
                    counter++;
                }
            }
            return tmpColors;
        }

        // After a player leaves we recreate the selflessness array
        public int[] DelGenSelflessness(int N, int playerId, int[] selflessness)
        {
            int[] tmpSelflesness = new int[N];
            int counter = 0;
            for (int i = 0; i < N; i++)
            {
                if (i == playerId)
                {
                    tmpSelflesness[counter] = selflessness[i];
                    counter++;
                }
            }
            return tmpSelflesness;
        }
    }
}
