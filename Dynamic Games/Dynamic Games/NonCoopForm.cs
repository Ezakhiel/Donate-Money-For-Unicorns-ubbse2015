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
        private int N, c, nc;
        private float r, pd, cd;
        private int[,] checkMatrix, graph;
        private int[] colors;
        private int edgeNr, turn = 0;
        private Rules rules;

        public NonCoopForm()
        {
            InitializeComponent();
            rules = new Rules();
        }

        private void NonCoopForm_Load(object sender, EventArgs e)
        {
            
        }

        public bool checkParams()
        {
            if (NoPTB.Text.Equals(""))
            {
                //MessageBox.Show(this,"Please enter the number of the players!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (InvestmentTB.Text.Equals(""))
            {
                //MessageBox.Show(this, "Please enter the investment!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (MultiTB.Text.Equals(""))
            {
                //MessageBox.Show(this, "Please enter the multiplication factor!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (RuleParamTB.Text.Equals(""))
            {
                //MessageBox.Show(this, "Please fill every textbox!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (GraphTypeCB.Text.Equals(""))
            {
                //MessageBox.Show(this, "Please select the graph type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            if (!checkParams())
            {
                return;
            }

            r = float.Parse(MultiTB.Text);
            c = Convert.ToInt32(InvestmentTB.Text);

           

            // If the simulation isn't running
            if (StartButton.Text.Equals("Start"))
            {

                // Counting the payoff values
                Random rand = new Random();

                N = Convert.ToInt32(NoPTB.Text);
                int coopPerc = rand.Next(50, 100);
                percTB.Text = coopPerc + "";
                nc = N * coopPerc / 100; int nd = N - nc;

                NrCoopTB.Text = nc + "";
                nrDefTB.Text = nd + "";

                pd = (r * nc * c) / N; cd = pd - c;

                DefectorTB.Text = pd + "";
                ContributorTB.Text = cd + "";

                StartButton.Text = "Step";
                NoPTB.ReadOnly = true;
                MultiTB.ReadOnly = true;
                InvestmentTB.ReadOnly = true;
                

                float money = Int32.Parse(NrCoopTB.Text) * c * r;
                MoneyTB.Text = money + "";

                // Generating the graph
                edgeNr = 0;
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

                // Drawing the graph
                DrawGraph();
            }
            else
            {
                
                if (ruleCB.Text.Equals(""))
                {
                    MessageBox.Show("Please select a rule!");
                }
                else if (ruleCB.Text.Equals("Neighbors Decide"))
                {
                     //----------------------------------------------------------------------------------------------------------//
                    // If at least <RuleParamTB.text> % of my neighbors decide not to contribute, then I won't contribute either//
                   //----------------------------------------------------------------------------------------------------------//
                
                     int[] newColors = rules.NeighborsDecide(N, checkMatrix, colors, Convert.ToInt32(RuleParamTB.Text));

                     ReColor(newColors);

                }
                else if (ruleCB.Text.Equals("Mult. Fact. Grows"))
                {
                     //-----------------------------------------------------------------------------------------//
                    // If <RuleParamTB.text> % of the players contribute, then the multiplication factor grows //
                   // ----------------------------------------------------------------------------------------//

                    MultiTB.Text = rules.MultFactGrows(N, r, Convert.ToInt32(RuleParamTB.Text), Convert.ToInt32(percTB.Text)) + "";
                    r = float.Parse(MultiTB.Text);
                    float totalMoney = N * r * c;

                    int[] newColors = new int[N];

                    Random rand = new Random();
                    for (int i = 0; i < N; i++)
                    {
                        if (pd  >= c * rand.Next((int)r))
                        {
                            newColors[i] = 2;
                        }
                        else
                        {
                            newColors[i] = 1;
                        }
                        
                        /*if (float.Parse(MoneyTB.Text) < rand.Next(85) * totalMoney / 100)
                        {
                            newColors[i] = 1;
                        }
                        else
                        {
                            newColors[i] = colors[i];
                        }*/
                    }

                    ReColor(newColors);
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
            RuleParamTB.Text = "";
            MoneyTB.Text = "";

            turn = 0;

            graphBox.Image = null;
        }


        private void DrawGraph()
        {
            Graphics graphics = graphBox.CreateGraphics();
            //graphics.DrawEllipse(Pens.Black, 75, 0, 350, 350);

            float r = 175, alpha = 360/N;
            double x, y;
            Point[] coords = new Point[N];

            for (int i = 0; i < N; i++)
            {
                x = r * Math.Cos(i*alpha * Math.PI / 180);
                y = r * Math.Sin(i*alpha * Math.PI / 180);
                x += r*2 - 110;
                y += r - 10;
                coords[i] = new Point((int)x+10,(int)y+10); 
                if(colors[i] == 1){
                    graphics.FillEllipse(Brushes.Red, (int)x, (int)y, 20, 20);
                } else {
                    graphics.FillEllipse(Brushes.Green, (int)x, (int)y, 20, 20);
                }
            }

            if (/*turn == 0*/true)
            {
                for (int i = 0; i < edgeNr; i++)
                {
                    if (graph[i, 0] != graph[i, 1])
                    {
                        graphics.DrawLine(Pens.Black, coords[graph[i, 0]], coords[graph[i, 1]]);
                    }
                }
            }

            turn++;

        }

        public void ReColor(int[] newColors)
        {
            int allDefNr = 0;
            for (int i = 0; i < N; i++)
            {
                if (newColors[i] == 1)
                {
                    allDefNr++;
                }
                colors[i] = newColors[i];
            }

            nc = (N - allDefNr);
            NrCoopTB.Text = nc + "";
            nrDefTB.Text = allDefNr + "";

            percTB.Text = Convert.ToInt32(NrCoopTB.Text) * 100 / N + "";

            float money = Int32.Parse(NrCoopTB.Text) * c * r;
            MoneyTB.Text = money + "";

            pd = (r * Int32.Parse(NrCoopTB.Text) * c) / N; cd = pd - c;
            DefectorTB.Text = pd + "";
            ContributorTB.Text = cd + "";

            DrawGraph();
        }

        async Task PutTaskDelay()
        {
            await Task.Delay(1500);
        }

        private async void AutomaticButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                StartButton.PerformClick();
                await PutTaskDelay();
            }
        }

        // We change the parameters name when the rule changes 
        private void ruleCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ruleCB.Text.Equals("Neighbors Decide"))
            {
                RuleParamL.Text = "Neighbor%: ";
            }
            else if (ruleCB.Text.Equals("Mult. Fact. Grows"))
            {
                RuleParamL.Text = "Grow%: ";
            }
            else
            {
                RuleParamL.Text = "MinPerc%: ";
            }
        }

        
    }
}
