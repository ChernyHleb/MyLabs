using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Tkach.Lab4.Proxy
{
    class Box : IBox
    {
        TestImage image = null;
        public void Draw(Canvas canvas, double x, double y)
        {
            if(image is null)
            {
                canvas.Children.Clear();

                Rectangle rec = new Rectangle();
                rec.Width = 50;
                rec.Height = 50;
                rec.Fill = Brushes.Black;
                canvas.Children.Add(rec);

                Canvas.SetLeft(rec, x);
                Canvas.SetTop(rec, y);
            }
            else
            {
                image.Draw(canvas, x, y);
            }
        }
    }
}
