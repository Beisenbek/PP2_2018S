using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

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
        Timer wormTimer;

        public static int boardW = 35;
        public static int boardH = 35;

        bool[,] field = new bool[10,10];

        public Worm worm;
        public Food food;
        public Wall wall;

        GameLevel gameLevel;

        public void SetupBoard()
        {
            Console.SetWindowSize(Game.boardW, Game.boardH);
            Console.SetBufferSize(Game.boardW, Game.boardH);
            Console.CursorVisible = false;
        }

        public Game()
        {
            gameLevel = GameLevel.First;
         
            worm = new Worm(new Point { X = 10, Y = 10 }, 
                            ConsoleColor.White, '*');
            food = new Food(new Point { X = 14, Y = 10 },
                           ConsoleColor.White, '+');
            wall = new Wall(null,ConsoleColor.White, '#');

            wall.LoadLevel(GameLevel.First);


            wormTimer = new Timer();
            wormTimer.Interval = 500;
            wormTimer.Elapsed += T_Elapsed;
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            worm.Clear();
            worm.Move();
            CanWormEat();
            IsItCrash();
            worm.Draw();
        }

        private void CanWormEat()
        {
            if (worm.body[0].Equals(food.body[0]))
            {
                worm.body.Add(new Point { X = food.body[0].X, Y = food.body[0].Y });
                food.Draw();
            }
        }
        private void IsItCrash()
        {
            foreach (Point p in wall.body)
            {
                if (p.Equals(worm.body[0]))
                {
                    wormTimer.Stop();
                    worm.IsAlive = false;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Clear();
                    Console.WriteLine("GAME OVER!!!");
                  
                    break;
                }
            }
        }

        public void Exit()
        {

        }

        public void Start()
        {
            wall.Draw();
            food.Draw();
            wormTimer.Start();
        }

        public void Process(ConsoleKeyInfo pressedButton)
        {
            switch (pressedButton.Key)
            {
                case ConsoleKey.UpArrow:
                    worm.DX = 0;
                    worm.DY = -1;
                    break;
                case ConsoleKey.DownArrow:
                    worm.DX = 0;
                    worm.DY = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    worm.DX = -1;
                    worm.DY = 0;
                    break;
                case ConsoleKey.RightArrow:
                    worm.DX = 1;
                    worm.DY = 0;
                    break;
                case ConsoleKey.Escape:
                    break;
                case ConsoleKey.Spacebar:
                    if (worm.IsPaused)
                    {
                        worm.IsPaused = false;
                        wormTimer.Start();
                    }
                    else
                    {
                        worm.IsPaused = true;
                        wormTimer.Stop();
                    }
                    break;
            }
        }
    }
}
