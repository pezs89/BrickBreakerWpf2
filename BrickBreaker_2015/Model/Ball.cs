using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            try
            {
                HorizontalMovement = horizontalMovement;
                VerticalMovement = verticalMovement;
                BallType = ballType;
            }
            catch
            { }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Shape of the ball.
        /// </summary>
        /// <returns>The ball's ellipse.</returns>
        public Ellipse GetEllipse()
        {
            // Set the ball's image as the set image.
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(ImagePath, UriKind.Relative));

            // Create the ellipse.
            Ellipse ballEllipse = new Ellipse();
            ballEllipse.Fill = imgBrush;
            ballEllipse.Width = Area.Width;
            ballEllipse.Height = Area.Height;

            // Bind the X position of the ball ellipse to the canvas.
            Binding ellipseXBinding = new Binding("Area.X");
            ellipseXBinding.Source = this;
            ballEllipse.SetBinding(Canvas.LeftProperty, ellipseXBinding);

            // Bind the Y position of the ball ellipse to the canvas.
            Binding ellipseYBinding = new Binding("Area.Y");
            ellipseYBinding.Source = this;
            ballEllipse.SetBinding(Canvas.TopProperty, ellipseYBinding);

            // Bind the width of the ball ellipse to the canvas.
            Binding ellipseWidthBinding = new Binding("Area.Width");
            ellipseWidthBinding.Source = this;
            ballEllipse.SetBinding(Canvas.WidthProperty, ellipseWidthBinding);

            // Bind the height of the ball ellipse to the canvas.
            Binding ellipseHeightBinding = new Binding("Area.Height");
            ellipseHeightBinding.Source = this;
            ballEllipse.SetBinding(Canvas.HeightProperty, ellipseHeightBinding);

            return ballEllipse;
        }
        
        /// <summary>
        /// Moves the ball.
        /// </summary>
        /// <param name="ballSpeed">The spedd of the ball.</param>
        public void Move(double ballSpeed)
        {
            try
            {
                area.X += VerticalMovement * ballSpeed;
                area.Y += HorizontalMovement * ballSpeed;

                onPropertyChanged("Area");
            }
            catch
            { }
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
            try
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
                            area.X += racketSpeed;
                        }
                        // The differance is smaller than the length the racket can move in a tick.
                        else
                        {
                            area.X += racket.Area.X + racket.Area.Width / 2 - mousePositionX;
                        }
                    }

                    onPropertyChanged("Area");
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
                            area.X -= racketSpeed;
                        }
                        // The differance is smaller than the length the racket can move in a tick.
                        else
                        {
                            area.X -= mousePositionX - racket.Area.X + racket.Area.Width / 2;
                        }
                    }

                    onPropertyChanged("Area");
                }
            }
            catch
            { }
        }

        /// <summary>
        /// Move the ball by key if it's on the racket.
        /// </summary>
        /// <param name="racketSpeed">The racketSpeed.</param>
        /// <param name="canvasWidth">The canvasWidth.</param>
        /// <param name="racket">The racket.</param>
        public void KeyMove(double racketSpeed, double canvasWidth, Racket racket)
        {
            try
            {
                // Move the racket left.
                if (racket.Direction == Racket.Directions.Left)
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
                        // The racket's speed is greater then the distance left.
                        if (racket.Area.X - 0 < racketSpeed)
                        {
                            area.X -= racket.Area.X - 0;
                        }
                        // The racket can move by the racket's speed.
                        else
                        {
                            area.X -= racketSpeed;
                        }
                    }

                    onPropertyChanged("Area");
                }
                // Move the racket right.
                else if (racket.Direction == Racket.Directions.Right)
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
                        // The racket's speed is greater then the distance left.
                        if (canvasWidth - racket.Area.X + racket.Area.Width < racketSpeed)
                        {
                            area.X -= canvasWidth - racket.Area.X + racket.Area.Width;
                        }
                        // The racket can move by the racket's speed.
                        else
                        {
                            area.X += racketSpeed;
                        }
                    }

                    onPropertyChanged("Area");
                }
            }
            catch
            { }
        }

        /// <summary>
        /// Changes the ball type to hard.
        /// </summary>
        public void ChangeToHard()
        {
            try
            {
                BallType = Ball.BallsType.Hard;
                ImagePath = @"..\..\Resources\Media\Ball\hardball.jpg";

                onPropertyChanged("Area");
            }
            catch
            { }
        }

        /// <summary>
        /// Changes the ball to steel.
        /// </summary>
        public void ChangeToSteel()
        {
            try
            {
                BallType = Ball.BallsType.Steel;
                ImagePath = @"..\..\Resources\Media\Ball\steelball.jpg";

                onPropertyChanged("Area");
            }
            catch
            { }
        }

        /// <summary>
        /// Changes the ball to small size.
        /// </summary>
        /// <param name="ballMinRadius">The small size of the ball.</param>
        public void ChangeBallToSmall(double ballMinRadius)
        {
            try
            {
                area.Width = ballMinRadius * 2;
                area.Height = ballMinRadius * 2;

                onPropertyChanged("Area");
            }
            catch
            { }
        }

        /// <summary>
        /// Repositions the ball if it's inside the brick.
        /// </summary>
        /// <param name="brick">The brick.</param>
        public void RepositionBallAtBrick(Brick brick)
        {
            try
            {
                if (Area.X < brick.Area.X + brick.Area.Width)
                {
                    area.X = brick.Area.X + brick.Area.Width;

                    onPropertyChanged("Area");
                }

                if (Area.X > brick.Area.X + Area.Width)
                {
                    area.X = brick.Area.X + Area.Width;

                    onPropertyChanged("Area");
                }

                if (Area.Y < brick.Area.Y + brick.Area.Height)
                {
                    area.Y = brick.Area.Y + brick.Area.Height;

                    onPropertyChanged("Area");
                }

                if (Area.Y > brick.Area.Y + Area.Height)
                {
                    area.Y = brick.Area.Y + Area.Height;

                    onPropertyChanged("Area");
                }
            }
            catch
            { }
        }

        /// <summary>
        /// Repositions the ball if it's not right on the racket.
        /// </summary>
        /// <param name="racket">The racket.</param>
        public void RepositionBallAtRacket(Racket racket)
        {
            try
            {
                if (Area.Y > racket.Area.Y - Area.Height)
                {
                    area.Y = racket.Area.Y - Area.Height;

                    onPropertyChanged("Area");
                }
            }
            catch
            { }
        }

        /// <summary>
        /// Repositions the ball if it's out of the canvas walls.
        /// </summary>
        /// <param name="canvasWidth">The width of the canvas.</param>
        public void RepositionBallAtCanvas(double canvasWidth)
        {
            try
            {
                if (Area.X < 0)
                {
                    area.X = 0;

                    onPropertyChanged("Area");
                }

                if (Area.X > canvasWidth - Area.Width)
                {
                    area.X = canvasWidth - Area.Width;

                    onPropertyChanged("Area");
                }

                if (Area.Y < 0)
                {
                    area.Y = 0;

                    onPropertyChanged("Area");
                }
            }
            catch
            { }
        }

        /// <summary>
        /// Changes the ball to large size.
        /// </summary>
        /// <param name="ballMaxRadius">The large size of the ball.</param>
        /// <param name="ballRadius">The normal size of the ball.</param>
        /// <param name="canvasWidth">The width of the canvas.</param>
        /// <param name="canvasHeight">The height of the canvas.</param>
        /// <param name="racketHeight">The height of the racket.</param>
        public void ChangeBallToLarge(double ballMaxRadius, double ballRadius, double canvasWidth, double canvasHeight, double racketHeight)
        {
            try
            {
                // Reposition the ball, so that it will not trigger an error when obtaining bonus effect.
                if (Area.X + (ballMaxRadius * 2) > canvasWidth)
                {
                    area.X -= ((ballMaxRadius - ballRadius) * 2);
                }
                else if (Area.Y + (ballMaxRadius * 2) + racketHeight > canvasHeight)
                {
                    area.Y -= ((ballMaxRadius - ballRadius) * 2);
                }

                area.Width = ballMaxRadius * 2;
                area.Height = ballMaxRadius * 2;

                onPropertyChanged("Area");
            }
            catch
            { }
        }

        #endregion Methods
    }
}
