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
using Dynamic_Games.NonCoops;

namespace Dynamic_Games
{
    public partial class NonCoopForm : Form
    {
        private int N, c, nc;
        private float r, pd, cd;
        private int[,] checkMatrix, graph;
        private int[] colors, selflesness;
        private int edgeNr, turn = 0;
        private bool isMultiFactor = true;
        private Rules rules;
        private NonCoopManager ncManager;
        private float[] moneyArr, investmentArr;

        public NonCoopForm()
        {
            InitializeComponent();
            rules = new Rules();
            ncManager = new NonCoopManager();
            moneyArr = new float[3];
            investmentArr = new float[3];

            for (int i = 0; i < 3; i++)
            {
                moneyArr[i] = -1;
                investmentArr[i] = -1;
            }
        }

        private void NonCoopForm_Load(object sender, EventArgs e)
        {

        }

        public bool checkParams()
        {
            if (NoPTB.Text.Equals(""))
            {
                MessageBox.Show(this, "Please enter the number of the players!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (InvestmentTB.Text.Equals(""))
            {
                MessageBox.Show(this, "Please enter the investment!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (MultiTB.Text.Equals(""))
            {
                MessageBox.Show(this, "Please enter the multiplication factor!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (RuleParamTB.Text.Equals(""))
            {
                MessageBox.Show(this, "Please fill every textbox!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                addToChart(nc, nd);

                pd = (r * nc * c) / N; cd = pd - c;

                DefectorTB.Text = pd + "";
                ContributorTB.Text = cd + "";

                StartButton.Text = "Step";
                NoPTB.ReadOnly = true;


                float money = Int32.Parse(NrCoopTB.Text) * c * r;
                MoneyTB.Text = money + "";
                moneyArr[0] = money / N;
                investmentArr[0] = c;

                // Generating the graph
                edgeNr = rand.Next(N * (N - 1) / 2);
                Tuple<int[,], int[,]> t = ncManager.GenerateGraph(edgeNr, N);

                graph = t.Item1;
                checkMatrix = t.Item2;

                // Deciding whether a player contibutes or not
                colors = ncManager.GenColors(N, nc, nd);

                // Generating selflesness factors
                selflesness = ncManager.GenSelflesnessFactors(N);

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
                    //--------------------------------------------------------------------------------------------------------------//
                    // If <RuleParamTB.text> % of the players contribute, then the multiplication factor grows + Selfessness Factor //
                    // -------------------------------------------------------------------------------------------------------------//

                    MultiTB.Text = rules.MultFactGrows(N, r, Convert.ToInt32(RuleParamTB.Text), Convert.ToInt32(percTB.Text)) + "";
                    r = float.Parse(MultiTB.Text);


                    ReColor(rules.SelflesnessMultFactGrows(N, pd, c, moneyArr, investmentArr, selflesness, colors));
                }
                else
                {
                    //-------------------------------------------------------------------------------------------//
                    //                           Neighbors decide with Selflessness Factor                      //
                    // ----------------------------------------------------------------------------------------//

                    int[] newColors = rules.NeighborsAndSelflesness(N, c, pd, checkMatrix, colors, Convert.ToInt32(RuleParamTB.Text), selflesness, investmentArr, moneyArr);

                    ReColor(newColors);
                }

            }
        }

        // Restart Button
        private void RestartButton_Click(object sender, EventArgs e)
        {
            StartButton.Text = "Start";
            NoPTB.ReadOnly = false;

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
            foreach (var series in LineChart.Series)
            {
                series.Points.Clear();
            }
        }


        private void DrawGraph()
        {
            Graphics graphics = graphBox.CreateGraphics();
            //graphics.DrawEllipse(Pens.Black, 75, 0, 350, 350);

            float r = 175, alpha = 360 / N;
            double x, y;
            Point[] coords = new Point[N];

            for (int i = 0; i < N; i++)
            {
                x = r * Math.Cos(i * alpha * Math.PI / 180);
                y = r * Math.Sin(i * alpha * Math.PI / 180);
                x += r * 2 - 110;
                y += r + 10;
                coords[i] = new Point((int)x + 10, (int)y + 10);
                if (colors[i] == 1)
                {
                    graphics.FillEllipse(Brushes.Red, (int)x, (int)y, 20, 20);
                }
                else if (colors[i] == 2)
                {
                    graphics.FillEllipse(Brushes.Green, (int)x, (int)y, 20, 20);
                }
                else if (colors[i] == 3)
                {
                    graphics.FillEllipse(Brushes.Yellow, (int)x, (int)y, 20, 20);
                }
                else
                {
                    graphics.FillEllipse(Brushes.Blue, (int)x, (int)y, 20, 20);
                }
            }

            if (true)
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
                if (newColors[i] == 1 || newColors[i] == 3)
                {
                    allDefNr++;
                }
                colors[i] = newColors[i];
            }

            nc = (N - allDefNr);
            NrCoopTB.Text = nc + "";
            nrDefTB.Text = allDefNr + "";

            addToChart(nc, allDefNr);

            percTB.Text = Convert.ToInt32(NrCoopTB.Text) * 100 / N + "";

            float money = Int32.Parse(NrCoopTB.Text) * c;
            if (isMultiFactor)
            {
                money *= r;
            }

            MoneyTB.Text = money + "";
            moneyArr[turn % 3] = money / N;
            investmentArr[turn % 3] = c;

            pd = (r * Int32.Parse(NrCoopTB.Text) * c) / N; cd = pd - c;
            DefectorTB.Text = pd + "";
            ContributorTB.Text = cd + "";


            DrawGraph();
        }

        // Automatic step
        async Task PutTaskDelay()
        {
            await Task.Delay(550);
        }

        async Task PutTaskDelayShort()
        {
            await Task.Delay(100);
        }

        private async void AutomaticButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                StartButton.PerformClick();
                await PutTaskDelay();
            }
        }

        // Chart Control
        private void addToChart(int c, int d)
        {
            LineChart.Series["D"].Points.AddY(d);
            LineChart.Series["C"].Points.AddY(c);
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
                RuleParamL.Text = "Neighbor%: ";
            }
        }

        // Adding a new player to the game
        private async void AddPlayerButton_Click(object sender, EventArgs e)
        {
            graphBox.Image = null;

            await PutTaskDelayShort();

            Random rand = new Random();
            int edgeNrTmp = edgeNr;
            edgeNrTmp += rand.Next(N - 1) + 1;

            Tuple<int[,], int[,]> t = ncManager.AddPlayerGenGraph(N, edgeNr, edgeNrTmp, graph, checkMatrix);
            int[,] tmpGraph = t.Item1;
            int[,] tmpCheckMatrix = t.Item2;

            N++;
            NoPTB.Text = N + "";
            edgeNr = edgeNrTmp;

            checkMatrix = new int[N, N];
            checkMatrix = tmpCheckMatrix;
            graph = new int[edgeNr, 2];
            graph = tmpGraph;

            int[] tmpColors = new int[N];

            for (int i = 0; i < N - 1; i++)
            {
                tmpColors[i] = colors[i];
            }

            if (rand.Next(2) == 0)
            {
                tmpColors[N - 1] = 3; // Defector
                nrDefTB.Text = (int.Parse(nrDefTB.Text) + 1) + "";
            }
            else
            {
                tmpColors[N - 1] = 4; // Cooperator
                nc++;
                NrCoopTB.Text = nc + "";
            }

            percTB.Text = (nc * 100 / N) + "";
            colors = tmpColors;

            selflesness = ncManager.AddPlayerGenSelflesness(N, selflesness);

            DrawGraph();
        }

        private async void DelPlayerButton_Click(object sender, EventArgs e)
        {
            // You can not delete a player if there are only two of them left
            if (N < 3)
            {
                MessageBox.Show("Nah, come on, there are only two players and you want to delete one of 'em? Shame...");
                return;
            }

            graphBox.Image = null;

            await PutTaskDelayShort();

            Random rand = new Random();

            int playerId = rand.Next(N);
            int edgeNrTmp = edgeNr;
            int neighborNr = ncManager.NeighborCounter(N, playerId, checkMatrix);


            edgeNrTmp -= neighborNr;

            Tuple<int[,], int[,]> t = ncManager.DelPlayerGenGraph(edgeNrTmp, N, edgeNr, playerId, graph, checkMatrix);
            int[,] tmpGraph = t.Item1;
            int[,] tmpCheckMatrix = t.Item2;

            int minusi = 0, minusj = 0;

            for (int i = 0; i < N; i++)
            {
                minusj = 0;
                if (i != playerId)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (j != playerId)
                        {
                            tmpCheckMatrix[i - minusi, j - minusj] = checkMatrix[i, j];
                        }
                        else
                        {
                            minusj = 1;
                        }
                    }
                }
                else
                {
                    minusi = 1;
                }
            }

            N--;
            NoPTB.Text = N + "";

            checkMatrix = new int[N, N];
            checkMatrix = tmpCheckMatrix;

            graph = new int[edgeNrTmp, 2];
            graph = tmpGraph;
            edgeNr = edgeNrTmp;

            if (colors[playerId] == 1)
            {
                nrDefTB.Text = (int.Parse(nrDefTB.Text) - 1) + "";
            }
            else
            {
                NrCoopTB.Text = (int.Parse(nrDefTB.Text) - 1) + "";
            }

            colors = ncManager.DelGenColors(N, playerId, colors);

            selflesness = ncManager.DelGenSelflessness(N, playerId, selflesness);

            DrawGraph();
        }

        private void EquilButton_Click(object sender, EventArgs e)
        {
            var equilForm = new NonCoopEquilForm();
            this.Hide();
            equilForm.ShowDialog();
            // When new form DioalogResult = ok
            this.Show();
        }
        
    }
}
