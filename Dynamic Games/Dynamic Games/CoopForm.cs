using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CColor = System.Drawing.Color;
using System.Resources;
using System.Windows.Forms.DataVisualization.Charting;
using Dynamic_Games.coop.backend;
using Dynamic_Games.Coop.Exceptions;

namespace Dynamic_Games
{
    public partial class CoopForm : Form
    {
        Random randomGen = new Random();
        List<string> coal;
        Controller controller;
        List<int> profits;

        //close the form
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
        }

        public CoopForm()
        {
            InitializeComponent();
            initDgvChart();
            initInput();
            controller = Controller.getInstance();
        }

        private void initDgvChart()
        {
            dgvCoalition.AutoGenerateColumns = false;
            dgvCoalition.ColumnCount = 1;
            //dgvCoalition.Columns[0].Name = "Players";
            dgvCoalition.Columns[0].Name = "Coalitions";
            Title title = chartProfit.Titles.Add("Winning ratio");
            title.Font = new System.Drawing.Font("Arial", 10f,FontStyle.Bold);
            var chartArea = new ChartArea("WinningRatio");
            chartArea.AxisX.Title = "Coalitions";
            chartArea.AxisY.Title = "Winning rate";
        }

        private void initInput()
        {
            buttonClear.Enabled = false;
            numericPlayer.Value = 3;
            var text = "1 1 0 3" + Environment.NewLine + "0 0 0 2" + Environment.NewLine + "2 2 2 2";
            richTextBoxMaterials.Text = text;
            text = "X1+X2+X3" + Environment.NewLine + "X2+X3" + Environment.NewLine + "2*X4";
            richTextBoxPlayerFunc.Text = text;
        }

        //check if everything is filled.
        public bool CheckFill()
        {
            if (numericPlayer.Value <= 0 || richTextBoxPlayerFunc.Text == "" || richTextBoxMaterials.Text == "")
            {
                return false;
            }
            return true;
        }

        //start the magic function xD
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (CheckFill())
            {
                if (buttonStart.Text == "   Start")
                {
                    buttonStart.Text = "   Pause";
                    buttonStart.Image = Dynamic_Games.Properties.Resources.pause;
                    buttonClear.Enabled = false;
                    buttonStop.Enabled = true;

                    var playerFuncTokenized = tokenizer(richTextBoxPlayerFunc.Text);
                    var materialsTokenized = tokenizer(richTextBoxMaterials.Text);
                    var materials = new int[materialsTokenized.Length][];
                    for (var i = 0; i < materials.Length; i++)
                    {
                        string[] splitString = materialsTokenized[i].Split(new string[] { " " }, StringSplitOptions.None).ToArray();
                        materials[i] = new int[splitString.Length];
                        for (var j = 0; j < splitString.Length; j++)
                        {
                            materials[i][j] = Convert.ToInt32(splitString[j]);
                        }
                    }
                        
                    //DgvFirstRow();
                    //FillDataGrid();
                    //chart();
                    try
                    {
                        controller.init(playerFuncTokenized, materials);
                        timer1.Enabled = true;
                    }
                    catch(InputException ex)
                    {
                        buttonStop_Click(null, null);
                        Console.WriteLine(ex.ToString());
                        MessageBox.Show(this, ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else if (buttonStart.Text == "   Pause")
                {
                    buttonStart.Text = "   Resume";
                    buttonStart.Image = Dynamic_Games.Properties.Resources.play;
                    buttonClear.Enabled = true;
                    buttonStop.Enabled = true;
                    timer1.Enabled = false;
                }
                else
                {
                    buttonStart.Text = "   Pause";
                    buttonStart.Image = Dynamic_Games.Properties.Resources.pause;
                    buttonClear.Enabled = false;
                    buttonStop.Enabled = true;
                    timer1.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show(this, "You have to fill everything!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //stop button
        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStart.Text = "   Start";
            buttonStart.Enabled = false;
            buttonClear.Enabled = true;
            buttonStop.Enabled = false;
            timer1.Enabled = false;
            controller.stop();
        }

        //clear button
        private void buttonClear_Click(object sender, EventArgs e)
        {
            dgvCoalition.Rows.Clear();
            dgvCoalition.Refresh();

            initInput();
            buttonStart.Enabled = true;
            buttonStart.Image = Dynamic_Games.Properties.Resources.play;
            buttonStop.Enabled = false;
            buttonClear.Enabled = false;
            foreach (var series in chartProfit.Series)
            {
                series.Points.Clear();
            }
            
        }

        private string[] tokenizer(string inputString)
        {
            //string[] splitString = inputString.Split(' ').ToArray();
            try
            {
                string[] stringSeparators = new string[] { "\n" };
                string[] splitString = inputString.Split(stringSeparators, StringSplitOptions.None).ToArray();
                return splitString;
            }
            catch
            {
                Console.WriteLine("Tokenizer failed! Check input");
                throw;
            }
        }

        //private CColor GetRandomColor()
        //{
        //    return CColor.FromArgb(randomGen.Next(0, 255), randomGen.Next(0, 255), randomGen.Next(0, 255));
        //}

        // fill dgv's first row with players
        private void DgvFirstRow()
        {
            var s = GetPlayersArray(Decimal.ToInt32(numericPlayer.Value));
            var list = "";
            foreach (var l in s)
            {
                list += "(" + l + ") ";
            }
            dgvCoalition.Rows.Add(list);
            dgvCoalition.DefaultCellStyle.Font = new Font(Font, FontStyle.Bold);
        }

        // fill the datagrid with coalition
        private void FillDataGrid()
        {
            Decimal.ToInt32(numericPlayer.Value);
            for (int i = 0; i < 1; i++)
            {
                //this.coal = BackTrack(Decimal.ToInt32(numericPlayer.Value));
                var c = "";
                foreach (var e in coal)
                {
                    c += e;
                }
                var row = new object[] { c };
                dgvCoalition.Rows.Add(row);
                //dgvCoalition.Rows[i].Cells[0].Style.ForeColor = GetRandomColor();
                dgvCoalition.DefaultCellStyle.Font = new Font(Font, FontStyle.Bold);
            }
            dgvCoalition.FirstDisplayedScrollingRowIndex = dgvCoalition.RowCount - 1;

        }

        // get a list's min value
        private int getMin(List<int> list)
        {
            int min = Int32.MaxValue;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < min)
                {
                    min = list[i];
                }
            }
            return min;
        }

        // get a list's max value
        private int getMax(List<int> list)
        {
            int max = Int32.MinValue;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > max)
                {
                    max = list[i];
                }
            }
            return max;
        }

        //chart fill
        private void chart()
        {
            /*List<int> winningFunc = new List<int>();
            int count = 1;
            int rnd;
            
            for (int i = 0; i < this.coal.Count; i++)
            {
                if (this.coal[i] == ")    ")
                {
                    count++;
                }
            }

            //random generate numbers for the list
            int count2 = count;
            while (count2 > 0)
            {
                rnd = randomGen.Next(10, 1000);
                winningFunc.Add(rnd);
                count2--;
            }*/
            var avg = profits.Min() - profits.Average() <= 0 ? 0 : profits.Min() - profits.Average();
            chartProfit.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(avg);
            //chartProfit.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(winningFunc.Max());

            for (int j = 0; j < profits.Count; j++)
            {
                chartProfit.Series["Coalitions"].Points.AddY(profits[j]);
            }
        }

        // make a list from the number of players, in this format : ex. P1
        private List<string> GetPlayersArray(int numberOfPlayers)
        {
            try
            {
                List<string> res = new List<string>();
                for (int i = 0; i < numberOfPlayers; i++)
                {
                    res.Add("P" + (i + 1));
                }
                return res;
            }
            catch
            {
                Console.WriteLine("Couldn't create the players list!");
                return new List<string>();
            }
        }

        // from players list, make random coalitions, output ex.: (P1,P2)   (P3)
        private List<string> BackTrack(int numOfPlayers)
        {
            try
            {
                const string SPACE = ")    ";
                List<string> getList = new List<string>();
                List<string> res = new List<string>();
                getList = GetPlayersArray(numOfPlayers);
                int rnd, playersCount = getList.Count;

                while (playersCount > 0)
                {
                    rnd = randomGen.Next(0, playersCount + 1);
                    if (rnd >= playersCount)
                    {
                        if (res.Count != 0 && res.Last() != SPACE)
                        {
                            res.Add(SPACE);
                        }
                    }
                    else
                    {
                        var toadd = getList[rnd];
                        if (res.Count == 0 || res.Last() == SPACE)
                        {
                            if (getList.Count == 1)
                            {
                                res.Add("(" + toadd + ")");
                            }
                            else
                            {
                                res.Add("(" + toadd);
                            }
                        }
                        else if (getList.Count == 1)
                        {
                            if (res.Last() != SPACE)
                            {
                                res.Add("," + toadd + ")");
                            }
                            else
                            {
                                res.Add(toadd + ")");
                            }
                        }
                        else
                        {
                            res.Add("," + toadd);
                        }
                        getList.RemoveAt(rnd);
                        playersCount--;
                    }
                }
                return res;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't create the coalitions list!");
                return new List<string>();
            }
        }

        private void dataGridViewCoalition_SelectionChanged(object sender, EventArgs e)
        {
            dgvCoalition.ClearSelection();
        }

        // richboxMaterials accepts only numbers and whitespace characters
        private void richTextBoxMaterials_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar);
        }

        // richboxPlayerFunc accepts only xX characters, numbers and some special characters: - + / * ^
        private void richTextBoxPlayerFunc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            // Check for a naughty character in the KeyDown event.
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[Xx0-9+\-\/\*\^]"))
            {
                // Stop the character from being entered into the control since it is illegal.
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        // refresh the chart and datagridview in every second
        private void timer1_Tick(object sender, EventArgs e)
        {
            //dgvCoalition.Rows.Clear();
            ///dgvCoalition.Refresh();
            //int addPlayers = Decimal.ToInt32(numericPlayer.Value) + 1;
            //int leftPlayers = Decimal.ToInt32(numericPlayer.Value) - 1;
            Dynamic_Games.Coop.Models.PartialResult result = controller.getPartialResult();
            if (result != null) {
                if (result.End)
                {
                    buttonStop_Click(null, null);
                }
                else
                {
                    coal = result.Coalitions;
                    profits = result.Profits;
                    FillDataGrid();
                    foreach (var series in chartProfit.Series)
                    {
                        series.Points.Clear();
                    }
                    chart();
                }
            }
        }

        // add one new player (dynamic game)
        private void buttonNewPlayer_Click(object sender, EventArgs e)
        {

            numericPlayer.Value += 1;
        }

        // one player leave (dynamic game)
        private void buttonLeaver_Click(object sender, EventArgs e)
        {
            numericPlayer.Value -= 1;
        }
    }
}
