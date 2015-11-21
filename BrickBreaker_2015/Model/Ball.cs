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

        // The type of the ball.
        private BallsType ballType;

        // Shows if the ball is in move.
        private bool ballInMove;

        // The types of the balls.
        public enum BallsType
        {
            Normal,
            Hard,
            Steel
        }

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the ballType.
        /// </summary>
        /// <value>
        /// The ballType.
        /// </value>
        public BallsType BallType
        {
            get { return ballType; }
            set { ballType = value; }
        }

        /// <summary>
        /// Gets or sets the ballInMove.
        /// </summary>
        /// <value>
        /// The ballInMove.
        /// </value>
        public bool BallInMove
        {
            get { return ballInMove; }
            set { ballInMove = value; }
        }

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

        /// <summary>
        /// Initializes a new instance of the <see cref="Ball"/> class.
        /// </summary>
        /// <param name="posX">The x position of the ball.</param>
        /// <param name="posY">The y position of the ball.</param>
        /// <param name="width">The width of the ball.</param>
        /// <param name="height">The height of the ball.</param>
        /// <param name="horizontalMovement">The horizontal movement of the ball.</param>
        /// <param name="verticalMovement">The vertical movement of the ball.</param>
        /// <param name="ballType">The type of the ball.</param>
        /// <param name="imagePath">The image of the ball.</param>
        public Ball(double posX, double posY, double width, double height, string imagePath, double horizontalMovement, double verticalMovement, BallsType ballType)
            : base(posX, posY, width, height, imagePath)
        {
            HorizontalMovement = horizontalMovement;
            VerticalMovement = verticalMovement;
            BallType = ballType;
        }

        #endregion Constructors

        #region Methods
        
        /// <summary>
        /// Moves the ball.
        /// </summary>
        /// <param name="ballSpeed">The spedd of the ball.</param>
        public void Move(double ballSpeed)
        {
            area.X += VerticalMovement * ballSpeed;
            area.Y += HorizontalMovement * ballSpeed;

            onPropertyChanged("Area");
        }

        /// <summary>
        /// Move the ball by mouse if it's on the racket.
        /// </summary>
        /// <param name="racketSpeed">The racketSpeed.</param>
        /// <param name="canvasWidth">The canvasWidth.</param>
        /// <param name="mousePositionX">The mousePositionX.</param>
        /// <param name="racket">The racket.</param>
        public void MouseMove(double racketSpeed, double canvasWidth, double mousePositionX, Racket racket)
        {
            // The mouse is left to the racket.
            if (mousePositionX < racket.Area.X + racket.Area.Width / 2)
            {
                // The racket is at the edge of the canvas.
                if (racket.Area.X <= 0)
                {
                    // The ball sticks out to the left side.
                    if (Area.X <= racket.Area.X)
                    {
                        area.X = 0;
                    }
                }
                // There is space to move.
                else
                {
                    // The differance is greater than the length the racket can move in a tick.
                    if (racket.Area.X + racket.Area.Width / 2 - mousePositionX >= racketSpeed)
                    {
                        area.X -= racketSpeed;
                    }
                    // The differance is smaller than the length the racket can move in a tick.
                    else
                    {
                        area.X -= racket.Area.X + racket.Area.Width / 2 - mousePositionX;
                    }
                }
            }
            // The mouse is right to the racket.
            else if (mousePositionX > racket.Area.X + racket.Area.Width / 2)
            {
                // The racket is at the edge of the canvas.
                if (racket.Area.X + racket.Area.Width >= canvasWidth)
                {
                    // The ball sticks out to the right side.
                    if (Area.X >= racket.Area.X + racket.Area.Width - Area.Width)
                    {
                        area.X = canvasWidth - Area.Width;
                    }
                }
                // There is space to move.
                else
                {
                    // The differance is greater than the length the racket can move in a tick.
                    if (mousePositionX - racket.Area.X + racket.Area.Width / 2 >= racketSpeed)
                    {
                        area.X += racketSpeed;
                    }
                    // The differance is smaller than the length the racket can move in a tick.
                    else
                    {
                        area.X += mousePositionX - racket.Area.X + racket.Area.Width / 2;
                    }
                }
            }

            onPropertyChanged("Area");
        }

        /// <summary>
        /// Move the ball by key if it's on the racket.
        /// </summary>
        /// <param name="racketSpeed">The racketSpeed.</param>
        /// <param name="canvasWidth">The canvasWidth.</param>
        /// <param name="racket">The racket.</param>
        public void KeyMove(double racketSpeed, double canvasWidth, Racket racket)
        {
            // The racket is at the edge of the canvas.
            if (racket.Area.X <= 0)
            {
                // The ball sticks out to the left side.
                if (Area.X <= racket.Area.X)
                {
                    area.X = 0;
                }
            }
            // The racket is at the edge of the canvas.
            else if (racket.Area.X + racket.Area.Width >= canvasWidth)
            {
                // The ball sticks out to the right side.
                if (Area.X >= racket.Area.X + racket.Area.Width - Area.Width)
                {
                    area.X = canvasWidth - Area.Width;
                }
            }
            // There is space to move.
            else
            {
                // The left key is pushed.
                if (racket.Direction == Racket.Directions.Left)
                {
                    area.X -= racketSpeed;
                }
                // The right key is pushed.
                else if (racket.Direction == Racket.Directions.Right)
                {
                    area.X += racketSpeed;
                }
            }

            onPropertyChanged("Area");
        }

        #endregion Methods
    }
}
