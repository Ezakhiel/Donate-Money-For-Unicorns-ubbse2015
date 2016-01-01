using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Games.coop.models
{
    public class Coalition
    {
        List<Player> players;
        long maximumValue;
        int[] materials;

        public Coalition(int m)
        {
            players = new List<Player>();
            materials = new int[m];
        }

        public int calculateMaximumValue(){
            //TODO: calculate maximum value by players
            int max = 0;
            for (int i = 0; i < materials.Length; i++)
            {
                if (materials[i] > max)
                {
                    max = materials[i];
                }
            }
            return max;
        }

        public void addPlayer(Player player)
        {
            if (player.Materials.Length > materials.Length)
            {
                //TODO: create exception
                //throw new Exception();
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
