using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab1
{
    class StackCalculator
    {
        Stack<int> stack;

        public StackCalculator()
        {

        }

        public int Calculate(List<string> expressionList)
        {
            stack = new Stack<int>();
            int a, b;
            foreach(string elem in expressionList)
            {
                
                switch(elem)
                {
                    case "+":
                        stack.Push(stack.Pop() + stack.Pop());
                        break;
                    case "-":
                        b = stack.Pop();
                        a = stack.Pop();
                        stack.Push(a - b);
                        break;
                    case "*":
                        stack.Push(stack.Pop() * stack.Pop());
                        break;
                    case "/":
                        b = stack.Pop();
                        a = stack.Pop();
                        stack.Push(a / b);
                        break;
                    case "^":
                        b = stack.Pop();
                        a = stack.Pop();
                        stack.Push((int)Math.Pow(a, b));
                        break;
                    default:
                        stack.Push(Int32.Parse(elem));
                        break;
                }
            }

            return stack.Pop();
        }
    }
}
