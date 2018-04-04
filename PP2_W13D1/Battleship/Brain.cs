using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{

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

        public ShipType[] st = { ShipType.D1, ShipType.D1, ShipType.D1, ShipType.D1,
                          ShipType.D2, ShipType.D2, ShipType.D2,
                          ShipType.D3, ShipType.D3,
                          ShipType.D4};

        public int stIndex = -1;

        CellState[,] map = new CellState[10, 10];
        List<Ship> units = new List<Ship>();

        MyDelegate invoker;
        public Brain(MyDelegate invoker)
        {
            this.invoker = invoker;
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    map[i, j] = CellState.empty;
                }
            }
            invoker.Invoke(map);
        }


        public bool Process2(string msg)
        {
            bool successShoot = false;

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
                    successShoot = true;

                    int index = -1;
                    for(int k = 0; k < units.Count; ++k)
                    {
                        foreach(ShipPoint p in units[k].body)
                        {
                            if(p.X == i && p.Y == j)
                            {
                                index = k;
                                break;
                            }
                        }
                        if(index != -1)
                        {
                            break;
                        }

                    }

                    if (index != -1)
                    {
                        bool killed = true;

                        foreach (ShipPoint p in units[index].body)
                        {
                            if (map[p.X, p.Y] != CellState.striked)
                            {
                                killed = false;
                                break;
                            }
                        }

                        if (killed)
                        {
                            foreach (ShipPoint p in units[index].body)
                            {
                                map[p.X, p.Y] = CellState.killed;
                            }
                        }
                    }

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

            invoker.Invoke(map);
            return successShoot;
        }

        public void Process(string msg)
        {
            string[] val = msg.Split('_');
            int i = int.Parse(val[0]);
            int j = int.Parse(val[1]);
            Point p = new Point(i, j);

            ShipPlacement(p);
            
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

            foreach (ShipPoint p in ship.body)
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
            foreach (ShipPoint p in ship.body)
            {
                MarkCell(p.X, p.Y);
            }
        }


        public void ShipPlacement(Point p)
        {
            if (stIndex + 1 < st.Length)
            {
                stIndex++;
                Ship ship = new Ship(p, st[stIndex]);
                if (IsGoodLocated(ship)) {
                    units.Add(ship);
                    MarkLocation(ship);
                    invoker.Invoke(map);
                }else
                {
                    stIndex--;
                }
            }
        }

    }
}
