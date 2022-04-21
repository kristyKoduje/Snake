using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Snake.Elements
{
    enum EDirection
    { 
        up,
        right,
        down,
        left
    }
    class SnakeBody
    {
        public List<Point> BodyParts { get; private set; }
        public EDirection Direction { get; private set; }
        public int Lenght => BodyParts.Count();

        public SnakeBody(Point inicialPoint, EDirection initialDirection)
        {
            this.BodyParts.Add(inicialPoint);
            this.Direction = initialDirection;            
        }        
        public void ChangeDirection(EDirection newDirection)
        {
            this.Direction = newDirection;
        }
        public void MoveASnake(Point newPosition)
        {
            this.BodyParts.Insert(0, newPosition);
            this.BodyParts.Remove(BodyParts.Last());
        }
    }
}
