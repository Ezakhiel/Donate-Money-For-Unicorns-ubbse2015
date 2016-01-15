﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Games.coop.models
{
    class Coalition
    {
        private List<Player> players;
        private bool maximumCalculated;
        private Double maximumValue;
        private int[] materials;

        public List<Player> Players
        {
            get { return players; }
        }

        public Coalition(int m)
        {
            players = new List<Player>();
            materials = new int[m];
        }

        public void addPlayer(Player player)
        {
            if (player.Materials.Length > materials.Length)
            {
                //TODO: create exception
                throw new Exception();
            }
            players.Add(player);
            materials = materials.Zip(player.Materials, (x, y) => x + y).ToArray<int>();
            maximumCalculated = false;
        }

        public void removePlayer(Player player)
        {
            if (player.Materials.Length > materials.Length)
            {
                //TODO: create exception
                throw new Exception();
            }
            players.Remove(player);
            materials = materials.Zip(player.Materials, (x, y) => x - y).ToArray<int>();
            maximumCalculated = false;
        }

        private void calculateMaximumValue()
        {
            maximumValue = 0;
            bool init = true;
            foreach (var player in players)
            {
                var value = player.ValueFunction.getValue(materials);
                if (value > maximumValue || init)
                {
                    maximumValue = value;
                    init = false;
                }
            }
            maximumCalculated = true;
        }

        public Double getMaximumValue()
        {
            if (!maximumCalculated)
                calculateMaximumValue();
            return maximumValue;
        }

        public override String ToString()
        {
            String result = "(";
            foreach (Player a in players)
            {
                result += a.ToString() + ",";
            }
            result = result.Remove(result.Length - 1, 1) + ")";
            return result;
        }
    }
}
