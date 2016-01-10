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

namespace Dynamic_Games
{
    public partial class CoopForm : Form
    {
        Random randomGen = new Random();

        //close the form
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            //// Confirm user wants to close
            //switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            //{
            //    case DialogResult.No:
            //        e.Cancel = true;
            //        break;
            //    default:
            //        this.DialogResult = DialogResult.OK;
            //        break;
            //}
        }

        public CoopForm()
        {
            InitializeComponent();
            initDGV();
        }

        private void initDGV()
        {
            dgvCoalition.AutoGenerateColumns = false;
            dgvCoalition.ColumnCount = 2;
            dgvCoalition.Columns[0].Name = "Player";
            dgvCoalition.Columns[1].Name = "Coalitions";
        }

        private void initInput()
        {
            buttonClear.Enabled = false;
            numericPlayer.Value = 0;
            richTextBoxMaterials.Text = "";
            richTextBoxWinning.Text = "";
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
                    FillDataGrid();
                }
                else if (buttonStart.Text == "   Pause")
                {
                    buttonStart.Text = "   Resume";
                    buttonStart.Image = Dynamic_Games.Properties.Resources.play;
                    buttonClear.Enabled = true;
                    buttonStop.Enabled = true;
                }
                else
                {
                    buttonStart.Text = "   Pause";
                    buttonStart.Image = Dynamic_Games.Properties.Resources.pause;
                    buttonClear.Enabled = false;
                    buttonStop.Enabled = true;
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
            buttonStart.Text = "Start";
            buttonStart.Enabled = false;
            buttonClear.Enabled = true;
            buttonStop.Enabled = false;
        }

        //clear button
        private void buttonClear_Click(object sender, EventArgs e)
        {
            dgvCoalition.Rows.Clear();
            initInput();
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
            buttonClear.Enabled = false;
        }

        private CColor GetRandomColor()
        {
            return CColor.FromArgb(randomGen.Next(0, 255), randomGen.Next(0, 255), randomGen.Next(0, 255));
            // The error is here
        }

        // fill the datagrid with players and coalition
        public void FillDataGrid()
        {
            for (int i = 0; i < numericPlayer.Value; i++)
            {
                dgvCoalition.Rows.Add("P" + (i + 1));
                dgvCoalition.Rows[i].Cells[0].Style.ForeColor = GetRandomColor();
                dgvCoalition.DefaultCellStyle.Font = new Font(Font, FontStyle.Bold);
            }

            for (int i = 0; i < numericPlayer.Value; i++)
            {

            }
        }

        private void dataGridViewCoalition_SelectionChanged(object sender, EventArgs e)
        {
            dgvCoalition.ClearSelection();
        }



        //Random randomGen = new Random();

        //private CColor GetRandomColor()
        //{
        //    return CColor.FromArgb(randomGen.Next(0, 255), randomGen.Next(0, 255), randomGen.Next(0, 255));
        //    // The error is here
        //}

        //private void dataGridViewCoalition_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        //{
        //    //KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
        //    //KnownColor randomColorName = names[randomGen.Next(names.Length)];
            

        //    for (int i = 0; i < numericPlayer.Value; i++)
        //    {
        //        SolidBrush Brs = new SolidBrush(GetRandomColor());
        //        if (e.ColumnIndex == 1 && e.RowIndex > -1)
        //        {
        //            GraphicsExtensions.FillCircle(e.Graphics, Brs, e.CellBounds.Location.X + 18, e.CellBounds.Location.Y + 10, 7);
        //            e.Handled = true;
        //        }
        //    }
        //}
    }

    //public static class GraphicsExtensions
    //{
    //    public static void FillCircle(this Graphics g, Brush brush, float centerX, float centerY, float radius)
    //    {
    //        g.FillEllipse(brush, centerX - radius, centerY - radius, radius + radius, radius + radius);
    //    }
    //}
}
