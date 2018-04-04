using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public enum GameState
    {
        Start,
        ShipPlacement,
        Play
    }

    

    public enum CellState
    {
        empty,
        busy,
        striked,
        missed,
        killed
    }


    public delegate void MyDelegate(CellState[,] map);

    public class Brain
    {

        string[] st = { "1", "1", "1", "1", "2", "2", "2", "3", "3", "4" };
        int stIndex = 0;

        CellState[,] map = new CellState[10, 10];
        List<Ship> units = new List<Ship>();

        public GameState currentState;
        MyDelegate invoker;
        public Brain(MyDelegate invoker)
        {
            this.invoker = invoker;
            currentState = GameState.Start;
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    map[i, j] = CellState.empty;
                }
            }
            invoker.Invoke(map);
        }


        public void Process2(string msg)
        {
            string[] val = msg.Split('_');
            int i = int.Parse(val[0]);
            int j = int.Parse(val[1]);

            switch (map[i, j])
            {
                case CellState.empty:
                    map[i, j] = CellState.missed;
                    break;
                case CellState.busy:
                    map[i, j] = CellState.striked;
                    break;
                case CellState.striked:
                    break;
                case CellState.missed:
                    break;
                case CellState.killed:
                    break;
                default:
                    break;
            }
        }

        public void Empty(bool isInput, int i, int j)
        {
            if (isInput)
            {
                
            }else
            {

            }
        }

        public void Process(string msg)
        {
            string[] val = msg.Split('_');
            int i = int.Parse(val[0]);
            int j = int.Parse(val[1]);
            Point p = new Point(i, j);
            switch (currentState)
            {
                case GameState.Start:
                    Start(false, p);
                    break;
                case GameState.ShipPlacement:
                    ShipPlacement(false, p);
                    break;
                case GameState.Play:
                    Play(false, p);
                    break;
                default:
                    break;
            }
        }

        public void Play(bool isInput, Point p)
        {
            if (isInput)
            {
                currentState = GameState.Play;
            }
        }

        private bool IsGoodCell(int i, int j)
        {
            if (i < 0 || i > 9) return false;
            if (j < 0 || j > 9) return false;
            return map[i, j] == CellState.empty;
        }

        private bool IsGoodLocated(Ship ship)
        {
            bool res = true;

            foreach (Point p in ship.body)
            {
                if (!IsGoodCell(p.X, p.Y))
                {
                    res = false;
                    break;
                }
            }

            return res;
        }


        private void MarkCell(int i, int j)
        {
            map[i, j] = CellState.busy;
        }

        private void MarkLocation(Ship ship)
        {
            foreach (Point p in ship.body)
            {
                MarkCell(p.X, p.Y);
            }
        }


        public void Start(bool isInput, Point p)
        {
            Ship ship = new Ship(p, ShipType.D1);

            if (isInput)
            {
                currentState = GameState.Start;
            }
            else
            {
                if (IsGoodLocated(ship))
                {
                    units.Add(ship);
                    Ship1Da(true, p);
                }
            }
        }
        public void Ship4Da(bool isInput, Point p)
        {
            Ship ship = new Ship(p, ShipType.D4);

            if (isInput)
            {
                currentState = GameState.Ship4Da;
                MarkLocation(ship);
                invoker.Invoke(map);
            }
            else
            {
                Play(true, p);
            }
        }
        public void Ship3Da(bool isInput, Point p)
        {
            Ship ship = new Ship(p, ShipType.D3);

            if (isInput)
            {
                currentState = GameState.Ship3Da;
                MarkLocation(ship);
                invoker.Invoke(map);
            }
            else
            {
                if (IsGoodLocated(ship))
                {
                    units.Add(ship);
                    Ship3Db(true, p);
                }
            }
        }
        public void Ship3Db(bool isInput, Point p)
        {

            if (isInput)
            {
                Ship ship = new Ship(p, ShipType.D3);

                currentState = GameState.Ship3Db;
                MarkLocation(ship);
                invoker.Invoke(map);
            }
            else
            {
                Ship ship = new Ship(p, ShipType.D4);

                if (IsGoodLocated(ship))
                {
                    units.Add(ship);
                    Ship4Da(true, p);
                }
            }
        }
        public void Ship2Da(bool isInput, Point p)
        {
            Ship ship = new Ship(p, ShipType.D2);
            if (isInput)
            {
                currentState = GameState.Ship2Da;
                MarkLocation(ship);
                invoker.Invoke(map);
            }
            else
            {
                if (IsGoodLocated(ship))
                {
                    units.Add(ship);
                    Ship2Db(true, p);
                }
            }
        }
        public void Ship2Db(bool isInput, Point p)
        {
            Ship ship = new Ship(p, ShipType.D2);
            if (isInput)
            {
                currentState = GameState.Ship2Db;
                MarkLocation(ship);
                invoker.Invoke(map);
            }
            else
            {
                if (IsGoodLocated(ship))
                {
                    units.Add(ship);
                    Ship2Dc(true, p);
                }
            }
        }
        public void Ship2Dc(bool isInput, Point p)
        {
            if (isInput)
            {
                Ship ship = new Ship(p, ShipType.D2);

                currentState = GameState.Ship2Dc;
                MarkLocation(ship);
                invoker.Invoke(map);
            }
            else
            {
                Ship ship = new Ship(p, ShipType.D3);

                if (IsGoodLocated(ship))
                {
                    units.Add(ship);
                    Ship3Da(true, p);
                }
            }
        }
        public void Ship1Da(bool isInput, Point p)
        {
            Ship ship = new Ship(p, ShipType.D1);
            if (isInput)
            {
                currentState = GameState.Ship1Da;
                MarkLocation(ship);
                invoker.Invoke(map);
            }
            else
            {
                if (IsGoodLocated(ship))
                {
                    units.Add(ship);
                    Ship1Db(true, p);
                }
            }
        }
        public void Ship1Db(bool isInput, Point p)
        {
            Ship ship = new Ship(p, ShipType.D1);
            if (isInput)
            {
                currentState = GameState.Ship1Db;
                MarkLocation(ship);
                invoker.Invoke(map);
            }
            else
            {
                if (IsGoodLocated(ship))
                {
                    units.Add(ship);
                    Ship1Dc(true, p);
                }
            }
        }
        public void Ship1Dc(bool isInput, Point p)
        {
            Ship ship = new Ship(p, ShipType.D1);
            if (isInput)
            {
                currentState = GameState.Ship1Db;
                MarkLocation(ship);
                invoker.Invoke(map);
            }
            else
            {

                if (IsGoodLocated(ship))
                {
                    units.Add(ship);
                    Ship1Dc(true, p);
                }
            }
        }
        public void Ship1Dd(bool isInput, Point p)
        {
            if (isInput)
            {
                Ship ship = new Ship(p, ShipType.D1);
                currentState = GameState.Ship1Dd;
                MarkLocation(ship);
                invoker.Invoke(map);
            }
            else
            {
                Ship ship = new Ship(p, ShipType.D2);
                if (IsGoodLocated(ship))
                {
                    units.Add(ship);
                    Ship2Da(true, p);
                }
            }
        }


    }
}
