using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Snake.Elements
{

    class SnakeBody
    {
        public List<Point> BodyParts { get; private set; }
        public int Lenght => BodyParts.Count();

        public SnakeBody(Point inicialPoint)
        {
            this.BodyParts = new List<Point>();
            this.BodyParts.Add(inicialPoint);
            
        }
        public void MoveASnake(Point newPosition, bool eat)
        {
            this.BodyParts.Insert(0, newPosition);
            if (!eat)
                this.BodyParts.RemoveAt(Lenght-1);
        }
    }
}
