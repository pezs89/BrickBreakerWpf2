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

        // The limit of the number of highscores to save.
        private int highscoreLimit;

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

        // Time of the game.
        private DateTime timeOfGame;

        #endregion GameMechanicsValues

        #endregion Fields

        #region Properties

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
        /// Gets or sets the timeOfGame.
        /// </summary>
        /// <value>
        /// The timeOfGame.
        /// </value>
        public DateTime TimeOfGame
        {
            get { return timeOfGame; }
            set { timeOfGame = value; }
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
        /// <param name="canvasWidth">The width of the canvas.</param>
        /// <param name="canvasHeight">The height of the canvas.</param>
        public NewGameViewModel(double canvasWidth, double canvasHeight)
        {
            mapTxtAccess = new MapTxtAccess();
            optionsViewModel = new OptionsViewModel();

            this.canvasWidth = canvasWidth;
            this.canvasHeight = canvasHeight;
            PresetValues();

            #region SetLabelValues

            //// Show the scorepoints.
            //ScoreLabel.Content = "Score: " + scoreValue;
            //// Show the lifepoints.
            //LifeLabel.Content = "Life: " + lifePoint;
            //// Show the time.
            //TimeLabel.Content = "Time: " + timeOfGame.ToString("HH:mm:ss");

            #endregion SetLabelValues
        }

        #endregion Constructors

        #region Methods

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
                                ballList[j].VerticalMovement *= -1;
                            }
                            // The ball is at the top side of the canvas.
                            else if (ballList[j].Area.Y <= 0)
                            {
                                ballList[j].HorizontalMovement *= -1;
                            }
                            // The ball is at the bottom side of the canvas.
                            else if (ballList[j].Area.Y + ballList[j].Area.Width >= canvasHeight)
                            {
                                // There is only one ball.
                                if (ballList.Count == 1)
                                {
                                    playerLife -= 1;
                                    //LifeLabel.Content = "Life: " + playerLife;

                                    DisposeOfBall();
                                }
                                // There are more than one balls.
                                else
                                {
                                    ballList.RemoveAt(j);
                                    gameObjectList.Remove(ballList[j]);
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

                            #region PlaySound

                            // The sound is on.
                            if (GetOption().IsSoundEnabled)
                            {
                                // Play the sound.
                                mediaPlayer.Position = new TimeSpan(0);
                                mediaPlayer.Play();
                            }

                            #endregion PlaySound
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
                                    #region BallAndRacketContact

                                    // The ball is at contact with the racket.
                                    if (ballList[j].Area.X + ballList[j].Area.Width >= oneRacket.Area.X &&                           /* racket left side */
                                        ballList[j].Area.X + ballList[j].Area.Width <= oneRacket.Area.X + oneRacket.Area.Width &&    /* racket right side */
                                        ballList[j].Area.Y + ballList[j].Area.Width >= canvasHeight - racketHeight)                  /* racket top */
                                    {
                                        // Horizontal direction change.
                                        ballList[j].HorizontalMovement *= -1;

                                        #region InDevelopment

                                        //// The left of the racket.
                                        //if (ballList[j].Area.X + ballList[j].Area.Width / 2 < oneRacket.Area.X + (oneRacket.Area.Width / 2) - ballExaminationProximity)
                                        //{
                                        //    ballVerticalMovement *= ballVerticalMovement < 0 ? 1 : -1;
                                        //    double diff = (0) / ((oneRacket.Area.Width / 2) - ballExaminationProximity);
                                        //}
                                        //// The middle of the racket.
                                        //else if (ballList[j].Area.X + ballList[j].Area.Width / 2 >= oneRacket.Area.X + (oneRacket.Area.Width / 2) - ballExaminationProximity &&
                                        //         ballList[j].Area.X + ballList[j].Area.Width / 2 <= oneRacket.Area.X + (oneRacket.Area.Width / 2) + ballExaminationProximity)
                                        //{
                                        //    ballVerticalMovement = 0;
                                        //}
                                        //// The right of the racket.
                                        //else if (ballList[j].Area.X + ballList[j].Area.Width / 2 > oneRacket.Area.X + (oneRacket.Area.Width / 2) + ballExaminationProximity)
                                        //{
                                        //    ballVerticalMovement *= ballVerticalMovement > 0 ? 1 : -1;
                                        //}

                                        #endregion InDevelopment

                                        // The racket is sticky.
                                        if (oneRacket.StickyRacket)
                                        {
                                            // Stop the movement of the ball.
                                            ballList[j].BallInMove = false;

                                            // Set the horizontal movement of the ball to negative if not done already.
                                            if (ballList[j].HorizontalMovement > 0)
                                            {
                                                ballList[j].HorizontalMovement *= -1;
                                            }

                                            // Reposition the ball.
                                            if (ballList[j].Area.Y + ballList[j].Area.Width > oneRacket.Area.Y)
                                            {
                                                ballList[j].RepositionOnRacket(oneRacket);
                                            }
                                        }

                                        #region PlaySound

                                        // The sound is on.
                                        if (GetOption().IsSoundEnabled)
                                        {
                                            // Play the sound.
                                            mediaPlayer.Position = new TimeSpan(0);
                                            mediaPlayer.Play();
                                        }

                                        #endregion PlaySound
                                    }

                                    #endregion BallAndRacketContact
                                }
                            }

                            // There is at least one racket.
                            if (brickList.Count > 0)
                            {
                                // Check each brick.
                                for (int i = 0; i < brickList.Count; i++)
                                {
                                    #region BallAndBrickContact

                                    #region OldVersion

                                    //// The ball is at side of the brick.
                                    //if (!(ballList[j].Area.X + ballList[j].Area.Width / 2 < brickList[i].Area.X ||                           /* right */
                                    //    ballList[j].Area.X - ballList[j].Area.Width / 2 > brickList[i].Area.X + brickList[i].Area.Width ||   /* left */
                                    //    ballList[j].Area.Y + ballList[j].Area.Height / 2 < brickList[i].Area.Y ||                            /* bottom */
                                    //    ballList[j].Area.Y - ballList[j].Area.Height / 2 > brickList[i].Area.Y + brickList[i].Area.Height))  /* top */
                                    //{
                                    //    // If the ball is in contact with the brick
                                    //    if (ballList[j].BallType != Ball.BallsType.Steel)
                                    //    {
                                    //        // 
                                    //        if (ballList[j].Area.X + ballList[j].Area.Width / 2 >= brickList[i].Area.X) // r
                                    //        {
                                    //            // 
                                    //            if (ballList[j].Area.Y + ballList[j].Area.Height / 2 >= brickList[i].Area.Y) // rb
                                    //            {
                                    //                ballList[j].HorizontalMovement *= -1; // horizontal?
                                    //            }
                                    //            // 
                                    //            else if (ballList[j].Area.Y - ballList[j].Area.Height / 2 <= brickList[i].Area.Y + brickList[i].Area.Height) // rt
                                    //            {
                                    //                ballList[j].HorizontalMovement *= -1;
                                    //            }
                                    //            // 
                                    //            else
                                    //            {
                                    //                ballList[j].VerticalMovement *= -1;
                                    //            }
                                    //        }
                                    //        // 
                                    //        else if (ballList[j].Area.X + ballList[j].Area.Width / 2 <= brickList[i].Area.X + ballHorizontalMovement) // l
                                    //        {
                                    //            // 
                                    //            if (ballList[j].Area.Y + ballList[j].Area.Height / 2 >= brickList[i].Area.Y) // lb
                                    //            {
                                    //                ballList[j].HorizontalMovement *= -1;
                                    //            }
                                    //            // 
                                    //            else if (ballList[j].Area.Y - ballList[j].Area.Height / 2 <= brickList[i].Area.Y + brickList[i].Area.Height) // lt
                                    //            {
                                    //                ballList[j].HorizontalMovement *= -1;
                                    //            }
                                    //            // 
                                    //            else
                                    //            {
                                    //                ballList[j].VerticalMovement *= -1;
                                    //            }
                                    //        }
                                    //        // 
                                    //        else if (ballList[j].Area.Y + ballList[j].Area.Width / 2 >= brickList[i].Area.Y) // r
                                    //        {
                                    //            ballList[j].HorizontalMovement *= -1;
                                    //        }
                                    //        // 
                                    //        else if (ballList[j].Area.Y - ballList[j].Area.Width / 2 <= brickList[i].Area.Y + brickList[i].Area.Width) // l
                                    //        {
                                    //            ballList[j].HorizontalMovement *= -1;
                                    //        }
                                    //        // 
                                    //        else if (ballList[j].Area.Y + ballList[j].Area.Height / 2 >= brickList[i].Area.Y) // b
                                    //        {
                                    //            ballList[j].VerticalMovement *= -1;
                                    //        }
                                    //        // 
                                    //        else if (ballList[j].Area.Y - ballList[j].Area.Height / 2 <= brickList[i].Area.Y + brickList[i].Area.Height) // t
                                    //        {
                                    //            ballList[j].VerticalMovement *= -1;
                                    //        }
                                    //    }

                                    //    BrickContact(ballList[j], brickList[i]);
                                    //}

                                    #endregion OldVersion

                                    #region TestVersion

                                    //// The ball is at side of the brick.
                                    //if (!(ballList[j].Area.X + ballList[j].Area.Width / 2 < brickList[i].Area.X ||                          /* brick left side */
                                    //    ballList[j].Area.X + ballList[j].Area.Width / 2 > brickList[i].Area.X + brickList[i].Area.Width ||  /* brick right side */
                                    //    ballList[j].Area.Y + ballList[j].Area.Height / 2 < brickList[i].Area.Y ||                            /* brick top */
                                    //    ballList[j].Area.Y + ballList[j].Area.Height / 2 > brickList[i].Area.Y + brickList[i].Area.Height))  /* brick bottom */
                                    //{
                                    //    // If the ball is in contact with the brick and the examination proximity
                                    //    if (ballList[j].BallType != Ball.BallsType.Steel)
                                    //    {
                                    //        // 
                                    //        if (ballList[j].Area.X + ballList[j].Area.Width / 2 >= brickList[i].Area.X &&
                                    //            ballList[j].Area.X + ballList[j].Area.Width / 2 <= brickList[i].Area.X + brickList[i].Area.Width &&
                                    //            ((ballList[j].Area.Y + ballList[j].Area.Height / 2 >= brickList[i].Area.Y &&
                                    //            ballList[j].Area.Y + ballList[j].Area.Height / 2 - ballHorizontalMovement < brickList[i].Area.Y) ||
                                    //            (ballList[j].Area.Y + ballList[j].Area.Height / 2 <= brickList[i].Area.Y + brickList[i].Area.Height &&
                                    //            ballList[j].Area.Y + ballList[j].Area.Height / 2 - ballHorizontalMovement > brickList[i].Area.Y + brickList[i].Area.Height)))
                                    //        {
                                    //            // Horizontal direction change.
                                    //            ballList[j].HorizontalMovement *= -1;
                                    //        }
                                    //        // 
                                    //        else if (ballList[j].Area.Y + ballList[j].Area.Height / 2 >= brickList[i].Area.Y &&
                                    //                 ballList[j].Area.Y + ballList[j].Area.Height / 2 <= brickList[i].Area.Y + brickList[i].Area.Height &&
                                    //                 ((ballList[j].Area.X + ballList[j].Area.Width / 2 >= brickList[i].Area.X &&
                                    //                 ballList[j].Area.X + ballList[j].Area.Width / 2 - ballVerticalMovement < brickList[i].Area.X) ||
                                    //                 (ballList[j].Area.X + ballList[j].Area.Width / 2 <= brickList[i].Area.X + brickList[i].Area.Width &&
                                    //                 ballList[j].Area.X + ballList[j].Area.Width / 2 - ballVerticalMovement > brickList[i].Area.X + brickList[i].Area.Width)))
                                    //        {
                                    //            // Vertical direction change.
                                    //            ballList[j].VerticalMovement *= -1;
                                    //        }
                                    //        // 
                                    //        else if (ballList[j].Area.X + ballExaminationProximity > brickList[i].Area.X) // r
                                    //        {
                                    //            // 
                                    //            if (ballList[j].Area.Y + ballExaminationProximity > brickList[i].Area.Y) // rb
                                    //            {
                                    //                // Horizontal direction change.
                                    //                ballList[j].HorizontalMovement *= -1;
                                    //            }
                                    //            // 
                                    //            else if (ballList[j].Area.Y - ballExaminationProximity < brickList[i].Area.Y + brickList[i].Area.Height) // rt
                                    //            {
                                    //                // Horizontal direction change.
                                    //                ballList[j].HorizontalMovement *= -1;
                                    //            }
                                    //            // 
                                    //            else
                                    //            {
                                    //                // Vertical direction change.
                                    //                ballList[j].VerticalMovement *= -1;
                                    //            }
                                    //        }
                                    //        // 
                                    //        else if (ballList[j].Area.X + ballExaminationProximity < brickList[i].Area.X + ballHorizontalMovement) // l
                                    //        {
                                    //            // 
                                    //            if (ballList[j].Area.Y + ballExaminationProximity > brickList[i].Area.Y) // lb
                                    //            {
                                    //                // Horizontal direction change.
                                    //                ballList[j].HorizontalMovement *= -1;
                                    //            }
                                    //            // 
                                    //            else if (ballList[j].Area.Y - ballExaminationProximity < brickList[i].Area.Y + brickList[i].Area.Height) // lt
                                    //            {
                                    //                // Horizontal direction change.
                                    //                ballList[j].HorizontalMovement *= -1;
                                    //            }
                                    //            // 
                                    //            else
                                    //            {
                                    //                // Vertical direction change.
                                    //                ballList[j].VerticalMovement *= -1;
                                    //            }
                                    //        }
                                    //    }

                                    //    BrickContact(ballList[j], brickList[i]);
                                    //}
                                    //// The ball is at the corner of the brick.
                                    //else
                                    //{
                                    //    // No corner detection implemented.
                                    //}

                                    #endregion TestVersion

                                    #region NewVersion

                                    // 
                                    if (ballList[j].Area.X + ballList[j].Area.Width / 2 >= brickList[i].Area.X &&
                                        ballList[j].Area.X + ballList[j].Area.Width / 2 <= brickList[i].Area.X + brickList[i].Area.Width &&
                                        ballList[j].Area.Y + ballList[j].Area.Height / 2 >= brickList[i].Area.Y &&
                                        ballList[j].Area.Y + ballList[j].Area.Height / 2 <= brickList[i].Area.Y + brickList[i].Area.Height)
                                    {

                                    }

                                    #endregion NewVersion

                                    #endregion BallAndBrickContact
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
                                //// Add points to the score.
                                //scoreValue += oneBrick.ScorePoint;
                                //// Show the scorepints.
                                //ScoreLabel.Content = "Score: " + scoreValue;

                                // If the brick is lucky, then add bonus.
                                if (oneBrick.CalculateBonusChance())
                                {
                                    AddBonus(oneBrick);
                                }

                                brickList.Remove(oneBrick);
                                gameObjectList.Remove(oneBrick);
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
                            //// Add points to the score.
                            //scoreValue += oneBrick.ScorePoint;
                            //// Show the scorepints.
                            //ScoreLabel.Content = "Score: " + scoreValue;

                            // The brick is lucky, then add bonus.
                            if (oneBrick.CalculateBonusChance())
                            {
                                AddBonus(oneBrick);
                            }

                            brickList.Remove(oneBrick);
                            gameObjectList.Remove(oneBrick);
                        }
                    }
                }
                // The ball is a steel ball.
                else
                {
                    //// Add points to the score.
                    //scoreValue += oneBrick.ScorePoint;
                    //// Show the scorepints.
                    //ScoreLabel.Content = "Score: " + scoreValue;

                    // If the brick is lucky, then add bonus.
                    if (oneBrick.CalculateBonusChance())
                    {
                        AddBonus(oneBrick);
                    }

                    brickList.Remove(oneBrick);
                    gameObjectList.Remove(oneBrick);
                }

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
        /// 
        /// </summary>
        public void WindowLoaded()
        {
            try
            {
                // If no map or no options file was found then close the window.
                if (!String.IsNullOrEmpty(currentMapPath) && currentMapPath == "notfound")
                {
                    MessageBox.Show("Couldn't find the map file.", "Error");

                    //MapSelection returnToMapSelection = new MapSelection();
                    //returnToMapSelection.Show();
                    //Close();
                }
                else if (String.IsNullOrEmpty(currentMapPath))
                {
                    MessageBox.Show("Couldn't find the options xml file.", "Error");

                    //MapSelection returnToMapSelection = new MapSelection();
                    //returnToMapSelection.Show();
                    //Close();
                }

                //playerLife = gamePresets != null && gamePresets.LifePoint != 0 ? gamePresets.LifePoint : 3;
                //playerScorePoint = gamePresets != null && gamePresets.ScorePoint != 0 ? gamePresets.ScorePoint : 0;

                //// Show the scorepoints.
                //ScoreLabel.Content = "Score: " + scoreValue;
                //// Show the lifepoints.
                //LifeLabel.Content = "Life: " + lifePoint;
                //// Show the time.
                //TimeLabel.Content = "Time: " + timeOfGame.ToString("HH:mm:ss");
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
        public void CheckForGameOver(ref DispatcherTimer timer)
        {
            try
            {
                // There is at least one ball.
                if (ballList.Count > 0)
                {
                    int steelBallCount = 0;

                    // Check each ball.
                    foreach (Ball oneBall in ballList)
                    {
                        // See if there is any steel ball.
                        if (oneBall.BallType == Ball.BallsType.Steel)
                        {
                            steelBallCount++;
                        }
                    }

                    // There is at least one steal ball.
                    if (steelBallCount > 0)
                    {
                        // No bricks left.
                        if (brickList.Count == 0)
                        {
                            // No bonuses left.
                            if (bonusList.Count == 0)
                            {
                                gameIsOver = true;
                                gameOverStatus = "success";
                            }
                        }
                    }
                    // There are no steal balls.
                    else
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

                            // No steel bricks left.
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
                }

                // The game is over, the status is given and the game is still is session.
                if (gameIsOver && !string.IsNullOrEmpty(gameOverStatus) && gameInSession)
                {
                    GameOver(gameOverStatus, timer);
                }
            }
            catch (Exception e)
            {
                errorLogViewModel.LogError(e);
            }
        }

        /// <summary>
        /// Handles the highscores.
        /// </summary>
        private void HighScores(int score)
        {
            try
            {
                //GameOver submitScore = new GameOver();
                //submitScore.ScoreLabel.Content = score;
                //submitScore.Show();
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
        private void GameOver(string status, DispatcherTimer dispatcherTimer)
        {
            try
            {
                #region Fail

                if (status == "fail")
                {
                    dispatcherTimer.Stop();

                    MessageBox.Show("You've failed.", "Game Over");

                    gameIsOver = false;
                    gameOverStatus = null;

                    if (CheckHighScores(playerScorePoint))
                    {
                        HighScores(playerScorePoint);
                        //Close();
                    }
                    else
                    {
                        //MapSelection returnToMap = new MapSelection();
                        //returnToMap.Show();
                        //Close();
                    }
                }

                #endregion Fail

                #region Success

                else if (status == "success")
                {
                    dispatcherTimer.Stop();

                    MessageBox.Show("You've succeeded.", "Game Over");

                    gameIsOver = false;
                    gameOverStatus = null;

                    #region NotLastMap

                    if (GetOption().MapNumber < mapMaxNumber)
                    {
                        #region Continue

                        if (MessageBox.Show("You've succeeded. \n Would you like to continue.", "Game Over", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                optionsViewModel.OptionModel.MapNumber += 1;
                                optionsViewModel.SaveToXml();
                            }
                            catch
                            {

                            }

                            //Drawer newMap = new Drawer();
                            //newMap.gamePresets = new GamePresets(lifePoint, scoreValue);
                            //newMap.Show();
                            //Close();
                        }

                        #endregion Constinue

                        #region Exit

                        else
                        {
                            if (CheckHighScores(playerScorePoint))
                            {
                                HighScores(playerScorePoint);
                                //Close();
                            }
                            else
                            {
                                //MapSelection returnToMap = new MapSelection();
                                //returnToMap.Show();
                                //Close();
                            }
                        }

                        #endregion Exit
                    }

                    #endregion NotLastMap

                    #region LastMap

                    else
                    {
                        if (CheckHighScores(playerScorePoint))
                        {
                            HighScores(playerScorePoint);
                            //Close();
                        }
                        else
                        {
                            //MapSelection returnToMap = new MapSelection();
                            //returnToMap.Show();
                            //Close();
                        }
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
        /// Checks if the score is in the highscores.
        /// </summary>
        /// <param name="scoreValue">The score.</param>
        /// <returns>True if the score can be submitted, false if not.</returns>
        private bool CheckHighScores(int score)
        {
            try
            {
                bool retVal = false;
                List<HighScoreModel> scores = scoreXmlAccess.LoadScores();
                int i = 0;

                while (i < scores.Count && !retVal)
                {
                    if (int.Parse(scores[i].PlayerScore) < playerScorePoint)
                    {
                        retVal = true;
                    }

                    i++;
                }

                if (i < highscoreLimit && !retVal)
                {
                    retVal = true;
                }

                return retVal;
            }
            catch (Exception e)
            {
                errorLogViewModel.LogError(e);

                return false;
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
                gameObjectList.Clear();
                if (brickList.Count > 0)
                {
                    for (int i = 0; i < brickList.Count; i++)
                    {
                        gameObjectList.Add(brickList[i]);
                    }
                }

                // Add new racket.
                Racket racket = new Racket((canvasWidth / 2) - (racketWidth / 2), canvasHeight - racketHeight, racketHeight, racketWidth,
                    @"..\..\Resources\Media\Racket\normalracket.jpg");
                racket.Direction = Racket.Directions.Stay;
                racket.StickyRacket = false;
                racketList.Add(racket);
                gameObjectList.Add(racket);

                // Add new ball.
                Ball ball = new Ball((canvasWidth / 2) - ballRadius, canvasHeight - racketHeight - (ballRadius * 2), ballRadius * 2, ballRadius * 2,
                    @"..\..\Resources\Media\Ball\normalball.jpg", ballHorizontalMovement, ballVerticalMovement, Ball.BallsType.Normal);
                ball.VerticalMovement = ballVerticalMovement > 0 ? ballVerticalMovement : -ballVerticalMovement;
                ball.HorizontalMovement = ballHorizontalMovement < 0 ? ballHorizontalMovement : -ballHorizontalMovement;
                ball.BallInMove = false;
                ballList.Add(ball);
                gameObjectList.Add(ball);
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
                        // There is at least one bonus.
                        if (bonusList.Count > 0)
                        {
                            // Check each bonus.
                            for (int i = 0; i < bonusList.Count; i++)
                            {
                                // The racket and the bonus overleap somewhere.
                                if (oneRacket.Area.X < bonusList[i].Area.X + bonusList[i].Area.Width &&    /* bonus rigth side */
                                    oneRacket.Area.X + oneRacket.Area.Width > bonusList[i].Area.X &&       /* bonus left side */
                                    oneRacket.Area.Y < bonusList[i].Area.Y + bonusList[i].Area.Height)     /* bonus bottom */
                                {
                                    playerScorePoint += bonusList[i].ScorePoint;
                                    //ScoreLabel.Content = "Score: " + scoreValue;

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
                                            Ball ball = new Ball(oneRacket.Area.X + (oneRacket.Area.Width / 2) - ballRadius, oneRacket.Area.Y - (ballRadius * 2),
                                                ballRadius * 2, ballRadius * 2, @"..\..\Resources\Media\Ball\normalball.jpg", 0, 0, Ball.BallsType.Normal);
                                            ball.VerticalMovement = ballVerticalMovement > 0 ? ballVerticalMovement : -ballVerticalMovement;
                                            ball.HorizontalMovement = ballHorizontalMovement < 0 ? ballHorizontalMovement : -ballHorizontalMovement;
                                            ball.BallInMove = false;
                                            ballList.Add(ball);
                                            gameObjectList.Add(ball);
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

                                    //LifeLabel.Content = "Life: " + lifePoint;

                                    // The player's life points reached 0, game over.
                                    if (playerLife <= 0)
                                    {
                                        gameOverStatus = "fail";
                                        gameIsOver = true;
                                    }

                                    #endregion AddBonusEffect

                                    bonusList.Remove(bonusList[i]);
                                    gameObjectList.Remove(bonusList[i]);
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
        private void PresetValues()
        {
            try
            {
                #region PresetValues

                highscoreLimit = 10;
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

                try
                {
                    if (GetOption().MapNumber > 0 && GetOption().MapNumber < 6)
                    {
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
                    if (!string.IsNullOrEmpty(currentMapPath) && currentMapPath != "notfound")
                    {
                        // Add a racket.
                        racketList.Add(new Racket(canvasWidth / 2 - racketWidth / 2, canvasHeight - racketHeight, racketWidth, racketHeight, @"..\..\Resources\Media\Racket\normalracket.jpg"));
                        racketList[0].Direction = Racket.Directions.Stay;
                        racketList[0].StickyRacket = false;
                        gameObjectList.Add(racketList[0]);

                        // Add a ball.
                        ballList.Add(new Ball(canvasWidth / 2 - ballRadius, canvasHeight - racketHeight - ballRadius * 2, ballRadius * 2, ballRadius * 2, @"..\..\Resources\Media\Ball\normalball.jpg", ballHorizontalMovement, ballVerticalMovement, Ball.BallsType.Normal));
                        ballList[0].BallInMove = false;
                        gameObjectList.Add(ballList[0]);

                        // Add the bricks.
                        brickList = mapTxtAccess.LoadMap(currentMapPath, brickWidth, brickHeight);
                        if (brickList.Count > 0)
                        {
                            for (int i = 0; i < brickList.Count; i++)
                            {
                                gameObjectList.Add(brickList[i]);
                            }
                        }
                    }

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
                            bonusList.Remove(bonusList[i]);
                            gameObjectList.Remove(bonusList[i]);
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

                Bonus bonus = new Bonus(oneBrick.Area.X + (oneBrick.Area.Width / 2) - (bonusWidth / 2), oneBrick.Area.Y + oneBrick.Area.Height, bonusHeight, bonusWidth, bonusImage, type);
                bonus.ScorePoint = 5;
                bonusList.Add(bonus);
                gameObjectList.Add(bonus);

                if (bonus.Descend(bonusSpeed, canvasWidth, canvasHeight))
                {
                    bonusList.Remove(bonus);
                    gameObjectList.Remove(bonus);
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
                            // Move the racket.
                            oneRacket.MouseMove(racketSpeed, canvasWidth, e.GetPosition(sender).X);

                            // There is at least one ball.
                            if (ballList.Count > 0)
                            {
                                // Check each ball.
                                foreach (Ball oneBall in ballList)
                                {
                                    // The ball is on the racket.
                                    if (!oneBall.BallInMove)
                                    {
                                        // Move the ball.
                                        oneBall.MouseMove(racketSpeed, canvasWidth, e.GetPosition(sender).X, oneRacket);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            { }
        }

        /// <summary>
        /// Handles the left button click of the mouse.
        /// </summary>
        /// <param name="e">The mouse button event.</param>
        /// <param name="dispatcherTimer">The timer.</param>
        public void MouseLeftButtonDown(MouseButtonEventArgs e, ref DispatcherTimer dispatcherTimer)
        {
            try
            {
                // The mouse is a controller item and the game is not paused.
                if (GetOption().IsMouseEnabled && !gameIsPaused)
                {
                    // The timer is not going and the game has not been started.
                    if (!dispatcherTimer.IsEnabled && !gameInSession)
                    {
                        // Start the game.
                        dispatcherTimer.Start();
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
            catch
            { }
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
            catch
            { }
        }

        /// <summary>
        /// Handle all the key events.
        /// </summary>
        /// <param name="e">The key event.</param>
        /// <param name="dispatcherTimer">The timer.</param>
        public void KeyDown(KeyEventArgs e, ref DispatcherTimer dispatcherTimer)
        {
            try
            {
                #region EscapeKey

                // The pressed key is the Esc key.
                if (e.Key == Key.Escape)
                {
                    // Pause the game and send message.
                    dispatcherTimer.Stop();
                    gameIsPaused = true;
                    //TimeLabel.Content = "The game is paused.";

                    if (MessageBox.Show("Do you want to quit?", "Warning", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        //View.DifficultySelectionWindow returnToMapSelection = new View.DifficultySelectionWindow();
                        //returnToMapSelection.Show();
                        //Close();
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
                                    oneRacket.Direction = Racket.Directions.Left;
                                    oneRacket.KeyMove(racketSpeed, canvasWidth);

                                    // There is at least one ball.
                                    if (ballList.Count > 0)
                                    {
                                        // Check each ball.
                                        foreach (var oneBall in ballList)
                                        {
                                            // The ball is on the racket.
                                            if (!oneBall.BallInMove)
                                            {
                                                // Move the ball with the racket left if ball is not moving.
                                                oneBall.KeyMove(racketSpeed, canvasWidth, oneRacket);
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
                                    oneRacket.Direction = Racket.Directions.Right;
                                    oneRacket.KeyMove(racketSpeed, canvasWidth);

                                    // There is at least one ball.
                                    if (ballList.Count > 0)
                                    {
                                        // Check each ball.
                                        foreach (var oneBall in ballList)
                                        {
                                            // The ball is on the racket.
                                            if (!oneBall.BallInMove)
                                            {
                                                // Move the ball with the racket right if ball is not moving.
                                                oneBall.KeyMove(racketSpeed, canvasWidth, oneRacket);
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
                        // The keyboard is a controller item, the game is not paused and the game didn't begin yet.
                        if (GetOption().IsKeyboardEnabled && !gameIsPaused && !gameInSession)
                        {
                            // The timer didn't start yet.
                            if (!dispatcherTimer.IsEnabled)
                            {
                                // Start the game.
                                dispatcherTimer.Start();
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
                        // The game is not paused.
                        if (!gameIsPaused)
                        {
                            // Pause the game.
                            dispatcherTimer.Stop();
                            gameIsPaused = true;
                            //TimeLabel.Content = "The game is paused.";
                        }
                        // The game is paused.
                        else
                        {
                            // Continue the game.
                            dispatcherTimer.Start();
                            gameIsPaused = false;
                            //TimeLabel.Content = "Time: " + timeOfGame.ToString("HH:mm:ss");
                        }
                    }

                    #endregion PauseKey
                }

                #endregion OptionBindedKeys
            }
            catch
            { }
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
            catch
            {
                return null;
            }
        }

        #endregion KeyboardAndMouse

        #endregion Methods
    }
}
