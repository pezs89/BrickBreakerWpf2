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
        private double verticalMovement;

        // The ball's horizontal movement.
        private double horizontalMovement;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the horizontalMovement.
        /// </summary>
        /// <value>
        /// The horizontalMovement.
        /// </value>
        public double HorizontalMovement
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
        public double VerticalMovement
        {
            get { return verticalMovement; }
            set { verticalMovement = value; }
        }

        #endregion Properties

        #region Constructors

        public Ball(double posX, double posY, double width, double height, double horizontalMovement, double verticalMovement)
            : base(posX, posY, width, height)
        {
            HorizontalMovement = horizontalMovement;
            VerticalMovement = verticalMovement;
        }

        #endregion Constructors

        #region Methods

        public void Mozog(double canvasWidth, double canvasHeight, Racket racket)
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
