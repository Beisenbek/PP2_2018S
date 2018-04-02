using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

            PlayerPanel p1 = new PlayerPanel(PanelPosition.Left,PlayerType.Human);
            PlayerPanel p2 = new PlayerPanel(PanelPosition.Right, PlayerType.Bot);
            this.Controls.Add(p1);
            this.Controls.Add(p2);
        }

    }
}
