using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker_2015.Model
{
    enum Direction
    {
        Left, Right
    }
    class Racket : MainObject
    {

        const int move = 10;
        public Racket(int posX, int posY, int width,int height)
            : base(posX, posY, width, height)
        { }

        public void Move(Direction direction)
        {
            if (direction == Direction.Left)
            {
                area.X -= move;
            }
            else if (direction == Direction.Right)
            {
                area.X += move;
            }
            onPropertyChanged("Area");
        }
    }
}
