using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
class Program
{
    static int EvaluateFormula(string formula)
    {
        Stack<int> numStack = new Stack<int>();  
        Stack<char> operStack = new Stack<char>(); 
        void Calculate()
        {
            char oper = operStack.Pop();
            if (oper == 'M')
            {
                int num2 = numStack.Pop();
                int num1 = numStack.Pop();
                numStack.Push(Math.Max(num1, num2));
            }
            else if (oper == 'm')
            {
                int num2 = numStack.Pop();
                int num1 = numStack.Pop();
                numStack.Push(Math.Min(num1, num2));
            }
        }
        foreach (char c in formula)
        {
            if (char.IsDigit(c))
            {
                numStack.Push(int.Parse(c.ToString()));
            }
            else if (c == 'M' || c == 'm')
            {
                operStack.Push(c);
            }
            else if (c == '(')
            {
                operStack.Push(c);
            }
            else if (c == ')')
            {
                while (operStack.Count > 0 && operStack.Peek() != '(')
                {
                    Calculate();
                }
                operStack.Pop();
            }
            else if (c == '|')
            {
                while (operStack.Count > 0 && (operStack.Peek() == 'M' || operStack.Peek() == 'm'))
                {
                    Calculate();
                }
                operStack.Push(c);
            }
        }

        while (operStack.Count > 0)
        {
            Calculate();
        }

        return numStack.Pop();

        

    }
    static void Main()
    {
        string filePath = "formula.txt";  
        using (StreamReader sr = new StreamReader(filePath))
        {
            string formula = sr.ReadToEnd(); 
            int result = EvaluateFormula(formula); 
            Console.WriteLine($"Значение формулы {formula} = {result}");
        }
        Console.ReadKey();
    }
}
