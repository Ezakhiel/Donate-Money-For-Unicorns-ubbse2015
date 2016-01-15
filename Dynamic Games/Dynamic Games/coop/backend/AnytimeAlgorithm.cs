using Dynamic_Games.coop.models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Games.coop.backend
{
    class AnytimeAlgorithm : EquilibriumCalculator
    {
        private List<int[]> setG; // the set of possible integer partitions of n.
        private List<Double> avgOfSetG; // the average value of elements in Coalitions classified by G
        private List<Double> maxOfSetG;// the maximum value of elements in Coalitions classified by G
        private Double beta; // the bound on the quality of the best solution found so far
        private Double ub; // upper bound
        private Coalition[] cs; // best Coalition Structure found so far
        private int n; // number of Players;
        private Coalition[][] l; // l[s] is all Coalition containing s player
        private Player[] players;
        private List<Coalition[]> coalitionStructuresFound;

        private struct PruneResult
        {
            public List<int[]> setG;
            public List<Double> avgOfSetG;
            public List<Double> maxOfSetG;
        }

        private struct StackStructForSearchList
        {
            public int[] alpha;
            public Player[][] players;
            public List<Coalition>[] mSet;
            public int[] m;

            public StackStructForSearchList(int n)
            {
                alpha = new int[n];
                players = new Player[n][];
                mSet = new List<Coalition>[n];
                m = new int[n];
            }

        }

        //returns the maximum value of a coalition structure
        private Double ValueOfCoalitionStructure(Coalition[] cs)
        {
            Double result = 0;
            foreach (var c in cs)
            {
                result += c.getMaximumValue();
            }
            return result;
        }

        //get n Number's partitions containing  exactly l number;
        private List<int[]> getNumbersPartition(int n, int l)
        {
            List<int[]> partitions = new List<int[]>();
            int[] partition = new int[l]; // one partition contains exactly l number;
            partition[0] = n - l + 1;
            for (var j = 1; j < l; j++)
            {
                partition[j] = 1;
            }//the first partition is exact
            partitions.Add(partition.ToArray<int>());

            var index = 0;
            while (index >= 0)
            {
                if (index + 1 == l)
                {
                    index--;
                }
                else if (partition[index] - 1 > partition[index + 1])
                {
                    partition[index]--;
                    partition[index + 1]++;
                    partitions.Add(partition.ToArray<int>());
                    if (index + 1 < l)
                        index++;
                }
                else
                {
                    index--;
                }
            }//calculate all other partitions
            return partitions;
        }

        //generate n numbers all partitions except those are l long
        private List<int[]> generateNumbersAllPartitionExcept(int n, int l)
        {
            List<int[]> partitions = new List<int[]>();
            for (var i = 1; i <= n; i++)
            {
                if (i != l)
                    partitions.AddRange(getNumbersPartition(n, i));
            }

            return partitions;
        }

        private PruneResult prune(List<int[]> setG, List<Double> maxg, List<Double> avgg, Double v)
        {
            var i = 0;
            while (i < setG.Count)
            {
                if (maxg[i] > v)
                {
                    setG.RemoveAt(i);
                    maxg.RemoveAt(i);
                    avgg.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            var result = new PruneResult();
            result.setG = new List<int[]>();
            result.avgOfSetG = avgg;
            result.maxOfSetG = maxg;
            return result;
        }

        private void addtoFoundStructures(){
            coalitionStructuresFound.Add(cs.ToArray<Coalition>());
        }

        private void scanAndSearch()
        {
            //Pi = coalitions structures which contains i coalition
            var valueOfP1 = ValueOfCoalitionStructure(l[0]);
            var valueOfPn = ValueOfCoalitionStructure(l[n - 1]);
            cs = l[0];  //best coalition structure found so far
            var vcs = valueOfP1;  //value of best coalition structure found so far
            if (valueOfP1 < valueOfPn)
            {
                cs = l[n - 1];
                vcs = valueOfPn;
            }
            addtoFoundStructures();
            var maxs = new Double[n]; //maximum value of l[s]
            var avgs = new Double[n]; //average value of l[s]
            var sums = new Double[n]; //sum value of l[s]
            var vmax = Double.MinValue; //maximum of current coalitions structure formed by 2 complementary coalitions
            var xmax = 0; // index of vmax
            for (var s = 1; s <= n / 2; s++)//scan all complementary coalitions
            {
                var s1 = s - 1;
                var s2 = (n - s) - 1;
                var end = l[s1].Length; // length of coalitions containing s player
                if (s1 == s2)//same list
                {
                    end = end / 2;
                }
                maxs[s1] = Double.MinValue;
                maxs[s2] = Double.MinValue;
                sums[s1] = 0;
                for (var x = 1; x <= end; x++)
                {
                    var x1 = x - 1;
                    var x2 = (l[s1].Length - x + 1) - 1;
                    var v1 = l[s1][x1].getMaximumValue(); //value of coalition ls1x1
                    var v2 = l[s2][x2].getMaximumValue(); //value of coalition ls2x2
                    if (vmax < v1 + v2)
                    {
                        vmax = v1 + v2;
                        xmax = x;
                    }
                    if (maxs[s1] < v1)
                        maxs[s1] = v1;
                    if (maxs[s2] < v2)
                        maxs[s2] = v2;
                    sums[s1] += v1;
                    sums[s2] += v2;
                }
                var xmax1 = xmax - 1;
                var xmax2 = (l[s1].Length - xmax + 1) - 1;
                var currentCS = new Coalition[] { l[s1][xmax1], l[s2][xmax2] }; // create coalition Structure of the 2 complementary coalitions 
                var vcurrentCS = ValueOfCoalitionStructure(currentCS);//value of currentCS
                if (vcs < vcurrentCS)// found a new best coalition structure
                {
                    cs = currentCS;
                    addtoFoundStructures();
                    vcs = vcurrentCS; 
                }
                avgs[s1] = sums[s1] / l[s1].Length;
                avgs[s2] = sums[s2] / l[s2].Length;
            }
            var gSet = generateNumbersAllPartitionExcept(n, 2);
            //set of possible integer partitions of n except that contains 2 parts(because we just scanned them)
            maxOfSetG = new List<Double>();
            avgOfSetG = new List<Double>();
            for (var i = 0; i < gSet.Count; i++)
            {
                int[] g = (int[])gSet[i];
                Double maxg = 0;
                Double avgg = 0;
                for (var j = 0; j < g.Length; j++)
                {
                    maxg += maxs[g[j] - 1];
                    avgg += avgs[g[j] - 1];
                }
                maxOfSetG.Add(maxg);
                avgOfSetG.Add(avgg);
            }
            var ub = Math.Max(vcs, maxOfSetG.Max()); //calculate upper bound
            var lb = Math.Max(vcs, avgOfSetG.Max()); //calculate lower bound
            PruneResult pruneResult = prune(gSet, maxOfSetG, avgOfSetG, lb);
            gSet = pruneResult.setG;
            maxOfSetG = pruneResult.maxOfSetG;
            avgOfSetG = pruneResult.avgOfSetG;
            beta = Math.Min(n / 2, ub / vcs);
        }

        //select next partition from partition set(setG)
        private int select(List<Double> maxg)
        {
            var index = maxg.IndexOf(maxg.Max());
            return index;
        }

        //calculate maximum value of buildable coalition structure while searching
        private Double getMaximumValueOfBuildableCoalitionStructure(Double vck, int[] g, int k)
        {
            var result = vck;
            for (var i = k; i < g.Length; i++)
            {
                var max = l[g[k]][0].getMaximumValue();
                for (var j = 1; j < l[g[k]].Length; j++)
                {
                    var value = l[g[k]][j].getMaximumValue();
                    if (max < value)
                        max = value;
                }
                result = result + max;
            }

            return result;
        }

        //calculate MSet, MSet[i] contains all possible coalition at ith level of searching
        // g number partitions, k level, gk length of coalition, a: players at k level, alpha: lower bound
        private List<Coalition> getMSet(int[] g, int k, int gk, Player[] a, int alpha)
        {
            List<Coalition> result = new List<Coalition>();
            var end = n + 1;
            for (var i = 0; i <= k; i++)
                end = end - g[i]; //calculate upper bound
            for (var i = alpha; i <= end; i++)
            {
                foreach (Coalition c in l[gk]) //every gk long coalition
                {
                    if (c.Players[0] == a[i - 1]) //first player is in current available players
                    {
                        Boolean correct = true;
                        foreach (var p in c.Players)
                        {
                            if (!a.Contains(p)) correct = false;
                        }
                        if (correct)
                        {
                            result.Add(c);
                        }
                    }
                }
            }
            return result;
        }

        private Coalition[] searchList(int[] g, Double maxOfg)
        {
            Double vck = 0;
            Double vcs = ValueOfCoalitionStructure(cs);
            var k = 0;
            var stack = new StackStructForSearchList(g.Length); //stack for searching
            var ck = new List<Coalition>(); //list of current coalitions
            stack.players[0] = (Player[])players.Clone();
            stack.m[k] = -1; //coalition's index

            stack.alpha[0] = 1;
            stack.mSet[k] = getMSet(g, k, g[k] - 1, stack.players[k], stack.alpha[k]); //set of coalitions at first level

            while (k >= 0)
            {
                stack.m[k]++;
                if (stack.m[k] < stack.mSet[k].Count) //if it's a valid coalition index
                {
                    if (stack.m[k] > 0)
                    {
                        vck -= ((Coalition)ck[ck.Count - 1]).getMaximumValue();
                        ck.RemoveAt(ck.Count - 1); //remove previous Coalition
                    }
                    var currentCoalition = stack.mSet[k][stack.m[k]];
                    ck.Add(currentCoalition);
                    vck += currentCoalition.getMaximumValue();
                    if (k == g.Length - 1 && vck > vcs) // new best coalition structure
                    {
                        cs = ck.ToArray();
                        addtoFoundStructures();
                        vcs = vck;
                    }
                    else if (vcs < getMaximumValueOfBuildableCoalitionStructure(vck, g, k + 1)) //can the current CS better than the best so far
                    {
                        var newLengthOfPlayers = stack.players[k].Length - currentCoalition.Players.Count; // calculate number of rest players
                        stack.players[k + 1] = new Player[newLengthOfPlayers];
                        var j = 0;
                        for (var i = 0; i < stack.players[k].Length; i++)
                        {
                            if (!currentCoalition.Players.Contains(stack.players[k][i]))
                            {
                                stack.players[k + 1][j] = stack.players[k][i]; // players whos arent used yet
                                j++;
                            }
                        }
                        k++;
                        stack.m[k] = -1;
                        var index = 0;
                        if (k > 0 && g[k - 1] != g[k])
                        {
                            stack.alpha[k] = 1;
                        }
                        else
                        {
                            for (var i = 0; i < players.Length; i++)
                            {
                                if (players[i] == currentCoalition.Players[0])
                                    index = i;
                            }
                            stack.alpha[k] = index + 1;
                        } // calculate next level lower bound
                        stack.mSet[k] = getMSet(g, k, g[k] - 1, stack.players[k], stack.alpha[k]);
                        //calculate new coalitions to add current coalition structure at kth level
                    }
                }
                else
                {
                    if (stack.m[k] > 0)
                    {
                        vck -= ((Coalition)ck[ck.Count - 1]).getMaximumValue();
                        ck.RemoveAt(ck.Count - 1); // remove previous coalition
                    }
                    k--;
                }
                if (vcs == maxOfg) //if the cs is the best at this claster
                {
                    return cs;
                }
            }
            return cs;
        }

        //search all partitions
        private Coalition[] searchSpace(ArrayList a)
        {
            var vcs = ValueOfCoalitionStructure(cs);

            while (setG.Count != 0)
            {
                var gIndex = select(maxOfSetG);
                var g = (int[])setG[gIndex];
                var newCS = searchList(g, maxOfSetG[gIndex]);

                setG.RemoveAt(gIndex);
                maxOfSetG.RemoveAt(gIndex);
                avgOfSetG.RemoveAt(gIndex);

                if (newCS != cs)
                {
                    cs = newCS;
                    vcs = ValueOfCoalitionStructure(cs);
                    PruneResult pruneResult = prune(setG, maxOfSetG, avgOfSetG, vcs);
                    setG = pruneResult.setG;
                    maxOfSetG = pruneResult.maxOfSetG;
                    avgOfSetG = pruneResult.avgOfSetG;
                }
                if (setG.Count > 0)
                {
                    ub = Math.Max(vcs, maxOfSetG.Max()); // new upper bound
                    beta = Math.Min(ub / vcs, beta); //new bound on quality
                }
            }
            return cs;
        }

        //calculate l, combinations of Coalitions
        private List<Coalition>[] getCombinations(int n, Player[] players, int m)
        {
            var result = new List<Coalition>[n];
            var stack = new int[n];
            for (int i = 1; i <= n; i++)
            {
                stack[0] = -1;
                result[i - 1] = new List<Coalition>();
                int l = 0;
                while (l >= 0)
                {
                    stack[l]++;
                    if (stack[l] >= n)
                    {
                        l--;
                    }
                    else
                    {
                        if (l == i - 1)
                        {
                            Coalition coalition = new Coalition(m);
                            for (var j = 0; j < i; j++)
                            {
                                coalition.addPlayer(players[stack[j]]);
                            }
                            result[i - 1].Add(coalition);
                        }
                        else
                        {
                            l++;
                            stack[l] = stack[l - 1];
                        }
                    }
                }
            }
            return result;
        }

        public void init(Player[] players, int m)
        {
            this.players = players;
            this.n = players.Length;
            l = new Coalition[n][];
            var combinations = getCombinations(n, players, m);
            for (var i = 0; i < n; i++)
            {
                l[i] = combinations[i].ToArray();
            }
            coalitionStructuresFound = new List<Coalition[]>();
            scanAndSearch();
            searchSpace(new ArrayList(players));
        }

        public List<Coalition> getPartialResult()
        {
            if (coalitionStructuresFound.Count > 0)
            {
                var currentCS = coalitionStructuresFound[0];
                coalitionStructuresFound.RemoveAt(0);
                return currentCS.ToList<Coalition>();
            }
            else
            {
                return null;
            }
        }
    }
}
