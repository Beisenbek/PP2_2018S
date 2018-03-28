using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public enum GameState
    {
        Start,
        Ship4Da,
        Ship3Da,
        Ship3Db,
        Ship2Da,
        Ship2Db,
        Ship2Dc,
        Ship1Da,
        Ship1Db,
        Ship1Dc,
        Ship1Dd,
        Play
    }

    public enum CellState
    {
        empty,
        busy,
        striked,
        missed,
        killed,
        masked
    }


    public delegate void MyDelegate(CellState[,] map);

    public class Brain
    {
        CellState[,] map = new CellState[10, 10];

        GameState currentState;
        MyDelegate invoker;
        public Brain(MyDelegate invoker)
        {
            this.invoker = invoker;
            currentState = GameState.Start;
            for(int i = 0; i < 10; ++i)
            {
                for(int j = 0; j < 10; ++j)
                {
                    map[i, j] = CellState.empty;
                }
            }
            invoker.Invoke(map);
        }

        public void Process(string msg)
        {
            switch (currentState)
            {
                case GameState.Start:
                    Start(false, msg);
                    break;
                case GameState.Ship4Da:
                    break;
                case GameState.Ship3Da:
                    break;
                case GameState.Ship3Db:
                    break;
                case GameState.Ship2Da:
                    Ship2Da(false, msg);
                    break;
                case GameState.Ship2Db:
                    Ship2Db(false, msg);
                    break;
                case GameState.Ship2Dc:
                    Ship2Dc(false, msg);
                    break;
                case GameState.Ship1Da:
                    Ship1Da(false, msg);
                    break;
                case GameState.Ship1Db:
                    Ship1Db(false, msg);
                    break;
                case GameState.Ship1Dc:
                    Ship1Dc(false, msg);
                    break;
                case GameState.Ship1Dd:
                    Ship1Dd(false, msg);
                    break;
                case GameState.Play:
                    Play(false, msg);
                    break;
                default:
                    break;
            }
        }

        public void Play(bool isInput, string msg)
        {

        }

        private bool IsGoodCell(int i, int j)
        {
            if (i < 0 || i > 9) return false;
            if (j < 0 || j > 9) return false;
            return map[i, j] == CellState.empty;
        }

        private bool IsGoodLocation(string msg)
        {
            string[] val = msg.Split('_');
            int i = int.Parse(val[0]);
            int j = int.Parse(val[1]);

            bool res = false;


            switch (currentState)
            {
                case GameState.Ship4Da:
                    break;
                case GameState.Ship3Da:
                    break;
                case GameState.Ship3Db:
                    break;
                case GameState.Ship1Dd:
                case GameState.Ship2Da:
                case GameState.Ship2Db:
                    res = IsGoodCell(i, j) && IsGoodCell(i, j + 1);
                    break;
                case GameState.Ship2Dc:
                    break;
                case GameState.Start:
                case GameState.Ship1Da:
                case GameState.Ship1Db:
                case GameState.Ship1Dc:
                    res = IsGoodCell(i, j);
                    break;
                case GameState.Play:
                    break;
                default:
                    break;
            }

            return res;
        }


        private void MarkCell(int i, int j)
        {
            map[i, j] = CellState.busy;
        }

        private void MarkLocation(string msg)
        {
            string[] val = msg.Split('_');
            int i = int.Parse(val[0]);
            int j = int.Parse(val[1]);
            //map[i, j] = CellState.busy;

            switch (currentState)
            {
               
                case GameState.Ship4Da:
                    break;
                case GameState.Ship3Da:
                    break;
                case GameState.Ship3Db:
                    break;
                case GameState.Ship1Dd:
                case GameState.Ship2Da:
                case GameState.Ship2Db:
                    MarkCell(i, j);
                    MarkCell(i, j + 1);
                    break;
                case GameState.Ship2Dc:
                    break;
                case GameState.Start:
                case GameState.Ship1Da:
                case GameState.Ship1Db:
                case GameState.Ship1Dc:
                    MarkCell(i, j);
                    break;
                case GameState.Play:
                    break;
                default:
                    break;
            }
        }


        public void Start(bool isInput, string msg)
        {
            if (isInput)
            {
                currentState = GameState.Start;
            }else
            {
                if (IsGoodLocation(msg))
                {
                    Ship1Da(true, msg);
                }
            }
        }
        public void Ship4Da(bool isInput, string msg)
        {

        }
        public void Ship3Da(bool isInput, string msg)
        {

        }
        public void Ship3Db(bool isInput, string msg)
        {

        }
        public void Ship2Da(bool isInput, string msg)
        {

        }
        public void Ship2Db(bool isInput, string msg)
        {

        }
        public void Ship2Dc(bool isInput, string msg)
        {

        }
        public void Ship1Da(bool isInput, string msg)
        {
            if (isInput)
            {
                currentState = GameState.Ship1Da;
                MarkLocation(msg);
                invoker.Invoke(map);
            }else
            {
                if (IsGoodLocation(msg))
                {
                    Ship1Db(true, msg);
                }
            }

        }
        public void Ship1Db(bool isInput, string msg)
        {
            if (isInput)
            {
                currentState = GameState.Ship1Db;
                MarkLocation(msg);
                invoker.Invoke(map);
            }
            else
            {
                if (IsGoodLocation(msg))
                {
                    Ship1Dc(true, msg);
                }
            }
        }
        public void Ship1Dc(bool isInput, string msg)
        {
            if (isInput)
            {
                currentState = GameState.Ship1Dc;
                MarkLocation(msg);
                invoker.Invoke(map);
            }
            else
            {
                if (IsGoodLocation(msg))
                {
                    Ship1Dd(true, msg);
                }
            }
        }
        public void Ship1Dd(bool isInput, string msg)
        {
            if (isInput)
            {
                currentState = GameState.Ship1Dd;
                MarkLocation(msg);
                invoker.Invoke(map);
            }
            else
            {
                if (IsGoodLocation(msg))
                {
                    Ship2Da(true, msg);
                }
            }
        }


    }
}
