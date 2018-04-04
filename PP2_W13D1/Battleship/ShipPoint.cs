using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public enum PartType
    {
        ShipPart,
        Aura
    }

    public class ShipPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PartType PType { get; set; }
    }
}
