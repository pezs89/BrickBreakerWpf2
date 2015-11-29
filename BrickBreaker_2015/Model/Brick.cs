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
    /// Base class for Brick.
    /// </summary>
    class Brick : MainObject
    {
        #region Fields

        // The type of the brick.
        private BricksType brickType;

        // The score value the brick's worth.
        private int scorePoint;

        // The number to break the brick.
        private int breakNumber;

        // The brick types.
        public enum BricksType
        {
            Easy,
            Medium,
            Hard,
            Steel
        }

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the brickType.
        /// </summary>
        /// <value>
        /// The brickType.
        /// </value>
        public BricksType BrickType
        {
            get { return brickType; }
            set { brickType = value; }
        }

        /// <summary>
        /// Gets or sets the scorePoint.
        /// </summary>
        /// <value>
        /// The scorePoint.
        /// </value>
        public int ScorePoint
        {
            get { return scorePoint; }
            set { scorePoint = value; }
        }

        /// <summary>
        /// Gets or sets the breakNumber.
        /// </summary>
        /// <value>
        /// The breakNumber.
        /// </value>
        public int BreakNumber
        {
            get { return breakNumber; }
            set { breakNumber = value; }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Brick"/> class.
        /// </summary>
        /// <param name="posX">The x position of the brick.</param>
        /// <param name="posY">The y position of the brick.</param>
        /// <param name="width">The width of the brick.</param>
        /// <param name="height">The height of the brick.</param>
        /// <param name="brickType">The type of the brick.</param>
        /// <param name="imagePath">The image of the brick.</param>
        public Brick(double posX, double posY, double width, double height, string imagePath, BricksType brickType)
            : base(posX, posY, width, height, imagePath)
        {
            try
            {
                BrickType = brickType;
            }
            catch
            { }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Shape of the brick.
        /// </summary>
        /// <returns>The brick's rectangle.</returns>
        public Rectangle GetRectangle()
        {
            // Set the brick's image as the set image.
            ImageBrush imgBrush = new ImageBrush();
            imgBrush.ImageSource = new BitmapImage(new Uri(ImagePath, UriKind.Relative));

            // Create the rectangle.
            Rectangle brickRectangle = new Rectangle();
            brickRectangle.Fill = imgBrush;
            brickRectangle.Width = Area.Width;
            brickRectangle.Height = Area.Height;

            // Bind the X position of the brick rectangle to the canvas.
            Binding rectangleXBinding = new Binding("Area.X");
            rectangleXBinding.Source = this;
            brickRectangle.SetBinding(Canvas.LeftProperty, rectangleXBinding);

            // Bind the Y position of the brick rectangle to the canvas.
            Binding rectangleYBinding = new Binding("Area.Y");
            rectangleYBinding.Source = this;
            brickRectangle.SetBinding(Canvas.TopProperty, rectangleYBinding);

            // Bind the width of the brick rectangle to the canvas.
            Binding rectangleWidthBinding = new Binding("Area.Width");
            rectangleWidthBinding.Source = this;
            brickRectangle.SetBinding(Canvas.WidthProperty, rectangleWidthBinding);

            // Bind the height of the brick rectangle to the canvas.
            Binding rectangleHeightBinding = new Binding("Area.Height");
            rectangleHeightBinding.Source = this;
            brickRectangle.SetBinding(Canvas.HeightProperty, rectangleHeightBinding);

            return brickRectangle;
        }

        /// <summary>
        /// Decrements the breaknumber of the brick.
        /// </summary>
        public void DecrementBreakNumber()
        {
            try
            {
                if (BreakNumber > 0)
                {
                    BreakNumber--;

                    switch (BrickType)
                    {
                        case BricksType.Medium:
                            if (ImagePath != @"..\..\Resources\Media\Brick\brokenmediumbrick.jpg")
                            {
                                ImagePath = @"..\..\Resources\Media\Brick\brokenmediumbrick.jpg";

                                onPropertyChanged("Area");
                            }
                            break;
                        case BricksType.Hard:
                            if (ImagePath != @"..\..\Resources\Media\Brick\brokenhardbrick.jpg")
                            {
                                ImagePath = @"..\..\Resources\Media\Brick\brokenhardbrick.jpg";

                                onPropertyChanged("Area");
                            }
                            break;
                    }
                }
            }
            catch
            { }
        }

        /// <summary>
        /// Calculation of bonus chance.
        /// </summary>
        /// <returns>True if brick contains bonus.</returns>
        public bool CalculateBonusChance()
        {
            try
            {
                bool retVal = false;

                if (BrickType == BricksType.Medium || BrickType == BricksType.Hard)
                {
                    // Bonus is only available with medium and hard bricks.
                    Random rnd = new Random();

                    if (rnd.Next(1, 101) <= 25)
                    {
                        // 25% chance of bonus in medium and hard bricks.
                        retVal = true;
                    }
                }

                return retVal;
            }
            catch
            {
                return false;
            }
        }

        #endregion Methods
    }
}
