using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dynamic_Games;
using Dynamic_Games.Properties;
using Dynamic_Games.IncInformation.Player;

namespace Dynamic_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CardVisTest()
        {
            bool result = true;
            IncInformationForm testForm = new IncInformationForm();
            if (testForm.Flop1.Image != testForm.table.flop[0].CardImage)
                result = false;
            if (testForm.Flop2.Image != testForm.table.flop[1].CardImage)
                result = false;
            if (testForm.Flop3.Image != testForm.table.flop[2].CardImage)
                result = false;
            if (testForm.River.Image != testForm.table.river.CardImage)
                result = false;
            if (testForm.Turn.Image != testForm.table.turn.CardImage)
                result = false;
            int i = 0;
            foreach (Player p in testForm.table.players)
            {
                if (testForm.cardIterator[i].Image != p.cards[0].CardImage)
                    result = false;
                if (testForm.cardIterator[i + 1].Image = p.cards[1].CardImage)
                    result = false;
                i += 2;
            }
            Assert.IsTrue(result);
        }
    }
}
