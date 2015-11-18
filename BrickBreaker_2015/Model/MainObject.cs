using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BrickBreaker_2015.Model
{
    /// <summary>
    /// Base class for MainObject.
    /// </summary>
    abstract class MainObject : Bindable
    {
        #region Fields

        // The area.
        protected Rect area;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>
        /// The area.
        /// </value>
        public Rect Area
        {
            get { return area; }
            set { area = value; }
        }

        #endregion Properties

        #region Constructors

        public MainObject(double posX, double posY, double width, double height)
        {
            Area = new Rect(posX, posY, width, height);
        }

        #endregion Constructors

        #region Methods

        #endregion Methods
    }
}
