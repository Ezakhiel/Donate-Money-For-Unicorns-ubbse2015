using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using HoldemHand;

using MyCard = Dynamic_Games.IncInformation.Cards;
using Dynamic_Games.IncInformation.Game;

namespace Dynamic_Games.IncInformation.Player
{
    class AIPlayer : Player
    {
        public Parameters par;

        public AIPlayer(int cash,int id,Table t,Parameters p)
        {
            cards = new List<MyCard.Card>(2);
            this.cash = cash;
            this.id = id;
            this.table = t;
            this.folded = false;
            this.par = p;

        }

        public override void setPos(Position p) 
        {
            this.pos = p;
        }
        public override void setCards(MyCard.Card c1, MyCard.Card c2) 
        {
            cards = new List<MyCard.Card>(2);
          //  c1.CardImage = Properties.Resources.back;
          //  c2.CardImage = Properties.Resources.back;
            cards.Add(c1);
            cards.Add(c2);
        }

        public override double getChance()
        {
            Hand myhand = table.getHand(id);
            //increase delay to increase accuracy!!!
            //should be calculated for multiple players, but time was short....
            return Hand.WinOdds(myhand.PocketCards, myhand.Board, "", 1, 0.25) * 100;

        }

        public override void decision()
        {
            if (table.controls.restart)
            {
                table.controls.restart = false;
                throw new ThreadInterruptedException();
            }
            // Player , strat type, CallValue, winchance, ActivePlayerCount, player.bet, gene for winchance, gene for bet
            new AI(this, table, par.style, table.deal.tt.tCall, this.getChance(), table.activePlayerCount(), par.winFactor, par.betFactor);
            
            if (table.controls.restart)
            {
                table.controls.restart = false;
                throw new ThreadInterruptedException();
            }
        }
    }
}
