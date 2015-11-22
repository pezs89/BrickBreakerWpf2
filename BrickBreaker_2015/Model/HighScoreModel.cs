using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrickBreaker_2015.Model;
using BrickBreaker_2015.ViewModel;

namespace BrickBreaker_2015.Model
{
    /// <summary>
    /// Base class for HighScoreModel.
    /// </summary>
    class HighScoreModel
    {
        #region Fields

        // The player's name field of the HighScoreModel class.
        private string playerName;

        // The player's score field of the HighScoreModel class.
        private string playerScore;

        #endregion Fields
        
        #region Properties

        /// <summary>
        /// Gets or sets the playerName.
        /// </summary>
        /// <value>
        /// The playerName.
        /// </value>
        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        /// <summary>
        /// Gets or sets the playerScore.
        /// </summary>
        /// <value>
        /// The playerScore.
        /// </value>
        public string PlayerScore
        {
            get { return playerScore; }
            set { playerScore = value; }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HighScoreModel"/> class.
        /// </summary>
        public HighScoreModel()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="HighScoreModel"/> class.
        /// </summary>
        /// <param name="playerName">The player's name field.</param>
        /// <param name="playerScore">The player's score field.</param>
        public HighScoreModel(string playerName, string playerScore)
        {
            try
            {
                PlayerName = playerName;
                PlayerScore = playerScore;
            }
            catch (Exception)
            { }
        }

        #endregion Constructors

        #region Methods

        #endregion Methods
    }
}
