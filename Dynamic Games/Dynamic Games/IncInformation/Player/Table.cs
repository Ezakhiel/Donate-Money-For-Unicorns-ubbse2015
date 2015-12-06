using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dynamic_Games.IncInformation.Cards;

namespace Dynamic_Games.IncInformation.Player
{
    public enum State
    {
        Preriver,
        river,
        flop,
        turn,
    };
    class Table
    {
        public List<Player> players = new List<Player>(8);
        private int playerCount;
        private int bigAt;
        public List<Card> flop = new List<Card>(3);
        public Card river;
        public Card turn;
        private Deck deck;
        public int AllBet;
        public State GameState;

        public Table(Deck deck, int playerCount)
        {
            this.deck = deck;
            this.playerCount = playerCount;
            for (int i = 0; i < playerCount; i++)
            {
                players.Add(new HumanPlayer(1000));
                players.ElementAt(i).setCards(deck.getCard(), deck.getCard());
                players.ElementAt(i).setPos(Position.None);
                players.ElementAt(i).setBet(0);
            }
            initTable();
        }

        private void movePos()
        {
            int i = 0;
            foreach (Player p in players)
            {
                if (p.pos == Position.BigBlind)
                {
                    p.setPos(Position.SmallBlind);
                    break;
                }
                i++;
            }
            if (i == players.Count)
                players.ElementAt(0).setPos(Position.BigBlind);
            else
                players.ElementAt(i + 1).setPos(Position.BigBlind);
        }

        public void initTable()
        {
            deck.initDeck();
            foreach(Player p in players)
            {
                p.setCards(deck.getCard(), deck.getCard());  
            }
            movePos();
            flop.Add(deck.getCard());
            flop.Add(deck.getCard());
            flop.Add(deck.getCard());
            river = deck.getCard();
            turn = deck.getCard();
        }

    }
}
