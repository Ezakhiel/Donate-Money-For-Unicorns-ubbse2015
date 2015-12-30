using System;
using System.Collections.Generic;
using System.Text;
using HoldemHand;

namespace HandEvaluator
{
    class Program
    {
        static void Main(string[] args)
         {
             // initialize board
             string board = "2d kh qh 3h qc";
             // Create a mask with AKs plus board
             Hand h1 = new Hand("ad kd", board);
             // Create a mask with 23 unsuited plus board
             Hand h2 = new Hand("2h qd", board);
             // Find stronger mask and print results
           
             if (h1 > h2)
             {
                 Console.WriteLine("{0} greater than \n\t{1}", h1.Description, h2.Description);
             }
             else
             {
                 Console.WriteLine("{0} less than or equal \n\t{1}", h1.Description, h2.Description);
             }
             Console.WriteLine(h1.HandValue);
             Console.WriteLine(h2.HandValue);
             Console.ReadLine();
        }
     }
}

