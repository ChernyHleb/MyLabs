using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tkach.Lab5.Interpreter.Models
{
    class MultipleSpacesInterpreter : IAbstractExpressionInterpreter
    {
        public string Interpret(string context)
        {
            string newContext = context;
            // несколько пробелов в один
            newContext = (new Regex("[ ]+")).Replace(newContext, " ");
            // пробел в начале текста
            newContext = (new Regex("^[ ]")).Replace(newContext, "");
            // пробел в конце текста
            newContext = (new Regex("^[ ]")).Replace(newContext, "");

            return newContext;
        }
    }
}
