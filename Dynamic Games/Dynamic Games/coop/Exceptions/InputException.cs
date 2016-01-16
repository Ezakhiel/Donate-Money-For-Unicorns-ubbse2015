using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Games.Coop.Exceptions
{
    class InputException : Exception
    {
        public InputException(string message) : base(message) { }

        public InputException(string message, Exception inner) : base(message, inner) { }
    }
}
