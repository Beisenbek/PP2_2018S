using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class StatusBar
    {
        public static void ShowInfo(string info)
        {
            Console.SetCursorPosition(0, Game.boardH - 2);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.DarkGray;

            for (int i = 0; i < Game.boardW; ++i)
            {
                for (int j = Game.boardW - 3; j <= Game.boardW - 1; ++j)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(' ');
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(20, Game.boardH - 2);
            Console.Write(info);
        }
    }
}
