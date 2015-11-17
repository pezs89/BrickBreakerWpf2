using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace BrickBreaker_2015.Model
{
    /// <summary>
    /// Base class for Options.
    /// </summary>
    public class Options
    {
        #region Fields

        // The resolution field of the Options class.
        private string resolution;

        // The left button field of the Options class.
        private string leftMove;

        // The right button field of the Options class.
        private string rightMove;

        // The pause button field of the Options class.
        private string pauseButton;

        // The fire button field of the Options class.
        private string fireButton;

        // The mouse enabled field of the Options class.
        private bool isMouseEnabled;

        // The sound enabled field of the Options class.
        private bool isSoundEnabled;

        // The keyboard enabled field of the Options class.
        private bool isKeyboardEnabled;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the resolution.
        /// </summary>
        /// <value>
        /// The resolution.
        /// </value>
        public string Resolution
        {
            get { return resolution; }
            set { resolution = value; }
        }

        /// <summary>
        /// Gets or sets the leftMove.
        /// </summary>
        /// <value>
        /// The leftMove.
        /// </value>
        public string LeftMove
        {
            get { return leftMove; }
            set { leftMove = value; }
        }

        /// <summary>
        /// Gets or sets the pauseButton.
        /// </summary>
        /// <value>
        /// The pauseButton.
        /// </value>
        public string PauseButton
        {
            get { return pauseButton; }
            set { pauseButton = value; }
        }

        /// <summary>
        /// Gets or sets the fireButton.
        /// </summary>
        /// <value>
        /// The fireButton.
        /// </value>
        public string FireButton
        {
            get { return fireButton; }
            set { fireButton = value; }
        }

        /// <summary>
        /// Gets or sets the isMouseEnabled.
        /// </summary>
        /// <value>
        /// The isMouseEnabled.
        /// </value>
        public bool IsMouseEnabled
        {
            get { return isMouseEnabled; }
            set { isMouseEnabled = value; }
        }

        /// <summary>
        /// Gets or sets the rightMove.
        /// </summary>
        /// <value>
        /// The rightMove.
        /// </value>
        public string RightMove
        {
            get { return rightMove; }
            set { rightMove = value; }
        }

        /// <summary>
        /// Gets or sets the isKeyboardEnabled.
        /// </summary>
        /// <value>
        /// The isKeyboardEnabled.
        /// </value>
        public bool IsKeyboardEnabled
        {
            get { return isKeyboardEnabled; }
            set { isKeyboardEnabled = value; }
        }

        /// <summary>
        /// Gets or sets the isSoundEnabled.
        /// </summary>
        /// <value>
        /// The isSoundEnabled.
        /// </value>
        public bool IsSoundEnabled
        {
            get { return isSoundEnabled; }
            set { isSoundEnabled = value; }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Options"/> class.
        /// </summary>
        public Options()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Options"/> class.
        /// </summary>
        /// <param name="resolution">The resolution field.</param>
        /// <param name="leftMove">The leftMove field.</param>
        /// <param name="rightMove">The rightMove field.</param>
        /// <param name="pauseButton">The pauseButton field.</param>
        /// <param name="fireButton">The fireButton field.</param>
        /// <param name="isMouseEnabled">The isMouseEnabled field.</param>
        /// <param name="isSoundEnabled">The isSoundEnabled field.</param>
        /// <param name="isKeyboardEnabled">The isKeyboardEnabled field.</param>
        public Options(string resolution, string leftMove, string rightMove, string pauseButton, string fireButton, bool isMouseEnabled, bool isSoundEnabled, bool isKeyboardEnabled)
        {
            Resolution = resolution;
            LeftMove = leftMove;
            RightMove = rightMove;
            PauseButton = pauseButton;
            FireButton = fireButton;
            IsMouseEnabled = isMouseEnabled;
            IsSoundEnabled = isSoundEnabled;
            IsKeyboardEnabled = isKeyboardEnabled;
        }

        #endregion Constructors

        #region Methods

        #endregion Methods
    }
}
