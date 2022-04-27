using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Snake.Drawer.FoodTypes
{
    interface IFood : IDrawer
    {
        List<Point> PositionsOfFoods { get; }
        DrawingGroup Food { get; }
        void AddFood(Point newPosition);
        void ClearFoodList();

    }
}
