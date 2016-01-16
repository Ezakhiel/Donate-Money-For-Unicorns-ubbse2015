using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using MyCard = Dynamic_Games.IncInformation.Cards;
using Dynamic_Games.IncInformation.Game;

namespace Dynamic_Games.IncInformation.Player
{
    public enum Position
    {
        SmallBlind = 1,
        BigBlind = 2,
        None = 0,
    };

    public abstract class Player
    {
        public int id;
        public int cash;
        public List<MyCard.Card> cards;
        public Position pos;
        public int playerBet;
        private bool playerfolded;
        public Table table;

        public bool folded
        {
            get
            {
                return playerfolded;
            }

            set
            {
                playerfolded = value;
                foldChange();
            }
        }

        public int bet
        {
            get
            {
                return playerBet;
            }

            set
            {

                if (cash <= (value - playerBet))
                {
                    playerBet += cash;
                    cash = 0;
                }
                else
                    if (value > 0)
                    {
                        cash = cash - (value - playerBet);
                        playerBet = value;
                    }
                    else
                        if (value < 0)
                        {
                            playerBet += value;
                        }


                betChanged();
            }
        }

        protected virtual void betChanged()
        {
            table.controls.playerVis[this.id].bet.Invoke((Action)delegate
            {
                table.controls.playerVis[this.id].bet.Text = this.bet.ToString();
                table.controls.playerVis[this.id].money.Text = cash.ToString();
            });

        }

        protected virtual void foldChange()
        {
            if (folded)
                table.controls.playerVis[id].betLBL.Invoke((Action)delegate
                {
                    table.controls.playerVis[id].betLBL.ForeColor = Color.Red;
                });
            else
                table.controls.playerVis[id].betLBL.Invoke((Action)delegate
                {
                    table.controls.playerVis[id].betLBL.ForeColor = Color.Black;
                });
        }
        public abstract void decision();
        public abstract double getChance();
        public abstract void setPos(Position p);
        public abstract void setCards(MyCard.Card c1, MyCard.Card c2);
    }
}
