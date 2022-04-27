using Snake.Drawer.FoodTypes;
using Snake.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Snake.Logic
{
    static class Eating
    {
        public static bool SnakeEatFood(SnakeBody snake, IFood food)
        {
            foreach (Point point in food.PositionsOfFoods)
                if (snake.BodyParts.First() == point)
                    return true;
            return false;
        }
    }
}
