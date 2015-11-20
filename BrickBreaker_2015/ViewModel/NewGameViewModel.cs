using BrickBreaker_2015.DataAccess;
using BrickBreaker_2015.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Media;

namespace BrickBreaker_2015.ViewModel
{
    /// <summary>
    /// Interaction logic for NewGameViewModel.
    /// </summary>
    class NewGameViewModel : Bindable
    {
        #region Fields

        #region ViewModels

        // The map txt access layer.
        private MapTxtAccess mapTxtAccess;

        // The options viewmodel.
        private OptionsViewModel optionsViewModel;

        #endregion ViewModels

        #region MapPaths

        // The path string of the first map.
        private string firstMapPath = @"..\..\Resources\Maps\FirstMap.txt";

        // The path string of the second map.
        private string secondMapPath = @"..\..\Resources\Maps\SecondMap.txt";

        // The path string of the third map.
        private string thirdMapPath = @"..\..\Resources\Maps\ThirdMap.txt";

        // The path string of the fourth map.
        private string forthMapPath = @"..\..\Resources\Maps\FourthMap.txt";

        // The path string of the fifth map.
        private string fifthMapPath = @"..\..\Resources\Maps\FifthMap.txt";

        #endregion MapPaths

        #region GameObjects

        // The list of main objects.
        private ObservableCollection<MainObject> gameObjectList;

        // The list of balls.
        private ObservableCollection<Ball> ballList;

        // The list of bricks.
        private ObservableCollection<Brick> brickList;

        // The list of rackets.
        private ObservableCollection<Racket> racketList;

        // The list of bonuses.
        private ObservableCollection<Bonus> bonusList;

        #endregion GameObjects

        #region GameFunctionValues

        #region Ball

        // The speed of the ball.
        private double ballSpeed;

        // The radius of the ball.
        private double ballRadius;

        // The minimum radius of the ball.
        private double ballMinRadius;

        // The maximum radius of the ball.
        private double ballMaxRadius;

        // The horizontal movement of the ball.
        private double ballHorizontalMovement;

        // The vertical movement of the ball.
        private double ballVerticalMovement;

        #endregion Ball

        #region Bonus

        // The speed of the bonus.
        private double bonusSpeed;

        // The width of the bonus.
        private double bonusWidth;

        // The height of the bonus.
        private double bonusHeight;

        #endregion Bonus

        #region Brick

        // The width of the brick.
        private double brickWidth;

        // The height of the brick.
        private double brickHeight;

        #endregion Brick

        #region Racket

        // The width of the racket.
        private double racketWidth;

        // The height of the racket.
        private double racketHeight;

        // The speed of the racket.
        private double racketSpeed;

        // The minimum size of the racket.
        private double racketMinSize;

        // The maximum size of the racket.
        private double racketMaxSize;

        // The size to modify the racket.
        private double racketDifference;

        #endregion Racket

        #endregion GameFunctionValues

        #region GameMechanicsValues

        // The maximum number of maps.
        private int mapMaxNumber;

        // The score point of the player.
        private int playerScorePoint;

        // The players life count.
        private int playerLife;

        // The path of the current map;
        private string currentMapPath;

        // Shows if the game is paused.
        private bool gameIsPaused;

        // Shows if the game is over.
        private bool gameIsOver;

        // Shows if the game is in session.
        private bool gameInSession;

        // Plays sound.
        private MediaPlayer mediaPlayer;

        // The scale number for speed.
        private double speedScale;

        // the examination proximity of the ball.
        private double ballExaminationProximity;

        // The status of the game when over.
        private string gameOverStatus;

        // The number to scale the objects with horizontally.
        private double horizontalScaleNumber;

        // The number to scale the objects with vartically.
        private double verticalScaleNumber;

        // A random.
        private Random rnd;

        // The width of the canvas.
        private double canvasWidth;

        // The height of the canvas.
        private double canvasHeight;

        #endregion GameMechanicsValues

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

        /// <summary>
        /// Gets or sets the forthMapPath.
        /// </summary>
        /// <value>
        /// The forthMapPath.
        /// </value>
        public string ForthMapPath
        {
            get { return forthMapPath; }
            set { forthMapPath = value; }
        }

        /// <summary>
        /// Gets or sets the fifthMapPath.
        /// </summary>
        /// <value>
        /// The fifthMapPath.
        /// </value>
        public string FifthMapPath
        {
            get { return fifthMapPath; }
            set { fifthMapPath = value; }
        }

        /// <summary>
        /// Gets or sets the ballList.
        /// </summary>
        /// <value>
        /// The ballList.
        /// </value>
        public ObservableCollection<Ball> BallList
        {
            get { return ballList; }
            set { ballList = value; }
        }

        /// <summary>
        /// Gets or sets the racketList.
        /// </summary>
        /// <value>
        /// The racketList.
        /// </value>
        public ObservableCollection<Racket> RacketList
        {
            get { return racketList; }
            set { racketList = value; }
        }

        /// <summary>
        /// Gets or sets the brickList.
        /// </summary>
        /// <value>
        /// The brickList.
        /// </value>
        public ObservableCollection<Brick> BrickList
        {
            get { return brickList; }
            set { brickList = value; }
        }

        /// <summary>
        /// Gets or sets the bonusList.
        /// </summary>
        /// <value>
        /// The bonusList.
        /// </value>
        public ObservableCollection<Bonus> BonusList
        {
            get { return bonusList; }
            set { bonusList = value; }
        }

        /// <summary>
        /// Gets or sets the gameObjectList.
        /// </summary>
        /// <value>
        /// The gameObjectList.
        /// </value>
        public ObservableCollection<MainObject> GameObjectList
        {
            get { return gameObjectList; }
            set { gameObjectList = value; }
        }

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

            this.canvasWidth = canvasWidth;
            this.canvasHeight = canvasHeight;
            PresetValues();

            //// Show the scorepoints.
            //ScoreLabel.Content = "Score: " + scoreValue;
            //// Show the lifepoints.
            //LifeLabel.Content = "Life: " + lifePoint;
            //// Show the time.
            //TimeLabel.Content = "Time: " + timeOfGame.ToString("HH:mm:ss");
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        private void PresetValues()
        {
            #region PresetValues

            playerLife = 3;
            playerScorePoint = 0;
            gameInSession = false;
            gameIsPaused = false;
            gameIsOver = false;
            gameOverStatus = "";
            currentMapPath = "";
            bonusSpeed = 1;
            mapMaxNumber = 5;
            ballHorizontalMovement = 5;
            ballVerticalMovement = 5;
            racketSpeed = 10;
            ballSpeed = 1;
            speedScale = 1;
            brickWidth = 27.7;
            brickHeight = 8;
            racketWidth = 80;
            racketHeight = 8;
            bonusWidth = 24;
            bonusHeight = 24;
            ballRadius = 5;
            ballMinRadius = 3;
            ballMaxRadius = 15;
            ballExaminationProximity = 4;
            horizontalScaleNumber = 1;
            verticalScaleNumber = 1;
            racketMaxSize = 160;
            racketMinSize = 40;
            racketDifference = 16;
            mediaPlayer = new MediaPlayer();
            rnd = new Random();

            // Initialize the lists.
            gameObjectList = new ObservableCollection<MainObject>();
            ballList = new ObservableCollection<Ball>();
            brickList = new ObservableCollection<Brick>();
            racketList = new ObservableCollection<Racket>();
            bonusList = new ObservableCollection<Bonus>();

            #endregion PresetValues

            #region SetScaling

            switch (GetOption().Resolution)
            {
                case "580x420":
                    horizontalScaleNumber = 1;
                    verticalScaleNumber = 1;
                    break;
                case "640x480":
                    horizontalScaleNumber = 1.25;
                    verticalScaleNumber = 1.25;
                    break;
                case "800x600":
                    horizontalScaleNumber = 1.6;
                    verticalScaleNumber = 1.6;
                    break;
            }

            switch (GetOption().Difficulty)
            {
                case 1:
                    speedScale = 1;
                    break;
                case 2:
                    speedScale = 1.2;
                    break;
                case 3:
                    speedScale = 1.4;
                    break;
            }

            // Set the scaling.
            bonusWidth *= horizontalScaleNumber;
            bonusHeight *= verticalScaleNumber;
            racketWidth *= horizontalScaleNumber;
            racketHeight *= verticalScaleNumber;
            brickWidth *= horizontalScaleNumber;
            brickHeight *= verticalScaleNumber;
            ballHorizontalMovement *= speedScale;
            ballVerticalMovement *= speedScale;
            ballRadius *= horizontalScaleNumber;
            ballMinRadius *= horizontalScaleNumber;
            ballMaxRadius *= horizontalScaleNumber;
            bonusSpeed *= speedScale;
            ballSpeed *= speedScale;
            racketSpeed *= speedScale;
            ballExaminationProximity *= horizontalScaleNumber;
            racketMaxSize *= horizontalScaleNumber;
            racketMinSize *= horizontalScaleNumber;
            racketDifference *= horizontalScaleNumber;

            #endregion SetScaling

            #region MapSelection

            switch (GetOption().MapNumber)
            {
                case 1:
                    currentMapPath = firstMapPath;
                    break;
                case 2:
                    currentMapPath = secondMapPath;
                    break;
                case 3:
                    currentMapPath = thirdMapPath;
                    break;
                case 4:
                    currentMapPath = forthMapPath;
                    break;
                case 5:
                    currentMapPath = fifthMapPath;
                    break;
            }

            #endregion MapSelection

            #region FillLists

            racketList.Add(new Racket(canvasWidth / 2 - racketWidth / 2, canvasHeight - racketHeight, racketWidth, racketHeight, @""));
            racketList[0].Direction = Racket.Directions.Stay;
            racketList[0].StickyRacket = false;
            gameObjectList.Add(racketList[0]);
            ballList.Add(new Ball(canvasWidth / 2 - ballRadius, canvasHeight - racketHeight - ballRadius * 2, ballRadius, ballRadius, ballHorizontalMovement, ballVerticalMovement, Ball.BallsType.Normal, @""));
            ballList[0].BallInMove = false;
            gameObjectList.Add(ballList[0]);
            brickList = mapTxtAccess.LoadMap(currentMapPath, brickWidth, brickHeight);
            if (brickList.Count > 0)
            {
                for (int i = 0; i < brickList.Count; i++)
                {
                    gameObjectList.Add(brickList[i]);
                }
            }

            #endregion FillLists

            #region SetValues

            mediaPlayer.Open(new Uri(@"..\..\Resources\Media\Sounds\play_this.mp3", UriKind.Relative));

            #endregion SetValues
        }

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

        /// <summary>
        /// Adds a bonus.
        /// </summary>
        /// <param name="oneBrick">The brick.</param>
        private void AddBonus(Brick oneBrick)
        {
            string bonusImage = "";
            Bonus.BonusesType type = Bonus.BonusesType.BallBigger;

            switch (rnd.Next(1, 11))
            {
                case 1:
                    type = Bonus.BonusesType.BallBigger;
                    bonusImage = @"..\..\Resources\Media\Bonus\ballbigger.jpg";
                    break;
                case 2:
                    type = Bonus.BonusesType.BallSmaller;
                    bonusImage = @"..\..\Resources\Media\Bonus\ballsmaller.jpg";
                    break;
                case 3:
                    type = Bonus.BonusesType.HardBall;
                    bonusImage = @"..\..\Resources\Media\Bonus\hardball.jpg";
                    break;
                case 4:
                    type = Bonus.BonusesType.LifeDown;
                    bonusImage = @"..\..\Resources\Media\Bonus\lifedown.jpg";
                    break;
                case 5:
                    type = Bonus.BonusesType.LifeUp;
                    bonusImage = @"..\..\Resources\Media\Bonus\lifeup.jpg";
                    break;
                case 6:
                    type = Bonus.BonusesType.NewBall;
                    bonusImage = @"..\..\Resources\Media\Bonus\newball.jpg";
                    break;
                case 7:
                    type = Bonus.BonusesType.RacketLengthen;
                    bonusImage = @"..\..\Resources\Media\Bonus\racketlengthen.jpg";
                    break;
                case 8:
                    type = Bonus.BonusesType.RacketShorten;
                    bonusImage = @"..\..\Resources\Media\Bonus\racketshorten.jpg";
                    break;
                case 9:
                    type = Bonus.BonusesType.SteelBall;
                    bonusImage = @"..\..\Resources\Media\Bonus\steelball.jpg";
                    break;
                case 10:
                    type = Bonus.BonusesType.StickyRacket;
                    bonusImage = @"..\..\Resources\Media\Bonus\stickyracket.jpg";
                    break;
            }

            Bonus bonus = new Bonus(oneBrick.Area.X + (oneBrick.Area.Width / 2) - (bonusWidth / 2), oneBrick.Area.Y + oneBrick.Area.Height, bonusHeight, bonusWidth, type, bonusImage);
            bonus.ScorePoint = 5;
            bonusList.Add(bonus);

            if (bonus.Descend(bonusSpeed, canvasWidth, canvasHeight))
            {
                bonusList.Remove(bonus);
            }
        }

        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <returns>The options object or null.</returns>
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

        #region KeyboardAndMouse

        #region MouseControls


        public void MouseMove(Canvas sender, MouseEventArgs e)
        {
            if (e.GetPosition(sender).X != racketList[0].Area.X + racketList[0].Area.Width / 2)
            {
                
            }
        }


        public void MouseDown(MouseButtonEventArgs e)
        {

        }

        #endregion MouseControls

        #region KeyboardControls


        public void KeyUp(KeyEventArgs e)
        {
            if ((SpecKeys(e.Key) == GetOption().LeftMove || SpecKeys(e.Key) == GetOption().RightMove) && racketList[0].Direction != Racket.Directions.Stay)
            {
                racketList[0].Direction = Racket.Directions.Stay;
            }
        }


        public void KeyDown(KeyEventArgs e)
        {
            if (SpecKeys(e.Key) == GetOption().LeftMove && racketList[0].Direction != Racket.Directions.Left)
            {
                racketList[0].Direction = Racket.Directions.Left;
            }
            else if (SpecKeys(e.Key) == GetOption().RightMove && racketList[0].Direction != Racket.Directions.Right)
            {
                racketList[0].Direction = Racket.Directions.Right;
            }

            racketList[0].KeyMove(racketSpeed, 0, 0);
        }

        #endregion KeyboardControls

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

        #endregion KeyboardAndMouse

        #endregion Methods
    }
}
