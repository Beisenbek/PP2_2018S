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
        Brain brain;
        int cellW = 30;

        public Form1()
        {
            InitializeComponent();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    Button btn = new Button();
                    btn.Name = i + "_" + j;
                    btn.Click += Btn_Click;
                    btn.Size = new Size(cellW, cellW);
                    btn.Location = new Point(i * cellW, j * cellW);
                    player1Panel.Controls.Add(btn);
                }
            }

            brain = new Brain(ChangeButton);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            brain.Process(btn.Name);
        }

        private int GetIndexByName(string name)
        {
            Random rnd = new Random();
            return rnd.Next(0, player1Panel.Controls.Count);
        }
        private void ChangeButton(CellState[,] map)
        {
            Color colorToFill = Color.White;

            for(int i = 0; i < 10; ++i)
            {
                for(int j = 0; j < 10; ++j)
                {
                    switch (map[i,j])
                    {
                        case CellState.empty:
                            colorToFill = Color.White;
                            break;
                        case CellState.busy:
                            colorToFill = Color.Blue;
                            break;
                        case CellState.striked:
                            colorToFill = Color.Yellow;
                            break;
                        case CellState.missed:
                            colorToFill = Color.Gray;
                            break;
                        case CellState.killed:
                            colorToFill = Color.Red;
                            break;
                        case CellState.masked:
                            colorToFill = Color.DarkGray;
                            break;
                        default:
                            break;
                    }

                    player1Panel.Controls[10 * i + j].BackColor = colorToFill;
                }
            }
            
            
        }
    }
}
