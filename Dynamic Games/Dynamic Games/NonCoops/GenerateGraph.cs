using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Dynamic_Games
{
    class GenerateGraph
    {

        public void generate(int[,] matrix, int n, int[] colors)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter("graph.txt"))
            {
                file.WriteLine("graph G{");
                file.WriteLine("ranksep=0.3;");
                file.WriteLine("nodesep=0.3;");
                file.WriteLine("rankdir=LR;");
                file.WriteLine("fixedSize=true");
                file.WriteLine("node [shape=\"circle\",fontsize=\"12\", width = \"0.1\"];");
                file.WriteLine("compound=true;");
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, 0] != matrix[i, 1])
                    {
                        file.WriteLine(matrix[i, 0] + " -- " + matrix[i, 1]);
                    }
                }
                for (int i = 0; i < colors.Length; i++)
                {
                    if (colors[i] == 1)
                    {
                        file.WriteLine(i+ " [fillcolor=\"red\", style=\"filled\"];");
                    }
                    else
                    {
                        file.WriteLine(i + " [fillcolor=\"green\", style=\"filled\"];");
                    }
                }
                file.WriteLine("}");
            }
        }

        public void runPicture()
        {
            string fileName = "bin\\dot";
            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\NonCoops\Kits\", fileName);
            
            var process = Process.Start(path, "graph.txt -Tjpg -o graph.jpg");
            process.WaitForExit();
        }


    }
}
