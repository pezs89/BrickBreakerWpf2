using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker_2015.Model
{
    enum Direction
    {
        Left, Right, Stay
    }

    class Racket : MainObject
    {
        #region Fields

        const int move = 10;

        #endregion Fields

        #region Properties

        #endregion Properties

        #region Constructors

        public Racket(int posX, int posY, int width,int height)
            : base(posX, posY, width, height)
        { }

        #endregion Constructors

        #region Methods

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

        #endregion Methods
    }
}
