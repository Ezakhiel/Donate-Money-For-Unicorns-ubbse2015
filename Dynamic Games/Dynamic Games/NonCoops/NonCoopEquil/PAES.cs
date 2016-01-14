using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Games
{

    class PAES
    {
        int LARGE = 200000000;// should be about the maximum size of an integer for your compiler
        Random r;
        double pm;  // mutation rate as a decimal probability per bit (zero probability of generating current allele, uniform probability of generating all other allele values. i.e. for binary chromosomes this is the "flip" mutation rate.) 
        int depth, genes, alleles, archive, objectives, iterations; // command line parameters 
        int arclength, game, co; // current length of the archive

        double[] gl_offset = new double[10];   // MAX_OBJ the range, offset etc of the grid 
        double[] gl_range = new double[10];
        double[] gl_largest = new double[10];
        int[] grid_pop = new int[1000000];//new int[32768];   // MAX_LOC the array holding the population residing in each grid location


        char[] problem = new char[50];

        Solution c; // current solution
        Solution m; // mutant solution
        public List<Solution> arc; // archive of solutions
        List<string> parameters;
        NonCoopEquilForm form;
        String equil;
        public PAES(NonCoopEquilForm form1, int g, double max, String eq, int nr, String PM, List<string> paramet)
        {
            game = g;
            arclength = 0;
            equil = eq;
            co = 0;
            form = form1;
            r = new Random();
            int i;
            int result;
            parameters = paramet;
            depth = 3; //?? kellene novelni nagy szamok eseten..
            objectives = nr;
            genes = nr;
            alleles = (int)max;  
            archive = 50;     
            iterations = 1000; //? 10000
            pm = Convert.ToDouble(PM); 
 
            // begin (1+1)-PAES
            init();

            evaluate(c);
            add_to_archive(c);

            // begin main loop
            for (i = 0; i < iterations; i++)
            {
                m = new Solution(c);   // copy the current solution
                
                mutate(m);  // and mutate using the per-bit mutation rate specified by the command param pm
                evaluate(m);

                if (equil.Equals("Pareto"))
                    result = compare_max_Pareto(c.obj, m.obj, objectives);
                else
                    result = compare_max_Nash(c.obj, m.obj, objectives);


                if (result != 1)  // if mutant is not dominated by current (else discard it)
                {
            
                    if (result == -1)  // if mutant dominates current              
                    {
                        update_grid(m);           //calculate grid location of mutant solution and renormalize archive if necessary
                        archive_soln(m);          //update the archive by removing all dominated individuals

                        c = new Solution(m);      // replace c with m
                    }
                    else if (result == 0)  // if mutant and current are nondominated wrt each other
                    {
                        result = compare_to_archive(m);
                        if (result != -1)  // if mutant is not dominated by archive (else discard it)
                        {
                            update_grid(m);
                            archive_soln(m);
                            if ((grid_pop[m.grid_loc] <= grid_pop[c.grid_loc]) || (result == 1)) // if mutant dominates the archive or 
                            {                                                               // is in less crowded grid loc than c  
                                c = new Solution(m); // then replace c with m
                            }
                        }
                    }
                }
                if (arclength >= 50)
                    break;
            }
            Console.WriteLine("arclenth= " + arclength + "  Archive:");
            for (i = 0; i < arclength; i++)
            {
                for (int j = 0; j < objectives; j++)
                {
                    System.Console.Write(arc[i].obj[j].ToString() + ' ');
                }
                System.Console.WriteLine();
            }
            form.add_toListview(arc);
            if (game == 2)
                form.lConclusion.Text = "Number of cooperators: " + co.ToString();
        }
// // // // // //
        int compare_to_archive(Solution s)  // compares a solution to every member of the archive. Returns -1 if dominated by
        {                               // any member, 1 if dominates any member, and 0 otherwise
            int i = 0;
            int result = 0;

            while ((i < arclength) && (result != 1) && (result != -1))
            {
                if (equil.Equals("Pareto"))
                    result = compare_max_Pareto(m.obj, arc[i].obj, objectives);
                else
                    result = compare_max_Nash(m.obj, arc[i].obj, objectives);
                i++;
            }
            return (result);
        }

        void init()
        {
            int i;
            int val;

            c = new Solution();
            m = new Solution();
            arc = new List<Solution>(50);

            // initialise c with a uniform distribution of values from 0 to alleles-1
            for (i = 0; i < genes; i++)
            {
                val = (int)(alleles * (r.Next() / (Int32.MaxValue + 1.0)));
                c.chrom[i] = val;
            }
        }

        void add_to_archive(Solution s) 
        {
            arclength++;
            arc.Add(s);
        }

        void mutate(Solution s)  // apply mutation to chromosome s using per-gene mutation probability pm.  
        {
            int i;
            int var;

            for (i = 0; i < genes; i++)
            {
                if ((r.Next() / (Int32.MaxValue + 1.0)) < pm) // mutate gene ?
                {
                    var = 1 + (int)((alleles - 1) * (r.Next() / (Int32.MaxValue + 1.0)));  // generate var between 1 and alleles-2
                    s.chrom[i] = (s.chrom[i] + var) % alleles;  // add var to allele value of current gene and mod.  
                }
            }
        }

        void evaluate(Solution s)
        {
            Payoffs p = new Payoffs();
            if (game == 1)
            {
                for (int i = 0; i < objectives; i++)
                    s.obj[i] = p.Cournot_payoff(s.chrom[i], s.chrom, parameters);
            }
            else
                if (game == 2)
                {                                      // nr.player   0 1     invest., mult.fact 
                    for (int i = 0; i < objectives; i++)
                        s.obj[i] = p.Public_good_payoff(s.chrom[i], objectives, s.chrom, parameters);;
                    co = p.getCoop();
                }
        }

        //c               m       objectives
        int compare_max_Pareto(double[] first, double[] second, int n)
        {
            // as for compare_min() but for maximization problems 

            int deflt = 0;
            int current;
            int i = 0;
            do
            {
                if (first[i] > second[i])
                    current = 1;
                else if (second[i] > first[i])
                    current = -1;
                else
                    current = 0;
                if ((current != 0) && (current == ((-1) * deflt))) 
                {
                    return (0);
                }
                if (current != 0)
                {
                    deflt = current;
                }
                i++;
            } while (i < n);
            return (deflt);
        }

        int compare_max_Nash(double[] first, double[] second, int n)
        {
            double[] first1;
            double[] second1;
            int k1 = 0;
            int k2 = 0;
            for (int i = 0; i < n; i++)
            {
                first1 = (double[])first.Clone();
                second1 = (double[])second.Clone();
               // first1 = first;
               // second1 = second;
                first1[i] = second[i];
                second1[i] = first[i];
                if (first[i] > first1[i])
                    k1++;
                if (second[i] > second1[i])
                    k2++;
                }
                if (k1 < k2)
                    return -1; //1
                if (k1 > k2)
                    return 1;
           // }
            return 0;
        }


        int equal(double[] first, double[] second, int n)
        {
            // checks to n-dimensional vectors of objectives to see if they are identical
            // returns 1 if they are, 0 otherwise

            int i = 0;
            do
            {
                if (first[i] != second[i])
                    return (0);
                i++;
            } while (i < n);
            return (1);
        }


        void archive_soln(Solution s)
        {
            // given a solution s, add it to the archive if
            // a) the archive is empty 
            // b) the archive is not full and s is not dominated or equal to anything currently in the archive
            // c) s dominates anything in the archive                        
            // d) the archive is full but s is nondominated and is in a no more crowded square than at least one solution
            // in addition, maintain the archive such that all solutions are nondominated. 

            int i;
            int repl = 0;
            bool yes = false;
            int most;
            int result;
            int join = 0;
            int old_arclength;
            int set = 0;


            int[] tag = new int[200];//MAX_ARC
            List<Solution> tmp = new List<Solution>(50);

            for (i = 0; i < archive; i++)
            {
                tag[i] = 0;
            }


            if (arclength == 0)
            {
                add_to_archive(s);
                return;
            }


            i = 0;
            result = 0;
            while ((i < arclength) && (result != -1))
            {
                result = equal(s.obj, arc[i].obj, objectives);
                if (result == 1)
                    break;
                if (equil.Equals("Pareto"))
                    result = compare_max_Pareto(s.obj, arc[i].obj, objectives);
                else
                    result = compare_max_Nash(s.obj, arc[i].obj, objectives);

                if ((result == 1) && (join == 0))
                {
                    arc[i] = s;
                    join = 1;
                }
                else if (result == 1)
                {
                    tag[i] = 1;
                    set = 1;
                }
                i++;
            }

            old_arclength = arclength;
            if (set == 1)
            {
                for (i = 0; i < arclength; i++)
                {
                    tmp.Add(arc[i]);
                }
                arclength = 0;

                for (i = 0; i < old_arclength; i++)
                {
                    if (tag[i] != 1)
                    {
                        arc[arclength] = tmp[i];
                        arclength++;
                    }
                }
            }


            if ((join == 0) && (result == 0))  // ie solution is non-dominated by the list
            {
                if (arclength == archive)
                {
                    most = grid_pop[s.grid_loc];
                    for (i = 0; i < arclength; i++)
                    {
                        if (grid_pop[arc[i].grid_loc] > most)
                        {
                            most = grid_pop[arc[i].grid_loc];
                            repl = i;
                            yes = true;
                        }
                    }
                    if (yes)
                    {
                        arc[repl] = s;
                    }
                }
                else
                {
                    add_to_archive(s);
                }
            }
        }

        int find_loc(double[] eval)
        {
            // find the grid location of a solution given a vector of its objective values

            int loc = 0;
            int d;
            int n = 1;

            int i;

            int[] inc = new int[10]; //MAX_OBJ
            double[] width = new double[10];


            // if the solution is out of range on any objective, return 1 more than the maximum possible grid location number
            for (i = 0; i < objectives; i++)
            {
                if ((eval[i] < gl_offset[i]) || (eval[i] > gl_offset[i] + gl_range[i]))
                 //   return ((int)Math.Pow(2, (objectives * depth))); 
                    return ((int)Math.Pow((objectives * depth),4)); 
            }

            for (i = 0; i < objectives; i++)
            {
                inc[i] = n;
                n *= 2;
                width[i] = gl_range[i];
            }

            for (d = 1; d <= depth; d++)
            {
                for (i = 0; i < objectives; i++)
                {
                    if (eval[i] < width[i] / 2 + gl_offset[i])
                        loc += inc[i];
                    else
                        gl_offset[i] += width[i] / 2;
                }
                for (i = 0; i < objectives; i++)
                {
                    inc[i] *= (objectives * 2);
                    width[i] /= 2;
                }
            }
            return (loc);
        }

        void update_grid(Solution s)
        {
            // recalculate ranges for grid in the light of a new solution s
            //static int change = 0;
            int change = 0;
            int a, b;
            int square;
            double[] offset = new double[10];//MAX_OBJ
            double[] largest = new double[10];
            double sse;
            double product;

            for (a = 0; a < objectives; a++)
            {
                offset[a] = LARGE;
                largest[a] = -LARGE;
            }

            for (b = 0; b < objectives; b++)
            {
                for (a = 0; a < arclength; a++)
                {
                    if (arc[a].obj[b] < offset[b])
                        offset[b] = arc[a].obj[b];
                    if (arc[a].obj[b] > largest[b])
                        largest[b] = arc[a].obj[b];
                }
            }


            for (b = 0; b < objectives; b++)
            {
                if (s.obj[b] < offset[b])
                    offset[b] = s.obj[b];
                if (s.obj[b] > largest[b])
                    largest[b] = s.obj[b];
            }

            sse = 0;
            product = 1;

            for (a = 0; a < objectives; a++)
            {

                sse += ((gl_offset[a] - offset[a]) * (gl_offset[a] - offset[a]));
                sse += ((gl_largest[a] - largest[a]) * (gl_largest[a] - largest[a]));
                product *= gl_range[a];
            }

            if (sse > (0.1 * product * product))	//if the summed squared error (difference) between old and new
            //minima and maxima in each of the objectives
            {                                   //is bigger than 10 percent of the square of the size of the space
                change++;                         // then renormalise the space and recalculte grid locations

                for (a = 0; a < objectives; a++)
                {
                    gl_largest[a] = largest[a] + 0.2 * largest[a];
                    gl_offset[a] = offset[a] + 0.2 * offset[a];
                    gl_range[a] = gl_largest[a] - gl_offset[a];
                }

                //for (a = 0; a < Math.Pow(2, (objectives * depth)); a++)
                for (a = 0; a < Math.Pow((objectives * depth),4); a++)
                {
                    grid_pop[a] = 0;
                }

                for (a = 0; a < arclength; a++)
                {
                    square = find_loc(arc[a].obj);
                    //(&arc[a])->grid_loc = square;
                    arc[a].grid_loc = square;
                    grid_pop[square]++;

                }
            }
            square = find_loc(s.obj);
            s.grid_loc = square;
            //grid_pop[(int)Math.Pow(2, (objectives * depth))] = -5;
            grid_pop[(int)Math.Pow((objectives * depth),4)] = -5;
            grid_pop[square]++;
        }
    }
}
