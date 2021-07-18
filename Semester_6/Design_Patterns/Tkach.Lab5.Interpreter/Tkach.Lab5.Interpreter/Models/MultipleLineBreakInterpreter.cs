using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tkach.Lab5.Interpreter.Models
{
    class MultipleLineBreakInterpreter : IAbstractExpressionInterpreter
    {
        public string Interpret(string context)
        {
            context = (new Regex("(\r\n)+")).Replace(context, "\r\n");
            return context;
        }
    }
}
