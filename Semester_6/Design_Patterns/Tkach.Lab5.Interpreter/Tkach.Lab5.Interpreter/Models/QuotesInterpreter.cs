using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tkach.Lab5.Interpreter.Models
{
    class QuotesInterpreter : IAbstractExpressionInterpreter
    {
        public string Interpret(string context)
        {
            context = (new Regex("(“)+")).Replace(context, "«");
            context = (new Regex("(”)+")).Replace(context, "»");

            return context;
        }
    }
}
