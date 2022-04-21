﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using Snake.Elements;

namespace Snake.Drawer
{
    class DrawerOfSnake : IDrawer
    {
        private ISnakeBodyParts snakePartsToDraw { get; set; }
        private SnakeBody snakeBodyPosition { get; set; }
        public DrawerOfSnake(ISnakeBodyParts snakePartsToDraw, SnakeBody snakeBodyPosition)
        {
            this.snakePartsToDraw = snakePartsToDraw;
            this.snakeBodyPosition = snakeBodyPosition;
        }

        public void DrawAnObject(DrawingContext drawingContext)
        {

            if (snakeBodyPosition.Lenght > 0)
            {
                drawAPart(drawingContext, snakeBodyPosition.BodyParts.First(), snakePartsToDraw.Head);
            }

            if (snakeBodyPosition.Lenght > 1)
            {
                for (int i = 1; i < snakeBodyPosition.Lenght - 1; i++)
                {
                    drawAPart(drawingContext, snakeBodyPosition.BodyParts[i], snakePartsToDraw.CentralPart);
                }
                drawAPart(drawingContext, snakeBodyPosition.BodyParts.Last(), snakePartsToDraw.Tail);
            }
        }

        private void drawAPart(DrawingContext drawingContext, Point point, DrawingGroup partToDraw)
        {
            TranslateTransform transform = new TranslateTransform(point.X, point.Y);
            drawingContext.PushTransform(transform);
            drawingContext.DrawDrawing(partToDraw);
        }
    }
}
