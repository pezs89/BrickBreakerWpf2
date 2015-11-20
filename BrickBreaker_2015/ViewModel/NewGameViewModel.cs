using BrickBreaker_2015.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrickBreaker_2015.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BrickBreaker_2015.ViewModel
{
    /// <summary>
    /// Interaction logic for NewGameViewModel.
    /// </summary>
    class NewGameViewModel
    {
        #region Fields

        // The map txt access layer.
        private MapTxtAccess mapTxtAccess;

        // The options viewmodel.
        private OptionsViewModel optionsViewModel;

        // The path string of the first map.
        private string firstMapPath = @"..\..\Resources\Maps\FirstMap.txt";

        // The path string of the second map.
        private string secondMapPath = @"..\..\Resources\Maps\SecondMap.txt";

        // The path string of the third map.
        private string thirdMapPath = @"..\..\Resources\Maps\ThirdMap.txt";

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the firstMapPath.
        /// </summary>
        /// <value>
        /// The firstMapPath.
        /// </value>
        public string FirstMapPath
        {
            get { return firstMapPath; }
            set { firstMapPath = value; }
        }

        /// <summary>
        /// Gets or sets the secondMapPath.
        /// </summary>
        /// <value>
        /// The secondMapPath.
        /// </value>
        public string SecondMapPath
        {
            get { return secondMapPath; }
            set { secondMapPath = value; }
        }

        /// <summary>
        /// Gets or sets the thirdMapPath.
        /// </summary>
        /// <value>
        /// The thirdMapPath.
        /// </value>
        public string ThirdMapPath
        {
            get { return thirdMapPath; }
            set { thirdMapPath = value; }
        }

        public Racket Racket { get; set; }

        public ObservableCollection<Ball> BallList { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NewGameViewModel"/> class.
        /// </summary>
        public NewGameViewModel()
        {
            mapTxtAccess = new MapTxtAccess();
            optionsViewModel = new OptionsViewModel();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewGameViewModel"/> class.
        /// </summary>
        /// <param name="canvasWidth">The width of the canvas.</param>
        /// <param name="canvasHeight">The height of the canvas.</param>
        public NewGameViewModel(double canvasWidth, double canvasHeight)
        {
            mapTxtAccess = new MapTxtAccess();
            optionsViewModel = new OptionsViewModel();

            Racket = new Racket(canvasWidth / 2 - 40, canvasHeight - 40, 80, 10);

            BallList = new ObservableCollection<Ball>();
            BallList.Add(new Ball(0, 0, 20, 20, 5, 5, Ball.BallsType.Normal, @"..\..\Resources\Media\Ball\normalball.jpg"));
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Finds the map txt file by the given path.
        /// </summary>
        /// <param name="pathString">The map's path.</param>
        /// <returns>True if the map exists, false if it doesn't.</returns>
        public bool FindMap(string pathString)
        {
            try
            {
                return mapTxtAccess.FileExists(pathString);
            }
            catch
            {
                return false;
            }
        }

        public void KeyUp(KeyEventArgs e)
        {

        }

        public void KeyDown(KeyEventArgs e)
        {
            if (SpecKeys(e.Key) == GetOption().LeftMove)
            {
                //racket.direction.left
            }
            else if (SpecKeys(e.Key) == GetOption().RightMove)
            {
                //racket.direction.right
            }
            else
            {
                //racket.direction.stay
            }
        }

        public void MouseMove(MouseEventArgs e)
        {

        }

        public void MouseDown(MouseButtonEventArgs e)
        {

        }

        public Options GetOption()
        {
            try
            {
                return optionsViewModel.OptionModel;
            }
            catch
            {
                return null;
            }
        }

        public void UtoMozgat(Racket.Direction direction)
        {
            Racket.Move(direction);
        }

        public void LabdaMozgat(double canvasSzelesseg, double canvasMagassag) //  összes labda!
        {
            foreach (Ball labda in BallList)
            {
                labda.Mozog(canvasSzelesseg, canvasMagassag, Racket);
            }
        }

        public bool Vege(double canvasMagassag)
        {
            foreach (Ball labda in BallList)
            {
                if (labda.Area.Top > canvasMagassag)
                {
                    return true;
                }
            }

            return false;
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
