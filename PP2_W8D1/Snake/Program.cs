using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.SetupBoard();
            game.Start();

            while (game.worm.IsAlive)
            {
                ConsoleKeyInfo pressedButton = Console.ReadKey();
                game.Process(pressedButton);
            }
        }
    }
}
