using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker_2015.DataAccess
{
    /// <summary>
    /// Interaction logic for MapTxtAccess.
    /// </summary>
    class MapTxtAccess
    {
        #region Fields

        // The path to the txt file.
        private string pathString;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the pathString.
        /// </summary>
        /// <value>
        /// The pathString.
        /// </value>
        private string PathString
        {
            get { return pathString; }
            set { pathString = value; }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MapTxtAccess"/> class.
        /// </summary>
        /// <param name="pathstring">The path to the txt file.</param>
        public MapTxtAccess(string pathstring)
        {
            PathString = pathstring;
        }

        #endregion Constructors

        #region Methods

        #endregion Methods
    }
}
