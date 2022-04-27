using Snake.Drawer;
using Snake.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DrawerOfAllObjects drawer { get; set; }
        private GameSett gameSett { get; set;  }
        private MyTimers timers { get; set; }
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gameSett = new GameSett((int)this.spImage.ActualWidth, (int)this.spImage.ActualHeight);
            drawer = new DrawerOfAllObjects(gameSett, (int)this.spImage.ActualWidth, (int)this.spImage.ActualHeight);
            timers = new MyTimers(drawer, gameSett, this.Dispatcher);

            arena.Source = drawer.RenderBitmap;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            EDirection newDirection = gameSett.snakeMove.EDirectionOfSnake;
            if (Keyboard.IsKeyDown(Key.Up))
                newDirection = EDirection.up;
            else if (Keyboard.IsKeyDown(Key.Down))
                newDirection = EDirection.down;
            else if (Keyboard.IsKeyDown(Key.Left))
                newDirection = EDirection.left;
            else if (Keyboard.IsKeyDown(Key.Right))
                newDirection = EDirection.right;
            gameSett.snakeMove.ChangeDirection(newDirection);
        }
    }
}
