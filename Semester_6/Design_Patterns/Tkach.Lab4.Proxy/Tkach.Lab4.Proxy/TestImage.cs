using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Tkach.Lab4.Proxy
{
    class TestImage : IBox
    {
        Image image;
        Canvas canvas;

        public TestImage(Canvas canvas, string path, Point position)
        {
            this.canvas = canvas;
            Uri resourceUri = new Uri("csharp_logo.png", UriKind.Relative);
            BitmapImage bmpImage = new BitmapImage(resourceUri);
            image = new Image();
            image.Source = bmpImage;

            image.Width = bmpImage.PixelWidth;
            image.Height = bmpImage.PixelHeight;

            canvas.Children.Clear();
            canvas.Children.Add(image);
            Draw(position);
        }

        public void Draw(Point position)
        {
            Canvas.SetLeft(image, position.X);
            Canvas.SetTop(image, position.Y);
        }
    }
}
