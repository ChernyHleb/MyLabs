using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tkach.Lab5.Interpreter.Models
{
    class SpacePositionInterpreter : IAbstractExpressionInterpreter
    {
        public string Interpret(string context)
        {
            string newContext = context;
            newContext = (new Regex("([(] )+")).Replace(newContext, "(");
            newContext = (new Regex("( [)])+")).Replace(newContext, ")");
            newContext = (new Regex("( [,])+")).Replace(newContext, ",");
            newContext = (new Regex("( [.])+")).Replace(newContext, ".");
            newContext = (new Regex("([“] )+")).Replace(newContext, "“");
            newContext = (new Regex("( [”])+")).Replace(newContext, "”");
            newContext = (new Regex("([«] )+")).Replace(newContext, "«");
            newContext = (new Regex("( [»])+")).Replace(newContext, "»");
            newContext = (new Regex("( [;])+")).Replace(newContext, ";");

            return newContext;
        }
    }
}
