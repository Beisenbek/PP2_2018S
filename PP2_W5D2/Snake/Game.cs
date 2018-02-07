using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Game
    {
        Worm worm;
        public Game()
        {
            worm = new Worm(new Point { X = 10, Y = 10 }, 
                            '*',
                            ConsoleColor.White);

        }

        public void Draw()
        {
            Console.Clear();
            worm.Draw();
        }

        public void Exit()
        {

        }

        public void Start()
        {

        }

        public void Process(ConsoleKeyInfo pressedButton)
        {
            switch (pressedButton.Key)
            {
                case ConsoleKey.UpArrow:
                    worm.Move(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    worm.Move(0, 1);
                    break;
                case ConsoleKey.LeftArrow:
                    worm.Move(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    worm.Move(1, 0);
                    break;
                case ConsoleKey.Escape:
                    break;
            }
        }
    }
}
