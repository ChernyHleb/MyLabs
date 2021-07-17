using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tkach.Lab4.Proxy
{
    class Box : IBox
    {
        private TestImage image = null;
        private Rectangle rec;
        private Canvas canvas;
        private Point currentPosition;

        private string resource;

        public Box(string resource, Canvas canvas, Point position)
        {
            this.currentPosition = position;
            this.resource = resource;
            this.canvas = canvas;

            rec = new Rectangle();
            rec.MouseLeftButtonDown += new MouseButtonEventHandler(Window_MouseDoubleClick);
            BitmapImage bmpImage = new BitmapImage(new Uri(resource, UriKind.Relative));
            rec.Width = bmpImage.PixelWidth; ;
            rec.Height = bmpImage.PixelHeight;
            rec.Fill = Brushes.Black;

            canvas.Children.Clear();
            canvas.Children.Add(rec);
            Draw(currentPosition);
        }

        public void Draw(Point position)
        {
            currentPosition = position;
            if (image is null)
            {
                Canvas.SetLeft(rec, position.X);
                Canvas.SetTop(rec, position.Y);
            }
            else
            {
                image.Draw(position);
            }
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            image = new TestImage(canvas, resource, currentPosition);
        }
    }
}
