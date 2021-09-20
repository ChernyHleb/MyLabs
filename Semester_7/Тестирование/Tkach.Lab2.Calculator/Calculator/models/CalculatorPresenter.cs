using System;

namespace Calculator.models
{
    class CalculatorPresenter : interfaces.ICalculatorPresenter
    {
        interfaces.ICalculatorView view;
        interfaces.ICalculator model;

        private double result;
        
        public CalculatorPresenter(interfaces.ICalculatorView view)
        {
            this.view = view;
            this.model = new Calculator();
            this.result = 0;
        }

        public double getResult()
        {
            return result;
        }

        public void onDivideClicked()
        {
            result = model.divide(Convert.ToDouble(view.getArg1()),
                                  Convert.ToDouble(view.getArg2())
                                  );
        }

        public void onMinusClicked()
        {
            result = model.subtract(Convert.ToDouble(view.getArg1()),
                                    Convert.ToDouble(view.getArg2())
                                    );
        }

        public void onMultiplyClicked()
        {
            result = model.multiply(Convert.ToDouble(view.getArg1()),
                                    Convert.ToDouble(view.getArg2())
                                    );
        }

        public void onPlusClicked()
        {
            result = model.sum(Convert.ToDouble(view.getArg1()),
                               Convert.ToDouble(view.getArg2())
                               );
        }
    }
}
