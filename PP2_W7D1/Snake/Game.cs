using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    enum GameLevel
    {
        First,
        Second,
        Bonus
    }

    class Game
    {
        public static int boardW = 35;
        public static int boardH = 35;

        bool[,] field = new bool[10,10];

        Worm worm;
        Food food;
        Wall wall;
        public bool isAlive;

        GameLevel gameLevel;

        public void SetupBoard()
        {
            Console.SetWindowSize(Game.boardW, Game.boardH);
            Console.SetBufferSize(Game.boardW, Game.boardH);
            Console.CursorVisible = false;
        }

        public Game()
        {
            isAlive = true;
            gameLevel = GameLevel.First;
         
            worm = new Worm(new Point { X = 10, Y = 10 }, 
                            ConsoleColor.White, '*');
            food = new Food(new Point { X = 20, Y = 10 },
                           ConsoleColor.White, '+');

            food.Draw();
            wall = new Wall(null,ConsoleColor.White, '#');

            wall.LoadLevel(GameLevel.First);
            wall.Draw();

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
                    worm.Clear();
                    worm.Move(0, -1);
                    worm.Draw();
                    break;
                case ConsoleKey.DownArrow:
                    worm.Clear();
                    worm.Move(0, 1);
                    worm.Draw();

                    break;
                case ConsoleKey.LeftArrow:
                    worm.Clear();
                    worm.Move(-1, 0);
                    worm.Draw();

                    break;
                case ConsoleKey.RightArrow:
                    worm.Clear();
                    worm.Move(1, 0);
                    worm.Draw();

                    break;
                case ConsoleKey.Escape:
                    break;
                case ConsoleKey.F2:
                    worm.Save();
                    food.Save();
                    break;
                case ConsoleKey.F1:
                    worm = worm.Load() as Worm;
                    food = food.Load() as Food;
                    break;
            }

            if(worm.body[0].Equals(food.body[0]))
            {
                worm.body.Add(new Point { X = food.body[0].X, Y = food.body[0].Y });
                food.Draw();
            }
            else
            {
                foreach (Point p in wall.body)
                {
                    if (p.Equals(worm.body[0]))
                    {
                        Console.Clear();
                        Console.WriteLine("GAME OVER!!!");
                        isAlive = false;
                        break;
                    }
                }
            }
        }
    }
}
