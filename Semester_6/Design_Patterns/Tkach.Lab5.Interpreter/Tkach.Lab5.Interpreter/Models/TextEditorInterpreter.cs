using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab5.Interpreter.Models
{
    class TextEditorInterpreter : IAbstractExpressionInterpreter
    {
        private List<IAbstractExpressionInterpreter> interpreters;
        public string Interpret(string context)
        {
            throw new NotImplementedException();
        }
    }
}
