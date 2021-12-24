namespace Calculator.models
{
    public class Calculator : interfaces.ICalculator
    {
        public Calculator()
        {

        }
        /**
         * Вычисляет отношение числа а к числу b.
         * Должен выбросить {@link java.lang.ArithmeticException} если |b| < 10e-8
         */
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
