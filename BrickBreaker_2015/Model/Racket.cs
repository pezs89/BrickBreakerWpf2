using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker_2015.Model
{
    class Racket : MainObject
    {
        #region Fields

        private double move = 10;

        public enum Direction
        {
            Left,
            Right,
            Stay
        }

        #endregion Fields

        #region Properties

        public Direction dir { get; set; }

        #endregion Properties

        #region Constructors

        public Racket(double posX, double posY, double width, double height)
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
