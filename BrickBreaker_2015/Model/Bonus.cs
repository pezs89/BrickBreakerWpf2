using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker_2015.Model
{
    /// <summary>
    /// Base class for Bonus.
    /// </summary>
    class Bonus : MainObject
    {
        #region Fields

        // The score value of the bouns.
        private int scorePoint;

        // The type of the bonus.
        private BonusesType bonusType;

        // The type of the bonuses.
        public enum BonusesType
        {
            LifeUp,
            LifeDown,
            NewBall,
            RacketLengthen,
            RacketShorten,
            BallBigger,
            BallSmaller,
            StickyRacket,
            HardBall,
            SteelBall
        }

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the bonusType.
        /// </summary>
        /// <value>
        /// The bonusType.
        /// </value>
        public BonusesType BonusType
        {
            get { return bonusType; }
            set { bonusType = value; }
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

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Bonus"/> class.
        /// </summary>
        /// <param name="posX">The x position of the bonus.</param>
        /// <param name="posY">The y position of the bonus.</param>
        /// <param name="width">The width of the bonus.</param>
        /// <param name="height">The height of the bonus.</param>
        /// <param name="bonusType">The type of the bonus.</param>
        /// <param name="imagePath">The image of the bonus.</param>
        public Bonus(double posX, double posY, double width, double height, string imagePath, BonusesType bonusType)
            : base(posX, posY, width, height, imagePath)
        {
            try
            {
                BonusType = bonusType;
            }
            catch
            { }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Descends the specified speed.
        /// </summary>
        /// <param name="bonusSpeed">The speed of the bonus.</param>
        /// <param name="canvasWidth">The width of the canvas.</param>
        /// <param name="canvasHeight">The height of the canvas.</param>
        /// <returns>True if the bonus can be removed.</returns>
        public bool Descend(double bonusSpeed, double canvasWidth, double canvasHeight)
        {
            try
            {
                if (Area.Y >= canvasHeight)
                {
                    // If the bouns top reaches the bottom of the canvas, then it can be removed.
                    return true;
                }
                else
                {
                    // If the bouns top didn't reaches the bottom of the canvas, then move it down.
                    area.Y += bonusSpeed;
                    onPropertyChanged("Area");

                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        #endregion Methods
    }
}
