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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void buttonNonCoop_Click(object sender, EventArgs e)
        {
            var nonCoopForm = new NonCoopForm();
            this.Hide();
            nonCoopForm.ShowDialog();
            // When new form DioalogResult = ok
            this.Show();

        }

        private void buttonCoop_Click(object sender, EventArgs e)
        {
            var coopForm = new CoopForm();
            this.Hide();
            coopForm.ShowDialog();
            // When new form DioalogResult = ok
            this.Show();
            
        }

        private void buttonIncompInf_Click(object sender, EventArgs e)
        {
            var incInfForm = new IncInformationForm();
            this.Hide();
            incInfForm.ShowDialog();
            // When new form DioalogResult = ok
            this.Show();
        }
    }
}
