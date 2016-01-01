using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dynamic_Games;
using Dynamic_Games.IncInformation;
using Dynamic_Games.IncInformation.Player;
using Dynamic_Games.coop;
using Dynamic_Games.coop.models;
using System.Collections.Generic;

namespace Dynamic_test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void CardTest()
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
            foreach (Dynamic_Games.IncInformation.Player.Player p in testForm.table.players)
            {
                if (testForm.cardIterator[i].Image != p.cards[0].CardImage)
                    result = false;
                if (testForm.cardIterator[i + 1].Image != p.cards[1].CardImage)
                    result = false;
                i += 2;
            }
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InputCoopTest()
        {
            //(numericPlayer.Value == 0 || textBoxProduct.Text == "" || richTextBoxMaterials.Text == "")
            CoopForm coopTest = new CoopForm();

            coopTest.textBoxProduct.Text = "";
            coopTest.numericPlayer.Value = 0;
            coopTest.richTextBoxMaterials.Text = "";
            Assert.IsFalse(coopTest.CheckFill());

            coopTest.numericPlayer.Value = 5;
            Assert.IsFalse(coopTest.CheckFill());

            coopTest.textBoxProduct.Text = "alma";
            Assert.IsFalse(coopTest.CheckFill());

            coopTest.richTextBoxMaterials.Text = "rost\nmag";
            Assert.IsTrue(coopTest.CheckFill());
        }

        [TestMethod]
        public void CoalitionMaxTest()
        {
            Coalition c = new Coalition(5);
            ValueFunction vf = new ValueFunction();
            int[] materials = new int[5];
            int max = 0;
            materials[0] = 1;
            materials[1] = 5;
            materials[2] = 3;
            materials[3] = 8;
            materials[4] = 4;
            /*int[] materials2 = new int[3];
            materials[0] = 1;
            materials[1] = 3;
            materials[2] = 5; */
            /*int[] materials3 = new int[4];
            materials[0] = 10;
            materials[1] = 9;
            materials[2] = 3;
            materials[3] = 4;*/
            Dynamic_Games.coop.models.Player p1 = new Dynamic_Games.coop.models.Player(vf, materials);
            //Dynamic_Games.coop.models.Player p2 = new Dynamic_Games.coop.models.Player();
            //Dynamic_Games.coop.models.Player p3 = new Dynamic_Games.coop.models.Player();
            c.addPlayer(p1);
            //c.addPlayer(p2);
            //c.addPlayer(p3);
            p1.Materials = materials;
            //p2.Materials = materials2;
            //p3.Materials = materials3;

            for (int i = 0; i < materials.Length; i++)
            {
                if (materials[i] > max)
                {
                    max = materials[i];
                }
            }
            int res = c.calculateMaximumValue();
            Assert.AreEqual(max, res);
        }
    }
}
