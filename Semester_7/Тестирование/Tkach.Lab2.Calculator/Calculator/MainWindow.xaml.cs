using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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




        private void ButtonSum_Click(object sender, RoutedEventArgs e)
        {
            if(arg1 == "")
                getFirstArgumentAsString();
            oper = ((Button)sender).Content.ToString();
            ExpressionBox.Text = String.Format("{0} {1} {2}", arg1, oper, arg2);
        }

        private void ButtonSub_Click(object sender, RoutedEventArgs e)
        {
            if (arg1 == "") 
                getFirstArgumentAsString();
            oper = ((Button)sender).Content.ToString();
            ExpressionBox.Text = String.Format("{0} {1} {2}", arg1, oper, arg2);
        }

        private void ButtonEq_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonMul_Click(object sender, RoutedEventArgs e)
        {
            if (arg1 == "") 
                getFirstArgumentAsString();
            oper = ((Button)sender).Content.ToString();
            ExpressionBox.Text = String.Format("{0} {1} {2}", arg1, oper, arg2);
        }

        private void ButtonDiv_Click(object sender, RoutedEventArgs e)
        {
            if (arg1 == "") 
                getFirstArgumentAsString();
            oper = ((Button)sender).Content.ToString();
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
    }
}
