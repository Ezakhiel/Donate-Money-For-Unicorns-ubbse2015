using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dynamic_Games.IncInformation.Cards;

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
        public int cash;
        public List<Card> cards;
        public Position pos;
        public int bet;

        public abstract void setBet(int b);
        public abstract void setPos(Position p); 
        public abstract void setCards(Card c1, Card c2);
    }
}
