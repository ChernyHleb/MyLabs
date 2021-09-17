using System.Collections.Generic;

namespace Tkach.Lab1
{
    class TranslatorToRPN
    {
        Dictionary<string, int> operationPriority =
            new Dictionary<string, int>()
            {
                {"(", 1},
                {")", 1},
                {"+", 2},
                {"-", 2},
                {"*", 3},
                {"/", 3},
                {"^", 4}
            };

        public TranslatorToRPN()
        {
            
        }

        public List<string> Translate(List<string> expression)
        {
            Stack<string> stack = new Stack<string>();
            List<string> RPN = new List<string>();

            foreach(string elem in expression)
            {
                // если операнд
                if(operationPriority.ContainsKey(elem) == false)
                {
                    RPN.Add(elem);
                    continue;
                }

                //если операция или скобка

                // 1. если стек пуст, то опеpация из входной стpоки 
                // пеpеписывается в стек
                // 2. откpывающая скобка пpоталкивается в стек
                if (stack.Count == 0 || elem == "(")
                {
                    stack.Push(elem);
                    continue;
                }

                // закpывающая кpуглая скобка выталкивает все опеpации из стека 
                // до ближайшей откpывающей скобки, сами скобки в выходную стpоку 
                // не пеpеписываются, а уничтожают дpуг дpуга
                if (elem == ")")
                {
                    string stackElem = stack.Pop();
                    while (stackElem != "(")
                    {
                        RPN.Add(stackElem);
                        stackElem = stack.Pop();
                    }
                    continue;
                }

                //опеpация выталкивает из стека все опеpации с 
                //большим или pавным пpиоpитетом в выходную стpоку
                while(operationPriority[stack.Peek()] >= operationPriority[elem])
                {
                    RPN.Add(stack.Pop());
                }

                stack.Push(elem);
            }

            while(stack.Count != 0)
            {
                RPN.Add(stack.Pop());
            }

            return RPN;
        }
    }
}
