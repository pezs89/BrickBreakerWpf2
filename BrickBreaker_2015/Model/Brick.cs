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

        // The path to tha brick's picture.
        private string brickPicture;

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

        /// <summary>
        /// Gets or sets the brickPicture.
        /// </summary>
        /// <value>
        /// The brickPicture.
        /// </value>
        public string BrickPicture
        {
            get { return brickPicture; }
            set { brickPicture = value; }
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
        /// <param name="brickPicture">The picture of the brick.</param>
        public Brick(double posX, double posY, double width, double height, BricksType brickType, string brickPicture)
            : base(posX, posY, width, height)
        {
            BrickType = brickType;
            BrickPicture = brickPicture;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Decrements the breaknumber of the brick.
        /// </summary>
        public void DecrementBreakNumber()
        {
            if (BreakNumber > 0)
            {
                BreakNumber--;

                switch (BrickType)
                {
                    case BricksType.Medium:
                        if (BrickPicture != @"..\..\Resources\Media\Brick\brokenmediumbrick.jpg")
                        {
                            BrickPicture = @"..\..\Resources\Media\Brick\brokenmediumbrick.jpg";
                        }
                        break;
                    case BricksType.Hard:
                        if (BrickPicture != @"..\..\Resources\Media\Brick\brokenhardbrick.jpg")
                        {
                            BrickPicture = @"..\..\Resources\Media\Brick\brokenhardbrick.jpg";
                        }
                        break;
                }
            }
        }

        #endregion Methods
    }
}
