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

        // The bonus is deleted.
        private bool isDeleted;

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

        /// <summary>
        /// Gets or sets the isDeleted.
        /// </summary>
        /// <value>
        /// The isDeleted.
        /// </value>
        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainObject"/> class.
        /// </summary>
        /// <param name="posX">The x position of the MainObject.</param>
        /// <param name="posY">The y position of the MainObject.</param>
        /// <param name="width">The width of the MainObject.</param>
        /// <param name="height">The height of the MainObject.</param>
        /// <param name="imagePath">The image path of the MainObject.</param>
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
