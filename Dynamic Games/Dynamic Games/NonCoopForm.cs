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
        private int[] colors, selflesness;
        private int edgeNr, turn = 0;
        private bool isMultiFactor = true;
        private Rules rules;
        private float[] moneyArr, investmentArr;

        public NonCoopForm()
        {
            InitializeComponent();
            rules = new Rules();
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
                MessageBox.Show(this,"Please enter the number of the players!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                pd = (r * nc * c) / N; cd = pd - c;

                DefectorTB.Text = pd + "";
                ContributorTB.Text = cd + "";

                StartButton.Text = "Step";
                NoPTB.ReadOnly = true;
                

                float money = Int32.Parse(NrCoopTB.Text) * c * r;
                MoneyTB.Text = money + "";
                moneyArr[0] = money/N;
                investmentArr[0] = c;

                // Generating the graph
                edgeNr = 0;
                graph = null; colors = new int[N];
                checkMatrix = new int[N, N];

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


                // Generating selflesness factors
                selflesness = new int[N];
                for (int i = 0; i < N; i++)
                {
                    selflesness[i] = rand.Next(100);
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

                    float moneyBefore = 0, investmentBefore = 0, counter = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        if (moneyArr[i] != -1)
                        {
                            Console.WriteLine("MoneyArr[" + i + "] = " + moneyArr[i]);
                            moneyBefore += moneyArr[i];
                            investmentBefore += investmentArr[i];
                            counter++;
                        }
                    }

                    moneyBefore /= counter; investmentBefore /= counter;
                    Console.WriteLine("MoneyBefore: " + moneyBefore);

                    int[] newColors = new int[N];
                    Random rand = new Random();

                    for (int i = 0; i < N; i++)
                    {
                        Console.WriteLine(i + ". selflesness: " + selflesness[i]);
                    }

                    int howSelflessIAm = 0;
                    for (int i = 0; i < N; i++)
                    {
                        if (colors[i] == 1)
                        {
                            howSelflessIAm = rand.Next(100);
                            Console.WriteLine(i + " - RED - How Selfless I Am: " + howSelflessIAm);
                            if (howSelflessIAm < selflesness[i] && pd < moneyBefore)
                            {
                                newColors[i] = 2;
                            }
                            else
                            {
                                newColors[i] = 1;
                            }
                        }
                        else
                        {
                            howSelflessIAm = rand.Next(100);
                            Console.WriteLine(i + " - GREEN - How Selfless I Am: " + howSelflessIAm);
                            if (selflesness[i] > 91)
                            {
                                newColors[i] = 2;
                            }
                            else if (pd > c && howSelflessIAm < selflesness[i])
                            {
                                newColors[i] = 2;
                            }
                            else
                            {
                                newColors[i] = 1;
                            }
                        }
                    }
                    /*for (int i = 0; i < N; i++)
                    {
                        if (colors[i] == 1)
                        {
                            if (moneyBefore < c && rand.Next(100) > selflesness[i])
                            {
                                newColors[i] = 2;
                            }
                            else
                            {
                                newColors[i] = 1;
                            }
                        }
                        else
                        {
                            if (moneyBefore < c * selflesness[i] / 100)
                            {
                                newColors[i] = 2;
                            }
                            else
                            {
                                newColors[i] = 1;
                            }
                        }
                    }*/

                    ReColor(newColors);
                }
                else if (ruleCB.Text.Equals("Minimum Percentage"))
                {
                    //-------------------------------------------------------------------------------------------//
                    //                           Neighbors decide with Selflessness Factor                      //
                    // ----------------------------------------------------------------------------------------//

                    int[] newColors = rules.NeighborsDecide(N, checkMatrix, colors, Convert.ToInt32(RuleParamTB.Text));

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

            float r = 175, alpha = 360/N;
            double x, y;
            Point[] coords = new Point[N];

            for (int i = 0; i < N; i++)
            {
                x = r * Math.Cos(i*alpha * Math.PI / 180);
                y = r * Math.Sin(i*alpha * Math.PI / 180);
                x += r*2 - 110;
                y += r + 10;
                coords[i] = new Point((int)x+10,(int)y+10);
                if(colors[i] == 1){
                    graphics.FillEllipse(Brushes.Red, (int)x, (int)y, 20, 20);
                } else if(colors[i] == 2) {
                    graphics.FillEllipse(Brushes.Green, (int)x, (int)y, 20, 20);
                } else if(colors[i] == 3) {
                    graphics.FillEllipse(Brushes.Yellow, (int)x, (int)y, 20, 20);
                } else {
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
            moneyArr[turn % 3] = money/N;
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
                RuleParamL.Text = "Minimum%: ";
            }
        }

        // Adding a new player to the game
        private async void AddPlayerButton_Click(object sender, EventArgs e)
        {
            graphBox.Image = null;

            await PutTaskDelayShort();

            Random rand = new Random();
            int edgeNrTmp = edgeNr;
            edgeNrTmp += rand.Next(N-1)+1;

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
            NoPTB.Text = N + "";

            int from = N-1, to;
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
            colors = new int[N];
            colors = tmpColors;

            int[] tmpSelflesness = new int[N];
            for (int i = 0; i < N - 1; i++)
            {
                tmpSelflesness[i] = selflesness[i];
            }

            tmpSelflesness[N - 1] = rand.Next(100);

            selflesness = new int[N];
            selflesness = tmpSelflesness;

            DrawGraph();
        }

        private async void DelPlayerButton_Click(object sender, EventArgs e)
        {
            if (N < 3)
            {
                return;
            }

            graphBox.Image = null;

            await PutTaskDelayShort();

            Random rand = new Random();

            int playerId = rand.Next(N), neighborNr = 0;
            int edgeNrTmp = edgeNr;

            for (int i = 0; i < N; i++)
            {
                if (checkMatrix[playerId,i] == 1)
                {
                    neighborNr++;
                }
            }


            edgeNrTmp -= neighborNr;

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
                            tmpCheckMatrix[i-minusi, j-minusj] = checkMatrix[i, j];
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
            
            checkMatrix = new int[N,N];
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

            int[] tmpColors = new int[N];
            counter = 0;
            for (int i = 0; i < N+1; i++)
            {
                if(i != playerId){
                    tmpColors[counter] = colors[i];
                    counter++;
                }
            }

            colors = new int[N];
            colors = tmpColors;

            int[] tmpSelflesness = new int[N];
            counter = 0;
            for (int i = 0; i < N; i++)
            {
                if (i == playerId)
                {
                    tmpSelflesness[counter] = selflesness[i];
                    counter++;
                }
            }

            selflesness = new int[N];
            selflesness = tmpSelflesness;

            DrawGraph();
        }
        
    }
}
