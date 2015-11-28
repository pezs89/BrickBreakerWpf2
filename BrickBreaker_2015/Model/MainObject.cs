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

        // The image path.
        private string imagePath;

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
            set
            {
                area = value; onPropertyChanged("Area");
            }
        }

        /// <summary>
        /// Gets or sets the imagePath.
        /// </summary>
        /// <value>
        /// The imagePath.
        /// </value>
        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }

        #endregion Properties

        #region Constructors

        public MainObject(double posX, double posY, double width, double height, string imagePath)
        {
            try
            {
                Area = new Rect(posX, posY, width, height);
                ImagePath = imagePath;
            }
            catch
            { }
        }

        #endregion Constructors

        #region Methods

        #endregion Methods
    }
}
