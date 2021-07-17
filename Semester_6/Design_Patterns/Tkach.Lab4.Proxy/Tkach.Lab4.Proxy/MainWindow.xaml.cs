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
        Box box = new Box();

        public MainWindow()
        {
            InitializeComponent();            
        }

        private void canvas1_MouseMove(object sender, MouseEventArgs e)
        {

            System.Windows.Point position = e.GetPosition(this);
            double pX = position.X;
            double pY = position.Y;

            box.Draw(canvas1, pX, pY);

        }
    }
}
