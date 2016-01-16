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
            if (controller != null)
            {
                controller.stop();
            }
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
            Title title = chartProfit.Titles.Add("Coalitions winning ratio");
            title.Font = new System.Drawing.Font("Arial", 10f, FontStyle.Bold);
            var chartArea = new ChartArea("WinningRatio");
            chartArea.AxisX.Title = "Coalitions";
            chartArea.AxisY.Title = "Winning rate";
        }

        private void initInput()
        {
            buttonClear.Enabled = false;
            //var text = "1 1 0 3" + Environment.NewLine + "0 0 0 2" + Environment.NewLine + "2 2 2 2";
            var text = "0 2 8 0 12 0 0 12 4" + Environment.NewLine +
                       "4 0 4 0 0 0 0 8 0" + Environment.NewLine +
                       "0 4 0 0 0 0 0 2 2" + Environment.NewLine +
                       "2 0 4 8 1 6 0 0 0" + Environment.NewLine +
                       "6 0 3 12 10 5 6 4 10" + Environment.NewLine +
                       "4 10 12 0 0 3 12 6 0" + Environment.NewLine +
                       "1 6 8 10 4 0 2 1 0" + Environment.NewLine +
                       "2 1 2 0 3 0 4 2 2";
            richTextBoxMaterials.Text = text;
            //text = "X1+X2+X3" + Environment.NewLine + "X2+X3" + Environment.NewLine + "2*X4";

            text = "0*X1+2*X2+0*X3+4*X4+0*X5+4*X6+0*X7+0*X8+2*X9" + Environment.NewLine +
                   "0*X1+1*X2+0*X3+0*X4+4*X5+1*X6+0*X7+1*X8+0*X9" + Environment.NewLine +
                   "4*X1+0*X2+0*X3+3*X4+3*X5+0*X6+0*X7+0*X8+4*X9" + Environment.NewLine +
                   "0*X1+5*X2+0*X3+4*X4+4*X5+5*X6+0*X7+0*X8+0*X9" + Environment.NewLine +
                   "0*X1+4*X2+1*X3+0*X4+5*X5+0*X6+5*X7+0*X8+4*X9" + Environment.NewLine +
                   "0*X1+3*X2+0*X3+4*X4+4*X5+0*X6+0*X7+4*X8+1*X9" + Environment.NewLine +
                   "0*X1+1*X2+5*X3+0*X4+0*X5+0*X6+1*X7+3*X8+0*X9" + Environment.NewLine +
                   "0*X1+1*X2+0*X3+0*X4+1*X5+0*X6+0*X7+0*X8+2*X9";

            richTextBoxPlayerFunc.Text = text;
            numericPlayer.Value = richTextBoxPlayerFunc.Lines.Count();
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

        
        private void initCalc()
        {
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
            try
            {
                timer1.Enabled = false;
                controller.stop();
                controller.init(playerFuncTokenized, materials);
                timer1.Enabled = true;
            }
            catch (InputException ex)
            {
                buttonStop_Click(null, null);
                Console.WriteLine(ex.ToString());
                MessageBox.Show(this, ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                    initCalc();
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

        //chart fill
        private void chart()
        {
            var avg = profits.Min() - profits.Average() <= 0 ? 0 : profits.Min() - profits.Average();
            chartProfit.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(avg);

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
            if (result != null)
            {
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

        // when a player comes in, gets a random function
        private String getRandomFunction(int m)
        {
            String result = "";
            for (int j = 0; j < m; j++)
            {
                result += ((randomGen.Next() % 2) * (randomGen.Next() % 5 + 1)) + "*X" + (j + 1);
                if (j < m - 1) result += "+";
            }
            return result;
        }

        // when a player comes in, gets a random materials
        private String getRandomMaterials(int m)
        {
    	    String result = "";
            for (int j = 0; j < m; j++)
            {
                result += ((randomGen.Next() % 3) * (randomGen.Next() % 7));
                if (j != m - 1) 
                {
                    result += " ";
                }            
            }
        	return result;
        }


        // add one new player (dynamic game)
        private void buttonNewPlayer_Click(object sender, EventArgs e)
        {
            int count = 0;

            numericPlayer.Value += 1;

            if (richTextBoxMaterials.Lines.Count() == 0)
            {
                count = randomGen.Next() % 11 + 5;
            }
            else
            {
                count = richTextBoxMaterials.Lines[0].Count(f => f == ' ') + 1;
            }

            richTextBoxMaterials.AppendText(Environment.NewLine + getRandomMaterials(count));
            richTextBoxPlayerFunc.AppendText(Environment.NewLine + getRandomFunction(count));
          
            if (buttonStart.Text == "   Pause")
            {
                initCalc();
            }
        }

        private string rmvLine(RichTextBox rtb,int line)
        {
            string res = "";
            for (int i =0; i< rtb.Lines.Count(); i++)
            {
                if (i != line)
                {
                    res += rtb.Lines[i] + '\n';
                }
            }
            return res.Remove(res.Length - 1);
        }

        // one player leave (dynamic game)
        private void buttonLeaver_Click(object sender, EventArgs e)
        {
            numericPlayer.Value -= 1;
            int count = Math.Min(richTextBoxMaterials.Lines.Count(),richTextBoxPlayerFunc.Lines.Count());
            if (count > 0)
            {
                var rndLine = randomGen.Next() % count;
                richTextBoxMaterials.Text = rmvLine(richTextBoxMaterials, rndLine);
                richTextBoxPlayerFunc.Text = rmvLine(richTextBoxPlayerFunc, rndLine);
            }

            if (buttonStart.Text == "   Pause")
            {
                initCalc();
            }
        }

        private void richTextBoxPlayerFunc_TextChanged(object sender, EventArgs e)
        {
            var lineCount = richTextBoxPlayerFunc.Lines.Count();
            numericPlayer.Value = lineCount;
        }

        internal Dynamic_Games.Coop.Models.PartialResult PartialResult
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
