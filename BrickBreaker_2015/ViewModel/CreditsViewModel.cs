using BrickBreaker_2015.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker_2015.ViewModel
{
    /// <summary>
    /// 
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
        /// 
        /// </summary>
        public CreditsViewModel()
        {
            scoreXmlAccess = new ScoresXmlAccess();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
