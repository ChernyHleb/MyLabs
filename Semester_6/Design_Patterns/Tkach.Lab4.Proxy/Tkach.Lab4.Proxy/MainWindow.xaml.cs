using System.Windows;
using System.Windows.Input;

namespace Tkach.Lab4.Proxy
{
    public partial class MainWindow : Window
    {
        Box box;

        public MainWindow()
        {
            InitializeComponent();
            box = new Box("csharp_logo.png", canvas1, Mouse.GetPosition(this));
        }

        private void canvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if(box != null)
                box.Draw(e.GetPosition(this));
        }
    }
}
