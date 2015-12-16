using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dynamic_Games.coop.models;

namespace Dynamic_Games.coop.backend
{
    interface EquilibriumCalculator
    {
        public void init();

        public List<Coalition> getPartialResult();
    }
}
