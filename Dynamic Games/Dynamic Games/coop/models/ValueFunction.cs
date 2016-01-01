using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Games.coop.models
{
    public class ValueFunction
    {
        public String function;
        public String parameters;

        public String Function
        {
            get { return function; }
            set { function = value; }
        }

        public String Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }

        public long getValue(int[] materials)
        {
            long value = 0;
            // TODO: use parameters on function and get back the value
            return value;
        }
        

    }
}
