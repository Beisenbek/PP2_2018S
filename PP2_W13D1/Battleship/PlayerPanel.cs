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

    class PlayerPanel : Panel
    {
        public Brain brain;
        int cellW = 20;
        PanelPosition panelPosition;
        PlayerType playerType;
        TurnDelegate tDelegate;

        public PlayerPanel(PanelPosition panelPosition, PlayerType playerType,TurnDelegate tDelegate)
        {
            this.panelPosition = panelPosition;
            this.playerType = playerType;
            this.tDelegate = tDelegate;

            Initialize();
            Random rnd1 = new Random(Guid.NewGuid().GetHashCode());
            Random rnd2 = new Random(Guid.NewGuid().GetHashCode());

            if (playerType == PlayerType.Human)
            {
                while (brain.stIndex < brain.st.Length - 1)
                {
                    int row = rnd1.Next(0, 10);
                    int column = rnd1.Next(0, 10);
                    string msg = string.Format("{0}_{1}", row, column);
                    brain.Process(msg);
                }
            }

            if (playerType == PlayerType.Bot)
            {
                while (brain.stIndex < brain.st.Length - 1)
                {
                    int row = rnd2.Next(0, 10);
                    int column = rnd2.Next(0, 10);
                    string msg = string.Format("{0}_{1}", row, column);
                    brain.Process(msg);
                }
            }
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
            if (brain.stIndex < brain.st.Length - 1)
            {
                brain.Process(btn.Name);
            }
            else
            {
                if (!brain.Process2(btn.Name))
                {
                    tDelegate.Invoke();
                }
            }
        }

        private void ChangeButton(CellState[,] map)
        {
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    Color colorToFill = Color.White;
                    bool isEnabled = true;

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
                            isEnabled = false;
                            break;
                        case CellState.missed:
                            colorToFill = Color.Gray;
                            isEnabled = false;
                            break;
                        case CellState.killed:
                            colorToFill = Color.Red;
                            isEnabled = false;
                            break;
                        default:
                            break;
                    }

                    this.Controls[10 * i + j].BackColor = colorToFill;
                    this.Controls[10 * i + j].Enabled = isEnabled;
                }
            }


        }

    }
}
