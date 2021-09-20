﻿namespace Calculator.interfaces
{
    interface ICalculatorPresenter
    {
        /**
        * Вызывается формой в тот момент, когда пользователь нажал на кнопку '+'
        */
        void onPlusClicked();

        /**
         * Вызывается формой в тот момент, когда пользователь нажал на кнопку '-'
         */
        void onMinusClicked();

        /**
         * Вызывается формой в тот момент, когда пользователь нажал на кнопку '/'
         */
        void onDivideClicked();

        /**
         * Вызывается формой в тот момент, когда пользователь нажал на кнопку '*'
         */
        void onMultiplyClicked();

        double getResult();
    }
}
