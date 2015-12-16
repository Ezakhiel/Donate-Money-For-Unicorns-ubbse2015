using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Dynamic_Games
{
    public partial class NonCoopForm : Form
    {
        private GenerateGraph gg;
        private int[,] checkMatrix, graph;
        private int[] colors;
        private int N;

        public NonCoopForm()
        {
            InitializeComponent();
            gg = new GenerateGraph();
        }

        private void NonCoopForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // If the simulation isn't running
            if (StartButton.Text.Equals("Start"))
            {
                StartButton.Text = "Step";
                NoPTB.ReadOnly = true;
                MultiTB.ReadOnly = true;
                InvestmentTB.ReadOnly = true;

                Random rand = new Random();

                // Counting the payoff values
                int r = Convert.ToInt32(MultiTB.Text);
                int c = Convert.ToInt32(InvestmentTB.Text);
                N = Convert.ToInt32(NoPTB.Text);
                int coopPerc = rand.Next(50,100);
                percTB.Text = coopPerc + "";
                int nc = N * coopPerc / 100; int nd = N - nc;


                NrCoopTB.Text = nc + "";
                nrDefTB.Text = nd + "";



                int pd = (r * nc * c) / N, cd = pd - c;
                DefectorTB.Text = pd + "";
                ContributorTB.Text = cd + "";

                // Generating the graph
                int edgeNr = 0;
                graph = null; colors = new int[N];
                checkMatrix = new int[N, N];

                if (GraphTypeCB.Text.Equals("Random Graph"))
                {
                    edgeNr = rand.Next(N * (N - 1) / 2);
                    graph = new int[edgeNr, 2];

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
                            graph[i, 0] = i;
                            graph[i, 1] = to;

                        }
                    }

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


                }
                else
                {

                }

                // Making the image and drawing on the form
                gg.generate(graph, edgeNr, colors);
                gg.runPicture();

                while (File.Exists("graph.jpg") == false)
                {
                    Console.Write("Exists: " + System.IO.File.Exists("graph.jpg"));
                }
                graphBox.ImageLocation = "graph.jpg";
            }
            else
            {
                if (ruleCB.Text.Equals(""))
                {
                    MessageBox.Show("Please select a rule!");
                }
                else if (ruleCB.Text.Equals("Neighbors Decide"))
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


                    Console.WriteLine();
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            Console.Write(checkMatrix[i, j] + " ");
                        }
                        Console.WriteLine();
                    }

                        for (int i = 0; i < N; i++)
                        {
                            Console.WriteLine(i + ". node: " + neighborCont[i]);
                        }
                }
                else if (ruleCB.Text.Equals("Mult. Fact. Grows"))
                {

                }
                else if (ruleCB.Text.Equals("Minimum Percentage"))
                {

                }

            }
        }

        // Restart Button
        private void RestartButton_Click(object sender, EventArgs e)
        {
            StartButton.Text = "Start";
            NoPTB.ReadOnly = false;
            MultiTB.ReadOnly = false;
            InvestmentTB.ReadOnly = false;

            NoPTB.Text = "";
            MultiTB.Text = "";
            InvestmentTB.Text = "";
            NrCoopTB.Text = "";
            nrDefTB.Text = "";
            percTB.Text = "";
            ContributorTB.Text = "";
            DefectorTB.Text = "";
        }
    }
}
