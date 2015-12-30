using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandEvaluator;

using MyCard = Dynamic_Games.IncInformation.Cards;
using System.Drawing;
using System.ComponentModel;

namespace Dynamic_Games.IncInformation.Player
{
    public enum State
    {
        Preflop, Flop, Turn, River
    };
    class Table : INotifyPropertyChanged
    {

        public List<Player> players = new List<Player>(8);
        private int playerCount;
        private int bigAt;
        public List<MyCard.Card> flop = new List<MyCard.Card>(3);
        private MyCard.Card flopH1;
        private MyCard.Card flopH2;
        private MyCard.Card flopH3; // didnt use list because individual elements cant be bassed as ref
        public MyCard.Card river;
        private MyCard.Card riverHidden;
        public MyCard.Card turn;
        private MyCard.Card turnHidden;
        private MyCard.Deck deck;
        public int AllBet;
        private State GameState;

        public int call;
        public int[] playerBet;
        public int[] playerPot;
        public int bigBlind;
        public int smallBlind;

        // Event handler for gamestate change
        public event PropertyChangedEventHandler StateChanged;
        public State statevalue
        {
            get
            {
                return GameState;
            }

            set
            {
                GameState = value;
                OnStateChanged();
            }
        }
        public Table(MyCard.Deck d, int playerCount)
        {
            riverHidden = new MyCard.Card("unknown", Properties.Resources.back);
            turnHidden = new MyCard.Card("unknown", Properties.Resources.back);
            flopH1 = new MyCard.Card("unknown", Properties.Resources.back);
            flopH2 = new MyCard.Card("unknown", Properties.Resources.back);
            flopH3 = new MyCard.Card("unknown", Properties.Resources.back);
            this.deck = d;
            this.bigBlind = 50;
            this.smallBlind = 25;
            this.playerCount = playerCount;
            this.playerBet = new int[playerCount];
            this.playerPot = new int[playerCount];
            for (int i = 0; i < playerCount; i++)
            {
                players.Add(new HumanPlayer(1000));
                players.ElementAt(i).setCards(deck.getCard(), deck.getCard());
                players.ElementAt(i).setPos(Position.None);
                players.ElementAt(i).setBet(0);
            }
            resetTable();
          //  State dummy = statevalue;
            statevalue = State.Preflop;
           // OnStateChanged();
        }

        private void swapCard(ref MyCard.Card c1, ref MyCard.Card c2)
        {
            MyCard.Card temp = c1;
            c1 = c2;
            c2 = temp;
        }

        // Event handler
        protected virtual void OnStateChanged()
        {
            switch (GameState)
            {
                case State.Preflop:
                    MyCard.Card tmpcard;
                    swapCard(ref riverHidden, ref river);

                    swapCard(ref turnHidden, ref turn);
                    tmpcard = flop[0];
                    swapCard(ref flopH1, ref tmpcard);
                    flop[0] = tmpcard;
                    tmpcard = flop[1];
                    swapCard(ref flopH2, ref tmpcard);
                    flop[1] = tmpcard;
                    tmpcard = flop[2];
                    swapCard(ref flopH3, ref tmpcard);
                    flop[2] = tmpcard;
                    break;
                case State.Flop:
                    tmpcard = flop[0];
                    swapCard(ref flopH1, ref tmpcard);
                    flop[0] = tmpcard;
                    tmpcard = flop[1];
                    swapCard(ref flopH2, ref tmpcard);
                    flop[1] = tmpcard;
                    tmpcard = flop[2];
                    swapCard(ref flopH3, ref tmpcard);
                    flop[2] = tmpcard;
                    break;
                case State.River:
                    swapCard(ref riverHidden, ref river);
                    break;
                case State.Turn:
                    swapCard(ref turnHidden, ref turn);
                    break;
            }
           // raiseState();
        }

        public void raiseState()
        {
            bool raising = true;
            while (raising)
            {

            }
        }

        // Evenethander end

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

        public void resetTable()
        {
            deck.initDeck();
            riverHidden = new MyCard.Card("unknown", Properties.Resources.back);
            turnHidden = new MyCard.Card("unknown", Properties.Resources.back);
            flopH1 = new MyCard.Card("unknown", Properties.Resources.back);
            flopH2 = new MyCard.Card("unknown", Properties.Resources.back);
            flopH3 = new MyCard.Card("unknown", Properties.Resources.back);
            flop = new List<MyCard.Card>(3);
            foreach (Player p in players)
            {
                p.setCards(deck.getCard(), deck.getCard());
            }
           // movePos();
            flop.Add(deck.getCard());
            flop.Add(deck.getCard());
            flop.Add(deck.getCard());
            river = deck.getCard();
            turn = deck.getCard();
        }

        public State nextState(State s)
        {
            Boolean ok = false;
            foreach (State next in Enum.GetValues(typeof(State)))
            {
                if (ok)
                    return next;
                if (next == s)
                    ok = true;
            }
            resetTable();
            return State.Preflop;
        }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }
    }
}
