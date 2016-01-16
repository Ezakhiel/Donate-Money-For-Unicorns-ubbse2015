using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Games.Coop.Models
{
    class PartialResult
    {
        private List<string> coalitions;
        private List<int> profits;
        private Boolean end;

        public List<string> Coalitions{
            get { return coalitions; }
            set { coalitions = value; }
        }

        public List<int> Profits
        {
            get { return profits; }
            set { profits = value; }
        }

        public Boolean End
        {
            get { return end; }
            set { end = value; }
        }
    }
}
