using Snake.Drawer.FoodTypes;
using Snake.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Snake.Logic
{    enum EDirection
    {
        up,
        right,
        down,
        left
    }
    class SnakeMove
    {
        private SnakeBody snakeBody { get; set; }
        private int maxWidth { get; set; }
        private int maxHeight { get; set; }
        private int distanceToMove { get; set; }
        public EDirection EDirectionOfSnake { get; private set; }
        private Dictionary<EDirection, EDirection > notPairDirection = new Dictionary<EDirection, EDirection>()
        {
            { EDirection.down, EDirection.up },
            { EDirection.up, EDirection.down },
            { EDirection.left, EDirection.right },
            { EDirection.right, EDirection.left }
        };
        public SnakeMove(SnakeBody snakeBody, EDirection eDirection, int distanceToMove, int maxWidth, int maxHeight)
        {
            this.snakeBody = snakeBody;
            this.distanceToMove = distanceToMove;
            this.maxHeight = maxHeight;
            this.maxWidth = maxWidth;
            this.EDirectionOfSnake = eDirection;
        }

        public void Move(bool eat)
        {
            Point newPoint = snakeBody.BodyParts.First();
            switch (EDirectionOfSnake)
            {
                case EDirection.up:
                    newPoint.Y -= distanceToMove;
                    if (newPoint.Y < 0)
                        newPoint.Y += maxHeight;
                    break;
                case EDirection.right:
                    newPoint.X += distanceToMove;
                    if (newPoint.X > maxWidth)
                        newPoint.X -= maxWidth;
                    break;
                case EDirection.down:
                    newPoint.Y += distanceToMove;
                    if (newPoint.Y > maxHeight)
                        newPoint.Y -= maxHeight;
                    break;
                case EDirection.left:
                    newPoint.X -= distanceToMove;
                    if (newPoint.X < 0)
                        newPoint.X += maxWidth;
                    break;
            }
            snakeBody.MoveASnake(newPoint, eat);
        }
        public void ChangeDirection(EDirection newDirection)
        {
            if (notPairDirection[newDirection] != EDirectionOfSnake)
                EDirectionOfSnake = newDirection;
        }
    }
}
