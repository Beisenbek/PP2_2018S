using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    enum CalcStates
    {
        FirstNumber,
        SecondNumber
    }

    enum OperationsState
    {
        Plus,
        Minus
    }

    class Calc
    {
        public int firstNumber;
        public int secondNumber;
        public int resultNumber;
        public CalcStates currentState;
        public OperationsState currentOperation;
        public Calc()
        {
            currentState = CalcStates.FirstNumber;
            firstNumber = 0;
            secondNumber = 0;
            resultNumber = 0;
        }
    }
}
