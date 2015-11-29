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
using System.Windows;

namespace BrickBreaker_2015.ViewModel
{
    /// <summary>
    /// Interaction logic for NewGameViewModel.
    /// </summary>
    class NewGameViewModel : Bindable
    {
        #region Fields

        #region ViewModels

        // The error log viewmodel.
        private ErrorLogViewModel errorLogViewModel;

        // The map txt access layer.
        private MapTxtAccess mapTxtAccess;

        // The score xml access layer.
        private ScoresXmlAccess scoreXmlAccess;

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

        // The canvas.
        private Canvas canvas;

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

        // The action the view needs to take.
        private ViewActionStatus viewAction;

        // The actions the view can take.
        public enum ViewActionStatus
        {
            DoNothing,
            OpenHighscores,
            OpenMenu,
            NewMap
        }

        #endregion GameMechanicsValues

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the gameIsOver.
        /// </summary>
        /// <value>
        /// The gameIsOver.
        /// </value>
        public bool GameIsOver
        {
            get { return gameIsOver; }
            set { gameIsOver = value; }
        }

        /// <summary>
        /// Gets or sets the gameInSession.
        /// </summary>
        /// <value>
        /// The gameInSession.
        /// </value>
        public bool GameInSession
        {
            get { return gameInSession; }
            set { gameInSession = value; }
        }

        /// <summary>
        /// Gets or sets the gameIsPaused.
        /// </summary>
        /// <value>
        /// The gameIsPaused.
        /// </value>
        public bool GameIsPaused
        {
            get { return gameIsPaused; }
            set { gameIsPaused = value; }
        }

        /// <summary>
        /// Gets or sets the viewAction.
        /// </summary>
        /// <value>
        /// The viewAction.
        /// </value>
        public ViewActionStatus ViewAction
        {
            get { return viewAction; }
            set { viewAction = value; }
        }

        /// <summary>
        /// Gets or sets the playerLife.
        /// </summary>
        /// <value>
        /// The playerLife.
        /// </value>
        public int PlayerLife
        {
            get { return playerLife; }
            set { playerLife = value; }
        }

        /// <summary>
        /// Gets or sets the playerScorePoint.
        /// </summary>
        /// <value>
        /// The playerScorePoint.
        /// </value>
        public int PlayerScorePoint
        {
            get { return playerScorePoint; }
            set { playerScorePoint = value; }
        }

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

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NewGameViewModel"/> class.
        /// </summary>
        public NewGameViewModel()
        {
            try
            {
                errorLogViewModel = new ErrorLogViewModel();
                mapTxtAccess = new MapTxtAccess();
                scoreXmlAccess = new ScoresXmlAccess();
                optionsViewModel = new OptionsViewModel();
            }
            catch
            { }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewGameViewModel"/> class.
        /// </summary>
        /// <param name="canvas">The canvas.</param>
        public NewGameViewModel(ref Canvas canvas)
        {
            mapTxtAccess = new MapTxtAccess();
            optionsViewModel = new OptionsViewModel();

            this.canvas = canvas;
            PresetValues1();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Cleans the lists from the deleted game objects.
        /// </summary>
        public void CleanListsFromDeleted()
        {
            try
            {
                #region Bonus

                // There is at least one bonus.
                if (bonusList.Count > 0)
                {
                    // Check each bonus.
                    for (int i = 0; i < bonusList.Count; i++)
                    {
                        // The bonus is deleted.
                        if (bonusList[i].IsDeleted)
                        {
                            // Remove the item and decrement the iterator.
                            bonusList.Remove(bonusList[i]);
                            i--;
                        }
                    }
                }

                #endregion Bonus

                #region Brick

                // There is at least one brick.
                if (brickList.Count > 0)
                {
                    // Check each brick.
                    for (int i = 0; i < brickList.Count; i++)
                    {
                        // The brick is deleted.
                        if (brickList[i].IsDeleted)
                        {
                            // Remove the item and decrement the iterator.
                            brickList.Remove(brickList[i]);
                            i--;
                        }
                    }
                }

                #endregion Brick

                #region Ball

                // There is at least one ball.
                if (ballList.Count > 0)
                {
                    // Check each ball.
                    for (int i = 0; i < ballList.Count; i++)
                    {
                        // The ball is deleted.
                        if (ballList[i].IsDeleted)
                        {
                            // Remove the item and decrement the iterator.
                            ballList.Remove(ballList[i]);
                            i--;
                        }
                    }
                }

                #endregion Ball

                #region Racket

                // There is at least one racket.
                if (racketList.Count > 0)
                {
                    // Check each racket.
                    for (int i = 0; i < racketList.Count; i++)
                    {
                        // The racket is deleted.
                        if (racketList[i].IsDeleted)
                        {
                            // Remove the item and decrement the iterator.
                            racketList.Remove(racketList[i]);
                            i--;
                        }
                    }
                }

                #endregion Racket
            }
            catch (Exception e)
            {
                errorLogViewModel.LogError(e);
            }
        }

        /// <summary>
        /// Sets the needed fields for a new map and gameplay.
        /// </summary>
        public void NewMap()
        {
            // Clear the previous game objects.
            canvas.Children.Clear();
            ballList.Clear();
            racketList.Clear();
            brickList.Clear();
            bonusList.Clear();

            // Set some fields.
            gameInSession = false;
            gameIsPaused = false;

            // Load the current game objects.
            WindowLoaded();
        }

        /// <summary>
        /// Refreshes the game objects on the canvas.
        /// </summary>
        public void RefreshDisplay()
        {
            canvas.Children.Clear();

            #region Ball

            // There is at leat one ball.
            if (ballList.Count > 0)
            {
                // Check each ball.
                for (int i = 0; i < ballList.Count; i++)
                {
                    // The ball is not deleted.
                    if (!ballList[i].IsDeleted)
                    {
                        canvas.Children.Add(ballList[i].GetEllipse());
                    }
                }
            }

            #endregion Ball

            #region Racket

            // There is at leat one racket.
            if (racketList.Count > 0)
            {
                // Check each racket.
                for (int i = 0; i < racketList.Count; i++)
                {
                    canvas.Children.Add(racketList[i].GetRectangle());
                }
            }

            #endregion Racket

            #region Brick

            // There is at leat one brick.
            if (brickList.Count > 0)
            {
                // Check each brick.
                for (int i = 0; i < brickList.Count; i++)
                {
                    // The brick is not deleted.
                    if (!brickList[i].IsDeleted)
                    {
                        canvas.Children.Add(brickList[i].GetRectangle());
                    }
                }
            }

            #endregion Brick

            #region Bonus

            // There is at leat one bonus.
            if (bonusList.Count > 0)
            {
                // Check each bonus.
                for (int i = 0; i < bonusList.Count; i++)
                {
                    // The bonus is not deleted.
                    if (!bonusList[i].IsDeleted)
                    {
                        canvas.Children.Add(bonusList[i].GetRectangle());
                    }
                }
            }

            #endregion Bonus
        }

        /// <summary>
        /// Checks if the ball is in contact with an object.
        /// </summary>
        public void BallAtContact()
        {
            try
            {
                // There is at least one ball.
                if (ballList.Count > 0)
                {
                    // Check each ball.
                    for (int j = 0; j < ballList.Count; j++)
                    {
                        // The ball is not deleted.
                        if (!ballList[j].IsDeleted)
                        {
                            // The ball is in move.
                            if (ballList[j].BallInMove)
                            {
                                #region BallAndWallContact

                                // The ball is at the side of canvas.
                                if (ballList[j].Area.X <= 0 ||                                       /* Left wall */
                                    ballList[j].Area.X + ballList[j].Area.Width >= canvasWidth ||    /* Right wall */
                                    ballList[j].Area.Y <= 0 ||                                       /* Top wall */
                                    ballList[j].Area.Y + ballList[j].Area.Width >= canvasHeight)     /* Bottom wall */
                                {
                                    // The ball is at the left or right side of the canvas.
                                    if (ballList[j].Area.X <= 0 || ballList[j].Area.X + ballList[j].Area.Width >= canvasWidth)
                                    {
                                        // Vertical direction change.
                                        ballList[j].VerticalMovement *= -1;
                                    }
                                    // The ball is at the top side of the canvas.
                                    else if (ballList[j].Area.Y <= 0)
                                    {
                                        // Horizontal direction change.
                                        ballList[j].HorizontalMovement *= -1;
                                    }
                                    // The ball is at the bottom side of the canvas.
                                    else if (ballList[j].Area.Y + ballList[j].Area.Width >= canvasHeight)
                                    {
                                        // There is only one ball.
                                        if (ballList.Count == 1)
                                        {
                                            // Decrement the player's life points.
                                            playerLife -= 1;

                                            // Clear the racket, ball and bonus game objects from the field.
                                            DisposeOfBall();
                                        }
                                        // There is more than one ball.
                                        else
                                        {
                                            // Set the ball as deleted.
                                            ballList[j].IsDeleted = true;
                                        }

                                        // The life points reached 0.
                                        if (playerLife <= 0)
                                        {
                                            gameIsOver = true;
                                            gameOverStatus = "fail";
                                        }

                                        break;
                                    }
                                    // The ball is at the corners of the canvas.
                                    else
                                    {
                                        // Horizontal direction change.
                                        ballList[j].HorizontalMovement *= -1;
                                        // Vertical direction change.
                                        ballList[j].VerticalMovement *= -1;
                                    }

                                    ballList[j].RepositionBallAtCanvas(canvasWidth);

                                    PlaySound();
                                }

                                #endregion BallAndWallContact

                                // The ball is not at the side walls of the canvas.
                                else
                                {
                                    // There is at least one racket.
                                    if (racketList.Count > 0)
                                    {
                                        // Check each racket.
                                        foreach (var oneRacket in racketList)
                                        {
                                            // The racket is not deleted.
                                            if (!oneRacket.IsDeleted)
                                            {
                                                #region BallAndRacketContact

                                                // The ball is at contact with the racket.
                                                if (ballList[j].Area.X + ballList[j].Area.Width >= oneRacket.Area.X &&                           /* racket left side */
                                                    ballList[j].Area.X + ballList[j].Area.Width <= oneRacket.Area.X + oneRacket.Area.Width &&    /* racket right side */
                                                    ballList[j].Area.Y + ballList[j].Area.Width >= canvasHeight - racketHeight)                  /* racket top */
                                                {
                                                    // Horizontal direction change.
                                                    ballList[j].HorizontalMovement *= -1;

                                                    // The racket is sticky.
                                                    if (oneRacket.StickyRacket)
                                                    {
                                                        // Stop the movement of the ball.
                                                        ballList[j].BallInMove = false;
                                                        ballList[j].RelativePosition = ballList[j].Area.X + ballList[j].Area.Width / 2 - racketList[0].Area.X;

                                                        // Set the horizontal movement of the ball to negative if not done already.
                                                        if (ballList[j].HorizontalMovement > 0)
                                                        {
                                                            // Horizontal direction change.
                                                            ballList[j].HorizontalMovement *= -1;
                                                        }
                                                    }

                                                    ballList[j].RepositionBallAtRacket(oneRacket);

                                                    PlaySound();
                                                }

                                                #endregion BallAndRacketContact
                                            }
                                        }
                                    }

                                    // There is at least one brick.
                                    if (brickList.Count > 0)
                                    {
                                        // Check each brick.
                                        for (int i = 0; i < brickList.Count; i++)
                                        {
                                            // The brick is not deleted.
                                            if (!brickList[i].IsDeleted)
                                            {
                                                #region BallAndBrickContact

                                                // The ball is in contact with a brick.
                                                if (((ballList[j].Area.X + ballList[j].Area.Width / 2 >= brickList[i].Area.X ||
                                                    ballList[j].Area.X + ballList[j].Area.Width / 2 <= brickList[i].Area.X + brickList[i].Area.Width) &&
                                                    ballList[j].Area.Y + ballList[j].Area.Height >= brickList[i].Area.Y) &&                                 /* bottom of the ball */
                                                    ((ballList[j].Area.X + ballList[j].Area.Width / 2 >= brickList[i].Area.X ||
                                                    ballList[j].Area.X + ballList[j].Area.Width / 2 <= brickList[i].Area.X + brickList[i].Area.Width) &&
                                                    ballList[j].Area.Y <= brickList[i].Area.Y + brickList[i].Area.Height) &&                                /* top of the ball */
                                                    ((ballList[j].Area.Y + ballList[j].Area.Height / 2 >= brickList[i].Area.Y ||
                                                    ballList[j].Area.Y + ballList[j].Area.Height / 2 <= brickList[i].Area.Y + brickList[i].Area.Height) &&
                                                    ballList[j].Area.X <= brickList[i].Area.X + brickList[i].Area.Width) &&                                 /* left of the ball */
                                                    ((ballList[j].Area.Y + ballList[j].Area.Height / 2 >= brickList[i].Area.Y ||
                                                    ballList[j].Area.Y + ballList[j].Area.Height / 2 <= brickList[i].Area.Y + brickList[i].Area.Height) &&
                                                    ballList[j].Area.X + ballList[j].Area.Width >= brickList[i].Area.X))                                    /* right of the ball */
                                                {
                                                    // Horizontal side contact.
                                                    if (((ballList[j].Area.X + ballList[j].Area.Width / 2 >= brickList[i].Area.X ||
                                                        ballList[j].Area.X + ballList[j].Area.Width / 2 <= brickList[i].Area.X + brickList[i].Area.Width) &&
                                                        ballList[j].Area.Y + ballList[j].Area.Height >= brickList[i].Area.Y) ||                             /* bottom of the ball */
                                                        ((ballList[j].Area.X + ballList[j].Area.Width / 2 >= brickList[i].Area.X ||
                                                        ballList[j].Area.X + ballList[j].Area.Width / 2 <= brickList[i].Area.X + brickList[i].Area.Width) &&
                                                        ballList[j].Area.Y <= brickList[i].Area.Y + brickList[i].Area.Height))                              /* top of the ball */
                                                    {
                                                        // The ball is not a steel ball.
                                                        if (ballList[j].BallType != Ball.BallsType.Steel)
                                                        {
                                                            // Horizontal direction change.
                                                            ballList[j].HorizontalMovement *= -1;
                                                        }
                                                    }
                                                    // Vertical side contact.
                                                    else if (((ballList[j].Area.Y + ballList[j].Area.Height / 2 >= brickList[i].Area.Y ||
                                                        ballList[j].Area.Y + ballList[j].Area.Height / 2 <= brickList[i].Area.Y + brickList[i].Area.Height) &&
                                                        ballList[j].Area.X <= brickList[i].Area.X + brickList[i].Area.Width) ||                             /* left of the ball */
                                                        ((ballList[j].Area.Y + ballList[j].Area.Height / 2 >= brickList[i].Area.Y ||
                                                        ballList[j].Area.Y + ballList[j].Area.Height / 2 <= brickList[i].Area.Y + brickList[i].Area.Height) &&
                                                        ballList[j].Area.X + ballList[j].Area.Width >= brickList[i].Area.X))                                /* right of the ball */
                                                    {
                                                        // The ball is not a steel ball.
                                                        if (ballList[j].BallType != Ball.BallsType.Steel)
                                                        {
                                                            // Vertical direction change.
                                                            ballList[j].VerticalMovement *= -1;
                                                        }
                                                    }

                                                    BrickContact(ballList[j], brickList[i]);
                                                }

                                                #endregion BallAndBrickContact
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                errorLogViewModel.LogError(e);
            }
        }

        /// <summary>
        /// Brick is at contact with ball.
        /// </summary>
        /// <param name="oneBall">One ball.</param>
        /// <param name="oneBrick">One brick.</param>
        private void BrickContact(Ball oneBall, Brick oneBrick)
        {
            try
            {
                // The ball is not a steel ball.
                if (oneBall.BallType != Ball.BallsType.Steel)
                {
                    // The brick is not a steel brick.
                    if (oneBrick.BrickType != Brick.BricksType.Steel)
                    {
                        // The ball is not a hard ball.
                        if (oneBall.BallType != Ball.BallsType.Hard)
                        {
                            // The brick is at breaking point.
                            if (oneBrick.BreakNumber == 1)
                            {
                                // If the brick is lucky, then add bonus.
                                if (oneBrick.CalculateBonusChance())
                                {
                                    AddBonus(oneBrick);
                                }

                                // Add the brick's points to the player's points and make it deleted.
                                playerScorePoint += oneBrick.ScorePoint;
                                oneBrick.IsDeleted = true;
                            }
                            // The brick is not at breaking point.
                            else
                            {
                                // Decrement the breaking number.
                                oneBrick.DecrementBreakNumber();
                            }
                        }
                        // The ball is a hard ball.
                        else
                        {
                            // The brick is lucky, then add bonus.
                            if (oneBrick.CalculateBonusChance())
                            {
                                AddBonus(oneBrick);
                            }

                            // Add the brick's points to the player's points and make it deleted.
                            playerScorePoint += oneBrick.ScorePoint;
                            oneBrick.IsDeleted = true;
                        }
                    }
                }
                // The ball is a steel ball.
                else
                {
                    // If the brick is lucky, then add bonus.
                    if (oneBrick.CalculateBonusChance())
                    {
                        AddBonus(oneBrick);
                    }

                    // Add the brick's points to the player's points and make it deleted.
                    playerScorePoint += oneBrick.ScorePoint;
                    oneBrick.IsDeleted = true;
                }

                PlaySound();
            }
            catch (Exception e)
            {
                errorLogViewModel.LogError(e);
            }
        }

        /// <summary>
        /// Plays the sound.
        /// </summary>
        private void PlaySound()
        {
            try
            {
                // The sound is a on.
                if (GetOption().IsSoundEnabled)
                {
                    // Play the sound.
                    mediaPlayer.Position = new TimeSpan(0);
                    mediaPlayer.Play();
                }
            }
            catch (Exception e)
            {
                errorLogViewModel.LogError(e);
            }
        }

        /// <summary>
        /// Sets the values for the map.
        /// </summary>
        public void WindowLoaded()
        {
            try
            {
                // Set the values for the current map.
                PresetValues2();

                // If the map wasn't found then close the window.
                if (!string.IsNullOrEmpty(currentMapPath) && currentMapPath == "notfound")
                {
                    MessageBox.Show("Couldn't find the map file.", "Error");

                    viewAction = ViewActionStatus.OpenMenu;
                }
                // The current map path is empty, this should be impossible.
                else if (string.IsNullOrEmpty(currentMapPath))
                {
                    MessageBox.Show("Couldn't find the options xml file.", "Error");

                    viewAction = ViewActionStatus.OpenMenu;
                }
            }
            catch (Exception e)
            {
                errorLogViewModel.LogError(e);
            }
        }

        /// <summary>
        /// Checks for game ending consequences.
        /// </summary>
        /// <param name="timer">The timer.</param>
        public void CheckForGameOver()
        {
            try
            {
                // There is at least one ball.
                if (ballList.Count > 0)
                {
                    // There are still bricks left.
                    if (brickList.Count > 0)
                    {
                        int notSteelBrickCount = 0;

                        // Check each brick.
                        foreach (Brick oneBrick in brickList)
                        {
                            // See how many not steel bricks are there.
                            if (oneBrick.BrickType != Brick.BricksType.Steel)
                            {
                                notSteelBrickCount++;
                            }
                        }

                        // No non steel bricks left.
                        if (notSteelBrickCount == 0)
                        {
                            gameIsOver = true;
                            gameOverStatus = "success";
                        }
                    }
                    // No bricks left.
                    else
                    {
                        // No bonuses left.
                        if (bonusList.Count == 0)
                        {
                            gameIsOver = true;
                            gameOverStatus = "success";
                        }
                    }
                }

                // The game is over, the status is given and the game is still is session.
                if (gameIsOver && !string.IsNullOrEmpty(gameOverStatus) && gameInSession)
                {
                    GameOver(gameOverStatus);
                }
            }
            catch (Exception e)
            {
                errorLogViewModel.LogError(e);
            }
        }

        /// <summary>
        /// Handles the end of the game.
        /// </summary>
        /// <param name="status">The status.</param>
        private void GameOver(string status)
        {
            try
            {
                #region Fail

                // The game ended in failure.
                if (status == "fail")
                {
                    MessageBox.Show("You've failed.", "Game Over");

                    gameIsOver = false;
                    gameOverStatus = null;

                    viewAction = ViewActionStatus.OpenHighscores;
                }

                #endregion Fail

                #region Success

                // The game ended in success.
                else if (status == "success")
                {
                    gameIsOver = false;
                    gameOverStatus = null;

                    #region NotLastMap

                    if (GetOption().MapNumber < mapMaxNumber)
                    {
                        #region Continue

                        // The map has been cleared and the player chose to continue.
                        if (MessageBox.Show("You've succeeded. \n Would you like to continue.", "Game Over", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            // Increment the map's number.
                            optionsViewModel.OptionModel.MapNumber += 1;
                            optionsViewModel.SaveToXml();
                            viewAction = ViewActionStatus.NewMap;
                        }

                        #endregion Constinue

                        #region Exit

                        // The map has been cleared and the player chose to exit.
                        else
                        {
                            viewAction = ViewActionStatus.OpenHighscores;
                        }

                        #endregion Exit
                    }

                    #endregion NotLastMap

                    #region LastMap

                    // This was the last map.
                    else
                    {
                        MessageBox.Show("You've succeeded.", "Game Over");
                        viewAction = ViewActionStatus.OpenHighscores;
                    }

                    #endregion LastMap
                }

                #endregion Success
            }
            catch (Exception e)
            {
                errorLogViewModel.LogError(e);
            }
        }

        /// <summary>
        /// Handles the event when the ball falls down.
        /// </summary>
        private void DisposeOfBall()
        {
            try
            {
                // Dispose balls, rackets, bonuses.
                racketList.Clear();
                ballList.Clear();
                bonusList.Clear();

                // Add a new racket.
                Racket racket = new Racket(canvasWidth / 2 - racketWidth / 2, canvasHeight - racketHeight, racketWidth, racketHeight, 
                    @"..\..\Resources\Media\Racket\normalracket.jpg");
                racket.Direction = Racket.Directions.Stay;
                racket.StickyRacket = false;
                racket.IsDeleted = false;
                canvas.Children.Add(racket.GetRectangle());
                racketList.Add(racket);

                // Add a new ball.
                Ball ball = new Ball((canvasWidth / 2) - ballRadius, canvasHeight - racketHeight - (ballRadius * 2), ballRadius * 2, ballRadius * 2,
                    @"..\..\Resources\Media\Ball\normalball.jpg", ballHorizontalMovement, ballVerticalMovement, Ball.BallsType.Normal);
                ball.VerticalMovement = ballVerticalMovement > 0 ? ballVerticalMovement : -ballVerticalMovement;
                ball.HorizontalMovement = ballHorizontalMovement < 0 ? ballHorizontalMovement : -ballHorizontalMovement;
                ball.BallInMove = false;
                ball.RelativePosition = ball.Area.X + ball.Area.Width / 2 - racketList[0].Area.X;
                ball.IsDeleted = false;
                canvas.Children.Add(ball.GetEllipse());
                ballList.Add(ball);
            }
            catch (Exception e)
            {
                errorLogViewModel.LogError(e);
            }
        }

        /// <summary>
        /// Checks if the racket is in contact with a bonus.
        /// </summary>
        public void RacketAtContactWithBonus()
        {
            try
            {
                // There is at least one racket.
                if (racketList.Count > 0)
                {
                    // Check each racket.
                    foreach (Racket oneRacket in racketList)
                    {
                        // The racket is not deleted.
                        if (!oneRacket.IsDeleted)
                        {
                            // There is at least one bonus.
                            if (bonusList.Count > 0)
                            {
                                // Check each bonus.
                                for (int i = 0; i < bonusList.Count; i++)
                                {
                                    // The bonus is not deleted.
                                    if (!bonusList[i].IsDeleted)
                                    {
                                        // The racket and the bonus overleap somewhere.
                                        if (oneRacket.Area.X < bonusList[i].Area.X + bonusList[i].Area.Width &&    /* bonus rigth side */
                                            oneRacket.Area.X + oneRacket.Area.Width > bonusList[i].Area.X &&       /* bonus left side */
                                            oneRacket.Area.Y < bonusList[i].Area.Y + bonusList[i].Area.Height)     /* bonus bottom */
                                        {
                                            // Add the score of the bonus to the player's bonus.
                                            playerScorePoint += bonusList[i].ScorePoint;

                                            #region AddBonusEffect

                                            // Add the bonus effect.
                                            switch (bonusList[i].BonusType)
                                            {
                                                case Bonus.BonusesType.LifeUp:
                                                    playerLife++;
                                                    break;
                                                case Bonus.BonusesType.LifeDown:
                                                    playerLife--;
                                                    break;
                                                case Bonus.BonusesType.NewBall:
                                                    // Create ball and set the needed properties.
                                                    Ball ball = new Ball(oneRacket.Area.X + (oneRacket.Area.Width / 2) - ballRadius, oneRacket.Area.Y - (ballRadius * 2),
                                                        ballRadius * 2, ballRadius * 2, @"..\..\Resources\Media\Ball\normalball.jpg", 0, 0, Ball.BallsType.Normal);
                                                    ball.VerticalMovement = ballVerticalMovement > 0 ? ballVerticalMovement : -ballVerticalMovement;
                                                    ball.HorizontalMovement = ballHorizontalMovement < 0 ? ballHorizontalMovement : -ballHorizontalMovement;
                                                    ball.BallInMove = false;
                                                    ball.RelativePosition = ball.Area.X + ball.Area.Width / 2 - racketList[0].Area.X;
                                                    ball.IsDeleted = false;
                                                    canvas.Children.Add(ball.GetEllipse());
                                                    ballList.Add(ball);
                                                    break;
                                                case Bonus.BonusesType.RacketLengthen:
                                                    oneRacket.Lengthen(racketMaxSize, racketDifference);
                                                    break;
                                                case Bonus.BonusesType.RacketShorten:
                                                    oneRacket.Shorthen(racketMinSize, racketDifference);
                                                    break;
                                                case Bonus.BonusesType.BallBigger:
                                                    // There are at least one ball.
                                                    if (ballList.Count > 0)
                                                    {
                                                        // Check each ball.
                                                        foreach (var oneBall in ballList)
                                                        {
                                                            oneBall.ChangeBallToLarge(ballMaxRadius, ballRadius, canvasWidth, canvasHeight, racketHeight);
                                                        }
                                                    }
                                                    break;
                                                case Bonus.BonusesType.BallSmaller:
                                                    // There is at least one ball.
                                                    if (ballList.Count > 0)
                                                    {
                                                        // Check each ball.
                                                        foreach (var oneBall in ballList)
                                                        {
                                                            oneBall.ChangeBallToSmall(ballMinRadius);
                                                        }
                                                    }
                                                    break;
                                                case Bonus.BonusesType.StickyRacket:
                                                    // The racket is not sticky.
                                                    if (!oneRacket.StickyRacket)
                                                    {
                                                        oneRacket.ChangeToSticky();
                                                    }
                                                    break;
                                                case Bonus.BonusesType.HardBall:
                                                    // There is at least one ball.
                                                    if (ballList.Count > 0)
                                                    {
                                                        // Check each ball.
                                                        foreach (var oneBall in ballList)
                                                        {
                                                            oneBall.ChangeToHard();
                                                        }
                                                    }
                                                    break;
                                                case Bonus.BonusesType.SteelBall:
                                                    // There is at least one ball.
                                                    if (ballList.Count > 0)
                                                    {
                                                        // Check each ball.
                                                        foreach (var oneBall in ballList)
                                                        {
                                                            oneBall.ChangeToSteel();
                                                        }
                                                    }
                                                    break;
                                            }

                                            // The player's life points reached 0, game over.
                                            if (playerLife <= 0)
                                            {
                                                gameOverStatus = "fail";
                                                gameIsOver = true;
                                            }

                                            #endregion AddBonusEffect

                                            // Set bonus to deleted.
                                            bonusList[i].IsDeleted = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                errorLogViewModel.LogError(e);
            }
        }

        /// <summary>
        /// Presets the values.
        /// </summary>
        private void PresetValues1()
        {
            try
            {
                #region PresetValues

                // Set the values for the functionality fileds.
                viewAction = ViewActionStatus.DoNothing;
                playerLife = 3;
                playerScorePoint = 0;
                gameInSession = false;
                gameIsPaused = false;
                gameIsOver = false;
                gameOverStatus = "";
                currentMapPath = "notfound";
                bonusSpeed = 1;
                mapMaxNumber = 5;
                ballHorizontalMovement = 5;
                ballVerticalMovement = 5;
                racketSpeed = 20;
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
                ballList = new ObservableCollection<Ball>();
                brickList = new ObservableCollection<Brick>();
                racketList = new ObservableCollection<Racket>();
                bonusList = new ObservableCollection<Bonus>();

                #endregion PresetValues
                
                #region SetScaling

                // Set the dimensions scaling based on the resolution.
                switch (GetOption().Resolution)
                {
                    case "580x420":
                        horizontalScaleNumber = 0.9;
                        verticalScaleNumber = 0.9;
                        break;
                    case "640x480":
                        horizontalScaleNumber = 1;
                        verticalScaleNumber = 1;
                        break;
                    case "800x600":
                        horizontalScaleNumber = 1.25;
                        verticalScaleNumber = 1.25;
                        break;
                }

                // Set the speed scaling based on the difficulty.
                switch (GetOption().Difficulty)
                {
                    case 1:
                        speedScale = 0.9;
                        break;
                    case 2:
                        speedScale = 1;
                        break;
                    case 3:
                        speedScale = 1.2;
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
            }
            catch (Exception e)
            {
                errorLogViewModel.LogError(e);
            }
        }

        /// <summary>
        /// Presets the values that are needed for the map.
        /// </summary>
        private void PresetValues2()
        {
            try
            {
                #region MapSelection

                try
                {
                    // The map number is valid.
                    if (GetOption().MapNumber > 0 && GetOption().MapNumber < 6)
                    {
                        // Set the current map path.
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
                    }
                }
                catch
                { }

                #endregion MapSelection

                #region FillLists

                try
                {
                    canvasHeight = canvas.ActualHeight;
                    canvasWidth = canvas.ActualWidth;

                    // The current map path is valid.
                    if (!string.IsNullOrEmpty(currentMapPath) && currentMapPath != "notfound")
                    {
                        // Add a racket.
                        racketList.Add(new Racket(canvasWidth / 2 - racketWidth / 2, canvasHeight - racketHeight, racketWidth, racketHeight,
                            @"..\..\Resources\Media\Racket\normalracket.jpg"));
                        racketList[0].Direction = Racket.Directions.Stay;
                        racketList[0].StickyRacket = false;
                        racketList[0].IsDeleted = false;
                        canvas.Children.Add(racketList[0].GetRectangle());

                        // Add a ball.
                        ballList.Add(new Ball(canvasWidth / 2 - ballRadius, canvasHeight - racketHeight - ballRadius * 2, ballRadius * 2, ballRadius * 2,
                            @"..\..\Resources\Media\Ball\normalball.jpg", -ballHorizontalMovement, -ballVerticalMovement, Ball.BallsType.Normal));
                        ballList[0].BallInMove = false;
                        ballList[0].IsDeleted = false;
                        ballList[0].RelativePosition = ballList[0].Area.X + ballList[0].Area.Width / 2 - racketList[0].Area.X;
                        canvas.Children.Add(ballList[0].GetEllipse());

                        // Add the bricks.
                        brickList = mapTxtAccess.LoadMap(currentMapPath, brickWidth, brickHeight);
                        // There is at least one brick.
                        if (brickList.Count > 0)
                        {
                            // Check each brick.
                            for (int i = 0; i < brickList.Count; i++)
                            {
                                canvas.Children.Add(brickList[i].GetRectangle());
                            }
                        }
                    }

                    // Set the sound for the media player to play.
                    mediaPlayer.Open(new Uri(@"..\..\Resources\Media\Sounds\play_this.mp3", UriKind.Relative));
                }
                catch
                { }

                #endregion FillLists
            }
            catch (Exception e)
            {
                errorLogViewModel.LogError(e);
            }
        }

        /// <summary>
        /// Movethe objects.
        /// </summary>
        public void MoveObjects()
        {
            try
            {
                #region MoveBalls

                // There is at least one ball.
                if (ballList.Count > 0)
                {
                    // Check each ball.
                    foreach (var oneBall in ballList)
                    {
                        // The ball is not on the racket.
                        if (oneBall.BallInMove)
                        {
                            // Move the ball.
                            oneBall.Move(ballSpeed);
                        }
                    }
                }

                #endregion MoveBalls

                #region MoveBonuses

                // There is at least one bonus.
                if (bonusList.Count > 0)
                {
                    // Check each bonus.
                    for (int i = 0; i < bonusList.Count; i++)
                    {
                        // Descend the bonus and remove it if it's out of the canvas.
                        if (bonusList[i].Descend(bonusSpeed, canvasWidth, canvasHeight))
                        {
                            // Delete the bonus if the top of it reached the bottom of the canvas.
                            bonusList[i].IsDeleted = true;
                        }
                    }
                }

                #endregion MoveBonuses
            }
            catch (Exception e)
            {
                errorLogViewModel.LogError(e);
            }
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
            catch (Exception e)
            {
                errorLogViewModel.LogError(e);

                return false;
            }
        }

        /// <summary>
        /// Adds a bonus.
        /// </summary>
        /// <param name="oneBrick">The brick.</param>
        private void AddBonus(Brick oneBrick)
        {
            try
            {
                string bonusImage = "";
                Bonus.BonusesType type = Bonus.BonusesType.BallBigger;

                // Random generate an effect for the bonus.
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

                // Create the bonus and set the needed properties.
                Bonus bonus = new Bonus(oneBrick.Area.X + (oneBrick.Area.Width / 2) - (bonusWidth / 2), oneBrick.Area.Y + oneBrick.Area.Height, 
                    bonusHeight, bonusWidth, bonusImage, type);
                bonus.ScorePoint = 50;
                bonus.IsDeleted = false;
                canvas.Children.Add(bonus.GetRectangle());
                bonusList.Add(bonus);

                // Move the bonus down.
                if (bonus.Descend(bonusSpeed, canvasWidth, canvasHeight))
                {
                    // Delete the bonus if the top of it reached the bottom of the canvas.
                    bonus.IsDeleted = true;
                }
            }
            catch (Exception e)
            {
                errorLogViewModel.LogError(e);
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
            catch (Exception e)
            {
                errorLogViewModel.LogError(e);

                return null;
            }
        }

        #region KeyboardAndMouse

        #region MouseControls

        /// <summary>
        /// Moves the racket by the mouse.
        /// </summary>
        /// <param name="sender">The canvas.</param>
        /// <param name="e">The mouse event.</param>
        public void MouseMove(Canvas sender, MouseEventArgs e)
        {
            try
            {
                // The mouse is a controller item and the game is not paused.
                if (GetOption().IsMouseEnabled && !gameIsPaused)
                {
                    // There is at least one racket.
                    if (racketList.Count > 0)
                    {
                        // Check each racket.
                        foreach (Racket oneRacket in racketList)
                        {
                            // The racket is not deleted.
                            if (!oneRacket.IsDeleted)
                            {
                                // Move the racket.
                                oneRacket.MouseMove(racketSpeed, canvasWidth, e.GetPosition(sender).X);

                                // There is at least one ball.
                                if (ballList.Count > 0)
                                {
                                    // Check each ball.
                                    foreach (Ball oneBall in ballList)
                                    {
                                        // The ball is not deleted.
                                        if (!oneBall.IsDeleted)
                                        {
                                            // The ball is on the racket.
                                            if (!oneBall.BallInMove)
                                            {
                                                // Move the ball.
                                                oneBall.MouseMove(oneRacket, canvasWidth, e.GetPosition(sender).X);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        /// <summary>
        /// Handles the left button click of the mouse.
        /// </summary>
        /// <param name="e">The mouse button event.</param>
        /// <param name="dispatcherTimer">The timer.</param>
        public void MouseLeftButtonDown(MouseButtonEventArgs e)
        {
            try
            {
                // The mouse is a controller item and the game is not paused.
                if (GetOption().IsMouseEnabled && !gameIsPaused)
                {
                    // The timer is not going and the game has not been started.
                    if (!gameInSession)
                    {
                        // Start the game.
                        gameInSession = true;
                    }

                    // There is at least one ball.
                    if (ballList.Count > 0)
                    {
                        bool oneGo = false;
                        int iteratorCounter = 0;

                        // Move the first ball.
                        while (!oneGo && iteratorCounter < ballList.Count)
                        {
                            // Start a ball.
                            if (!ballList[iteratorCounter].BallInMove)
                            {
                                ballList[iteratorCounter].BallInMove = true;
                                oneGo = true;
                            }

                            iteratorCounter++;
                        }
                    }
                }
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        #endregion MouseControls

        #region KeyboardControls

        /// <summary>
        /// Stop the racket's movevent by key.
        /// </summary>
        /// <param name="e">The key event.</param>
        public void KeyUp(KeyEventArgs e)
        {
            try
            {
                // The keyboard is a controller item.
                if (GetOption().IsKeyboardEnabled)
                {
                    // The released key is one of the racket moving keys.
                    if (SpecKeys(e.Key) == GetOption().LeftMove || SpecKeys(e.Key) == GetOption().RightMove)
                    {
                        // There is at least one racket.
                        if (racketList.Count > 0)
                        {
                            // Check each racket.
                            foreach (Racket oneRacket in racketList)
                            {
                                // The racket's direction is not stay.
                                if (oneRacket.Direction != Racket.Directions.Stay)
                                {
                                    // The racket's direction change to stay.
                                    oneRacket.Direction = Racket.Directions.Stay;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        /// <summary>
        /// Handle all the key events.
        /// </summary>
        /// <param name="e">The key event.</param>
        /// <param name="dispatcherTimer">The timer.</param>
        public void KeyDown(KeyEventArgs e)
        {
            try
            {
                #region EscapeKey

                // The pressed key is the Esc key.
                if (e.Key == Key.Escape)
                {
                    // Pause the game and send message.
                    gameIsPaused = true;

                    if (MessageBox.Show("Do you want to quit?", "Warning", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        gameInSession = false;
                        viewAction = ViewActionStatus.OpenMenu;
                    }
                }

                #endregion EscapeKey

                #region OptionBindedKeys

                // The pressed key is one of the binded keys.
                else if (SpecKeys(e.Key) == GetOption().FireButton || SpecKeys(e.Key) == GetOption().PauseButton || SpecKeys(e.Key) == GetOption().LeftMove ||
                    SpecKeys(e.Key) == GetOption().RightMove)
                {
                    #region MovementKeys

                    // The pressed key is one of the movement keys, the keyboard is controller item and the game is not paused.
                    if ((SpecKeys(e.Key) == GetOption().LeftMove || SpecKeys(e.Key) == GetOption().RightMove) && GetOption().IsKeyboardEnabled && !gameIsPaused)
                    {
                        #region LeftMovement

                        // The pressed key is the left movement key.
                        if (SpecKeys(e.Key) == GetOption().LeftMove)
                        {
                            // There is at least one racket.
                            if (racketList.Count > 0)
                            {
                                // Check each racket.
                                foreach (var oneRacket in racketList)
                                {
                                    // The racket is not deleted.
                                    if (!oneRacket.IsDeleted)
                                    {
                                        // Move the racket left.
                                        oneRacket.Direction = Racket.Directions.Left;
                                        oneRacket.KeyMove(racketSpeed, canvasWidth);

                                        // There is at least one ball.
                                        if (ballList.Count > 0)
                                        {
                                            // Check each ball.
                                            foreach (var oneBall in ballList)
                                            {
                                                // The ball is not deleted.
                                                if (!oneBall.IsDeleted)
                                                {
                                                    // The ball is on the racket.
                                                    if (!oneBall.BallInMove)
                                                    {
                                                        // Move the ball with the racket left if ball is not moving.
                                                        oneBall.KeyMove(canvasWidth, oneRacket);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        #endregion LeftMovement

                        #region RightMovement

                        // The pressed key is the right movement key.
                        else if (SpecKeys(e.Key) == GetOption().RightMove)
                        {
                            // There is at least one racket.
                            if (racketList.Count > 0)
                            {
                                // Check each racket.
                                foreach (var oneRacket in racketList)
                                {
                                    // The racket is not deleted.
                                    if (!oneRacket.IsDeleted)
                                    {
                                        // Move the racket right.
                                        oneRacket.Direction = Racket.Directions.Right;
                                        oneRacket.KeyMove(racketSpeed, canvasWidth);

                                        // There is at least one ball.
                                        if (ballList.Count > 0)
                                        {
                                            // Check each ball.
                                            foreach (var oneBall in ballList)
                                            {
                                                // The ball is not deleted.
                                                if (!oneBall.IsDeleted)
                                                {
                                                    // The ball is on the racket.
                                                    if (!oneBall.BallInMove)
                                                    {
                                                        // Move the ball with the racket right if ball is not moving.
                                                        oneBall.KeyMove(canvasWidth, oneRacket);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        #endregion RightMovement
                    }

                    #endregion MovementKeys

                    #region FireKey

                    // The pressed key is the fire key.
                    else if (SpecKeys(e.Key) == GetOption().FireButton)
                    {
                        // The keyboard is a controller item and the game didn't begin yet.
                        if (GetOption().IsKeyboardEnabled && !gameInSession)
                        {
                            // The game didn't start yet.
                            if (!gameInSession)
                            {
                                // Start the game.
                                gameInSession = true;
                            }

                            // There is at least one ball.
                            if (ballList.Count > 0)
                            {
                                bool oneGo = false;
                                int iteratorCounter = 0;

                                // Move the first ball.
                                while (!oneGo && iteratorCounter < ballList.Count)
                                {
                                    // Start a ball.
                                    if (!ballList[iteratorCounter].BallInMove)
                                    {
                                        ballList[iteratorCounter].BallInMove = true;
                                        oneGo = true;
                                    }

                                    iteratorCounter++;
                                }
                            }
                        }
                    }

                    #endregion FireKey

                    #region PauseKey

                    // The pressed key is the pause key.
                    else if (SpecKeys(e.Key) == GetOption().PauseButton)
                    {
                        // The game is not paused and the game has started.
                        if (!gameIsPaused && gameInSession)
                        {
                            // Pause the game.
                            gameIsPaused = true;
                        }
                        // The game is paused and the game has started.
                        else if (gameIsPaused && gameInSession)
                        {
                            // Continue the game.
                            gameIsPaused = false;
                        }
                    }

                    #endregion PauseKey
                }

                #endregion OptionBindedKeys
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        #endregion KeyboardControls

        /// <summary>
        /// Sets a string to the control key bindings for the keys.
        /// </summary>
        /// <param name="inputKey">The key to check.</param>
        /// <returns>The string for the key.</returns>
        public string SpecKeys(Key inputKey)
        {
            try
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
            catch (Exception e)
            {
                errorLogViewModel.LogError(e);
                return null;
            }
        }

        #endregion KeyboardAndMouse

        #endregion Methods
    }
}
