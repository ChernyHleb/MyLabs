using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using Calculator.models;
using Calculator.interfaces;
using Calculator.models;

namespace UnitTests
{
    [TestClass]
    public class CalculatorTests
    {
        /// <summary>
        /// тестируемый метод - сценарий - ожидаемый результат
        /// </summary>
        [TestMethod]
        public void Presenter_onDivideClicked_CommonDividion_1()
        {
            // Arrange
            MockView mockView = new MockView("100,16", "25,04");
            CalculatorPresenter presenter = new CalculatorPresenter(mockView);
            double expected = 4;
            // Act
            presenter.onDivideClicked();
            double result = presenter.getResult();
            // Assert
            Assert.AreEqual<double>(expected, result);
        }
        
        [TestMethod]
        public void Presenter_onMinusClicked_CommonSubtraction_1()
        {
            // Arrange
            MockView mockView = new MockView("10,2234", "15,2235");
            CalculatorPresenter presenter = new CalculatorPresenter(mockView);
            double expected = -5.0001;
            // Act
            presenter.onMinusClicked();
            double result = presenter.getResult();
            // Assert
            Assert.AreEqual<double>(expected, result);
        }

        [TestMethod]
        public void Presenter_onPlusClicked_CommonAdding_1()
        {
            // Arrange
            MockView mockView = new MockView("145,999", "15123,223232");
            CalculatorPresenter presenter = new CalculatorPresenter(mockView);
            double expected = 15269.222232;
            // Act
            presenter.onPlusClicked();
            double result = presenter.getResult();
            // Assert
            Assert.AreEqual<double>(expected, result);
        }

        [TestMethod]
        public void Presenter_onMultiplyClicked_CommonMultiplication_1()
        {
            // Arrange
            MockView mockView = new MockView("0", "15123,223232");
            CalculatorPresenter presenter = new CalculatorPresenter(mockView);
            double expected = 0;
            // Act
            presenter.onMultiplyClicked();
            double result = presenter.getResult();
            // Assert
            Assert.AreEqual<double>(expected, result);
        }

        [TestMethod]
        public void Model_divide_CommonDividion_1()
        {
            // Arrange
            Calculator.models.Calculator calculator = new Calculator.models.Calculator();
            double expected = 3.25;
            // Act
            double result = calculator.divide(13, 4);
            // Assert
            Assert.AreEqual<double>(expected, result);
        }

        [TestMethod]
        public void Model_multiply_CommonMultiplication_1()
        {
            // Arrange
            Calculator.models.Calculator calculator = new Calculator.models.Calculator();
            double expected = 169;
            // Act
            double result = calculator.multiply(13, 13);
            // Assert
            Assert.AreEqual<double>(expected, result);
        }
        
        [TestMethod]
        public void Model_subtract_CommonSubtracttion_1()
        {
            // Arrange
            Calculator.models.Calculator calculator = new Calculator.models.Calculator();
            double expected = -25;
            // Act
            double result = calculator.subtract(150, 175);
            // Assert
            Assert.AreEqual<double>(expected, result);
        }
         
        [TestMethod]
        public void Model_sum_CommonSum_1()
        {
            // Arrange
            Calculator.models.Calculator calculator = new Calculator.models.Calculator();
            double expected = 228;
            // Act
            double result = calculator.sum(200, 28);
            // Assert
            Assert.AreEqual<double>(expected, result);
        }

    }
}
