using Snake.Drawer;
using Snake.Drawer.FoodTypes;
using Snake.Drawer.SnakeBodyParts;
using Snake.Elements;
using Snake.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Snake
{
    class GameSett
    {
        public ISnakeBodyParts snakeBodyParts { get; }
        public SnakeBody snakeBody { get; }
        public SnakeMove snakeMove { get; }
        private List<IDrawer> objectsToDraw { get; set; }
        private int maxWidth { get; }
        private int maxHeight { get; }


        public IFood food { get; private set; }
        private int distance = 26;
        private EDirection initialDirection = EDirection.up;
        private Random random = new Random();

        public GameSett(int maxWidth, int maxHeight)
        {
            this.maxHeight = maxHeight;
            this.maxWidth = maxWidth;

            snakeBodyParts = new SnakeBodyPartBlueSquare();
            snakeBody = new SnakeBody(new Point(random.Next(1, maxWidth ) / 26 * 26, random.Next(1, maxHeight ) / 26 * 26));
            snakeMove = new SnakeMove(snakeBody, initialDirection, distance, maxWidth, maxHeight);

            this.objectsToDraw = new List<IDrawer>();
            this.objectsToDraw.Add(newFood());
            this.objectsToDraw.Add(newSnake());
        }

        private DrawerOfSnake newSnake()
        {
            return new DrawerOfSnake(new SnakeBodyPartBlueSquare(), snakeBody);
        }

        private IFood newFood()
        { 
            return food = new RedFood(new Point(random.Next(1, maxWidth)/26 * 26, random.Next(1, maxHeight ) / 26 * 26));
        }
        public void AddNewFood()
        {
            food.ClearFoodList();
            food.AddFood(new Point(random.Next(1, maxWidth ) / 26 * 26, random.Next(1, maxHeight ) / 26 * 26));   
        }
        public List<IDrawer> CopyOfObjectsToDraw()
        {
            return new List<IDrawer>(objectsToDraw);        
        }
    }


   
}
