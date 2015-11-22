using BrickBreaker_2015.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker_2015.ViewModel
{
    /// <summary>
    /// Interaction logic for ErrorLogViewModel.
    /// </summary>
    class ErrorLogViewModel
    {
        #region Fields

        // The error log file access layer.
        private ErrorLogTxtAccess errorLogTxtAccess;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the errorLogTxtAccess.
        /// </summary>
        /// <value>
        /// The errorLogTxtAccess.
        /// </value>
        private ErrorLogTxtAccess ErrorLogTxtAccess
        {
            get { return errorLogTxtAccess; }
            set { errorLogTxtAccess = value; }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorLogViewModel"/> class.
        /// </summary>
        public ErrorLogViewModel()
        {
            try
            {
                errorLogTxtAccess = new ErrorLogTxtAccess();
            }
            catch
            { }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Logs the error to the file.
        /// </summary>
        /// <param name="e">The exception.</param>
        public void LogError(Exception e)
        {
            try
            {
                ErrorLogTxtAccess.WriteToFile(e);
            }
            catch
            { }
        }

        #endregion Methods
    }
}
