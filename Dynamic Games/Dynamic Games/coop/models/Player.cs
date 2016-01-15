using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Games.coop.models
{
    public class Player
    {
        public const String prefix = "P";

        private String name;
        private ValueFunction valueFunction;
        private int[] materials;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

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

        public Player() { }

        public Player(ValueFunction valueFunction, int[] materials)
        {
            this.Materials = materials;
            this.ValueFunction = valueFunction;
        }

        public override string ToString()
        {
            return name;
        }

    }
}
