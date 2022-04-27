using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Snake.Drawer.FoodTypes
{
    class RedFood : IFood
    {
        public DrawingGroup Food { get; private set; }

        public List<Point> PositionsOfFoods { get; set; }


        //private Point position { get; }


        public RedFood(Point position)
        {
            PositionsOfFoods = new List<Point>();
            AddFood(position);
            createAFood();
        
        }

        private void createAFood()
        {
            Food = new DrawingGroup();
            Food.Children.Add(new GeometryDrawing(Brushes.Red, null, new RectangleGeometry(new Rect(new Size(25, 25)))));
        }

        public void DrawAnObject(DrawingContext drawingContext)
        {
            foreach(Point point in PositionsOfFoods)
            DrawerOfAllObjects.drawAPart(drawingContext, point, Food);
        }
        public void AddFood(Point newPosition)
        {
            PositionsOfFoods.Add(newPosition);
        }

        public void ClearFoodList()
        {
            PositionsOfFoods.Clear();
        }
    }
}
