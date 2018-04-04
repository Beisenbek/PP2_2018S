using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Battleship
{
    public delegate void TurnDelegate();

    class GameLogic
    {
        public PlayerPanel p1, p2;
        public GameLogic()
        {
            p1 = new PlayerPanel(PanelPosition.Left, PlayerType.Human, MakeBotTurn);
            p2 = new PlayerPanel(PanelPosition.Right, PlayerType.Bot, MakeBotTurn);
        }

        void MakeBotTurn()
        {
            Random rnd = new Random();
            int i = rnd.Next(0, 10);
            int j = rnd.Next(0, 10);
            while (p1.brain.Process2(string.Format("{0}_{1}", i, j)))
            {
                Thread.Sleep(1000);
                i = rnd.Next(0, 10);
                j = rnd.Next(0, 10);
            }
        }
    }
}
