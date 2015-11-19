using BrickBreaker_2015.Model;
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
        /// 
        /// </summary>
        /// <param name="pathString"></param>
        /// <param name="brickWidth"></param>
        /// <param name="brickHeight"></param>
        /// <returns></returns>
        private List<Brick> LoadMap(string pathString, double brickWidth, double brickHeight)
        {
            try
            {
                if (FileExists(pathString))
                {
                    double X = 0;
                    double Y = 0;
                    FileStream fs = new FileStream(pathString, FileMode.Open, FileAccess.Read, FileShare.None);
                    BinaryReader rd = new BinaryReader(fs);

                    while (rd.BaseStream.Position != rd.BaseStream.Length)
                    {
                        char[] oneLine = rd.ReadChars(24);

                        for (int i = 0; i < oneLine.Length; i++)
                        {
                            switch (oneLine[i])
                            {
                                case '.':
                                    break;
                                case '1':
                                    Brick brick1 = new Brick(X, Y, brickHeight, brickWidth, Brick.BricksType.Easy, @"");
                                    brick1.ScorePoint = 10;
                                    brick1.BreakNumber = 1;
                                    break;
                                case '2':
                                    Brick brick2 = new Brick(X, Y, brickHeight, brickWidth, Brick.BricksType.Medium, @"");
                                    brick2.ScorePoint = 20;
                                    brick2.BreakNumber = 2;
                                    break;
                                case '3':
                                    Brick brick3 = new Brick(X, Y, brickHeight, brickWidth, Brick.BricksType.Hard, @"");
                                    brick3.ScorePoint = 30;
                                    brick3.BreakNumber = 5;
                                    break;
                                case '4':
                                    Brick brick4 = new Brick(X, Y, brickHeight, brickWidth, Brick.BricksType.Steel, @"");
                                    brick4.ScorePoint = 40;
                                    brick4.BreakNumber = 1;
                                    break;
                            }

                            X += brickWidth;
                        }

                        X = 0;
                        Y += brickHeight;
                    }

                    rd.Close();
                    fs.Close();
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pathString"></param>
        /// <returns></returns>
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

        #endregion Methods
    }
}
