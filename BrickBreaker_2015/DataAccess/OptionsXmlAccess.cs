using BrickBreaker_2015.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BrickBreaker_2015.DataAccess
{
    /// <summary>
    /// Interaction logic for OptionsXmlAccess.
    /// </summary>
    class OptionsXmlAccess
    {
        #region Fields

        // The path to the xml file.
        private string pathString = @"..\..\Resources\OptionsSettings.xml";

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
        /// Initializes a new instance of the <see cref="OptionsXmlAccess"/> class.
        /// </summary>
        public OptionsXmlAccess()
        {
            try
            {
                // If the file can't be found then make a new.
                if (!FileExists(PathString))
                {
                    CreateNewFile();
                }
            }
            catch
            { }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Creates a new file.
        /// </summary>
        private void CreateNewFile()
        {
            try
            {
                XElement mouseElement = new XElement("mouse", "true");
                XElement keyboardElement = new XElement("keyboard", "true");
                XElement soundElement = new XElement("sound", "true");
                XElement resolutionElement = new XElement("resolution", "800x600");
                XElement leftkeyElement = new XElement("leftkey", "Left");
                XElement rightkeyElement = new XElement("rightkey", "Right");
                XElement firekeyElement = new XElement("firekey", "Space");
                XElement pausekeyElement = new XElement("pausekey", "P");
                XElement difficultyElement = new XElement("difficulty", "1");
                XElement mapElement = new XElement("map", "1");
                XAttribute newAttribute = new XAttribute("id", 1);
                XElement newElements = new XElement("option", newAttribute, mouseElement, keyboardElement, soundElement, resolutionElement, leftkeyElement, rightkeyElement, firekeyElement, pausekeyElement, difficultyElement, mapElement);
                XElement newOptions = new XElement("Options", newElements);
                XDocument newDocument = new XDocument(newOptions);
                newDocument.Save(PathString);
            }
            catch
            { }
        }

        /// <summary>
        /// Checks if the file exists.
        /// </summary>
        /// <param name="pathString">The path to the txt file.</param>
        /// <returns>True if exists, false if not.</returns>
        private bool FileExists(string pathString)
        {
            try
            {
                if (!string.IsNullOrEmpty(pathString) && File.Exists(pathString))
                {
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Loads the items from the options xml file.
        /// </summary>
        /// <returns>The list of highscore items or null.</returns>
        public Options LoadOptions()
        {
            try
            {
                if (FileExists(PathString))
                {
                    // Open the options xml file.
                    XDocument highscoresFromXml = XDocument.Load(PathString);
                    var readDataFromXml = highscoresFromXml.Descendants("option");

                    // Get the items from the options xml file.
                    Options returnValue = new Options();
                    var fromXml = from x in readDataFromXml
                                  select x;

                    // Store the items in an Options object.
                    foreach (var oneElement in fromXml)
                    {
                        returnValue.Resolution = (string)oneElement.Element("resolution");
                        returnValue.LeftMove = (string)oneElement.Element("leftkey");
                        returnValue.PauseButton = (string)oneElement.Element("pausekey");
                        returnValue.FireButton = (string)oneElement.Element("firekey");
                        returnValue.IsMouseEnabled = (bool)oneElement.Element("mouse");
                        returnValue.RightMove = (string)oneElement.Element("rightkey");
                        returnValue.IsKeyboardEnabled = (bool)oneElement.Element("keyboard");
                        returnValue.IsSoundEnabled = (bool)oneElement.Element("sound");
                        returnValue.MapNumber = (int)oneElement.Element("map");
                        returnValue.Difficulty = (int)oneElement.Element("difficulty");
                    }

                    return returnValue;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Updates the items in the options xml file.
        /// </summary>
        /// <param name="options">The options.</param>
        public void SaveOptions(Options options)
        {
            try
            {
                if (options != null && FileExists(PathString))
                {
                    // Open the options xml file.
                    XDocument settingsFromXml = XDocument.Load(PathString);
                    var readDataFromXml = settingsFromXml.Descendants("option");

                    // Get the items from the options xml file.
                    var fromXml = from x in readDataFromXml
                                  select x;

                    // Update the values in the options xml file.
                    foreach (var oneElement in fromXml)
                    {
                        fromXml.Single().Element("leftkey").Value = options.LeftMove;
                        fromXml.Single().Element("rightkey").Value = options.RightMove;
                        fromXml.Single().Element("pausekey").Value = options.PauseButton;
                        fromXml.Single().Element("resolution").Value = options.Resolution;
                        fromXml.Single().Element("firekey").Value = options.FireButton;
                        fromXml.Single().Element("mouse").Value = options.IsMouseEnabled.ToString();
                        fromXml.Single().Element("keyboard").Value = options.IsKeyboardEnabled.ToString();
                        fromXml.Single().Element("sound").Value = options.IsSoundEnabled.ToString();
                        fromXml.Single().Element("map").Value = options.MapNumber.ToString();
                        fromXml.Single().Element("difficulty").Value = options.Difficulty.ToString();
                    }

                    // Update the items in the options xml file.
                    settingsFromXml.Save(PathString);
                }
            }
            catch
            { }
        }

        #endregion Methods
    }
}
