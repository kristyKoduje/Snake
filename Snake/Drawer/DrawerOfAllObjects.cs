using Snake.Drawer.SnakeBodyParts;
using Snake.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Snake.Drawer
{
    class DrawerOfAllObjects
    {
        public RenderTargetBitmap RenderBitmap { get; set; }
        private GameSett gameSett { get; set; }

        public DrawerOfAllObjects(GameSett gameSett, int maxWidth, int maxHeigth)
        {
            this.gameSett = gameSett;
            this.RenderBitmap = new RenderTargetBitmap(maxWidth, maxHeigth, 96, 96, PixelFormats.Pbgra32);
        }

        public void DrawAllObjects()
        {
            RenderBitmap.Clear();
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            foreach (IDrawer objectToDraw in gameSett.CopyOfObjectsToDraw())
            {
                objectToDraw.DrawAnObject(drawingContext);
            }
            drawingContext.Close();
            RenderBitmap.Render(drawingVisual);
        }

        public static void drawAPart(DrawingContext drawingContext, Point point, DrawingGroup partToDraw)
        {
            TranslateTransform transform = new TranslateTransform(point.X, point.Y);
            drawingContext.PushTransform(transform);
            drawingContext.DrawDrawing(partToDraw);
            drawingContext.Pop();
        }
    }
}
