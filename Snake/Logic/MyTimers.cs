using Snake.Drawer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;

namespace Snake.Logic
{
    class MyTimers
    {
        private Timer drawingTimer { get; set; }
        private Timer movingTimer { get; set; }
        private DrawerOfAllObjects drawer { get; }
        private Dispatcher dispatcher { get;  }
        private GameSett gameSett { get; }
        public MyTimers(DrawerOfAllObjects drawer, GameSett gameSett, Dispatcher dispatcher)
        {
            this.drawer = drawer;
            this.dispatcher = dispatcher;
            this.gameSett = gameSett;
            SetDrawingTimer();
            SetMovingTimer();
        }

        private void SetDrawingTimer()
        {
            drawingTimer = new Timer(1);
            drawingTimer.Elapsed += DrawIt;
            drawingTimer.AutoReset = false;
            drawingTimer.Start();
        }

        private void SetMovingTimer()
        {
            movingTimer = new Timer(300);
            movingTimer.Elapsed += MoveIt;
            movingTimer.AutoReset = false;
            movingTimer.Start();
        }

        private void MoveIt(object sender, ElapsedEventArgs e)
        {
            bool eat = Eating.SnakeEatFood(gameSett.snakeBody, gameSett.food);
            dispatcher.Invoke(() =>
            {
                gameSett.snakeMove.Move(eat);
            });
            if (eat)
                gameSett.AddNewFood();
            movingTimer.Start();
        }

        private void DrawIt(object sender, ElapsedEventArgs e)
        {
            dispatcher.Invoke(() =>
            {
                drawer.DrawAllObjects();
                drawingTimer.Start();
            });
        }
    }
}
