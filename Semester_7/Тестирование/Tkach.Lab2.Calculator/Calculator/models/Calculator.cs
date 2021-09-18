namespace Calculator.models
{
    class Calculator : interfaces.ICalculator
    {
        public Calculator()
        {

        }

        public double divide(double a, double b)
        {
            return a / b;

        }

        public double multiply(double a, double b)
        {
            return a * b;
        }

        public double subtract(double a, double b)
        {
            return a - b;
        }

        public double sum(double a, double b)
        {
            return a + b;
        }
    }
}
