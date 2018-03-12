using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcWindowsFormsApplication2
{
    public delegate void MyDelegate(string msg);
    public enum CurrentState
    {
        Zero,
        AccumulateDigits,
        AccumulateDigitsWithDecimal,
        Compute,
        ShowResult,
        ShowError
    }
    public class Brain
    {
        public string firstNumber;
        public string secondNumber;
        public string currentNumber;
        public string result;
        public string op;

        public MyDelegate invoker;
        public CurrentState currentState;
        string[] all_digits = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
        string[] non_zero_digits = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
        string[] zero_digits = { "0" };

        string[] operations = { "+", "-" };
        string[] equals = { "=" };
        string[] separators = { "," };

        public Brain()
        {
            currentState = CurrentState.Zero;
        }

        public void Process(string operation)
        {
            switch (currentState)
            {
                case CurrentState.Zero:
                    Zero(false, operation);
                    break;
                case CurrentState.AccumulateDigits:
                    AccumulateDigits(false, operation);
                    break;
                case CurrentState.AccumulateDigitsWithDecimal:
                    AccumulateDigitsWithDecimal(false, operation);
                    break;
                case CurrentState.Compute:
                    Compute(false, operation);
                    break;
                case CurrentState.ShowResult:
                    ShowResult(false, operation);
                    break;
                case CurrentState.ShowError:
                    break;
                default:
                    break;
            }
        }

        public void Zero(bool isInput, string info)
        {
            if (isInput)
            {
                invoker.Invoke("0");
                currentState = CurrentState.Zero;
            }
            else
            {
                if (non_zero_digits.Contains(info))
                {
                    AccumulateDigits(true, info);
                }else if (zero_digits.Contains(info))
                {
                    Zero(true, info);
                }
            }
        }
        public void AccumulateDigits(bool isInput,string info)
        {
            if (isInput)
            {
                currentNumber = currentNumber + info;
                invoker.Invoke(currentNumber);
                currentState = CurrentState.AccumulateDigits;
            }
            else
            {
                if (all_digits.Contains(info))
                {
                    AccumulateDigits(true, info);
                }else if (operations.Contains(info))
                {
                    Compute(true, info);
                }else if (equals.Contains(info))
                {
                    ShowResult(true, info);
                }
            }

        }
        public void AccumulateDigitsWithDecimal(bool isInput, string info)
        {

        }
        public void Compute(bool isInput, string info)
        {
            if (isInput)
            {
                firstNumber = currentNumber;
                currentNumber = "";
                invoker.Invoke("0");
                currentState = CurrentState.Compute;
            }else
            {
                if (all_digits.Contains(info))
                {
                    AccumulateDigits(true, info);
                }
            }
        }

        public void ShowResult(bool isInput, string info)
        {
            if (isInput)
            {
                result = (int.Parse(firstNumber) + int.Parse(currentNumber)).ToString();
                firstNumber = "";
                currentNumber = result;
                invoker.Invoke(result);
                currentState = CurrentState.ShowResult;
            }else
            {
                if (zero_digits.Contains(info))
                {
                    Zero(true, info);
                }else if (operations.Contains(info))
                {
                    Compute(true, info);
                }
            }
        }

        public void ShowError(bool isInput, string info)
        {

        }
    }
}
