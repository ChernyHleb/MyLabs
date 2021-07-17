using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab5.Interpreter.Models
{
    interface IAbstractExpressionInterpreter
    {
        String Interpret(String context);
    }
}
