using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Games.coop.models
{
    public class Player
    {
        public ValueFunction valueFunction;
        public int[] materials;

        public ValueFunction ValueFunction
        {
            get { return valueFunction; }
            set { valueFunction = value; }
        }

        public int[] Materials
        {
            get { return materials; }
            set { materials = value; }
        }

        public Player(ValueFunction valueFunction, int[] materials)
        {
            this.Materials = materials;
            this.ValueFunction = valueFunction;
        }

    }
}
