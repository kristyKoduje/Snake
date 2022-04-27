using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Snake.Drawer
{
    interface ISnakeBodyParts
    {
        DrawingGroup Head { get; }
        DrawingGroup CentralPart { get; }
        DrawingGroup Tail { get; }
    }
}
