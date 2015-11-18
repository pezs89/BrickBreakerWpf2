using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BrickBreaker_2015.ViewModel
{
    /// <summary>
    /// Interaction logic for ScoresXmlAccess.
    /// </summary>
    class ScoresXmlAccess
    {
        #region Fields

        // The path to the xml file.
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
        /// Initializes a new instance of the <see cref="ScoresXmlAccess"/> class.
        /// </summary>
        /// <param name="pathstring">The path to the xml file.</param>
        public ScoresXmlAccess(string pathstring)
        {
            PathString = pathstring;

            try
            {
                // If the file can't be found then make a new.
                if (!File.Exists(PathString))
                {
                    XElement nameElement = new XElement("Name", "Test");
                    XElement scoreElement = new XElement("Score", "0");
                    XAttribute placeAttribute = new XAttribute("ID", 1);
                    XElement newElements = new XElement("Data", placeAttribute, nameElement, scoreElement);
                    XElement newPerson = new XElement("Person", newElements);
                    XDocument newDocument = new XDocument(newPerson);
                    newDocument.Save(PathString);
                }
            }
            catch
            { }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Loads the items from the highscores xml file.
        /// </summary>
        /// <returns>The list of highscore items or null.</returns>
        public List<Model.HighScoreModel> LoadScores()
        {
            try
            {
                // Open the highscores xml file.
                XDocument highscoresFromXml = XDocument.Load(PathString);
                var readDataFromXml = highscoresFromXml.Descendants("Data");

                // Get the items from the highscores xml file.
                List<Model.HighScoreModel> returnValue = new List<Model.HighScoreModel>();
                var fromXml = from x in readDataFromXml
                              select x;

                // Store the items in a Highscore list.
                foreach (var oneElement in fromXml)
                {
                    returnValue.Add(new Model.HighScoreModel((string)oneElement.Element("Name"), (string)oneElement.Element("Score")));
                }

                return returnValue;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Loads the items from the highscores xml file in raw xml format.
        /// </summary>
        /// <returns>The object of highscore items or null.</returns>
        public object LoadRawScores()
        {
            try
            {
                // Open the highscores xml file.
                var returnValue = XDocument.Load(PathString).Root;

                return returnValue;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Updates the items in the highscores xml file and creates new ones if necessary.
        /// </summary>
        /// <param name="highscores">The highscores list.</param>
        public void SaveScore(List<Model.HighScoreModel> highscores)
        {
            try
            {
                if (highscores != null && highscores.Count > 0)
                {
                    // Sort to descending order by scores.
                    highscores.Sort((x, y) => int.Parse(y.PlayerScore).CompareTo(int.Parse(x.PlayerScore)));

                    // Open the highscores xml file.
                    XDocument highscoresFromXml = XDocument.Load(PathString);
                    var readDataFromXml = highscoresFromXml.Descendants("Data");

                    // Get the items from the highscores xml file.
                    var fromXml = from x in readDataFromXml
                                  select x;

                    // Update the existing values in the highscores xml file.
                    int i = 0;
                    foreach (var oneItem in fromXml)
                    {
                        oneItem.Element("Name").Value = highscores[i].PlayerName;
                        oneItem.Element("Score").Value = highscores[i].PlayerScore;

                        i++;
                    }

                    // Create new items in the xml file if the input list is greater the number of records in the xml file.
                    if (highscores.Count > i)
                    {
                        for (int j = i; j < highscores.Count; j++)
                        {
                            // Create the new highscore item.
                            XElement nameElement = new XElement("Name", highscores[j].PlayerName);
                            XElement scoreElement = new XElement("Score", highscores[j].PlayerScore);
                            XAttribute placeAttribute = new XAttribute("ID", (j + 1).ToString());
                            XElement newElements = new XElement("Data", placeAttribute, nameElement, scoreElement);

                            // Add new item to the highscores xml file.
                            highscoresFromXml.Element("Person").Add(newElements);
                        }
                    }

                    // Update the values in the highscores xml file.
                    highscoresFromXml.Save(PathString);
                }
            }
            catch
            { }
        }

        #endregion Methods
    }
}
