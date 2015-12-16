using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Games.coop.models
{
    class Player
    {
        private ValueFunction valueFunction;
        private int[] materials;

        internal ValueFunction ValueFunction
        {
            get { return valueFunction; }
            set { valueFunction = value; }
        }

        public int[] Materials
        {
            get { return materials; }
            set { materials = value; }
        }

        public Player()
        {
        }

        public Player(ValueFunction valueFunction, int[] materials)
        {
            this.Materials = materials;
            this.ValueFunction = valueFunction;
        }

    }
}
