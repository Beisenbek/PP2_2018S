using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Menu
    {
        string[] items = { "New Game","Load Game","Save Game","Settings", "Exit"};
        int selectedItemIndex = 0;

        void NewGame()
        {

            StatusBar.ShowInfo("New Game!");
        }

        void LoadGame()
        {
            StatusBar.ShowInfo("LoadGame!");
        }

        void SaveGame()
        {
            StatusBar.ShowInfo("SaveGame!");
        }

        void Settings()
        {
            StatusBar.ShowInfo("Settings!");
        }

        void Exit()
        {
            StatusBar.ShowInfo("Exit!");
        }

        public void Draw()
        {

            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;

            for (int i = 0; i < Game.boardH - 2; ++i)
            {
                for (int j = 0; j < Game.boardW; ++j)
                {
                    Console.Write(' ');
                }
                Console.WriteLine();
            }


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(0, (Game.boardH - 25) / 2);

            for(int i = 0; i < items.Length; ++i)
            {
                if(i == selectedItemIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine(String.Format("          {0}. {1}", i, items[i]));
            }
        }

        public void Process(ConsoleKeyInfo pressedButton)
        {
            switch (pressedButton.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedItemIndex--;
                    if (selectedItemIndex < 0)
                    {
                        selectedItemIndex = items.Length - 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    selectedItemIndex++;
                    if (selectedItemIndex >= items.Length)
                    {
                        selectedItemIndex = 0;
                    }
                    break;
                case ConsoleKey.Enter:

                    switch (selectedItemIndex)
                    {
                        case 0:
                            NewGame();
                            break;
                        case 1:
                            LoadGame();
                            break;
                        case 2:
                            SaveGame();
                            break;
                        case 3:
                            Settings();
                            break;
                        case 4:
                            Exit();
                            break;
                    }

                    break;
            }

           Draw();
        }
    }
}
