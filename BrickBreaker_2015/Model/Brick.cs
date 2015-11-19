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

        //
        private BricksType brickType;

        // 
        private int scorePoint;

        // 
        private int breakNumber;

        // 
        private string brickPicture;

        // 
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
        /// 
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="brickType"></param>
        /// <param name="brickPicture"></param>
        public Brick(double posX, double posY, double width, double height, BricksType brickType, string brickPicture)
            : base(posX, posY, width, height)
        {
            BrickType = brickType;
            BrickPicture = brickPicture;
        }

        #endregion Constructors

        #region Methods

        #endregion Methods
    }
}
