using BrickBreaker_2015.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker_2015.ViewModel
{
    /// <summary>
    /// Interaction logic for CreditsViewModel.
    /// </summary>
    class CreditsViewModel
    {
        #region Fields

        // The score xml access layer.
        private ScoresXmlAccess scoreXmlAccess;

        #endregion Fields

        #region Properties

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditsViewModel"/> class.
        /// </summary>
        public CreditsViewModel()
        {
            scoreXmlAccess = new ScoresXmlAccess();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Loads the highscores items from the xml file in a raw format.
        /// </summary>
        /// <returns>The raw xml items or null.</returns>
        public object LoadRawScores()
        {
            try
            {
                return scoreXmlAccess.LoadRawScores();
            }
            catch
            {
                return null;
            }
        }

        #endregion Methods
    }
}
