using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dynamic_Games.IncInformation.Cards
{
    public class Deck
    {
        List<Dynamic_Games.IncInformation.Cards.Card> Cards;
        static Random rnd;
        public Deck()
        {
            rnd = new Random();
            initDeck();
        }

        public void initDeck()
        {
            // Resets deck with cards
            Cards = new List<Dynamic_Games.IncInformation.Cards.Card>(52);
            String symbol = "c";
            String nameHelper;
            Bitmap img;
            Dynamic_Games.IncInformation.Cards.Card tmpCard;
            for (int i = 0; i < 4; i++)
            {
                //c -> treff
                //d -> rombusz
                //h -> sziv
                //s -> pikk
                for (int num = 1; num <= 9; num++)
                {
                    nameHelper = symbol + "0" + num.ToString();
                    img = (Bitmap)Properties.Resources.ResourceManager.GetObject(nameHelper);
                    tmpCard = new Card(nameHelper, img);
                    Cards.Add(tmpCard);
                }
                for (int num = 10; num <= 13; num++)
                {
                    nameHelper = symbol + num.ToString();
                    img = (Bitmap)Properties.Resources.ResourceManager.GetObject(nameHelper);
                    tmpCard = new Card(nameHelper, img);
                    Cards.Add(tmpCard);
                }
                switch (symbol)
                {
                    case "c":
                        symbol = "d";
                        break;
                    case "d":
                        symbol = "h";
                        break;
                    case "h":
                        symbol = "s";
                        break;
                }

            }
        }

        public Dynamic_Games.IncInformation.Cards.Card getCard()
        {
            //gets and removes a card from the deck
            int r = rnd.Next(Cards.Count);
            Dynamic_Games.IncInformation.Cards.Card tempCard = Cards[r];
            Cards.RemoveAt(r);
            return tempCard;
        }
    }
}
