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

namespace Tkach.Lab4.Proxy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Rectangle rec = new Rectangle();
            rec.Width = 50;
            rec.Height = 50;
            rec.Fill = Brushes.Black;
            Rectangle r = new Rectangle();
            canvas1.Children.Add(rec);
            Canvas.SetLeft(rec, 50);
            Canvas.SetTop(rec, 100);
            
        }
    }
}
