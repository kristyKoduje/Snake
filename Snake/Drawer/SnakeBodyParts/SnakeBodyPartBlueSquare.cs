using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Snake.Drawer.SnakeBodyParts
{
    class SnakeBodyPartBlueSquare : ISnakeBodyParts
    {
        public DrawingGroup Head { get; private set; }

        public DrawingGroup CentralPart { get; private set; }

        public DrawingGroup Tail { get; private set; }

        public SnakeBodyPartBlueSquare()
        {
            createParts();
        }
        private void createParts()
        {
            Head = new DrawingGroup();
            CentralPart = new DrawingGroup();
            Tail = new DrawingGroup();

            GeometryDrawing bodyPart = new GeometryDrawing(Brushes.Blue, null, new RectangleGeometry(new Rect(new Size(25, 25))));
            GeometryDrawing eye = new GeometryDrawing(Brushes.Red, null, new EllipseGeometry(new Point(2.5, 2.5), 2.5, 2.5));
            GeometryDrawing tail = new GeometryDrawing(Brushes.Yellow, null, new EllipseGeometry(new Point(2.5, 2.5), 2.5, 2.5));

            Head.Children.Add(bodyPart);
            //Head.Children.Add(eye);

            CentralPart.Children.Add(bodyPart);

            Tail.Children.Add(bodyPart);
            //Tail.Children.Add(tail);
        }


    }
}
