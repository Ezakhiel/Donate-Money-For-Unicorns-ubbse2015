using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynamic_Games.IncInformation.Game;
using System.Threading;
/*
 * Megjegyzes: Fontos Jatekosszam szerinti optimalizatiot is kellene
 * vegezni az algoritmuson a pontos nyeresi % felmereseben.
 * pl: 5 jatekosnal 20% os nyeresu lapok 2 jatekosnal 70% os lapok....
 * Jelenleg normalizalt winchance-t kap az osztaly
 */
namespace Dynamic_Games.IncInformation.Player
{
    class AI
    {
       // double[,] callMatrix = new double[7,3] {
      //                                            { }
      //  } 

        Player me;
        Table table;
        int strategyType;
        int call;
        double winChance;
        int playerCount;
        double factorForWinChance;
        double factorForMyBet;
        double bigRaise;
        double smallRaise;

        public AI(Player AIPlayer,
                  Table t,
                  int strategyType,
                  int call,
                  double winChance,
                  int playerCount,
                  double randomFactorForWinChance,
                  double randomFactorForMyBet)
        {
            this.me = AIPlayer;
            this.table = t;
            this.strategyType = strategyType;
            this.call = call;
            this.winChance = winChance;
            this.playerCount = playerCount;
            this.factorForMyBet = randomFactorForMyBet;
            this.factorForWinChance = randomFactorForWinChance;
            this.smallRaise = ((factorForMyBet / 2) * me.cash) / 100;
            this.bigRaise = (factorForMyBet * me.cash) / 100;
            if (smallRaise < call)
                smallRaise = call;
            if (bigRaise < call)
                bigRaise = call;
            strategyForAI();

        }


        // Improvable
        public void tightPassive(double factWinChance)
        {
            // if he give a good starting card maybe he playing but not every time because he scaring, if he dont have good cards he fold
            switch (table.statevalue)
            {
                case (State.Preflop):
                    //Call
                    if (factWinChance > 30)
                    {
                        //raise
                        if (factWinChance > 70)
                        {
                            me.bet = (int)smallRaise;
                            break;
                        }
                        me.bet = call;
                    }
                    else
                    {
                        if (me.bet < call)
                        me.folded = true;
                    }
                    break;
                case (State.Flop):
                    if (factWinChance > 40)
                    {
                        //raise
                        if (factWinChance > 70)
                        {
                            if (factWinChance > 85)
                            {
                                me.bet = (int)bigRaise;
                                break;
                            }
                            me.bet = (int)smallRaise;
                            break;
                        }
                        me.bet = call;
                    }
                    else
                    {
                        if (me.bet < call)
                        me.folded = true;
                    }
                    break;
                case (State.Turn):
                    if (factWinChance > 40)
                    {
                        //raise
                        if (factWinChance > 70)
                        {
                            if (factWinChance > 80)
                            {
                                me.bet = (int)bigRaise;
                                break;
                            }
                            me.bet = (int)smallRaise;
                            break;
                        }
                        me.bet = call;
                    }
                    else
                    {
                        if (me.bet < call)
                        me.folded = true;
                    }
                    break;
                case (State.River):
                    if (factWinChance > 50)
                    {
                        //raise
                        if (factWinChance > 70)
                        {
                            if (factWinChance > 80)
                            {
                                //all in
                                if (factWinChance > 90)
                                {
                                    me.bet = me.cash;
                                    break;
                                }
                                me.bet = (int)bigRaise;
                                break;
                            }
                            me.bet = (int)smallRaise;
                            break;
                        }
                        me.bet = call;
                    }
                    else
                    {
                        if (me.bet < call)
                        me.folded = true;
                    }
                    break;
            }
        }


        public void loosePassive(double factWinChance)
        {
            // only call dont raise he want to see the all cards
            switch (table.statevalue)
            {
                case (State.Preflop):
                    //Call
                    if (factWinChance > 30)
                    {
                        //raise
                        if (factWinChance > 70)
                        {
                            me.bet = (int)smallRaise;
                            break;
                        }
                        me.bet = call;
                    }
                    else
                    {
                        if (me.bet < call)
                        me.folded = true;
                    }
                    break;
                case (State.Flop):
                    if (factWinChance > 40)
                    {
                        //raise
                        if (factWinChance > 70)
                        {
                            if (factWinChance > 85)
                            {
                                me.bet = (int)bigRaise;
                                break;
                            }
                            me.bet = (int)smallRaise;
                            break;
                        }
                        me.bet = call;
                    }
                    else
                    {
                        if (me.bet < call)
                        me.folded = true;
                    }
                    break;
                case (State.Turn):
                    if (factWinChance > 40)
                    {
                        //raise
                        if (factWinChance > 70)
                        {
                            if (factWinChance > 80)
                            {
                                me.bet = (int)bigRaise;
                                break;
                            }
                            me.bet = (int)smallRaise;
                            break;
                        }
                        me.bet = call;
                    }
                    else
                    {
                        if (me.bet < call)
                        me.folded = true;
                    }
                    break;
                case (State.River):
                    if (factWinChance > 50)
                    {
                        //raise
                        if (factWinChance > 70)
                        {
                            if (factWinChance > 80)
                            {
                                //all in
                                if (factWinChance > 90)
                                {
                                    me.bet = me.cash;
                                    break;
                                }
                                me.bet = (int)bigRaise;
                                break;
                            }
                            me.bet = (int)smallRaise;
                            break;
                        }
                        me.bet = call;
                    }
                    else
                    {
                        if (me.bet < call)
                        me.folded = true;
                    }
                    break;
            }
        }
        public void looseAgressive(double factWinChance)
        {
            // need to raise and be the last in the game dont mather if he loose or win
            switch (table.statevalue)
            {
                case (State.Preflop):
                    //Call
                    if (factWinChance > 30)
                    {
                        //raise
                        if (factWinChance > 60)
                        {
                            me.bet = (int)smallRaise;
                            break;
                        }
                        me.bet = call;
                    }
                    else
                    {
                        if (me.bet < call)
                        me.folded = true;
                    }
                    break;
                case (State.Flop):
                    if (factWinChance > 40)
                    {
                        //raise
                        if (factWinChance > 60)
                        {
                            if (factWinChance > 70)
                            {
                                me.bet = (int)bigRaise;
                                break;
                            }
                            me.bet = (int)smallRaise;
                            break;
                        }
                        me.bet = call;
                    }
                    else
                    {
                        if (me.bet < call)
                        me.folded = true;
                    }
                    break;
                case (State.Turn):
                    if (factWinChance > 40)
                    {
                        //raise
                        if (factWinChance > 60)
                        {
                            if (factWinChance > 70)
                            {
                                //all in
                                if (factWinChance > 80)
                                {
                                    me.bet = me.cash;
                                    break;
                                }
                                me.bet = (int)bigRaise;
                                break;
                            }
                            me.bet = (int)smallRaise;
                            break;
                        }
                        me.bet = call;
                    }
                    else
                    {
                        if (me.bet < call)
                        me.folded = true;
                    }
                    break;
                case (State.River):
                    if (factWinChance > 50)
                    {
                        //raise
                        if (factWinChance > 70)
                        {
                            if (factWinChance > 80)
                            {
                                //all in
                                if (factWinChance > 90)
                                {
                                    me.bet = me.cash;
                                    break;
                                }
                                me.bet = (int)bigRaise;
                                break;
                            }
                            me.bet = (int)smallRaise;
                            break;
                        }
                        me.bet = call;
                    }
                    else
                    {
                        if (me.bet < call)
                        me.folded = true;
                    }
                    break;

            }
        }
        public void tightAgressive(double factWinChance)
        {
            // need a good winChance to go but when he got do everyting 
            switch (table.statevalue)
            {
                case (State.Preflop):
                    //Call
                    if (factWinChance > 60)
                    {
                        //raise
                        if (factWinChance > 70)
                        {
                            me.bet = (int)bigRaise;
                            break;
                        }
                        me.bet = call;
                    }
                    else
                    {
                        if (me.bet < call)
                        me.folded = true;
                    }
                    break;
                case (State.Flop):
                    if (factWinChance > 60)
                    {
                        //raise
                        if (factWinChance > 70)
                        {
                            if (factWinChance > 80)
                            {
                                //all in
                                if (factWinChance > 90)
                                {
                                    me.bet = me.cash;
                                    break;
                                }
                                me.bet = (int)bigRaise;
                                break;
                            }
                            me.bet = (int)smallRaise;
                            break;
                        }
                        me.bet = call;
                    }
                    else
                    {
                        if (me.bet < call)
                        me.folded = true;
                    }
                    break;
                case (State.Turn):
                    if (factWinChance > 60)
                    {
                        //raise
                        if (factWinChance > 70)
                        {
                            if (factWinChance > 80)
                            {
                                //all in
                                if (factWinChance > 90)
                                {
                                    me.bet = me.cash;
                                    break;
                                } 
                                me.bet = (int)bigRaise;
                                break;
                            }
                            me.bet = (int)smallRaise;
                            break;
                        }
                        me.bet = call;
                    }
                    else
                    {
                        if (me.bet < call)
                        me.folded = true;
                    }
                    break;
                case (State.River):
                    if (factWinChance > 60)
                    {
                        //raise
                        if (factWinChance > 70)
                        {
                            if (factWinChance > 80)
                            {
                                //all in
                                if (factWinChance > 90)
                                {
                                    me.bet = me.cash;
                                    break;
                                }
                                me.bet = (int)bigRaise;
                                break;
                            }
                            me.bet = (int)smallRaise;
                            break;
                        }
                        me.bet = call;
                    }
                    else
                    {
                        if (me.bet < call)
                        me.folded = true;
                    }
                    break;
            }



        }

        public void strategyForAI()
        {

            
            double factorizedWinChance = (winChance * factorForWinChance) / 100;
            switch (strategyType)
            {
                case 1: // Tight Passive
                    {
                        tightPassive(factorizedWinChance);
                    } break;
                case 2: // Loose Passive
                    {
                        loosePassive(factorizedWinChance);
                    } break;
                case 3: // Tight Aggressive (TAG)
                    {
                        tightAgressive(factorizedWinChance);
                    } break;
                case 4: // Loose Aggressive (LAG)
                    {
                        looseAgressive(factorizedWinChance);
                    } break;
            }
            
        }



    }
}
