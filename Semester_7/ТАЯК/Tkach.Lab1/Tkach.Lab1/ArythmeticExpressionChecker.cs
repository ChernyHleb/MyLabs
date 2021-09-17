using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab1
{
    class ArythmeticExpressionChecker
    {
        List<string> mistakes;
        List<string> expressionList;

        public ArythmeticExpressionChecker()
        {

        }

        public bool IsArythmeticExpression(string expression)
        {
            mistakes = new List<string>();
            ExpressionToList(expression);
            
            /*
            op = {+ - / * ^}
            d - число
            недопустимые ситуации
            1. op в начале/конце выражения
            2. op op
            3. любой символ кроме op и цифр
            4. d d
            5. две скобки рядом
            6. ) в начале и ( в конце
            7. 
            
            
            */

            return true;
        }

        private void ExpressionToList(string expression)
        {
            expressionList = new List<string>(expression.Split(' '));
        }

        public List<string> getMistakes()
        {
            return mistakes;
        }

        public List<string> getExpressionList()
        {
            return expressionList;
        }
    }
}
