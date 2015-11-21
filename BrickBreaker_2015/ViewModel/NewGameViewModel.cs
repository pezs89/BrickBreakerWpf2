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
        /// Presets the values.
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
                    racketList.Add(new Racket(canvasWidth / 2 - racketWidth / 2, canvasHeight - racketHeight, racketWidth, racketHeight, @"..\..\Resources\Media\Racket\normalracket.jpg"));
                    racketList[0].Direction = Racket.Directions.Stay;
                    racketList[0].StickyRacket = false;
                    gameObjectList.Add(racketList[0]);

                    ballList.Add(new Ball(canvasWidth / 2 - ballRadius, canvasHeight - racketHeight - ballRadius * 2, ballRadius * 2, ballRadius * 2, ballHorizontalMovement, ballVerticalMovement, Ball.BallsType.Normal, @"..\..\Resources\Media\Ball\normalball.jpg"));
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
                }

                mediaPlayer.Open(new Uri(@"..\..\Resources\Media\Sounds\play_this.mp3", UriKind.Relative));
            }
            catch
            { }

            #endregion FillLists
        }

        #region InProgress

        /// <summary>
        /// 
        /// </summary>
        public void WindowLoaded()
        {
            //// If no map or no options file was found then close the window.
            //if (!String.IsNullOrEmpty(currentMapPath) && currentMapPath == "notfound")
            //{
            //    MessageBox.Show("Couldn't find the map file.", "Error");

            //    MapSelection returnToMapSelection = new MapSelection();
            //    returnToMapSelection.Show();
            //    Close();
            //}
            //else if (String.IsNullOrEmpty(currentMapPath))
            //{
            //    MessageBox.Show("Couldn't find the options xml file.", "Error");

            //    MapSelection returnToMapSelection = new MapSelection();
            //    returnToMapSelection.Show();
            //    Close();
            //}

            //lifePoint = gamePresets != null && gamePresets.LifePoint != 0 ? gamePresets.LifePoint : 3;
            //scoreValue = gamePresets != null && gamePresets.ScorePoint != 0 ? gamePresets.ScorePoint : 0;

            //ScoreLabel.Content = "Score: " + scoreValue;
            //// Show the scorepoints.
            //LifeLabel.Content = "Life: " + lifePoint;
            //// Show the lifepoints.
            //TimeLabel.Content = "Time: " + timeOfGame.ToString("HH:mm:ss");
            //// Show the time.
        }

        /// <summary>
        /// 
        /// </summary>
        public void TimerTick()
        {
            //// Draw.
            //MoveObjects();
            //BallAtContact();
            //RacketAtContactWithBonus();

            #region RefreshValues

            //timeOfGame = timeOfGame.AddMilliseconds(timeSpan);
            //// Add the timeSpan value to the timeOfGame in every tick to make the time go.
            //TimeLabel.Content = "Time: " + timeOfGame.ToString("HH:mm:ss");
            //// Show the time.

            #endregion RefreshValues

            //RefreshCanvas();

            #region GameOver

            //if (ballList.Count > 0)
            //{
            //    int steelBallCount = 0;

            //    foreach (var oneBall in ballList)
            //    {
            //        // See if there is any steel ball.
            //        if (oneBall.TypeOfBall == Ball.ballType.Steel)
            //        {
            //            steelBallCount++;
            //        }
            //    }

            //    if (steelBallCount > 0)
            //    {
            //        // If there is at least one steel ball.
            //        if (brickList.Count == 0)
            //        {
            //            // If no brick left.
            //            if (bonusList.Count == 0)
            //            {
            //                // If no bonus left.
            //                gameOver = true;
            //                gameOverStatus = "success";
            //            }
            //        }

            //    }
            //    else
            //    {
            //        // If no steel ball.
            //        if (brickList.Count > 0)
            //        {
            //            // There are still bricks left.
            //            int notSteelBrickCount = 0;

            //            foreach (var oneBrick in brickList)
            //            {
            //                // See how many not steel bricks are there
            //                if (oneBrick.TypeOfBrick != Brick.brickType.Steel)
            //                {
            //                    notSteelBrickCount++;
            //                }
            //            }

            //            if (notSteelBrickCount == 0)
            //            {
            //                // If only steel bricks left.
            //                gameOver = true;
            //                gameOverStatus = "success";
            //            }
            //        }
            //        else
            //        {
            //            // If no brick left.
            //            if (bonusList.Count == 0)
            //            {
            //                // If no bonus left.
            //                gameOver = true;
            //                gameOverStatus = "success";
            //            }
            //        }
            //    }
            //}

            //if (gameOver && !String.IsNullOrEmpty(gameOverStatus) && gameInSession)
            //{
            //    GameOver(gameOverStatus);
            //}

            #endregion GameOver
        }

        /// <summary>
        /// Checks if the racket is in contact with a bonus.
        /// </summary>
        private void RacketAtContactWithBonus()
        {
            //if (racketList.Count > 0)
            //{
            //    foreach (var oneRacket in racketList)
            //    {
            //        if (bonusList.Count > 0)
            //        {
            //            for (int i = 0; i < bonusList.Count; i++)
            //            {
            //                if (oneRacket.PositionX < bonusList[i].PositionX + bonusList[i].Width &&    /* bonus rigth side */
            //                    oneRacket.PositionX + oneRacket.Width > bonusList[i].PositionX &&       /* bonus left side */
            //                    oneRacket.PositionY < bonusList[i].PositionY + bonusList[i].Height)     /* bonus bottom */
            //                {
            //                    scoreValue += bonusList[i].ScorePoint;
            //                    ScoreLabel.Content = "Score: " + scoreValue;

                                #region AddBonusEffect

                                //switch (bonusList[i].TypeOfBonus)
                                //{
                                //    case Bonus.bonusType.LifeUp:
                                //        lifePoint++;
                                //        break;
                                //    case Bonus.bonusType.LifeDown:
                                //        lifePoint--;
                                //        break;
                                //    case Bonus.bonusType.NewBall:
                                //        Ball ball = new Ball(oneRacket.PositionX + (oneRacket.Width / 2) - ballRadius, oneRacket.PositionY - (ballRadius * 2), ballRadius, Ball.ballType.Normal, @"media\ball\normalball.jpg");
                                //        ball.VerticalMovement = ballVerticalMovement > 0 ? ballVerticalMovement : -ballVerticalMovement;
                                //        ball.HorizontalMovement = ballHorizontalMovement < 0 ? ballHorizontalMovement : -ballHorizontalMovement;
                                //        ball.BallInMove = false;
                                //        ballList.Add(ball);
                                //        canvasLayer.Children.Add(ball.GetEllipse());
                                //        break;
                                //    case Bonus.bonusType.RacketLengthen:
                                //        oneRacket.Width += (oneRacket.Width < racketMaxSize ? racketDifference : 0);
                                //        break;
                                //    case Bonus.bonusType.RacketShorten:
                                //        oneRacket.Width -= (oneRacket.Width > racketMinSize ? racketDifference : 0);
                                //        break;
                                //    case Bonus.bonusType.BallBigger:
                                //        if (ballList.Count > 0)
                                //        {
                                //            foreach (var oneBall in ballList)
                                //            {
                                //                if (oneBall.PositionX + (bigBall * 2) > canvasLayer.Width)
                                //                {
                                //                    oneBall.PositionX -= ((bigBall - ballRadius) * 2);
                                //                }
                                //                else if (oneBall.PositionY + (bigBall * 2) + racketHeight > canvasLayer.Height)
                                //                {
                                //                    oneBall.PositionY -= ((bigBall - ballRadius) * 2);
                                //                }
                                //                // Reposition the ball, so that it will not trigger an error when obtaining bonus effect.

                                //                oneBall.Radius = bigBall;
                                //            }
                                //        }
                                //        break;
                                //    case Bonus.bonusType.BallSmaller:
                                //        if (ballList.Count > 0)
                                //        {
                                //            foreach (var oneBall in ballList)
                                //            {
                                //                oneBall.Radius = smallBall;
                                //            }
                                //        }
                                //        break;
                                //    case Bonus.bonusType.StickyRacket:
                                //        if (!oneRacket.StickyRacket)
                                //        {
                                //            oneRacket.StickyRacket = true;
                                //            oneRacket.RacketImage = @"media\racket\stickyracket.jpg";
                                //        }
                                //        break;
                                //    case Bonus.bonusType.HardBall:
                                //        if (ballList.Count > 0)
                                //        {
                                //            foreach (var oneBall in ballList)
                                //            {
                                //                oneBall.TypeOfBall = Ball.ballType.Hard;
                                //                oneBall.BallImage = @"media\ball\hardball.jpg";
                                //            }
                                //        }
                                //        break;
                                //    case Bonus.bonusType.SteelBall:
                                //        if (ballList.Count > 0)
                                //        {
                                //            foreach (var oneBall in ballList)
                                //            {
                                //                oneBall.TypeOfBall = Ball.ballType.Steel;
                                //                oneBall.BallImage = @"media\ball\steelball.jpg";
                                //            }
                                //        }
                                //        break;
                                //}
                                //// Add the bonus effect.

                                //LifeLabel.Content = "Life: " + lifePoint;

                                //if (lifePoint <= 0)
                                //{
                                //    gameOverStatus = "fail";
                                //    gameOver = true;
                                //}

                                #endregion AddBonusEffect

            //                    bonusList.Remove(bonusList[i]);
            //                }
            //            }
            //        }
            //    }
            //}

            //RefreshCanvas();
        }

        /// <summary>
        /// Checks if the ball is in contact with an object.
        /// </summary>
        private void BallAtContact()
        {
            //if (ballList.Count > 0)
            //{
            //    for (int j = 0; j < ballList.Count; j++)
            //    {
            //        // Check every ball.
                    #region BallAndWallContact

                    //if (ballList[j].PositionX < 0 ||                                                    /* Left wall */
                    //    ballList[j].PositionX + (ballList[j].Radius * 2) > canvasLayer.ActualWidth ||   /* Right wall */
                    //    ballList[j].PositionY < 0 ||                                                    /* Top wall */
                    //    ballList[j].PositionY + (ballList[j].Radius * 2) > canvasLayer.ActualHeight)    /* Bottom wall */
                    //{
                    //    // If the ball is at the walls of the canvas.
                    //    if (ballList[j].PositionX < 0 || ballList[j].PositionX + (ballList[j].Radius * 2) > canvasLayer.ActualWidth)
                    //    {
                    //        // Side walls.
                    //        // Vertical direction change.
                    //        ballList[j].VerticalMovement *= -1;
                    //    }
                    //    else if (ballList[j].PositionY <= 0)
                    //    {
                    //        // Top wall.
                    //        // Horizontal direction change.
                    //        ballList[j].HorizontalMovement *= -1;
                    //    }
                    //    else if (ballList[j].PositionY + (ballList[j].Radius * 2) > canvasLayer.ActualHeight)
                    //    {
                    //        // Bottom wall.
                    //        if (ballList.Count == 1)
                    //        {
                    //            lifePoint -= 1;
                    //            LifeLabel.Content = "Life: " + lifePoint;

                    //            DisposeOfBall();
                    //        }
                    //        else
                    //        {
                    //            ballList.RemoveAt(j);
                    //        }

                    //        if (lifePoint == 0)
                    //        {
                    //            gameOver = true;
                    //            gameOverStatus = "fail";
                    //        }
                    //        else if (lifePoint < 0)
                    //        {
                    //            MessageBox.Show("An error occured.", "Error");
                    //            gameOver = true;
                    //            gameOverStatus = "fail";
                    //        }
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        // Corners of the canvas.
                    //        // Horizontal direction change.
                    //        ballList[j].HorizontalMovement *= -1;
                    //        // Vertical direction change.
                    //        ballList[j].VerticalMovement *= -1;
                    //    }

                    //    if (optionsSettings.SoundIsOn)
                    //    {
                    //        mPlayer.Position = new TimeSpan(0);
                    //        mPlayer.Play();
                    //    }
                    //}

                    #endregion BallAndWallContact

                    //else
                    //{
                    //    // If the ball is not at the sides of the canvas.
                    //    if (racketList.Count > 0)
                    //    {
                    //        foreach (var oneRacket in racketList)
                    //        {
                    //            // Check with racket.
                                #region BallAndRacketContact

                                //if (ballList[j].PositionX + ballList[j].Radius > oneRacket.PositionX &&                     /*racket left side*/
                                //    ballList[j].PositionX + ballList[j].Radius < oneRacket.PositionX + oneRacket.Width &&   /*racket right side*/
                                //    ballList[j].PositionY + (ballList[j].Radius * 2) > canvasLayer.Height - racketHeight)   /*racket top*/
                                //{
                                //    // Horizontal direction change.
                                //    ballList[j].HorizontalMovement *= -1;

                                //    //if (ballList[j].PositionX + ballList[j].Radius < oneRacket.PositionX + (oneRacket.Width / 2) - ballExaminationProximity)
                                //    //{
                                //    //    // The left of the racket.
                                //    //    ballVerticalMovement *= ballVerticalMovement < 0 ? 1 : -1;
                                //    //    double diff = () / ((oneRacket.Width / 2) - ballExaminationProximity);
                                //    //}
                                //    //else if (ballList[j].PositionX + ballList[j].Radius >= oneRacket.PositionX + (oneRacket.Width / 2) - ballExaminationProximity &&
                                //    //         ballList[j].PositionX + ballList[j].Radius <= oneRacket.PositionX + (oneRacket.Width / 2) + ballExaminationProximity)
                                //    //{
                                //    //    // The middle of the racket.
                                //    //    ballVerticalMovement = 0;
                                //    //}
                                //    //else if (ballList[j].PositionX + ballList[j].Radius > oneRacket.PositionX + (oneRacket.Width / 2) + ballExaminationProximity)
                                //    //{
                                //    //    // The right of the racket.
                                //    //    ballVerticalMovement *= ballVerticalMovement > 0 ? 1 : -1;

                                //    //}
                                //    // TODO: complex movement calculation based on where the ball landed

                                //    if (oneRacket.StickyRacket)
                                //    {
                                //        ballList[j].BallInMove = false;

                                //        if (ballList[j].PositionY + (ballList[j].Radius * 2) > oneRacket.PositionY)
                                //        {
                                //            ballList[j].PositionY = oneRacket.PositionY - (ballList[j].Radius * 2);
                                //        }
                                //    }
                                //    // TODO: bug with ball when racker is sticky

                                //    if (optionsSettings.SoundIsOn)
                                //    {
                                //        mPlayer.Position = new TimeSpan(0);
                                //        mPlayer.Play();
                                //    }
                                //}

                                #endregion BallAndRacketContact
                        //    }
                        //}

                        //if (brickList.Count > 0)
                        //{
                        //    for (int i = 0; i < brickList.Count; i++)
                        //    {
                        //        // Check every brick.
                                #region BallAndBrickContact

                                #region OldVersion

                                //if (!(ballList[j].PositionX + ballList[j].Radius < brickList[i].PositionX || /**/
                                //    ballList[j].PositionX - ballList[j].Radius > brickList[i].PositionX + brickList[i].Width || /**/
                                //    ballList[j].PositionY + ballList[j].Radius < brickList[i].PositionY || /**/
                                //    ballList[j].PositionY - ballList[j].Radius > brickList[i].PositionY + brickList[i].Height)) /**/
                                //{
                                //    // Sides
                                //    // TODO: Bug at contact with brick.
                                //    // If the ball is in contact with the brick
                                //    if (ballList[j].TypeOfBall != Ball.ballType.Steel)
                                //    {
                                //        if (ballList[j].PositionX + ballList[j].Radius > brickList[i].PositionX) // r
                                //        {
                                //            if (ballList[j].PositionY + ballList[j].Radius > brickList[i].PositionY) // rb
                                //            {
                                //                ballList[j].HorizontalMovement *= -1; // horizontal?
                                //            }
                                //            else if (ballList[j].PositionY - ballList[j].Radius < brickList[i].PositionY + brickList[i].Height) // rt
                                //            {
                                //                ballList[j].HorizontalMovement *= -1;
                                //            }
                                //            else
                                //            {
                                //                ballList[j].VerticalMovement *= -1;
                                //            }
                                //        }
                                //        else if (ballList[j].PositionX + ballList[j].Radius < brickList[i].PositionX + ballHorizontalMovement) // l
                                //        {
                                //            if (ballList[j].PositionY + ballList[j].Radius > brickList[i].PositionY) // lb
                                //            {
                                //                ballList[j].HorizontalMovement *= -1;
                                //            }
                                //            else if (ballList[j].PositionY - ballList[j].Radius < brickList[i].PositionY + brickList[i].Height) // lt
                                //            {
                                //                ballList[j].HorizontalMovement *= -1;
                                //            }
                                //            else
                                //            {
                                //                ballList[j].VerticalMovement *= -1;
                                //            }
                                //        }
                                //        else if (ballList[j].PositionY + ballList[j].Radius > brickList[i].PositionY) // r
                                //        {
                                //            ballList[j].HorizontalMovement *= -1;
                                //        }
                                //        else if (ballList[j].PositionY - ballList[j].Radius < brickList[i].PositionY + brickList[i].Width) // l
                                //        {
                                //            ballList[j].HorizontalMovement *= -1;
                                //        }
                                //        else if (ballList[j].PositionY + ballList[j].Radius > brickList[i].PositionY) // b
                                //        {
                                //            ballList[j].VerticalMovement *= -1;
                                //        }
                                //        else if (ballList[j].PositionY - ballList[j].Radius < brickList[i].PositionY + brickList[i].Height) // t
                                //        {
                                //            ballList[j].VerticalMovement *= -1;
                                //        }
                                //    }

                                //    BrickContact(ballList[j], brickList[i]);
                                //}

                                #endregion OldVersion

                                #region TestVersion

                                //if (!(ballList[j].PositionX + ballList[j].Radius < brickList[i].PositionX ||                      /* brick left side */
                                //    ballList[j].PositionX + ballList[j].Radius > brickList[i].PositionX + brickList[i].Width ||   /* brick right side */
                                //    ballList[j].PositionY + ballList[j].Radius < brickList[i].PositionY ||                        /* brick top */
                                //    ballList[j].PositionY + ballList[j].Radius > brickList[i].PositionY + brickList[i].Height))   /* brick bottom */
                                //{
                                //    // Sides
                                //    // If the ball is in contact with the brick and the examination proximity
                                //    if (ballList[j].TypeOfBall != Ball.ballType.Steel)
                                //    {
                                //        // TODO: check points
                                //        if (ballList[j].PositionX + ballList[j].Radius >= brickList[i].PositionX &&
                                //            ballList[j].PositionX + ballList[j].Radius <= brickList[i].PositionX + brickList[i].Width &&
                                //            ((ballList[j].PositionY + ballList[j].Radius >= brickList[i].PositionY &&
                                //            ballList[j].PositionY + ballList[j].Radius - ballHorizontalMovement < brickList[i].PositionY) ||
                                //            (ballList[j].PositionY + ballList[j].Radius <= brickList[i].PositionY + brickList[i].Height &&
                                //            ballList[j].PositionY + ballList[j].Radius - ballHorizontalMovement > brickList[i].PositionY + brickList[i].Height)))
                                //        {
                                //            // Horizontal direction change.
                                //            ballList[j].HorizontalMovement *= -1;
                                //        }
                                //        else if (ballList[j].PositionY + ballList[j].Radius >= brickList[i].PositionY &&
                                //                 ballList[j].PositionY + ballList[j].Radius <= brickList[i].PositionY + brickList[i].Height &&
                                //                 ((ballList[j].PositionX + ballList[j].Radius >= brickList[i].PositionX &&
                                //                 ballList[j].PositionX + ballList[j].Radius - ballVerticalMovement < brickList[i].PositionX) ||
                                //                 (ballList[j].PositionX + ballList[j].Radius <= brickList[i].PositionX + brickList[i].Width &&
                                //                 ballList[j].PositionX + ballList[j].Radius - ballVerticalMovement > brickList[i].PositionX + brickList[i].Width)))
                                //        {
                                //            // Vertical direction change.
                                //            ballList[j].VerticalMovement *= -1;
                                //        }

                                //        //    else if (ballList[j].PositionX + ballExaminationProximity > brickList[i].PositionX) // r
                                //        //    {
                                //        //        if (ballList[j].PositionY + ballExaminationProximity > brickList[i].PositionY) // rb
                                //        //        {
                                //        //            // Horizontal direction change.
                                //        //            ballList[j].HorizontalMovement *= -1;
                                //        //        }
                                //        //        else if (ballList[j].PositionY - ballExaminationProximity < brickList[i].PositionY + brickList[i].Height) // rt
                                //        //        {
                                //        //            // Horizontal direction change.
                                //        //            ballList[j].HorizontalMovement *= -1;
                                //        //        }
                                //        //        else
                                //        //        {
                                //        //            // Vertical direction change.
                                //        //            ballList[j].VerticalMovement *= -1;
                                //        //        }
                                //        //    }
                                //        //    else if (ballList[j].PositionX + ballExaminationProximity < brickList[i].PositionX + ballHorizontalMovement) // l
                                //        //    {
                                //        //        if (ballList[j].PositionY + ballExaminationProximity > brickList[i].PositionY) // lb
                                //        //        {
                                //        //            // Horizontal direction change.
                                //        //            ballList[j].HorizontalMovement *= -1;
                                //        //        }
                                //        //        else if (ballList[j].PositionY - ballExaminationProximity < brickList[i].PositionY + brickList[i].Height) // lt
                                //        //        {
                                //        //            // Horizontal direction change.
                                //        //            ballList[j].HorizontalMovement *= -1;
                                //        //        }
                                //        //        else
                                //        //        {
                                //        //            // Vertical direction change.
                                //        //            ballList[j].VerticalMovement *= -1;
                                //        //        }
                                //        //    }
                                //    }

                                //    BrickContact(ballList[j], brickList[i]);
                                //}
                                //else
                                //{
                                //    // No corner detection implemented.
                                //}

                                #endregion TestVersion

                                #endregion BallAndBrickContact
            //                }
            //            }
            //        }
            //    }
            //}
        }

        /// <summary>
        /// Movethe objects.
        /// </summary>
        private void MoveObjects()
        {
            //if (ballList.Count > 0)
            //{
            //    foreach (var oneBall in ballList)
            //    {
            //        if (oneBall.BallInMove)
            //        {
            //            oneBall.Move(ballSpeed);
            //        }
            //    }
            //}
            //// Move balls.

            //if (bonusList.Count > 0)
            //{
            //    for (int i = 0; i < bonusList.Count; i++)
            //    {
            //        if (bonusList[i].Descend(bonusSpeed, canvasLayer))
            //        {
            //            bonusList.Remove(bonusList[i]);
            //        }
            //    }
            //}
            //// Move bonuses.
        }

        /// <summary>
        /// Brick is at contact with ball.
        /// </summary>
        /// <param name="oneBall">One ball.</param>
        /// <param name="oneBrick">One brick.</param>
        private void BrickContact(Ball oneBall, Brick oneBrick)
        {
            //if (oneBall.TypeOfBall != Ball.ballType.Steel)
            //{
            //    if (oneBrick.TypeOfBrick != Brick.brickType.Steel)
            //    {
            //        if (oneBall.TypeOfBall != Ball.ballType.Hard)
            //        {
            //            if (oneBrick.BreakNumber == 1)
            //            {
            //                // If the brick is at breaking point.
            //                scoreValue += oneBrick.ScorePoint;
            //                // Add points to the score.
            //                ScoreLabel.Content = "Score: " + scoreValue;
            //                // Show the scorepints.

            //                if (oneBrick.CalculateBonusChance())
            //                {
            //                    // If the brick is lucky, then add bonus.
            //                    AddBonus(oneBrick);
            //                }

            //                brickList.Remove(oneBrick);
            //            }
            //            else
            //            {
            //                // If brick is not at breaking point, then decrement the breaking number.
            //                oneBrick.BreakNumber -= 1;

            //                if (oneBrick.TypeOfBrick == Brick.brickType.Hard)
            //                {
            //                    oneBrick.BrickImage = @"media\brick\brokenhardbrick.jpg";
            //                }
            //                else if (oneBrick.TypeOfBrick == Brick.brickType.Medium)
            //                {
            //                    oneBrick.BrickImage = @"media\brick\brokenmediumbrick.jpg";
            //                }
            //            }
            //        }
            //        else
            //        {
            //            scoreValue += oneBrick.ScorePoint;
            //            // Add points to the score.
            //            ScoreLabel.Content = "Score: " + scoreValue;
            //            // Show the scorepints.

            //            if (oneBrick.CalculateBonusChance())
            //            {
            //                // If the brick is lucky, then add bonus.
            //                AddBonus(oneBrick);
            //            }

            //            brickList.Remove(oneBrick);
            //        }
            //    }
            //}
            //else
            //{
            //    // If the ball is steel then no breaknumber scan's needed, every brick breaks at first contact.
            //    scoreValue += oneBrick.ScorePoint;
            //    ScoreLabel.Content = "Score: " + scoreValue;

            //    if (oneBrick.CalculateBonusChance())
            //    {
            //        // If the brick is lucky, then add bonus.
            //        AddBonus(oneBrick);
            //    }

            //    brickList.Remove(oneBrick);
            //}

            //if (optionsSettings.SoundIsOn)
            //{
            //    mPlayer.Position = new TimeSpan(0);
            //    mPlayer.Play();
            //}
        }

        /// <summary>
        /// Handles the event when the ball falls down.
        /// </summary>
        private void DisposeOfBall()
        {
            //canvasLayer.Children.Clear();
            //racketList.Clear();
            //ballList.Clear();
            //bonusList.Clear();
            //// Dispose balls, rackets, bonuses.

            //Racket racket = new Racket((canvasLayer.Width / 2) - (racketWidth / 2), canvasLayer.Height - racketHeight, racketHeight, racketWidth, @"media\racket\normalracket.jpg");
            //racketList.Add(racket);
            //canvasLayer.Children.Add(racket.GetRectangle());
            //// Add new racket.

            //Ball ball = new Ball((canvasLayer.Width / 2) - ballRadius, canvasLayer.Height - racketHeight - (ballRadius * 2), ballRadius, Ball.ballType.Normal, @"media\ball\normalball.jpg");
            //ball.VerticalMovement = ballVerticalMovement > 0 ? ballVerticalMovement : -ballVerticalMovement;
            //ball.HorizontalMovement = ballHorizontalMovement < 0 ? ballHorizontalMovement : -ballHorizontalMovement;
            //// TODO: bug at new ball movement
            //ball.BallInMove = false;
            //ballList.Add(ball);
            //canvasLayer.Children.Add(ball.GetEllipse());
            //// Add new ball.

            //RefreshCanvas();
        }

        /// <summary>
        /// Handles the end of the game.
        /// </summary>
        /// <param name="status">The status.</param>
        private void GameOver(string status)
        {
            //if (status == "fail")
            //{
            //    movingTimer.Stop();

            //    MessageBox.Show("You've failed.", "Game Over");

            //    gameOver = false;
            //    gameOverStatus = null;

            //    if (CheckHighScores(scoreValue))
            //    {
            //        HighScores(scoreValue);
            //        Close();
            //    }
            //    else
            //    {
            //        MapSelection returnToMap = new MapSelection();
            //        returnToMap.Show();
            //        Close();
            //    }
            //}
            //else if (status == "success")
            //{
            //    movingTimer.Stop();

            //    MessageBox.Show("You've succeeded.", "Game Over");

            //    gameOver = false;
            //    gameOverStatus = null;

            //    if (optionsSettings.MapNumber < mapMaxNumber)
            //    {
            //        if (MessageBox.Show("You've succeeded. \n Would you like to continue.", "Game Over", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //        {
            //            try
            //            {
            //                XDocument settingsFromXml = XDocument.Load("OptionsSettings.xml");
            //                var readDataFromXml = settingsFromXml.Descendants("option");
            //                var fromXml = from x in readDataFromXml
            //                              select x;
            //                // Load the values stored in the xml.

            //                fromXml.Single().Element("map").Value = (optionsSettings.MapNumber + 1).ToString();
            //                // Sets the number of the map to the xml for later use.

            //                settingsFromXml.Save("OptionsSettings.xml");
            //                // Save the changes in the values of the xml.
            //            }
            //            catch
            //            {

            //            }

            //            Drawer newMap = new Drawer();
            //            newMap.gamePresets = new GamePresets(lifePoint, scoreValue);
            //            newMap.Show();
            //            Close();
            //        }
            //        else
            //        {
            //            if (CheckHighScores(scoreValue))
            //            {
            //                HighScores(scoreValue);
            //                Close();
            //            }
            //            else
            //            {
            //                MapSelection returnToMap = new MapSelection();
            //                returnToMap.Show();
            //                Close();
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (CheckHighScores(scoreValue))
            //        {
            //            HighScores(scoreValue);
            //            Close();
            //        }
            //        else
            //        {
            //            MapSelection returnToMap = new MapSelection();
            //            returnToMap.Show();
            //            Close();
            //        }
            //    }
            //}
        }

        /// <summary>
        /// Checks if the score is in the highscores.
        /// </summary>
        /// <param name="scoreValue">The score.</param>
        /// <returns></returns>
        private bool CheckHighScores(int score)
        {
            //bool retVal = false;

            //if (File.Exists("Scores.xml"))
            //{
            //    XDocument settingsFromXml = XDocument.Load("Scores.xml");
            //    var readDataFromXml = settingsFromXml.Descendants("Data");
            //    var fromXml = from x in readDataFromXml
            //                  select x;
            //    // Load the values stored in the xml.

            //    int elementNumber = 0;

            //    foreach (var oneElement in fromXml)
            //    {
            //        if (scoreValue > (int)oneElement.Element("Score") && !retVal)
            //        {
            //            retVal = true;
            //        }

            //        elementNumber += 1;
            //    }

            //    if (elementNumber < 10 && !retVal)
            //    {
            //        retVal = true;
            //    }
            //    // See if there is a smaller scorepoint then the player's score.
            //}

            //return retVal;
            return false;
        }

        /// <summary>
        /// Handles the highscores.
        /// </summary>
        private void HighScores(int score)
        {
            //GameOver submitScore = new GameOver();
            //submitScore.ScoreLabel.Content = score;
            //submitScore.Show();
        }

        #endregion InProgress

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
            if (GetOption().IsMouseEnabled && !gameIsPaused)
            {
                if (racketList.Count > 0)
                {
                    foreach (Racket oneRacket in racketList)
                    {
                        oneRacket.MouseMove(racketSpeed, canvasWidth, e.GetPosition(sender).X);

                        if (ballList.Count > 0)
                        {
                            foreach (Ball oneBall in ballList)
                            {
                                if (!oneBall.BallInMove)
                                {
                                    oneBall.MouseMove(racketSpeed, canvasWidth, e.GetPosition(sender).X, oneRacket);
                                }
                            }
                        }
                    }
                }
            }

            //if (e.GetPosition(sender).X != racketList[0].Area.X + racketList[0].Area.Width / 2)
            //{
                
            //}
        }


        public void MouseDown(MouseButtonEventArgs e, DispatcherTimer dispatcherTimer)
        {
            if (GetOption().IsMouseEnabled && !gameIsPaused)
            {
                if (!dispatcherTimer.IsEnabled && !gameInSession)
                {
                    // Start the game.
                    dispatcherTimer.Start();
                    gameInSession = true;
                }

                if (ballList.Count > 0)
                {
                    bool oneGo = false;
                    int iteratorCounter = 0;

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

        #endregion MouseControls

        #region KeyboardControls


        public void KeyUp(KeyEventArgs e)
        {


            //if ((SpecKeys(e.Key) == GetOption().LeftMove || SpecKeys(e.Key) == GetOption().RightMove) && racketList[0].Direction != Racket.Directions.Stay)
            //{
            //    racketList[0].Direction = Racket.Directions.Stay;
            //}
        }


        public void KeyDown(KeyEventArgs e, DispatcherTimer dispatcherTimer)
        {
            //if (e.Key == Key.Escape)
            //{
            //    // Pause the game and send message.
            //    dispatcherTimer.Stop();
            //    gameIsPaused = true;
            //    TimeLabel.Content = "The game is paused.";

            //    if (MessageBox.Show("Do you want to quit?", "Warning", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //    {
            //        MapSelection returnToMapSelection = new MapSelection();
            //        returnToMapSelection.Show();
            //        Close();
            //    }
            //}
            //else if (SpecKeys(e.Key) == optionsSettings.FireKey || SpecKeys(e.Key) == optionsSettings.PauseKey || SpecKeys(e.Key) == optionsSettings.LeftKey || SpecKeys(e.Key) == optionsSettings.RightKey)
            //{
            //    if ((SpecKeys(e.Key) == optionsSettings.LeftKey || SpecKeys(e.Key) == optionsSettings.RightKey) && optionsSettings.KeyboardIsOn && !gameIsPaused)
            //    {
            //        if (SpecKeys(e.Key) == optionsSettings.LeftKey)
            //        {
            //            // Move the racket left.
            //            if (racketList.Count > 0)
            //            {
            //                foreach (var oneRacket in racketList)
            //                {
            //                    oneRacket.MoveKey(racketHorizontalMovement, "left", canvasLayer);

            //                    if (ballList.Count > 0)
            //                    {
            //                        foreach (var oneBall in ballList)
            //                        {
            //                            if (!oneBall.BallInMove)
            //                            {
            //                                // Move the ball with the racket left if ball is not moving.
            //                                oneBall.MoveKey(racketHorizontalMovement, "left", canvasLayer, oneRacket);
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        else if (SpecKeys(e.Key) == optionsSettings.RightKey)
            //        {
            //            // Move the racket right.
            //            if (racketList.Count > 0)
            //            {
            //                foreach (var oneRacket in racketList)
            //                {
            //                    oneRacket.MoveKey(racketHorizontalMovement, "right", canvasLayer);

            //                    if (ballList.Count > 0)
            //                    {
            //                        foreach (var oneBall in ballList)
            //                        {
            //                            if (!oneBall.BallInMove)
            //                            {
            //                                // Move the ball with the racket right if ball is not moving.
            //                                oneBall.MoveKey(racketHorizontalMovement, "right", canvasLayer, oneRacket);
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    else if (SpecKeys(e.Key) == optionsSettings.FireKey)
            //    {
            //        if (optionsSettings.KeyboardIsOn && !gameIsPaused && !gameInSession)
            //        {
            //            if (!movingTimer.IsEnabled)
            //            {
            //                // Start the game.
            //                movingTimer.Start();
            //                gameInSession = true;
            //            }

            //            if (ballList.Count > 0)
            //            {
            //                bool oneGo = false;
            //                int iteratorCounter = 0;

            //                while (!oneGo && iteratorCounter < ballList.Count)
            //                {
            //                    // Start a ball.
            //                    if (!ballList[iteratorCounter].BallInMove)
            //                    {
            //                        ballList[iteratorCounter].BallInMove = true;
            //                        oneGo = true;
            //                    }

            //                    iteratorCounter++;
            //                }
            //            }
            //        }
            //    }
            //    else if (SpecKeys(e.Key) == optionsSettings.PauseKey)
            //    {
            //        // Pause the game.
            //        if (!gameIsPaused)
            //        {
            //            dispatcherTimer.Stop();
            //            gameIsPaused = true;
            //            TimeLabel.Content = "The game is paused.";
            //        }
            //        else
            //        {
            //            dispatcherTimer.Start();
            //            gameIsPaused = false;
            //            TimeLabel.Content = "Time: " + timeOfGame.ToString("HH:mm:ss");
            //        }
            //    }
            //    // Process the control keys.
            //}

            //if (SpecKeys(e.Key) == GetOption().LeftMove && racketList[0].Direction != Racket.Directions.Left)
            //{
            //    racketList[0].Direction = Racket.Directions.Left;
            //}
            //else if (SpecKeys(e.Key) == GetOption().RightMove && racketList[0].Direction != Racket.Directions.Right)
            //{
            //    racketList[0].Direction = Racket.Directions.Right;
            //}

            //racketList[0].KeyMove(racketSpeed, 0, 0);
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
