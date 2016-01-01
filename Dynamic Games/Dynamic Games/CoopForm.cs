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

        //check if everything is filled.
        public bool CheckFill()
        {
            if (numericPlayer.Value <= 0 || textBoxProduct.Text == "" || richTextBoxMaterials.Text == "")
            {
                return false;
            }
            return true;
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

        
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (CheckFill())
            {
                if (buttonStart.Text == "Start")
                {
                    buttonStart.Text = "Pause";
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
            else
            {
                MessageBox.Show(this, "You have to fill everything!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStart.Text = "Start";
        }
    }
}
