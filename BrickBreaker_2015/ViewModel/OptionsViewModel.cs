﻿using BrickBreaker_2015.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrickBreaker_2015.View;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Linq;
using System.Windows.Input;

namespace BrickBreaker_2015.ViewModel
{
    /// <summary>
    /// Interaction logic for OptionsViewModel
    /// </summary>
    class OptionsViewModel : Bindable
    {
        #region Fields

        // The options.
        private Options optionModel;

        // The horizontal scale number.
        private double horizontalScaleNumber;

        // The vertical scale number.
        private double verticalScaleNumber;

        // The options xml access layer.
        private OptionsXmlAccess optionsXmlAccess = new OptionsXmlAccess(@"..\..\Resources\OptionsSettings.xml");

        // The scores xml access layer.
        private ScoresXmlAccess scoreXmlAccess = new ScoresXmlAccess(@"..\..\Resources\Scores.xml");

        // The changed field.
        private bool isChanged = false;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the optionModel.
        /// </summary>
        /// <value>
        /// The optionModel.
        /// </value>
        public Options OptionModel
        {
            get { return optionModel; }
            set { optionModel = value; } 
        }

        /// <summary>
        /// Gets or sets the horizontalScaleNumber.
        /// </summary>
        /// <value>
        /// The horizontalScaleNumber.
        /// </value>
        public double HorizontalScaleNumber
        {
            get { return horizontalScaleNumber; }
            set { horizontalScaleNumber = value; }
        }

        /// <summary>
        /// Gets or sets the verticalScaleNumber.
        /// </summary>
        /// <value>
        /// The verticalScaleNumber.
        /// </value>
        public double VerticalScaleNumber
        {
            get { return verticalScaleNumber; }
            set { verticalScaleNumber = value; }
        }

        /// <summary>
        /// Gets or sets the isChanged.
        /// </summary>
        /// <value>
        /// The isChanged.
        /// </value>
        public bool IsChanged
        {
            get { return isChanged; }
            set { isChanged = value; }
        }

        #endregion Properties

        #region Constructors

        public OptionsViewModel()
        {
            OptionModel = new Options();
            OptionModel = optionsXmlAccess.LoadOptions();

            switch (OptionModel.Resolution)
            {
                case "580x420":
                    HorizontalScaleNumber = 580;
                    VerticalScaleNumber = 420;
                    break;
                case "640x480":
                    HorizontalScaleNumber = 640;
                    VerticalScaleNumber = 480;
                    break;
                case "800x600":
                    HorizontalScaleNumber = 800;
                    VerticalScaleNumber = 600;
                    break;
            }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Saves the changes made to the options.
        /// </summary>
        /// <param name="resolution">The resolution.</param>
        /// <param name="leftMove">The leftMove.</param>
        /// <param name="rightMove">The rightMove.</param>
        /// <param name="pauseButton">The pauseButton.</param>
        /// <param name="fireButton">The fireButton.</param>
        /// <param name="isMouseEnabled">The isMouseEnabled.</param>
        /// <param name="isKeyboardEnabled">The isKeyboardEnabled.</param>
        /// <param name="isSoundEnabled">The isSoundEnabled.</param>
        public void SaveToXml(string resolution, string leftMove, string rightMove, string pauseButton, string fireButton, bool isMouseEnabled, bool isKeyboardEnabled, bool isSoundEnabled)
        {
            // Checks if there were any changes made to the options.
            if (fireButton != OptionModel.FireButton)
            {
                OptionModel.FireButton = fireButton;
                IsChanged = true;
            }

            if (isKeyboardEnabled != OptionModel.IsKeyboardEnabled)
            {
                OptionModel.IsKeyboardEnabled = isKeyboardEnabled;
                IsChanged = true;
            }

            if (isMouseEnabled != OptionModel.IsMouseEnabled)
            {
                OptionModel.IsMouseEnabled = isMouseEnabled;
                IsChanged = true;
            }

            if (isSoundEnabled != OptionModel.IsSoundEnabled)
            {
                OptionModel.IsSoundEnabled = isSoundEnabled;
                IsChanged = true;
            }

            if (leftMove != OptionModel.LeftMove)
            {
                OptionModel.LeftMove = leftMove;
                IsChanged = true;
            }

            if (pauseButton != OptionModel.PauseButton)
            {
                OptionModel.PauseButton = pauseButton;
                IsChanged = true;
            }

            if (resolution != OptionModel.Resolution)
            {
                OptionModel.Resolution = resolution;
                IsChanged = true;
            }

            if (rightMove != OptionModel.RightMove)
            {
                OptionModel.RightMove = rightMove;
                IsChanged = true;
            }

            // If changes were made, then save the changed values in the file.
            if (IsChanged)
            {
                optionsXmlAccess.SaveOptions(OptionModel);
            }
        }

        /// <summary>
        /// Checks if there's any overlap in the control key bindings.
        /// </summary>
        /// <param name="inputKey">The string value of the key to check.</param>
        /// <returns>True if ok, false if not.</returns>
        public bool Check(string inputKey)
        {
            if (!string.IsNullOrEmpty(inputKey))
            {
                if (inputKey == OptionModel.PauseButton || inputKey == OptionModel.RightMove || inputKey == OptionModel.FireButton)
                {
                    return false;
                }
                else if (inputKey == OptionModel.LeftMove || inputKey == OptionModel.PauseButton || inputKey == OptionModel.FireButton)
                {
                    return false;
                }
                else if (inputKey == OptionModel.LeftMove || inputKey == OptionModel.FireButton || inputKey == OptionModel.RightMove)
                {
                    return false;
                }
                else if (inputKey == OptionModel.LeftMove || inputKey == OptionModel.RightMove || inputKey == OptionModel.PauseButton)
                {
                    return false;
                }
            }
            
            return true;
        }

        /// <summary>
        /// Loads the items fro the highscores xml file in a raw xml format.
        /// </summary>
        /// <returns>The object of highscores or null.</returns>
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

        /// <summary>
        /// Sets a string to the control key bindings for the keys.
        /// </summary>
        /// <param name="inputKey">The key to check.</param>
        /// <returns>The string for the key.</returns>
        public string SpecKeys(Key inputKey)
        {
            string retVal = "";

            switch (inputKey)
            {
                case Key.Left:
                    retVal = "Left";
                    break;
                case Key.Right:
                    retVal = "Right";
                    break;
                case Key.Up:
                    retVal = "Up";
                    break;
                case Key.Down:
                    retVal = "Down";
                    break;
                case Key.Enter:
                    // Also known as Key.Return.
                    retVal = "Enter";
                    break;
                case Key.Space:
                    retVal = "Space";
                    break;
                case Key.LeftShift:
                    retVal = "LeftShift";
                    break;
                case Key.RightShift:
                    retVal = "RightShift";
                    break;
                case Key.LeftCtrl:
                    retVal = "LeftCtrl";
                    break;
                case Key.RightCtrl:
                    retVal = "RightCtrl";
                    break;
                case Key.LeftAlt:
                    retVal = "LeftAlt";
                    break;
                case Key.RightAlt:
                    retVal = "RightAlt";
                    break;
                case Key.Tab:
                    retVal = "Tab";
                    break;
                case Key.F1:
                    retVal = "F1";
                    break;
                case Key.F2:
                    retVal = "F2";
                    break;
                case Key.F3:
                    retVal = "F3";
                    break;
                case Key.F4:
                    retVal = "F4";
                    break;
                case Key.F5:
                    retVal = "F5";
                    break;
                case Key.F6:
                    retVal = "F6";
                    break;
                case Key.F7:
                    retVal = "F7";
                    break;
                case Key.F8:
                    retVal = "F8";
                    break;
                case Key.F9:
                    retVal = "F9";
                    break;
                case Key.F10:
                    retVal = "F10";
                    break;
                case Key.F11:
                    retVal = "F11";
                    break;
                case Key.F12:
                    retVal = "F12";
                    break;
                case Key.PageUp:
                    retVal = "PageUp";
                    break;
                case Key.PageDown:
                    retVal = "PageDown";
                    break;
                case Key.Home:
                    retVal = "Home";
                    break;
                case Key.Insert:
                    retVal = "Insert";
                    break;
                case Key.End:
                    retVal = "End";
                    break;
                case Key.Delete:
                    retVal = "Delete";
                    break;
                default:
                    retVal = inputKey.ToString();
                    break;
            } 
            
            return retVal;
        }

        #endregion Methods
    }
}
