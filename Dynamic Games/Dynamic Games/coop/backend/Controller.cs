using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dynamic_Games.coop.models;

namespace Dynamic_Games.coop.backend
{
    class Controller
    {
        static Controller instance;
        EquilibriumCalculator calculator;

        private Controller(){

        }

        public static Controller getInstance()
        {
            if (instance == null){
                instance = new Controller();
            }
            return instance;
        }

        public void init(List<Player> players){
            //TODO: init like calculate all calculation's maximum value
        }

        public void init(String filename)
        {
            //TODO: parse file
        }

        public List<Coalition> getPartialResult(){
            return calculator.getPartialResult();
        }
    }
}
