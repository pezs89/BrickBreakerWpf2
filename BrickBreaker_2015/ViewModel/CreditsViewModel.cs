using BrickBreaker_2015.DataAccess;
using BrickBreaker_2015.Model;
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
    class CreditsViewModel : Bindable
    {
        #region Fields

        // The error log viewmodel.
        private ErrorLogViewModel errorLogViewModel;

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
            try
            {
                errorLogViewModel = new ErrorLogViewModel();
                scoreXmlAccess = new ScoresXmlAccess();
            }
            catch
            { }
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
            catch (Exception e)
            {
                errorLogViewModel.LogError(e);

                return null;
            }
        }

        #endregion Methods
    }
}
