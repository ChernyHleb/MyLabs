using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab1.ExpressionChecker
{
    class ArythmeticExpressionChecker
    {
        Tokens currentToken;
        double currentNum;
        int errorAmount = 0;

        string input;
        int counter = 0;

        public ArythmeticExpressionChecker(string input) 
        {
            this.input = input;
        }

        double WriteError(string message)
        {
            errorAmount++;
            Console.WriteLine(String.Format("Error: {0}", message));
            return 1;
        }

        public Tokens getToken()
        {
            for (; counter < input.Length; counter++)
            {
                int i = counter;
                if (input[i] == ' ' || input[i] == '\n') { continue; }
                char ch = input[i];

                if(ch == '=')
                    return Tokens.Eq;
                else if (ch == '(')
                    return Tokens.Lp;
                else if (ch == ')')
                    return Tokens.Rp;
                else if (ch == '+')
                    return Tokens.Plus;
                else if (ch == '-')
                    return Tokens.Minus;
                else if (ch == '*')
                    return Tokens.Mul;
                else if (ch == '/')
                    return Tokens.Div;
                else if(ch == '0' ||
                        ch == '1' ||
                        ch == '2' ||
                        ch == '3' ||
                        ch == '4' ||
                        ch == '5' ||
                        ch == '6' ||
                        ch == '7' ||
                        ch == '8' ||
                        ch == '9' ||
                        ch == '.')
                {
                    string number = "";
                    number += input[i];
                    bool hasPoint = false;
                    if(input[i] == '.')
                    {
                        number = "0,";
                        hasPoint = true;
                    }

                    counter++;
                    for(; counter < input.Length; counter++)
                    {
                       if (input[counter] == '0' ||
                          input[counter] == '1' ||
                          input[counter] == '2' ||
                          input[counter] == '3' ||
                          input[counter] == '4' ||
                          input[counter] == '5' ||
                          input[counter] == '6' ||
                          input[counter] == '7' ||
                          input[counter] == '8' ||
                          input[counter] == '9')
                       {
                           number += input[counter];
                           continue;
                       }
                       else if(input[counter] == '.')
                       {
                           if (!hasPoint)
                           {
                               number += ",";
                               continue;
                           }
                           else
                           {
                               counter--;
                               currentNum = Convert.ToDouble(number);
                               return Tokens.Number;
                           }
                       }
                       else
                       {
                           counter--;
                           currentNum = Convert.ToDouble(number);
                           return Tokens.Number;
                       }
                    }
                    currentNum = Convert.ToDouble(number);
                    return Tokens.Number;
                }
                else
                    return Tokens.trash;
            }

            return Tokens.trash;
        }

        public void InputIntoTokens()
        {
            while(counter < input.Length)
            {
                string output = "";
                currentToken = getToken();
                counter++;
                output += currentToken.ToString();
                if (currentToken == Tokens.Number)
                    output += " " + currentNum.ToString();
                Console.WriteLine(output);
            }
        }
    }
}
