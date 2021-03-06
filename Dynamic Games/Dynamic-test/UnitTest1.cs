﻿using System;
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

            coopTest.richTextBoxPlayerFunc.Text = "";
            coopTest.numericPlayer.Value = 0;
            coopTest.richTextBoxMaterials.Text = "";
            Assert.IsFalse(coopTest.CheckFill());

            coopTest.numericPlayer.Value = 5;
            Assert.IsFalse(coopTest.CheckFill());

            coopTest.richTextBoxPlayerFunc.Text = "alma";
            Assert.IsFalse(coopTest.CheckFill());

            coopTest.richTextBoxMaterials.Text = "rost\nmag";
            Assert.IsTrue(coopTest.CheckFill());
        }

        [TestMethod]
        public void InputNonCoopTest()
        {
            //(numericPlayer.Value == 0 || textBoxProduct.Text == "" || richTextBoxMaterials.Text == "")
            NonCoopForm nonCoopTest = new NonCoopForm();

            nonCoopTest.NoPTB.Text = "";
            nonCoopTest.InvestmentTB.Text = "";
            nonCoopTest.MultiTB.Text = "";
            nonCoopTest.RuleParamTB.Text = "";
            nonCoopTest.GraphTypeCB.Text = "";
            Assert.IsFalse(nonCoopTest.checkParams());

            nonCoopTest.NoPTB.Text = "30";
            Assert.IsFalse(nonCoopTest.checkParams());

            nonCoopTest.InvestmentTB.Text = "10";
            Assert.IsFalse(nonCoopTest.checkParams());

            nonCoopTest.MultiTB.Text = "5";
            Assert.IsFalse(nonCoopTest.checkParams());

            nonCoopTest.RuleParamTB.Text = "75";
            Assert.IsFalse(nonCoopTest.checkParams());

            nonCoopTest.GraphTypeCB.Text = "Random Graph";
            Assert.IsTrue(nonCoopTest.checkParams());
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
        /// <summary>
        /// #alfa    = átlagosan legenerált lapok száma
        /// #epsilon = maximális eltérés
        /// #gamma   = átlagtól való átlagos eltérés
        /// </summary>
       
        [TestMethod]
        public void CardStatTest()
        {

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            String symbol = "c";
            String nameHelper;

            for (int i = 0; i < 4; i++)
            {
                for (int num = 1; num <= 9; num++)
                {
                    nameHelper = symbol + "0" + num.ToString();
                    dictionary.Add(nameHelper, 0);
                }
                for (int num = 10; num <= 13; num++)
                {
                    nameHelper = symbol + num.ToString();
                    dictionary.Add(nameHelper, 0);
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

            int n = 1000;

            for (int j = 0; j < n; j++)
            {
                Dynamic_Games.IncInformation.Cards.Deck d = new Dynamic_Games.IncInformation.Cards.Deck();
                for (int i = 0; i < 21; i++)
                {
                    Dynamic_Games.IncInformation.Cards.Card c = d.getCard();
                    dictionary[c.CardName]++;
                }
            }

            double alfa = n * 0.41;

            double epsilon = 100;

            bool result = true;

            Console.WriteLine("Epsilon : " + epsilon + "      Alfa : " + alfa);

            foreach (KeyValuePair<string, int> entry in dictionary)
            {
                Console.WriteLine("Key : " + entry.Key + "   Value: " + entry.Value + "     Gamma: " +(entry.Value - alfa));
                if (Math.Abs(entry.Value - alfa)> epsilon)
                {
                    Console.WriteLine("FAILED");
                    result = false;
                }
            }
            Assert.IsTrue(result);
        }
    }

}
