using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Games
{
    class Payoffs
    {
        int co = 0;

        public double Cournot_payoff(int s, int[] chrom, List<string> p)
        {
            double u_s;
            double a = Convert.ToDouble(p[0]);
            double c = Convert.ToDouble(p[1]);
            double sum = 0;
            for (int i = 0; i < chrom.Length; i++){
                sum+=chrom[i];
            }
            u_s = s * (a - c - sum);
            return u_s;
        }

        public double Public_good_payoff(int ch, int obj, int[] chrom, List<string> p)
        {
            double result;
            double invest = Convert.ToDouble(p[0]);
            double mult = Convert.ToDouble(p[1]);
            int coop = 0; //cooperators nr
            for (int i = 0; i < obj; i++)
            {
                if (chrom[i] > (invest / 2))
                    coop++;
            }
            
           // Console.WriteLine("COOP: " + coop);
            co = coop;
            result = (coop*invest*mult)/obj;
            if (ch > (invest / 2))
                result -= invest;

            return Math.Round(result, 2);
        }

        public int getCoop()
        {
            return co;
        }
    }
}
