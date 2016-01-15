using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dynamic_Games.coop.models
{
    public class ValueFunction
    {
        public const String MARK = "X";
        public const String pattern = MARK + @"(\d+)(\^)(\d+)";
        private String function;

        public String Function
        {
            get { return function; }
            set
            {
                function = Regex.Replace(value.ToUpper(), pattern, "Math.pow($1,$3)");
            }
        }

        public ValueFunction(String function)
        {
            this.Function = function;
        }

        //returns the value of function to given parameters
        public Double getValue(int[] materials)
        {
            String parameters = "";
            var index = 1;
            foreach (int material in materials)
            {
                parameters = parameters + MARK + index + " = " + material + ";";
                index++;
            }
            Type scriptType = Type.GetTypeFromCLSID(Guid.Parse("0E59F1D5-1FBE-11D0-8FF2-00A0D10038BC"));

            dynamic obj = Activator.CreateInstance(scriptType, false);
            obj.Language = "javascript";

            //execute function like javascript with the given parameters
            var value = obj.Eval(parameters + function);
            return value;
        }
        

    }
}
