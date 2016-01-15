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

namespace Dynamic_Games
{
    public partial class CoopForm : Form
    {
        Random randomGen = new Random();
        bool isClicked = false;

        //close the form
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
        }

        public CoopForm()
        {
            InitializeComponent();
            initDGV();
            initInput();
        }

        private void initDGV()
        {
            dgvCoalition.AutoGenerateColumns = false;
            dgvCoalition.ColumnCount = 1;
            //dgvCoalition.Columns[0].Name = "Players";
            dgvCoalition.Columns[0].Name = "Coalitions";
        }

        private void initInput()
        {
            buttonClear.Enabled = false;
            numericPlayer.Value = 3;
            var text = "1 1 0 3" + Environment.NewLine + "0 0 0 2" + Environment.NewLine + "2 2 2 2";
            richTextBoxMaterials.Text = text;
            text = "X1+X2+X3" + Environment.NewLine + "X2+X3" + Environment.NewLine + "2*X4";
            richTextBoxWinning.Text = text;
        }

        //check if everything is filled.
        public bool CheckFill()
        {
            if (numericPlayer.Value <= 0 || richTextBoxWinning.Text == "" || richTextBoxMaterials.Text == "")
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

                    //var winningTokenized = tokenizer(richTextBoxWinning.Text);
                    var materialsTokenized = tokenizer(richTextBoxMaterials.Text);

                    DgvFirstRow();
                    FillDataGrid();

                    isClicked = false;
                    timer1.Enabled = true;
                }
                else if (buttonStart.Text == "   Pause")
                {
                    buttonStart.Text = "   Resume";
                    buttonStart.Image = Dynamic_Games.Properties.Resources.play;
                    buttonClear.Enabled = true;
                    buttonStop.Enabled = true;
                    isClicked = true;
                    timer1.Enabled = false;
                }
                else
                {
                    buttonStart.Text = "   Pause";
                    buttonStart.Image = Dynamic_Games.Properties.Resources.pause;
                    buttonClear.Enabled = false;
                    buttonStop.Enabled = true;
                    isClicked = false;
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
            isClicked = true;
            timer1.Enabled = false;
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

        private int[] tokenizer(string inputString)
        {
            //string[] splitString = inputString.Split(' ').ToArray();
            try
            {
                string[] stringSeparators = new string[] { " ", "\n", "\t" };
                int[] splitInt = inputString.Split(stringSeparators, StringSplitOptions.None).Select(word => Int32.Parse(word)).ToArray();
                return splitInt;
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
            for (int i = 0; i < 1; i++)
            {
                var coal = BackTrack(Decimal.ToInt32(numericPlayer.Value));
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
        }

        private void chart()
        {
           // for(int i = 0; i < )
        }

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

        private void richTextBoxMaterials_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar);
        }

        private void richTextBoxWinning_KeyPress(object sender, KeyPressEventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            //dgvCoalition.Rows.Clear();
            ///dgvCoalition.Refresh();
            //int addPlayers = Decimal.ToInt32(numericPlayer.Value) + 1;
            //int leftPlayers = Decimal.ToInt32(numericPlayer.Value) - 1;

            FillDataGrid();
        }
    }
}
