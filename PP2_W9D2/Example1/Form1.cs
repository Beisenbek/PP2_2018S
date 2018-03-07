using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example1
{
    public partial class Form1 : Form
    {
        Calc calc = new Calc();

        public Form1()
        {
            InitializeComponent();
        }

        private void resultBtnClck(object sender, EventArgs e)
        {
            calc.currentState = CalcStates.FirstNumber;
            calc.secondNumber = int.Parse(display.Text);

            switch (calc.currentOperation)
            {
                case OperationsState.Plus:
                    calc.resultNumber = calc.firstNumber + calc.secondNumber;
                    break;
                case OperationsState.Minus:
                    calc.resultNumber = calc.firstNumber - calc.secondNumber;
                    break;
                default:
                    break;
            }

            
            display.Text = calc.resultNumber.ToString();
        }

        private void operationBtnClck(object sender, EventArgs e)
        {
            Button operationBtn = sender as Button;

            if (operationBtn.Text == "+")
            {
                calc.currentOperation = OperationsState.Plus;
            }
            else if (operationBtn.Text == "-")
            {
                calc.currentOperation = OperationsState.Minus;
            }

            calc.currentState = CalcStates.SecondNumber;

            if (calc.resultNumber != 0)
            {
                calc.firstNumber = calc.resultNumber;
            }else
            {
                calc.firstNumber = int.Parse(display.Text);
            }

            display.Text = "0";
        }

        private void dgtBtnClck(object sender, EventArgs e)
        {
            Button dgtBtn = sender as Button;
            if (display.Text == "0")
            {
                display.Text = dgtBtn.Text;
            }
            else
            {
                display.Text = display.Text + dgtBtn.Text;

            }
        }
    }
}
