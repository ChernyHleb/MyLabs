using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Tkach.Lab5.Interpreter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            inputTextBox.Text =
                "Cоздать    простейший      интерпретатор\n" +
                "Разработать UML–диаграммы\n" +
                "Дерево интерпретатора - пример паттерна Composite\n" +
                "C помощью паттерна “Interpreter”\n" +
                "Неправильное   использование       табуляторов\n" +
                "Наличие «лишнего» пробела после ( открывающей скобки), (перед закрывающей скобкой ), перед запятой , перед точкой .\n" +
                "Наличие \n\nмножественных символов \n\n\nперевода строки";

            #region Должно быть:
            /*
                1   Cоздать простейший интерпретатор (множественные пробелы)
                2.1 Разработать UML-диаграммы (дефис а не тире)
                2.2 Дерево интерпретатора – пример паттерна Composite (тире а не дефис)
                3   C помощью паттерна «Interpreter» (правильные кавычки)
                4   Неправильное использование табуляторов
                5	 Наличие «лишнего» пробела после (открывающей скобки), (перед закрывающей скобкой), перед запятой, перед точкой.
                6   Наличие \nмножественных символов \nперевода строки
            */
            #endregion


        }
    }
}
