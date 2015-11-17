using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker_2015.Model
{
    /// <summary>
    /// Base class for Ball.
    /// </summary>
    class Ball : MainObject
    {
        #region Fields

        // The ball's vartival movement.
        private int verticalMovement;

        // The ball's horizontal movement.
        private int horizontalMovement;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the horizontalMovement.
        /// </summary>
        /// <value>
        /// The horizontalMovement.
        /// </value>
        public int HorizontalMovement
        {
            get { return horizontalMovement; }
            set { horizontalMovement = value; }
        }

        /// <summary>
        /// Gets or sets the verticalMovement.
        /// </summary>
        /// <value>
        /// The verticalMovement.
        /// </value>
        public int VerticalMovement
        {
            get { return verticalMovement; }
            set { verticalMovement = value; }
        }

        #endregion Properties

        #region Constructors

        public Ball(int posX, int posY, int width, int height, int horizontalMovement, int verticalMovement)
            : base(posX, posY, width, height)
        {
            HorizontalMovement = horizontalMovement;
            VerticalMovement = verticalMovement;
        }

        #endregion Constructors

        #region Methods

        public void Mozog(int canvasWidth, int canvasHeight, Racket racket)
        {
            //Rect -> ütközésvizsgálat!
            area.X += HorizontalMovement;
            area.Y += VerticalMovement;

            if (area.Top < 0 || this.area.IntersectsWith(racket.Area))
            {
                VerticalMovement = -VerticalMovement;
                //terulet.Y = -terulet.Y;
            }

            if (area.Left < 0 || area.Right > canvasWidth)
            {
                HorizontalMovement = -HorizontalMovement;
                //terulet.X = -terulet.X;
            }

            onPropertyChanged("Area");
        }

        #endregion Methods
    }
}
