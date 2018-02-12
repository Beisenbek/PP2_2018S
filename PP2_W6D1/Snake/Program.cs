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

            Console.SetWindowSize(Game.boardW, Game.boardH);
            Console.SetBufferSize(Game.boardW, Game.boardH);
            Console.CursorVisible = false;


            StatusBar.ShowInfo("test!");


            while (true) { }

            /*Menu menu = new Menu();
            menu.Draw();
            /*Game game = new Game();
            game.SetupBoard();
            game.Start();

            while (true)
            {
                ConsoleKeyInfo pressedButton = Console.ReadKey();
                menu.Process(pressedButton);
                //game.Process(pressedButton);
            }
            */
        }
    }
}
