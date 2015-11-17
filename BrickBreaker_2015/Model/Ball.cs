﻿using System;
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

        #endregion Properties

        #region Constructors

        public Ball(int posX, int posY, int width, int height, int horizontalMovement, int verticalMovement)
            : base(posX, posY, width, height)
        {
            this.horizontalMovement = horizontalMovement;
            this.verticalMovement = verticalMovement;
        }

        #endregion Constructors

        #region Methods

        public void Mozog(int canvasWidth, int canvasHeight, Racket racket)
        {
            //Rect -> ütközésvizsgálat!
            area.X += horizontalMovement;
            area.Y += verticalMovement;

            if (area.Top < 0 || this.area.IntersectsWith(racket.Area))
            {
                verticalMovement = -verticalMovement;
                //terulet.Y = -terulet.Y;
            }
            if (area.Left < 0 || area.Right > canvasWidth)
            {
                horizontalMovement = -horizontalMovement;
                //terulet.X = -terulet.X;
            }

            onPropertyChanged("Area");
        }

        #endregion Methods
    }
}
