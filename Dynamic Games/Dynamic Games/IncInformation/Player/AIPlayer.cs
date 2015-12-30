using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyCard = Dynamic_Games.IncInformation.Cards;

namespace Dynamic_Games.IncInformation.Player
{
    class AIPlayer : Player
    {
        public AIPlayer(int cash)
        {
            cards = new List<MyCard.Card>(2);
            this.cash = cash;
        }

        public override void setBet(int b) 
        {
            bet = b;
        }
        public override void setPos(Position p) 
        {
            this.pos = p;
        }
        public override void setCards(MyCard.Card c1, MyCard.Card c2) 
        {
            cards = new List<MyCard.Card>(2);
            c1.CardImage = Properties.Resources.back;
            c2.CardImage = Properties.Resources.back;
            cards.Add(c1);
            cards.Add(c2);
        }

        public override double getChance()
        {
            throw new NotImplementedException();
        }
    }
}
