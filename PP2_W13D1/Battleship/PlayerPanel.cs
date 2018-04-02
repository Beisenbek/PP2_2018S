using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    enum PanelPosition
    {
        Left,
        Right
    }

    enum PlayerType
    {
        Human,
        Bot
    }

    class PlayerPanel:Panel
    {
        Brain brain;
        int cellW = 20;
        PanelPosition panelPosition;
        PlayerType playerType;

        public PlayerPanel(PanelPosition panelPosition, PlayerType playerType)
        {
            this.panelPosition = panelPosition;
            this.playerType = playerType;

            Initialize();
            Random rnd = new Random();

            //if (playerType == PlayerType.Bot)
            //{
            //    while (brain.currentState != GameState.Play)
            //    {
            //        int row = rnd.Next(0, 10);
            //        int column = rnd.Next(0, 10);
            //        string msg = string.Format("{0}_{1}", row, column);
            //        brain.Process(msg);
            //    }
            //}
        }

        private void Initialize()
        {
            this.Location = new System.Drawing.Point(cellW + 10, cellW + 10);

            if (panelPosition == PanelPosition.Right)
            {
                this.Location = new System.Drawing.Point(cellW * 10 + cellW + 20, cellW + 10);
            }

            this.BackColor = SystemColors.ActiveCaption;
            this.Size = new System.Drawing.Size(cellW * 10, cellW * 10);

            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    Button btn = new Button();
                    btn.Name = i + "_" + j;
                    btn.Click += Btn_Click;
                    btn.Size = new Size(cellW, cellW);
                    btn.Location = new Point(i * cellW, j * cellW);
                    this.Controls.Add(btn);
                }
            }

            brain = new Brain(ChangeButton);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            brain.Process(btn.Name);
        }

        private void ChangeButton(CellState[,] map)
        {
            Color colorToFill = Color.White;

            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    switch (map[i, j])
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
                        default:
                            break;
                    }

                    this.Controls[10 * i + j].BackColor = colorToFill;
                }
            }


        }

    }
}
