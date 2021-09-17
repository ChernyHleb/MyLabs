using System;
using System.Collections.Generic;

namespace Tkach.Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            ArythmeticExpressionChecker checker = new ArythmeticExpressionChecker();
            TranslatorToRPN translator = new TranslatorToRPN();
            StackCalculator calculator = new StackCalculator();

            while(true)
            {
                //List<string> expr = new List<string>()
                //{
                //    "2", "3", "+", "3", "3", "+", "*", "29", "-"
                //};
                //Console.WriteLine(calculator.Calculate(expr));

                Console.WriteLine("Insert arythmetic expression...");
                string expression = Console.ReadLine();

                // Проверка
                if(checker.IsArythmeticExpression(expression) == false)
                {
                    Console.WriteLine("this isnt arythmetic expression");
                    foreach(string mistake in checker.getMistakes())
                    {
                        Console.WriteLine(String.Format("~{0}", mistake));
                    }
                    continue;
                }

                Console.WriteLine("RESULT:");
                Console.WriteLine(calculator.Calculate(translator.Translate(checker.getExpressionList())));
                Console.Write("\n");
            }
        }
    }
}
