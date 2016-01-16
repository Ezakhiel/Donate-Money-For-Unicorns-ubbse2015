using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

using Dynamic_Games.IncInformation.Player;

namespace Dynamic_Games.IncInformation.Game
{

    public class TurnThread
    {
        public Deal deal;
        private ManualResetEvent threadSack = new ManualResetEvent(false);
        public int tCall;

        public TurnThread(Deal d)
        {
            this.deal = d;
        }

        public void doTurn(int turnCall, int bigBlindNext)
        {
            int actualPlayer = bigBlindNext;
            int raisedPlayer = actualPlayer;
            this.tCall = turnCall;

            do
            {
                deal.table.controls.Invoke((Action)delegate
                {
                    deal.table.controls.playerVis[actualPlayer].betLBL.BackColor = Color.Yellow;
                });

                //if not inactive
                if (!deal.activePlayers[actualPlayer].folded)
                {
                    // player sets fields
                    try
                    {
                        deal.activePlayers[actualPlayer].decision();
                    }
                    catch (ThreadInterruptedException exception)
                    {
                        theSack();
                    }

                    if (!deal.activePlayers[actualPlayer].folded)
                    {
                        if (deal.activePlayers[actualPlayer].bet < tCall)
                        {
                            if (deal.activePlayers[actualPlayer].cash != 0)
                            {
                                deal.activePlayers[actualPlayer].folded = true;
                            }
                        }
                        if (deal.activePlayers[actualPlayer].bet > tCall)
                        {
                            tCall = deal.activePlayers[actualPlayer].bet;
                            raisedPlayer = actualPlayer;
                        }
                    }
                }
                deal.table.controls.Invoke((Action)delegate
                {
                    deal.table.controls.playerVis[actualPlayer].betLBL.BackColor = Color.White;
                });
                actualPlayer++;
                if (deal.table.players.Count <= actualPlayer)
                {
                    actualPlayer = 0;
                }
                if (deal.table.activePlayerCount() == 1)
                {
                    break;
                }
                    
            }
            while (actualPlayer != raisedPlayer);
            //while true goes

            deal.table.controls.Invoke((Action)delegate
            {
                deal.table.controls.playerVis[raisedPlayer].betLBL.ForeColor = Color.Black;
            });

          //  Thread.Sleep(1000);
        }


        private void theSack()
        {
            deal.table.threadLockEvent.Set();
            while (!threadSack.WaitOne())
            {
                Thread.Sleep(2000000);
            }
        }
    }
}
