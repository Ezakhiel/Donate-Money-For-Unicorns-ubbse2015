using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Games.coop.models
{
    class Coalition
    {
        List<Player> players;
        long maximumValue;
        int[] materials;

        public Coalition(int m)
        {
            players = new List<Player>();
            materials = new int[m];
        }

        private void calculateMaximumValue(){
            //TODO: calculate maximum value by players
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
        }

        public long getMaximumValue()
        {
            return maximumValue;
        }
    }
}
