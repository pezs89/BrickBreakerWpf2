﻿using BrickBreaker_2015.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        #endregion Fields

        #region Properties

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MapTxtAccess"/> class.
        /// </summary>
        public MapTxtAccess()
        { }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Loads the bricks from the map.
        /// </summary>
        /// <param name="pathString">The path to the txt file.</param>
        /// <param name="brickWidth">The width of the bricks.</param>
        /// <param name="brickHeight">The height of the bricks.</param>
        /// <returns>The brick list or null.</returns>
        public ObservableCollection<Brick> LoadMap(string pathString, double brickWidth, double brickHeight)
        {
            try
            {
                if (FileExists(pathString))
                {
                    double X = 0;
                    double Y = 0;
                    ObservableCollection<Brick> returnValue = new ObservableCollection<Brick>();

                    // Open a connection to the txt file.
                    FileStream fileStream = new FileStream(pathString, FileMode.Open, FileAccess.Read, FileShare.None);

                    // Open a reader to read the txt file.
                    BinaryReader binaryReader = new BinaryReader(fileStream);

                    while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                    {
                        // The string row needs to be checked by characters.
                        char[] oneLine = binaryReader.ReadChars(24);

                        for (int i = 0; i < oneLine.Length; i++)
                        {
                            switch (oneLine[i])
                            {
                                case '.':
                                    break;
                                case '1':
                                    Brick brick1 = new Brick(X, Y, brickWidth, brickHeight, @"..\..\Resources\Media\Brick\easybrick.jpg", Brick.BricksType.Easy);
                                    brick1.ScorePoint = 10;
                                    brick1.BreakNumber = 1;
                                    brick1.IsDeleted = false;
                                    returnValue.Add(brick1);
                                    break;
                                case '2':
                                    Brick brick2 = new Brick(X, Y, brickWidth, brickHeight, @"..\..\Resources\Media\Brick\mediumbrick.jpg", Brick.BricksType.Medium);
                                    brick2.ScorePoint = 20;
                                    brick2.BreakNumber = 2;
                                    brick2.IsDeleted = false;
                                    returnValue.Add(brick2);
                                    break;
                                case '3':
                                    Brick brick3 = new Brick(X, Y, brickWidth, brickHeight, @"..\..\Resources\Media\Brick\hardbrick.jpg", Brick.BricksType.Hard);
                                    brick3.ScorePoint = 30;
                                    brick3.BreakNumber = 5;
                                    brick3.IsDeleted = false;
                                    returnValue.Add(brick3);
                                    break;
                                case '4':
                                    Brick brick4 = new Brick(X, Y, brickWidth, brickHeight, @"..\..\Resources\Media\Brick\steelbrick.jpg", Brick.BricksType.Steel);
                                    brick4.ScorePoint = 40;
                                    brick4.BreakNumber = 1;
                                    brick4.IsDeleted = false;
                                    returnValue.Add(brick4);
                                    break;
                            }

                            // Next column.
                            X += brickWidth;
                        }

                        // Ready the variables for the next row.
                        X = 0;
                        Y += brickHeight;
                    }

                    // Close the BinaryReader and the FileStream.
                    binaryReader.Close();
                    fileStream.Close();

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
        /// Checks if the file exists.
        /// </summary>
        /// <param name="pathString">The path to the txt file.</param>
        /// <returns>True if exists, false if not.</returns>
        public bool FileExists(string pathString)
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

        #endregion Methods
    }
}
