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

        // The image of the ball.
        private string ballImage;

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
        /// Gets or sets the ballImage.
        /// </summary>
        /// <value>
        /// The ballImage.
        /// </value>
        public string BallImage
        {
            get { return ballImage; }
            set { ballImage = value; }
        }

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
        /// <param name="ballImage">The image of the ball.</param>
        public Ball(double posX, double posY, double width, double height, double horizontalMovement, double verticalMovement, BallsType ballType, string ballImage)
            : base(posX, posY, width, height)
        {
            HorizontalMovement = horizontalMovement;
            VerticalMovement = verticalMovement;
            BallType = ballType;
            BallImage = ballImage;
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
        }


        public void Collision()
        {

        }

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
