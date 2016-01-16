using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using MyCard = Dynamic_Games.IncInformation.Cards;
using Dynamic_Games.IncInformation.Game;

namespace Dynamic_Games.IncInformation.Player
{
    class HumanPlayer : Player
    {
        

        public HumanPlayer(int cash, int i, Table t)
        {
            cards = new List<MyCard.Card>(2);
            this.cash = cash;
            this.id = i;
            this.table = t;
            this.folded = false;
        }

        public override void setCards(MyCard.Card c1, MyCard.Card c2)
        {
            cards = new List<MyCard.Card>(2);
            cards.Add(c1);
            cards.Add(c2);
        }

        public override void setPos(Position p)
        {
            this.pos = p;
        }

        public override double getChance()
        {
            throw new NotImplementedException();
        }

        public override void decision()
        {
            if (this.cash > 0)
                table.mre = new ManualResetEvent(false);
                table.mre.WaitOne();
                if (table.controls.restart)
                {
                    table.controls.restart = false;
                    throw new ThreadInterruptedException(); 
                }
                if (table.folded)
                {
                    this.folded = true;
                    table.folded = false;
                }
                else
                {
                    try
                    {
                        int tmpbet = 0;
                        if (table.called)
                        {
                            if (table.deal.tt.tCall == 0)
                                tmpbet = 0;
                            else
                                tmpbet = table.deal.tt.tCall - this.bet;
                            table.called = false;
                        }
                        else
                        {
                            tmpbet = Int32.Parse(this.table.controls.betTextBox.Text);
                        }
                            
                        if (table.isValidBet(tmpbet, id))
                        {
                            this.bet = this.bet + tmpbet;
                        }
                        table.controls.Invoke((Action)delegate
                        {
                            table.controls.betTextBox.Text = "0";
                        });
                    }
                    catch (FormatException e)
                    {
                        //doing nothing is a fix... XD
                    }
                        
                }
        }
    }
}
