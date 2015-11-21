using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                            }
                            break;
                        case BricksType.Hard:
                            if (ImagePath != @"..\..\Resources\Media\Brick\brokenhardbrick.jpg")
                            {
                                ImagePath = @"..\..\Resources\Media\Brick\brokenhardbrick.jpg";
                            }
                            break;
                    }

                    onPropertyChanged("Area");
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
