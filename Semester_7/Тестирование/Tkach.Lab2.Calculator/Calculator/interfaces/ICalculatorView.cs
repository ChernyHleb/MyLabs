﻿using System;

namespace Calculator.interfaces
{
    interface ICalculatorView
    {

        /**
         * Отображает результат вычисления
         */
        void printResult(double result);

        /**
         * Показывает ошибку, например деление на 0, пустые аргументы и прочее
         */
        void displayError(String message);

        /**
         * Возвращает значение, введенное в поле первого аргументы
         */
        String getFirstArgumentAsString();

        /**
         * Возвращает значение, введенное в поле второго аргументы
         */
        String getSecondArgumentAsString();
    }
}
