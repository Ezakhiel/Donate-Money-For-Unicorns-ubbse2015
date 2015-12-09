using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dynamic_Games
{
    public partial class CoopForm : Form
    {
        public CoopForm()
        {
            InitializeComponent();
        }

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

        private void DrawCoalitions()
        {
            Graphics g = panelCoalition.CreateGraphics();
            g.DrawEllipse(new Pen(Color.Black, 2), 20, 20, 70, 40);
            g.FillEllipse(Brushes.Red, 35, 34, 10, 10);
            g.FillEllipse(Brushes.Blue, 60, 34, 10, 10);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (buttonStart.Text == "Start")
            {
                buttonStart.Text = "Pause";
                DrawCoalitions();
            }
            else if (buttonStart.Text == "Pause")
            {
                buttonStart.Text = "Resume";
            }
            else
            {
                buttonStart.Text = "Pause";
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStart.Text = "Start";
        }


    }
}
