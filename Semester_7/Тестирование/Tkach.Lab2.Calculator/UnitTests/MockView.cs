using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.interfaces;

namespace UnitTests
{
    class MockView : ICalculatorView
    {
        public string arg1;
        public string arg2;

        public MockView(string a1, string a2)
        {
            arg1 = a1;
            arg2 = a2;
        }

        public void displayError(string message)
        {
            throw new NotImplementedException();
        }

        public string getArg1()
        {
            return arg1;
        }

        public string getArg2()
        {
            return arg2;
        }

        public string getFirstArgumentAsString()
        {
            throw new NotImplementedException();
        }

        public string getSecondArgumentAsString()
        {
            throw new NotImplementedException();
        }

        public void printResult(double result)
        {
            throw new NotImplementedException();
        }
    }
}
