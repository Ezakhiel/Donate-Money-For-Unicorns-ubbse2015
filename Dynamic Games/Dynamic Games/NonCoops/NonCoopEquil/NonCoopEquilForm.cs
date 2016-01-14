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
    public partial class NonCoopEquilForm : Form
    {
        int game, player_nr;
        public NonCoopEquilForm()
        {
            InitializeComponent();
        }

        private void NonCoopEquilForm_Load(object sender, EventArgs e)
        {
            cbGame.Items.Add("Cournot");
            cbGame.Items.Add("Public good");
            cbGame.SelectedIndex = 0;
            game = 1;

            tbParA.Text = "25";
            tbParC.Text = "9";
            tbSmax.Text = "10";
            tbPM.Text = "0.1";

            cbEquil.Items.Add("Pareto");
            cbEquil.Items.Add("Nash");
            cbEquil.SelectedIndex = 0;
            for (int i = 2; i <= 10; i++)            //? hany jatekos lehet?
            {
                cbNRPlayers.Items.Add(i.ToString());
            }
            cbNRPlayers.SelectedIndex = 0;
        }

        private void cbGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            pParam.Visible = true;
            if (cbGame.SelectedItem.Equals("Cournot"))
            {
                game = 1;
                lparam1.Text = "a =";
                lparam2.Text = "c =";
                lparam3.Text = "Max. strategy";
                lparam4.Text = "pm";
                lparam4.Visible = true;
                tbSmax.Visible = true;
            }                                          //else public good
            else
                if (cbGame.SelectedItem.Equals("Public good"))
                {
                    game = 2;
                    lparam1.Text = "Investment";
                    lparam2.Text = "Multipl. factor";
                    lparam3.Visible = false;
                    tbSmax.Visible = false;
                }
        }


        private void bStart_Click(object sender, EventArgs e)
        {
            lConclusion.Text = "";
            lvResult.Clear();
            //leellenorizni a parametereket
            double max = Convert.ToDouble(tbSmax.Text);
            player_nr = Convert.ToInt32(cbNRPlayers.SelectedItem);
            String equil = cbEquil.SelectedItem.ToString();
            List<string> parameters = new List<string>();
            if (cbGame.SelectedItem.Equals("Cournot"))
            {
                lvResult.View = View.Details;
                lvResult.Columns.Add("Nr", lvResult.Width / 8, HorizontalAlignment.Left);
                lvResult.Columns.Add("Payoff", -2, HorizontalAlignment.Center);

                parameters.Add(tbParA.Text);
                parameters.Add(tbParC.Text);
                PAES p = new PAES(this, game, max, equil, player_nr, tbPM.Text, parameters);
            }
            else
                if (cbGame.SelectedItem.Equals("Public good"))
                {
                    lvResult.View = View.Details;
                    lvResult.Columns.Add("Nr", lvResult.Width / 8, HorizontalAlignment.Left);
                    lvResult.Columns.Add("Payoff", -2, HorizontalAlignment.Center);

                    parameters.Add(tbParA.Text); //investment
                    parameters.Add(tbParC.Text); //mult.factor
                    double value = Convert.ToDouble(tbParA.Text); //investment
                    PAES p = new PAES(this, game, value, equil, player_nr, tbPM.Text, parameters);
                }
            
        }

        public void add_toListview(List<Solution> l)
        {
            String s; 
            ListViewItem x;
            for (int i = 0; i < l.Count; i++)
            {
                s = "";
                x = new ListViewItem((i + 1).ToString());

                for (int j = 0; j < player_nr; j++)
                {
                    s += l[i].obj[j].ToString() + "   ";
                }
                x.SubItems.Add(s);
                lvResult.Items.Add(x);
            }
            this.Refresh();
        }

    }
}
