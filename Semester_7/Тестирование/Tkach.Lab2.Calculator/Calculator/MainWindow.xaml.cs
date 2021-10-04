using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, interfaces.ICalculatorView
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string arg1 = "";
        public string arg2 = "";
        public string oper = "";
        public string lastop = "none";

        private static bool IsTextAllowed(string Text, string AllowedRegex)
        {
            try
            {
                var regex = new Regex(AllowedRegex);
                return !regex.IsMatch(Text);
            }
            catch
            {
                return true;
            }
        }

        public void displayError(string message)
        {
            throw new NotImplementedException();
        }

        public string getFirstArgumentAsString()
        {
            arg2 = "";
            oper = "";
            string text = InputBox.Text;
            arg1 = text;
            ExpressionBox.Text = String.Format("{0} {1} {2}" ,arg1, oper, arg2);
            InputBox.Text = "";
            return text;
        }

        public string getSecondArgumentAsString()
        {
            string text = InputBox.Text;
            InputBox.Text = "";
            arg2 = text;
            ExpressionBox.Text = String.Format("{0} {1} {2}", arg1, oper, arg2);
            return text;
        }

        public void printResult(double result)
        {
            throw new NotImplementedException();
        }

        private void InputBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = (!IsTextAllowed(e.Text, @"[^0-9.]"));
        }

        private string getOper(object sender)
        {
            string oper = ((Button)sender).Content.ToString();
            if(arg2 != "")
            {
                arg1 = InputBox.Text;
                arg2 = "";
            }
            
            return oper;
        }

        private void ButtonSum_Click(object sender, RoutedEventArgs e)
        {
            if(arg1 == "")
                getFirstArgumentAsString();
            oper = getOper(sender);
            ExpressionBox.Text = String.Format("{0} {1} {2}", arg1, oper, arg2);
        }

        private void ButtonSub_Click(object sender, RoutedEventArgs e)
        {
            if (arg1 == "") 
                getFirstArgumentAsString();
            oper = getOper(sender);
            ExpressionBox.Text = String.Format("{0} {1} {2}", arg1, oper, arg2);
        }

        private void ButtonEq_Click(object sender, RoutedEventArgs e)
        {
            if(lastop != oper)
            {
                arg2 = InputBox.Text;
                lastop = oper;
            }
            else
                arg1 = InputBox.Text;


            interfaces.ICalculatorPresenter presenter = new models.CalculatorPresenter(this);
            switch(oper)
            {
                case "+":
                    presenter.onPlusClicked();
                    break;
                case "-":
                    presenter.onMinusClicked();
                    break;
                case "*":
                    presenter.onMultiplyClicked();
                    break;
                case "/":
                    presenter.onDivideClicked();
                    break;
            }

            ExpressionBox.Text = String.Format("{0} {1} {2} =", arg1, oper, arg2);
            InputBox.Text = presenter.getResult().ToString();
        }

        private void ButtonMul_Click(object sender, RoutedEventArgs e)
        {
            if (arg1 == "") 
                getFirstArgumentAsString();
            oper = getOper(sender);
            ExpressionBox.Text = String.Format("{0} {1} {2}", arg1, oper, arg2);
        }

        private void ButtonDiv_Click(object sender, RoutedEventArgs e)
        {
            if (arg1 == "") 
                getFirstArgumentAsString();
            oper = getOper(sender);
            ExpressionBox.Text = String.Format("{0} {1} {2}", arg1, oper, arg2);
        }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void clear()
        {
            arg1 = "";
            arg2 = "";
            oper = "";
            InputBox.Text = "";
            ExpressionBox.Text = "";
        }

        public string getArg1()
        {
            return arg1;
        }

        public string getArg2()
        {
            return arg2;
        }
    }
}
