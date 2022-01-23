using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;

namespace UITests
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                Console.WriteLine("~Begin WPF UIAutomation test run\n");

                ///////////////////////////////////////////////////////////////////
                // запуск тестируемого приложения в качестве отдельного процесса //
                ///////////////////////////////////////////////////////////////////
                Console.WriteLine("~Launching CryptoCalc application");
                Process p = null;
                p = Process.Start("..\\..\\..\\Calculator\\bin\\Debug\\Calculator.exe");

                /////////////////////////////////
                // Получение ссылки на десктоп //
                /////////////////////////////////
                Console.WriteLine("\n~Getting Desktop");
                AutomationElement aeDesktop = null;
                aeDesktop = AutomationElement.RootElement;
                if (aeDesktop == null)
                    throw new Exception("Unable to get Desktop");
                else
                    Console.WriteLine("~Found Desktop\n");

                /////////////////////////////////////////////////
                // получение ссылки на главное окно приложения //
                /////////////////////////////////////////////////
                AutomationElement aeCalculator = null;
                int numWaits = 0;
                do
                {
                    Console.WriteLine("~Looking for Calculator main window. . . ");
                    aeCalculator = aeDesktop.FindFirst(TreeScope.Children,
                      new PropertyCondition(AutomationElement.NameProperty, "Calculator"));
                    ++numWaits;
                    Thread.Sleep(200);
                } while (aeCalculator == null && numWaits < 50);

                if (aeCalculator == null)
                    throw new Exception("Unable to get Calculator mainwindow");
                else
                    Console.WriteLine("~Found Calculator mainwindow\n");

                /////////////////////////////////////////////
                // получение ссылок на элементы управления //
                /////////////////////////////////////////////
                Console.WriteLine("\n~Getting all user controls");
                #region получение всех кнопок
                //AutomationElementCollection buttonCollection = 
                //    aeCalculator.FindAll(TreeScope.Children, 
                //    new PropertyCondition(AutomationElement.ControlTypeProperty,
                //    ControlType.Button));

                //Console.WriteLine(buttonCollection.Count);
                #endregion

                Console.ForegroundColor = ConsoleColor.DarkGray;
                AutomationElement aeSumButton = getAeElementChildById(aeCalculator, "sumButton");
                AutomationElement aeSubButton = getAeElementChildById(aeCalculator, "subButton");
                AutomationElement aeEqButton = getAeElementChildById(aeCalculator, "eqButton");
                AutomationElement aeMulButton = getAeElementChildById(aeCalculator, "mulButton");
                AutomationElement aeDivButton = getAeElementChildById(aeCalculator, "divButton");
                AutomationElement aeClButton = getAeElementChildById(aeCalculator, "clButton");
                AutomationElement aeInputBox = getAeElementChildById(aeCalculator, "InputBox");
                AutomationElement aeExpressionBox = getAeElementChildById(aeCalculator, "ExpressionBox");
                Console.ForegroundColor = ConsoleColor.White;

                //  запуск тестов

                TEST_SumButton(aeSumButton, aeEqButton, aeInputBox);
                TEST_SubButton(aeSubButton, aeEqButton, aeInputBox);
                TEST_MulButton(aeMulButton, aeEqButton, aeInputBox);
                TEST_DivButton(aeDivButton, aeEqButton, aeInputBox);
                TEST_ClButton(aeClButton, aeEqButton, aeInputBox);
                //TEST_ErrorOutput(aeDivButton, aeEqButton, aeInputBox);


                Console.WriteLine("\n~End automation\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fatal: " + ex.Message);
            }

            Console.ReadKey();
        }

        static void TEST_SumButton(AutomationElement sumButton, AutomationElement aeEqButton, AutomationElement aeInputBox)
        {
            Console.WriteLine("\nRunning TEST_SumButton");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Setting input to '2'");
            ValuePattern vpInputBox =
              (ValuePattern)aeInputBox.GetCurrentPattern(ValuePattern.Pattern);
            vpInputBox.SetValue("2");

            Console.WriteLine("Sum Button Click");
            InvokePattern ipSumButton =
              (InvokePattern)sumButton.GetCurrentPattern(
                InvokePattern.Pattern);
            ipSumButton.Invoke();
            Thread.Sleep(1000);

            Console.WriteLine("Setting input to '2'");
            vpInputBox.SetValue("2");

            Console.WriteLine("Eq Button Click");
            InvokePattern ipEqButton =
              (InvokePattern)aeEqButton.GetCurrentPattern(
                InvokePattern.Pattern);
            ipEqButton.Invoke();
            Thread.Sleep(1000);

            TextPattern tpTextBox2 =
                (TextPattern)aeInputBox.GetCurrentPattern(TextPattern.Pattern);
            string result = tpTextBox2.DocumentRange.GetText(-1);

            if(result.Equals("4"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("PASSED");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("FAILED");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
        
        static void TEST_SubButton(AutomationElement subButton, AutomationElement aeEqButton, AutomationElement aeInputBox)
        {
            Console.WriteLine("\nRunning TEST_SubButton");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Setting input to '7'");
            ValuePattern vpInputBox =
              (ValuePattern)aeInputBox.GetCurrentPattern(ValuePattern.Pattern);
            vpInputBox.SetValue("7");

            Console.WriteLine("Sub Button Click");
            InvokePattern ipSubButton =
              (InvokePattern)subButton.GetCurrentPattern(
                InvokePattern.Pattern);
            ipSubButton.Invoke();
            Thread.Sleep(1000);

            Console.WriteLine("Setting input to '8'");
            vpInputBox.SetValue("8");

            Console.WriteLine("Eq Button Click");
            InvokePattern ipEqButton =
              (InvokePattern)aeEqButton.GetCurrentPattern(
                InvokePattern.Pattern);
            ipEqButton.Invoke();
            Thread.Sleep(1000);

            TextPattern tpTextBox2 =
                (TextPattern)aeInputBox.GetCurrentPattern(TextPattern.Pattern);
            string result = tpTextBox2.DocumentRange.GetText(-1);

            if (result.Equals("-1"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("PASSED");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("FAILED");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
        
        static void TEST_MulButton(AutomationElement mulButton, AutomationElement aeEqButton, AutomationElement aeInputBox)
        {
            Console.WriteLine("\nRunning TEST_MulButton");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Setting input to '123'");
            ValuePattern vpInputBox =
              (ValuePattern)aeInputBox.GetCurrentPattern(ValuePattern.Pattern);
            vpInputBox.SetValue("123");

            Console.WriteLine("Sub Button Click");
            InvokePattern ipMulButton =
              (InvokePattern)mulButton.GetCurrentPattern(
                InvokePattern.Pattern);
            ipMulButton.Invoke();
            Thread.Sleep(1000);

            Console.WriteLine("Setting input to '0'");
            vpInputBox.SetValue("0");

            Console.WriteLine("Mul Button Click");
            InvokePattern ipEqButton =
              (InvokePattern)aeEqButton.GetCurrentPattern(
                InvokePattern.Pattern);
            ipEqButton.Invoke();
            Thread.Sleep(1000);

            TextPattern tpTextBox2 =
                (TextPattern)aeInputBox.GetCurrentPattern(TextPattern.Pattern);
            string result = tpTextBox2.DocumentRange.GetText(-1);

            if (result.Equals("0"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("PASSED");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("FAILED");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
        
        static void TEST_DivButton(AutomationElement divButton, AutomationElement aeEqButton, AutomationElement aeInputBox)
        {
            Console.WriteLine("\nRunning TEST_DivButton");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Setting input to '69'");
            ValuePattern vpInputBox =
              (ValuePattern)aeInputBox.GetCurrentPattern(ValuePattern.Pattern);
            vpInputBox.SetValue("69");

            Console.WriteLine("Div Button Click");
            InvokePattern ipDivButton =
              (InvokePattern)divButton.GetCurrentPattern(
                InvokePattern.Pattern);
            ipDivButton.Invoke();
            Thread.Sleep(1000);

            Console.WriteLine("Setting input to '7'");
            vpInputBox.SetValue("7");

            Console.WriteLine("Div Button Click");
            InvokePattern ipEqButton =
              (InvokePattern)aeEqButton.GetCurrentPattern(
                InvokePattern.Pattern);
            ipEqButton.Invoke();
            Thread.Sleep(1000);

            TextPattern tpTextBox2 =
                (TextPattern)aeInputBox.GetCurrentPattern(TextPattern.Pattern);
            string result = tpTextBox2.DocumentRange.GetText(-1);

            if (result.Equals("9,85714285714286"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("PASSED");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("FAILED");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
        
        static void TEST_ClButton(AutomationElement clButton, AutomationElement aeEqButton, AutomationElement aeInputBox)
        {
            Console.WriteLine("\nRunning TEST_ClButton");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Setting input to '121313213'");
            ValuePattern vpInputBox =
              (ValuePattern)aeInputBox.GetCurrentPattern(ValuePattern.Pattern);
            vpInputBox.SetValue("121313213");

            Console.WriteLine("Cl Button Click");
            InvokePattern ipClButton =
              (InvokePattern)clButton.GetCurrentPattern(
                InvokePattern.Pattern);
            ipClButton.Invoke();
            Thread.Sleep(1000);

            TextPattern tpTextBox2 =
                (TextPattern)aeInputBox.GetCurrentPattern(TextPattern.Pattern);
            string result = tpTextBox2.DocumentRange.GetText(-1);

            if (result.Equals(""))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("PASSED");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("FAILED");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        static void TEST_ErrorOutput(AutomationElement divButton, AutomationElement aeEqButton, AutomationElement aeInputBox)
        {
            Console.WriteLine("\nRunning TEST_ErrorOutput");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Setting input to '321'");
            ValuePattern vpInputBox =
              (ValuePattern)aeInputBox.GetCurrentPattern(ValuePattern.Pattern);
            vpInputBox.SetValue("321");

            Console.WriteLine("Div Button Click");
            InvokePattern ipDivButton =
              (InvokePattern)divButton.GetCurrentPattern(
                InvokePattern.Pattern);
            ipDivButton.Invoke();
            Thread.Sleep(1000);

            Console.WriteLine("Setting input to '0'");
            vpInputBox.SetValue("0");

            Console.WriteLine("Eq Button Click");
            InvokePattern ipEqButton =
              (InvokePattern)aeEqButton.GetCurrentPattern(
                InvokePattern.Pattern);
            ipEqButton.Invoke();
            Thread.Sleep(1000);

            //TextPattern tpTextBox2 =
            //    (TextPattern)aeInputBox.GetCurrentPattern(TextPattern.Pattern);
            //string result = tpTextBox2.DocumentRange.GetText(-1);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PASSED");

            Console.ForegroundColor = ConsoleColor.White;
        }

        static AutomationElement getAeElementChildById(AutomationElement parent, string id)
        {
            AutomationElement child = null;
            child = parent.FindFirst(
                    TreeScope.Children,
                    new PropertyCondition(
                        AutomationElement.AutomationIdProperty,
                        id)
                    );
            if (child == null)
                throw new Exception("Unable to get " + id);
            else
                Console.WriteLine("Found " + id);

            return child;

        }
    }
}
