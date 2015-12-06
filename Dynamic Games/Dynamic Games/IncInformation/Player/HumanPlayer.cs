using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dynamic_Games.IncInformation.Cards;

namespace Dynamic_Games.IncInformation.Player
{
    class HumanPlayer : Player
    {
        public HumanPlayer(int cash)
        {
            cards = new List<Card>(2);
            this.cash = cash;
        }

        public override void setCards(Card c1, Card c2)
        {
            cards.Add(c1);
            cards.Add(c2);
        }

        public override void setPos(Position p)
        {
            this.pos = p;
        }

        public override void setBet(int b)
        {
            bet = b;
        }


    }
}
