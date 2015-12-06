using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dynamic_Games.IncInformation.Cards
{
    public class Card
    {
        public String CardName;
        public Bitmap CardImage;

        public Card(String name, Bitmap image)
        {
            CardName = name;
            CardImage = image;
        }

    }
}
