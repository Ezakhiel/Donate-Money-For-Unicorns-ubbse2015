using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Dynamic_Games.IncInformation.Player;
using Dynamic_Games.IncInformation.Cards;

namespace Dynamic_Games
{
    public partial class IncInformationForm : Form
    {

        List<PictureBox> cardIterator = new List<PictureBox>(21);
        Table table;

        public IncInformationForm()
        {
            InitializeComponent();
            PostInit();
            table = new Table(new Deck(), 8);
            cardIterator.Add(P1C1);
            cardIterator.Add(P1C2);
            cardIterator.Add(P2C1);
            cardIterator.Add(P2C2);
            cardIterator.Add(P3C1);
            cardIterator.Add(P3C2);
            cardIterator.Add(P4C1);
            cardIterator.Add(P4C2);
            cardIterator.Add(P5C1);
            cardIterator.Add(P5C2);
            cardIterator.Add(P6C1);
            cardIterator.Add(P6C2);
            cardIterator.Add(P7C1);
            cardIterator.Add(P7C2);
            cardIterator.Add(P8C1);
            cardIterator.Add(P8C2);
            /*
            cardIterator.Add(Flop1);
            cardIterator.Add(Flop2);
            cardIterator.Add(Flop3);
            cardIterator.Add(River);
            cardIterator.Add(Turn);
            */
        }

        private void PostInit() 
        {
            List<int> players = new List<int> { 2, 3, 4, 5, 6, 7, 8 };
            this.ComboPlayerCount.SelectedIndexChanged -= new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            ComboPlayerCount.DataSource = players;
            this.ComboPlayerCount.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            List<String> playerTypes = new List<String> { "Human", "Computer" };
            var p2cb = new String[2];
            var p3cb = new String[2];
            var p4cb = new String[2];
            var p5cb = new String[2];
            var p6cb = new String[2];
            var p7cb = new String[2];
            var p8cb = new String[2];
            playerTypes.CopyTo(p2cb);
            playerTypes.CopyTo(p3cb);
            playerTypes.CopyTo(p4cb);
            playerTypes.CopyTo(p5cb);
            playerTypes.CopyTo(p6cb);
            playerTypes.CopyTo(p7cb);
            playerTypes.CopyTo(p8cb);
            P1ComboBox.DataSource = playerTypes;
            P2ComboBox.DataSource = p2cb;
            P3ComboBox.DataSource = p3cb;
            P4ComboBox.DataSource = p4cb;
            P5ComboBox.DataSource = p5cb;
            P6ComboBox.DataSource = p6cb;
            P7ComboBox.DataSource = p7cb;
            P8ComboBox.DataSource = p8cb;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    this.DialogResult = DialogResult.OK;
                    break;
            }
        }
        private void vizualize()
        {
            int needed = table.players.Count;
            int i = 0;
            foreach (Player p in table.players)
            {
                cardIterator[i].Image = p.cards[0].CardImage;
                cardIterator[i + 1].Image = p.cards[1].CardImage;
                i += 2;
            }
            Flop1.Image = table.flop[0].CardImage;
            Flop2.Image = table.flop[1].CardImage;
            Flop3.Image = table.flop[2].CardImage;
            River.Image = table.river.CardImage;
            Turn.Image = table.turn.CardImage;
        }

        private void IncInformationForm_Load(object sender, EventArgs e)
        {
            vizualize();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboPlayerCount.SelectedIndex)
            {
                case 0:
                    table = new Table(new Deck(),2);
                    P1C1.Show();
                    P1C2.Show();
                    P2C1.Show();
                    P2C2.Show();
                    P3C1.Hide();
                    P3C2.Hide();
                    P4C1.Hide();
                    P4C2.Hide();
                    P5C1.Hide();
                    P5C2.Hide();
                    P6C1.Hide();
                    P6C2.Hide();
                    P7C1.Hide();
                    P7C2.Hide();
                    P8C1.Hide();
                    P8C2.Hide();
                    break;

                case 1:
                    table = new Table(new Deck(),3);
                    P1C1.Show();
                    P1C2.Show();
                    P2C1.Show();
                    P2C2.Show();
                    P3C1.Show();
                    P3C2.Show();
                    P4C1.Hide();
                    P4C2.Hide();
                    P5C1.Hide();
                    P5C2.Hide();
                    P6C1.Hide();
                    P6C2.Hide();
                    P7C1.Hide();
                    P7C2.Hide();
                    P8C1.Hide();
                    P8C2.Hide();
                    break;
                case 2:
                    table = new Table(new Deck(),4);
                    P1C1.Show();
                    P1C2.Show();
                    P2C1.Show();
                    P2C2.Show();
                    P3C1.Show();
                    P3C2.Show();
                    P4C1.Show();
                    P4C2.Show();
                    P5C1.Hide();
                    P5C2.Hide();
                    P6C1.Hide();
                    P6C2.Hide();
                    P7C1.Hide();
                    P7C2.Hide();
                    P8C1.Hide();
                    P8C2.Hide();
                    break;
                case 3:
                    table = new Table(new Deck(),5);
                    P1C1.Show();
                    P1C2.Show();
                    P2C1.Show();
                    P2C2.Show();
                    P3C1.Show();
                    P3C2.Show();
                    P4C1.Show();
                    P4C2.Show();
                    P5C1.Show();
                    P5C2.Show();
                    P6C1.Hide();
                    P6C2.Hide();
                    P7C1.Hide();
                    P7C2.Hide();
                    P8C1.Hide();
                    P8C2.Hide();
                    break;
                case 4:
                    table = new Table(new Deck(),6);
                    P1C1.Show();
                    P1C2.Show();
                    P2C1.Show();
                    P2C2.Show();
                    P3C1.Show();
                    P3C2.Show();
                    P4C1.Show();
                    P4C2.Show();
                    P5C1.Show();
                    P5C2.Show();
                    P6C1.Show();
                    P6C2.Show();
                    P7C1.Hide();
                    P7C2.Hide();
                    P8C1.Hide();
                    P8C2.Hide();
                    break;
                case 5:
                    table = new Table(new Deck(),7);
                    P1C1.Show();
                    P1C2.Show();
                    P2C1.Show();
                    P2C2.Show();
                    P3C1.Show();
                    P3C2.Show();
                    P4C1.Show();
                    P4C2.Show();
                    P5C1.Show();
                    P5C2.Show();
                    P6C1.Show();
                    P6C2.Show();
                    P7C1.Show();
                    P7C2.Show();
                    P8C1.Hide();
                    P8C2.Hide();
                    break;
                case 6:
                    table = new Table(new Deck(),8);
                    P1C1.Show();
                    P1C2.Show();
                    P2C1.Show();
                    P2C2.Show();
                    P3C1.Show();
                    P3C2.Show();
                    P4C1.Show();
                    P4C2.Show();
                    P5C1.Show();
                    P5C2.Show();
                    P6C1.Show();
                    P6C2.Show();
                    P7C1.Show();
                    P7C2.Show();
                    P8C1.Show();
                    P8C2.Show();
                    break;
            }
            vizualize();
        }

        private void P1ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P1ComboBox.SelectedText.Equals("Human"))
            {
                table.players[0] = new HumanPlayer(1000);
            }
            else
            {
                table.players[0] = new AIPlayer(1000);
            }
        }

        private void P2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P2ComboBox.SelectedText.Equals("Human"))
            {
                table.players[1] = new HumanPlayer(1000);
            }
            else
            {
                table.players[1] = new AIPlayer(1000);
            }
        }

        private void P3ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P3ComboBox.SelectedText.Equals("Human"))
            {
                table.players[2] = new HumanPlayer(1000);
            }
            else
            {
                table.players[2] = new AIPlayer(1000);
            }
        }

        private void P4ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P4ComboBox.SelectedText.Equals("Human"))
            {
                table.players[3] = new HumanPlayer(1000);
            }
            else
            {
                table.players[3] = new AIPlayer(1000);
            }
        }

        private void P5ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P5ComboBox.SelectedText.Equals("Human"))
            {
                table.players[4] = new HumanPlayer(1000);
            }
            else
            {
                table.players[4] = new AIPlayer(1000);
            }
        }

        private void P6ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P6ComboBox.SelectedText.Equals("Human"))
            {
                table.players[5] = new HumanPlayer(1000);
            }
            else
            {
                table.players[5] = new AIPlayer(1000);
            }
        }

        private void P7ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P7ComboBox.SelectedText.Equals("Human"))
            {
                table.players[6] = new HumanPlayer(1000);
            }
            else
            {
                table.players[6] = new AIPlayer(1000);
            }
        }

        private void P8ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P8ComboBox.SelectedText.Equals("Human"))
            {
                table.players[7] = new HumanPlayer(1000);
            }
            else
            {
                table.players[7] = new AIPlayer(1000);
            }
        }

    

    }
}
