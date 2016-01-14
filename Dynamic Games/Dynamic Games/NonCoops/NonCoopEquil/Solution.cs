using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dynamic_Games
{
    public class Solution
    {
        public int[] chrom;
	    public double[] obj;
	    public int grid_loc;

        public Solution(){
            chrom = new int[10]; //1000
            obj = new double[10];
        }

        public Solution(Solution c)
        {
            chrom = new int[10];
            for (int i = 0; i < 10; i++)
            {
                chrom[i] = c.chrom[i];
            }
            obj = new double[10];
            for (int i = 0; i < 10; i++)
            {
                obj[i] = c.obj[i];
            }
        }


    }
}
