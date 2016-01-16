using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using Dynamic_Games.IncInformation.Player;
using Dynamic_Games.IncInformation.Cards;
using Dynamic_Games.IncInformation.Game;

namespace Dynamic_Games
{
    public partial class IncInformationForm : Form
    {

        public struct PlayerVisuals
        {
            public PictureBox c1;
            public PictureBox c2;
            public Label money;
            public Label betLBL;
            public Label bet;
            public Label typeLBL;
            public ComboBox typeBox;

            public void hide(){
                c1.Hide();
                c2.Hide();
                money.Hide();
                bet.Hide();
                betLBL.Hide();
                typeBox.Hide();
                typeLBL.Hide();
            }

            public void show()
            {
                c1.Show();
                c2.Show();
                money.Show();
                bet.Show();
                betLBL.Show();
                typeBox.Show();
                typeLBL.Show();
            }
        }


        List<PictureBox> cardIterator = new List<PictureBox>(21);
        public List<PlayerVisuals> playerVis = new List<PlayerVisuals>(6);
        List<Label> cashIterator = new List<Label>(8);
        public List<Label> betIterator = new List<Label>(8);
        Table table;
        int playernum;
        int aiNUm;
        public volatile bool restart;

        public IncInformationForm()
        {
            InitializeComponent();
            this.CreateHandle();
            groupVisuals();
            PostInit();
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
            cashIterator.Add(P1Cash);
            cashIterator.Add(P2Cash);
            cashIterator.Add(P3Cash);
            cashIterator.Add(P4Cash);
            cashIterator.Add(P5Cash);
            cashIterator.Add(P6Cash);
            cashIterator.Add(P7Cash);
            cashIterator.Add(P8Cash);
            betIterator.Add(P1Bet);
            betIterator.Add(P2Bet);
            betIterator.Add(P3Bet);
            betIterator.Add(P4Bet);
            betIterator.Add(P5Bet);
            betIterator.Add(P6Bet);
            betIterator.Add(P7Bet);
            betIterator.Add(P8Bet);
            playernum = 8;
            aiNUm = 0;
            restart = false;
            table = new Table(new Deck(), playernum, this);
            table.startTable();
            /*
            cardIterator.Add(Flop1);
            cardIterator.Add(Flop2);
            cardIterator.Add(Flop3);
            cardIterator.Add(River);
            cardIterator.Add(Turn);
            */
        }

        public void newTable()
        {
            table = new Table(new Deck(), playernum, this);
            resetPlayerBoxes();
            table.startTable();
        }

        private void groupVisuals()
        {
            PlayerVisuals p1 = new PlayerVisuals();
            p1.c1 = P1C1;
            p1.c2 = P1C2;
            p1.money = P1Cash;
            p1.bet = P1Bet;
            p1.betLBL = P1BetLBL;
            p1.typeLBL = P1Label;
            p1.typeBox = P1ComboBox;
            playerVis.Add(p1);
            PlayerVisuals p2 = new PlayerVisuals();
            p2.c1 = P2C1;
            p2.c2 = P2C2;
            p2.money = P2Cash;
            p2.bet = P2Bet;
            p2.betLBL = P2BetLBL;
            p2.typeLBL = P2Label;
            p2.typeBox = P2ComboBox;
            playerVis.Add(p2);
            PlayerVisuals p3 = new PlayerVisuals();
            p3.c1 = P3C1;
            p3.c2 = P3C2;
            p3.money = P3Cash;
            p3.bet = P3Bet;
            p3.betLBL = P3BetLBL;
            p3.typeLBL = P3Label;
            p3.typeBox = P3ComboBox;
            playerVis.Add(p3);
            PlayerVisuals p4 = new PlayerVisuals();
            p4.c1 = P4C1;
            p4.c2 = P4C2;
            p4.money = P4Cash;
            p4.bet = P4Bet;
            p4.betLBL = P4BetLBL;
            p4.typeLBL = P4Label;
            p4.typeBox = P4ComboBox;
            playerVis.Add(p4);
            PlayerVisuals p5 = new PlayerVisuals();
            p5.c1 = P5C1;
            p5.c2 = P5C2;
            p5.money = P5Cash;
            p5.bet = P5Bet;
            p5.betLBL = P5BetLBL;
            p5.typeLBL = P5Label;
            p5.typeBox = P5ComboBox;
            playerVis.Add(p5);
            PlayerVisuals p6 = new PlayerVisuals();
            p6.c1 = P6C1;
            p6.c2 = P6C2;
            p6.money = P6Cash;
            p6.bet = P6Bet;
            p6.betLBL = P6BetLBL;
            p6.typeLBL = P6Label;
            p6.typeBox = P6ComboBox;
            playerVis.Add(p6);
            PlayerVisuals p7 = new PlayerVisuals();
            p7.c1 = P7C1;
            p7.c2 = P7C2;
            p7.money = P7Cash;
            p7.bet = P7Bet;
            p7.betLBL = P7BetLBL;
            p7.typeLBL = P7Label;
            p7.typeBox = P7ComboBox;
            playerVis.Add(p7);
            PlayerVisuals p8 = new PlayerVisuals();
            p8.c1 = P8C1;
            p8.c2 = P8C2;
            p8.money = P8Cash;
            p8.bet = P8Bet;
            p8.betLBL = P8BetLBL;
            p8.typeLBL = P8Label;
            p8.typeBox = P8ComboBox;
            playerVis.Add(p8);
        }

        private void PostInit() 
        {
            List<int> players = new List<int> { 2, 3, 4, 5, 6, 7, 8 };
            this.ComboPlayerCount.SelectedIndexChanged -= new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            ComboPlayerCount.DataSource = players;      // insert "PLEASE SELECT PLAYER NUMBER"
            this.ComboPlayerCount.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            resetPlayerBoxes();
           
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void resetPlayerBoxes()
        {
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
            this.P1ComboBox.SelectedIndexChanged -= new System.EventHandler(this.P1ComboBox_SelectedIndexChanged);
            P1ComboBox.DataSource = playerTypes;
            this.P1ComboBox.SelectedIndexChanged += new System.EventHandler(this.P1ComboBox_SelectedIndexChanged);
            this.P2ComboBox.SelectedIndexChanged -= new System.EventHandler(this.P2ComboBox_SelectedIndexChanged);
            P2ComboBox.DataSource = p2cb;
            this.P2ComboBox.SelectedIndexChanged += new System.EventHandler(this.P2ComboBox_SelectedIndexChanged);
            this.P3ComboBox.SelectedIndexChanged -= new System.EventHandler(this.P3ComboBox_SelectedIndexChanged);
            P3ComboBox.DataSource = p3cb;
            this.P3ComboBox.SelectedIndexChanged += new System.EventHandler(this.P3ComboBox_SelectedIndexChanged);
            this.P4ComboBox.SelectedIndexChanged -= new System.EventHandler(this.P4ComboBox_SelectedIndexChanged);
            P4ComboBox.DataSource = p4cb;
            this.P4ComboBox.SelectedIndexChanged += new System.EventHandler(this.P4ComboBox_SelectedIndexChanged);
            this.P5ComboBox.SelectedIndexChanged -= new System.EventHandler(this.P5ComboBox_SelectedIndexChanged);
            P5ComboBox.DataSource = p5cb;
            this.P5ComboBox.SelectedIndexChanged += new System.EventHandler(this.P5ComboBox_SelectedIndexChanged);
            this.P6ComboBox.SelectedIndexChanged -= new System.EventHandler(this.P6ComboBox_SelectedIndexChanged);
            P6ComboBox.DataSource = p6cb;
            this.P6ComboBox.SelectedIndexChanged += new System.EventHandler(this.P6ComboBox_SelectedIndexChanged);
            this.P7ComboBox.SelectedIndexChanged -= new System.EventHandler(this.P7ComboBox_SelectedIndexChanged);
            P7ComboBox.DataSource = p7cb;
            this.P7ComboBox.SelectedIndexChanged += new System.EventHandler(this.P7ComboBox_SelectedIndexChanged);
            this.P8ComboBox.SelectedIndexChanged -= new System.EventHandler(this.P8ComboBox_SelectedIndexChanged);
            P8ComboBox.DataSource = p8cb;
            this.P8ComboBox.SelectedIndexChanged += new System.EventHandler(this.P8ComboBox_SelectedIndexChanged);
            for (int i = 1; i < 9; i++)
            {
                playerVis[i - 1].typeLBL.Text = "Player " + i + ":";
            }
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
                    restart = true;
                    Thread.Sleep(1000);
                    this.DialogResult = DialogResult.OK;
                    break;
            }
        }
        public void vizualize()
        {
            int needed = table.players.Count;
            int i = 0;
            foreach (Player p in table.players)
            {
                cardIterator[i].Image = (Image)p.cards[0].CardImage;
                cardIterator[i + 1].Image = (Image)p.cards[1].CardImage;
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
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (ComboPlayerCount.SelectedIndex)
            {
                case 0:
                    playernum = 2;
                    playerVis[2].hide();
                    playerVis[3].hide();
                    playerVis[4].hide();
                    playerVis[5].hide();
                    playerVis[6].hide();
                    playerVis[7].hide();
                    break;

                case 1:
                    playernum = 3;
                    playerVis[2].show();
                    playerVis[3].hide();
                    playerVis[4].hide();
                    playerVis[5].hide();
                    playerVis[6].hide();
                    playerVis[7].hide();
                    break;
                case 2:
                    playernum = 4;
                    playerVis[2].show();
                    playerVis[3].show();
                    playerVis[4].hide();
                    playerVis[5].hide();
                    playerVis[6].hide();
                    playerVis[7].hide();
                    break;
                case 3:
                    playernum = 5;
                    playerVis[2].show();
                    playerVis[3].show();
                    playerVis[4].show();
                    playerVis[5].hide();
                    playerVis[6].hide();
                    playerVis[7].hide();
                    break;
                case 4:
                    playernum = 6;
                    playerVis[2].show();
                    playerVis[3].show();
                    playerVis[4].show();
                    playerVis[5].show();
                    playerVis[6].hide();
                    playerVis[7].hide();
                    break;
                case 5:
                    playernum = 7;
                    playerVis[2].show();
                    playerVis[3].show();
                    playerVis[4].show();
                    playerVis[5].show();
                    playerVis[6].show();
                    playerVis[7].hide();
                    break;
                case 6:
                    playernum = 8;
                    playerVis[2].show();
                    playerVis[3].show();
                    playerVis[4].show();
                    playerVis[5].show();
                    playerVis[6].show();
                    playerVis[7].show();
                    break;
            }
            resetPlayerBoxes();

            table = new Table(new Deck(), playernum, this);
            foreach (Player p in table.players)
            {
                playerVis[p.id].money.Text = p.cash.ToString();
            }
            table.resetTable();
            vizualize();
            table.startTable();
        }

        private void aiNewGame()
        {
            // set bool to signal gameThread to restart
            restart = true;
            //release gamethread from user interaction lock
            table.mre.Set();
            //wait for thread response on being locked
            table.threadLockEvent.WaitOne();
            table.threadLockEvent = new ManualResetEvent(false);
            //reset bet-money
            foreach (Player p in table.players)
            {
                p.bet = 0;
                p.cash = 1000;
            }
            //starttable with new ai players
            table.startTable();
        }

        private void P1ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P1ComboBox.SelectedText.Equals("Human"))
            {
                table.players[0] = new HumanPlayer(1000,0,table);
                aiNUm--;
            }
            else
            {
                table.players[0] = new AIPlayer(1000, 0, table,(new Parameters(0)).getLatestParam(aiNUm));
                table.players[0].setPos(Position.SmallBlind);

                aiNUm++;
            }
            table.resetTable();
            table.statevalue = State.Preflop;
            vizualize();
            aiNewGame();
        }

        private void P2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P2ComboBox.SelectedText.Equals("Human"))
            {
                table.players[1] = new HumanPlayer(1000, 1, table);
                aiNUm--;
            }
            else
            {
                table.players[1] = new AIPlayer(1000, 1, table, (new Parameters(0)).getLatestParam(aiNUm));
                table.players[1].setPos(Position.BigBlind);
                aiNUm++;
            }
            table.resetTable();
            table.statevalue = State.Preflop;
            vizualize();
            aiNewGame();
        }

        private void P3ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P3ComboBox.SelectedText.Equals("Human"))
            {
                table.players[2] = new HumanPlayer(1000, 2, table);
                aiNUm--;
            }
            else
            {
                table.players[2] = new AIPlayer(1000, 2, table, (new Parameters(0)).getLatestParam(aiNUm));
                aiNUm++;
            }
            table.resetTable();
            table.statevalue = State.Preflop;
            vizualize();
            aiNewGame();
        }

        private void P4ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P4ComboBox.SelectedText.Equals("Human"))
            {
                table.players[3] = new HumanPlayer(1000, 3, table);
                aiNUm--;
            }
            else
            {
                table.players[3] = new AIPlayer(1000, 3, table, (new Parameters(0)).getLatestParam(aiNUm));
                aiNUm++;
            }
            table.resetTable();
            table.statevalue = State.Preflop;
            vizualize();
            aiNewGame();
        }

        private void P5ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P5ComboBox.SelectedText.Equals("Human"))
            {
                table.players[4] = new HumanPlayer(1000, 4, table);
                aiNUm--;
            }
            else
            {
                table.players[4] = new AIPlayer(1000, 4, table, (new Parameters(0)).getLatestParam(aiNUm));
                aiNUm++;
            }
            table.resetTable();
            table.statevalue = State.Preflop;
            vizualize();
            aiNewGame();
        }

        private void P6ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P6ComboBox.SelectedText.Equals("Human"))
            {
                table.players[5] = new HumanPlayer(1000, 5, table);
                aiNUm--;
            }
            else
            {
                table.players[5] = new AIPlayer(1000, 5, table, (new Parameters(0)).getLatestParam(aiNUm));
                aiNUm++;
            }
            table.resetTable();
            table.statevalue = State.Preflop;
            vizualize();
            aiNewGame();
        }

        private void P7ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P7ComboBox.SelectedText.Equals("Human"))
            {
                table.players[6] = new HumanPlayer(1000, 6, table);
                aiNUm--;
            }
            else
            {
                table.players[6] = new AIPlayer(1000, 6, table, (new Parameters(0)).getLatestParam(aiNUm));
                aiNUm++;
            }
            table.resetTable();
            table.statevalue = State.Preflop;
            vizualize();
            aiNewGame();
        }

        private void P8ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P8ComboBox.SelectedText.Equals("Human"))
            {
                table.players[7] = new HumanPlayer(1000, 7, table);
                aiNUm--;
            }
            else
            {
                table.players[7] = new AIPlayer(1000, 7, table, (new Parameters(0)).getLatestParam(aiNUm));
                aiNUm++;
            }
            table.resetTable();
            table.statevalue = State.Preflop;
            vizualize();
            aiNewGame();
        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            table.mre.Set();
        }

        private void foldBtn_Click(object sender, EventArgs e)
        {
            table.folded = true;
            finishBtn_Click(sender, e);
        }

        public void removeCards(int i)
        {
            playerVis[i].c1.Image = Properties.Resources.black;
            playerVis[i].c2.Image = Properties.Resources.black;

        }

        private void callBTN_Click(object sender, EventArgs e)
        {
            table.called = true;
            finishBtn_Click(sender, e);
        }

    }
}
