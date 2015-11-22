using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker_2015.DataAccess
{
    /// <summary>
    /// Interaction logic for ErrorLogTxtAccess.
    /// </summary>
    class ErrorLogTxtAccess
    {
        #region Fields

        // The path to the error log txt file.
        private string pathString = @"..\..\Resources\ErrorLog.txt";

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
        /// Initializes a new instance of the <see cref="ErrorLogTxtAccess"/> class.
        /// </summary>
        public ErrorLogTxtAccess()
        {
            try
            {
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
                // Create the file.
                File.Create(PathString);

                // Open a connection to the txt file.
                FileStream fs = new FileStream(PathString, FileMode.Open, FileAccess.Write, FileShare.None);

                // Open a writer to read the txt file.
                BinaryWriter wr = new BinaryWriter(fs);

                // Add a new log to the file.
                wr.Write(DateTime.Now.ToString() + ", File not found.");

                // Close the BinaryWriter and the FileStream.
                wr.Close();
                fs.Close();
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
                if (File.Exists(pathString))
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
        /// Writes to the file.
        /// </summary>
        /// <param name="e">The exception.</param>
        public void WriteToFile(Exception e)
        {
            try
            {
                // The exception is not empty and the file exists.
                if (e != null && FileExists(PathString))
                {
                    // Open a connection to the txt file.
                    FileStream fs = new FileStream(PathString, FileMode.Open, FileAccess.Write, FileShare.None);

                    // Open a writer to read the txt file.
                    BinaryWriter wr = new BinaryWriter(fs);

                    // Add a new log to the file.
                    wr.Write(DateTime.Now.ToString() + ", " + e.Message);

                    // Close the BinaryWriter and the FileStream.
                    wr.Close();
                    fs.Close();
                }
            }
            catch
            { }
        }

        #endregion Methods
    }
}
