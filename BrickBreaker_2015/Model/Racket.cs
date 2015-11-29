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
    /// Base class for Racket.
    /// </summary>
    class Racket : MainObject
    {
        #region Fields

        // Bonus: the racket gets sticky, so the ball sticks to it.
        private bool stickyRacket;

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
        /// <param name="imagePath">The image of the racket.</param>
        public Racket(double posX, double posY, double width, double height, string imagePath)
            : base(posX, posY, width, height, imagePath)
        { }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Shape of the racket.
        /// </summary>
        /// <returns>The racket's rectangle.</returns>
        public Rectangle GetRectangle()
        {
            // Set the racket's image as the set image.
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(ImagePath, UriKind.Relative));

            // Create the rectangle.
            Rectangle racketRectangle = new Rectangle();
            racketRectangle.Fill = imgBrush;
            racketRectangle.Width = Area.Width;
            racketRectangle.Height = Area.Height;

            // Bind the X position of the racket rectangle to the canvas.
            Binding rectangleXBinding = new Binding("Area.X");
            rectangleXBinding.Source = this;
            racketRectangle.SetBinding(Canvas.LeftProperty, rectangleXBinding);

            // Bind the Y position of the racket rectangle to the canvas.
            Binding rectangleYBinding = new Binding("Area.Y");
            rectangleYBinding.Source = this;
            racketRectangle.SetBinding(Canvas.TopProperty, rectangleYBinding);

            // Bind the width of the racket rectangle to the canvas.
            Binding rectangleWidthBinding = new Binding("Area.Width");
            rectangleWidthBinding.Source = this;
            racketRectangle.SetBinding(Canvas.WidthProperty, rectangleWidthBinding);

            // Bind the height of the racket rectangle to the canvas.
            Binding rectangleHeightBinding = new Binding("Area.Height");
            rectangleHeightBinding.Source = this;
            racketRectangle.SetBinding(Canvas.HeightProperty, rectangleHeightBinding);

            return racketRectangle;
        }

        /// <summary>
        /// Move the racket by mouse.
        /// </summary>
        /// <param name="racketSpeed">The racketSpeed.</param>
        /// <param name="canvasWidth">The canvasWidth.</param>
        /// <param name="mousePositionX">The mousePositionX.</param>
        public void MouseMove(double racketSpeed, double canvasWidth, double mousePositionX)
        {
            try
            {
                // The mouse is left to the racket.
                if (mousePositionX < Area.X + Area.Width / 2)
                {
                    // The racket is at the edge of the canvas.
                    if (Area.X <= 0)
                    {
                        area.X = 0;
                    }
                    // There is space to move.
                    else
                    {
                        // The differance is greater than the length the racket can move in a tick.
                        if (Area.X + Area.Width / 2 - mousePositionX >= racketSpeed)
                        {
                            area.X -= racketSpeed;
                        }
                        // The differance is smaller than the length the racket can move in a tick.
                        else
                        {
                            area.X -= Area.X + Area.Width / 2 - mousePositionX;
                        }
                    }

                    onPropertyChanged("Area");
                }
                // The mouse is right to the racket.
                else if (mousePositionX > Area.X + Area.Width / 2)
                {
                    // The racket is at the edge of the canvas.
                    if (Area.X + Area.Width >= canvasWidth)
                    {
                        area.X = canvasWidth - Area.Width;
                    }
                    // There is space to move.
                    else
                    {
                        // The differance is greater than the length the racket can move in a tick.
                        if (mousePositionX - Area.X + Area.Width / 2 >= racketSpeed)
                        {
                            area.X += racketSpeed;
                        }
                        // The differance is smaller than the length the racket can move in a tick.
                        else
                        {
                            area.X += mousePositionX - Area.X + Area.Width / 2;
                        }
                    }

                    onPropertyChanged("Area");
                }
            }
            catch
            { }
        }

        /// <summary>
        /// Move the racket by key.
        /// </summary>
        /// <param name="racketSpeed">The racketSpeed.</param>
        /// <param name="canvasWidth">The canvasWidth.</param>
        public void KeyMove(double racketSpeed, double canvasWidth)
        {
            try
            {
                // Move the racket left.
                if (Direction == Directions.Left)
                {
                    // The racket is at the edge of the canvas.
                    if (Area.X <= 0)
                    {
                        area.X = 0;
                    }
                    // There is space to move.
                    else
                    {
                        // The racket's speed is greater then the distance left.
                        if (Area.X - 0 < racketSpeed)
                        {
                            area.X -= Area.X - 0;
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
                else if (Direction == Directions.Right)
                {
                    // The racket is at the edge of the canvas.
                    if (Area.X + Area.Width >= canvasWidth)
                    {
                        area.X = canvasWidth - Area.Width;
                    }
                    // There is space to move.
                    else
                    {
                        // The racket's speed is greater then the distance left.
                        if (canvasWidth - Area.X + Area.Width < racketSpeed)
                        {
                            area.X -= canvasWidth - Area.X + Area.Width;
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
        /// Changes the racket to sticky.
        /// </summary>
        public void ChangeToSticky()
        {
            try
            {
                StickyRacket = true;
                ImagePath = @"..\..\Resources\Media\Racket\stickyracket.jpg";

                onPropertyChanged("Area");
            }
            catch
            { }
        }

        /// <summary>
        /// Makes the racket longer if it's in a given size.
        /// </summary>
        /// <param name="racketMaxSize">The max size of the racket.</param>
        /// <param name="racketDifference">The difference that is added to the racket.</param>
        public void Lengthen(double racketMaxSize, double racketDifference)
        {
            try
            {
                area.Width += (Area.Width < racketMaxSize ? racketDifference : 0);

                onPropertyChanged("Area");
            }
            catch
            { }
        }

        /// <summary>
        /// Makes the racket shorter if it's in a given size.
        /// </summary>
        /// <param name="racketMinSize">The min size of the racket.</param>
        /// <param name="racketDifference">The difference that is subtracted from the racket.</param>
        public void Shorthen(double racketMinSize, double racketDifference)
        {
            try
            {
                area.Width -= (Area.Width > racketMinSize ? racketDifference : 0);

                onPropertyChanged("Area");
            }
            catch
            { }
        }

        #endregion Methods
    }
}
