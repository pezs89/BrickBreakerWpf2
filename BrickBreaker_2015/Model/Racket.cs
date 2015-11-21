using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker_2015.Model
{
    /// <summary>
    /// Base class for Racket.
    /// </summary>
    class Racket : MainObject
    {
        #region Fields

        // Bonus: the racket gets sticky, so the ball sticks to it.
        private bool stickyRacket;

        // The picture of the racket.
        private string racketPicture;

        // The direction of the racket.
        private Directions direction;
        
        // The direction of the rackets.
        public enum Directions
        {
            Left,
            Right,
            Stay
        }

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the stickyRacket.
        /// </summary>
        /// <value>
        /// The stickyRacket.
        /// </value>
        public bool StickyRacket
        {
            get { return stickyRacket; }
            set { stickyRacket = value; }
        }

        /// <summary>
        /// Gets or sets the racketPicture.
        /// </summary>
        /// <value>
        /// The racketPicture.
        /// </value>
        public string RacketPicture
        {
            get { return racketPicture; }
            set { racketPicture = value; }
        }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>
        /// The direction.
        /// </value>
        public Directions Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Racket"/> class.
        /// </summary>
        /// <param name="posX">The x position of the racket.</param>
        /// <param name="posY">The y position of the racket.</param>
        /// <param name="width">The width of the racket.</param>
        /// <param name="height">The height of the racket.</param>
        /// <param name="racketPicture">The picture of the racket.</param>
        public Racket(double posX, double posY, double width, double height, string racketPicture)
            : base(posX, posY, width, height)
        {
            RacketPicture = racketPicture;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Move the racket by mouse.
        /// </summary>
        /// <param name="racketSpeed">The racketSpeed.</param>
        /// <param name="canvasWidth">The canvasWidth.</param>
        /// <param name="mousePositionX">The mousePositionX.</param>
        public void MouseMove(double racketSpeed, double canvasWidth, double mousePositionX)
        {
            // The mouse is left to the racket.
            if (mousePositionX < area.X + area.Width / 2)
            {
                // The racket is at the edge of the canvas.
                if (area.X <= 0)
                {
                    area.X = 0;
                }
                // There is space to move.
                else
                {
                    // The differance is greater than the length the racket can move in a tick.
                    if (area.X + area.Width / 2 - mousePositionX >= racketSpeed)
                    {
                        area.X -= racketSpeed;
                    }
                    // The differance is smaller than the length the racket can move in a tick.
                    else
                    {
                        area.X -= area.X + area.Width / 2 - mousePositionX;
                    }
                }
            }
            // The mouse is right to the racket.
            else if (mousePositionX > area.X + area.Width / 2)
            {
                // The racket is at the edge of the canvas.
                if (area.X + area.Width >= canvasWidth)
                {
                    area.X = canvasWidth - area.Width;
                }
                // There is space to move.
                else
                {
                    // The differance is greater than the length the racket can move in a tick.
                    if (mousePositionX - area.X + area.Width / 2 >= racketSpeed)
                    {
                        area.X += racketSpeed;
                    }
                    // The differance is smaller than the length the racket can move in a tick.
                    else
                    {
                        area.X += mousePositionX - area.X + area.Width / 2;
                    }
                }
            }

            onPropertyChanged("Area");
        }

        /// <summary>
        /// Move the racket by key.
        /// </summary>
        /// <param name="racketSpeed">The racketSpeed.</param>
        /// <param name="canvasWidth">The canvasWidth.</param>
        public void KeyMove(double racketSpeed, double canvasWidth)
        {
            // The racket is at the edge of the canvas.
            if (area.X <= 0)
            {
                area.X = 0;
            }
            // The racket is at the edge of the canvas.
            else if (area.X + area.Width >= canvasWidth)
            {
                area.X = canvasWidth - area.Width;
            }
            // There is space to move.
            else
            {
                // The left key is pushed.
                if (Direction == Directions.Left)
                {
                    area.X -= racketSpeed;
                }
                // The right key is pushed.
                else if (Direction == Directions.Right)
                {
                    area.X += racketSpeed;
                }
            }

            onPropertyChanged("Area");
        }

        #endregion Methods
    }
}
