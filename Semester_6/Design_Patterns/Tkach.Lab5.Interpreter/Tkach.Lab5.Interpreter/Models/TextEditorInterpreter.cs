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

        public TextEditorInterpreter()
        {
            interpreters = new List<IAbstractExpressionInterpreter>();
            interpreters.Add(new MultipleSpacesInterpreter());
            interpreters.Add(new HyphensDashesInterpreter());
            interpreters.Add(new QuotesInterpreter());
            interpreters.Add(new TabsInterpreter());
            interpreters.Add(new SpacePositionInterpreter());
            interpreters.Add(new MultipleLineBreakInterpreter());
        }

        public string Interpret(string context)
        {
            string newContext = context;
            foreach (IAbstractExpressionInterpreter interpreter in interpreters)
            {
                newContext = interpreter.Interpret(newContext);
            }

            return newContext;
        }
    }
}
