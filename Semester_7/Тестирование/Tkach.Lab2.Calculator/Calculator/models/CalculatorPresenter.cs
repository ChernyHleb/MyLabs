using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.models
{
    class CalculatorPresenter : interfaces.ICalculatorPresenter
    {
        interfaces.ICalculatorView view;
        interfaces.ICalculator model;
        
        public CalculatorPresenter(interfaces.ICalculatorView view)
        {
            this.view = view;
            this.model = new Calculator();
        }

        public void onDivideClicked()
        {
            throw new NotImplementedException();
        }

        public void onMinusClicked()
        {
            throw new NotImplementedException();
        }

        public void onMultiplyClicked()
        {
            throw new NotImplementedException();
        }

        public void onPlusClicked()
        {
            throw new NotImplementedException();
        }
    }
}
