using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BrickBreaker_2015.ViewModel;
using System.Windows.Threading;
using System.Threading;

namespace BrickBreaker_2015.View
{
    /// <summary>
    /// Interaction logic for GamePlayWindow.xaml.
    /// </summary>
    public partial class GamePlayWindow : Window
    {
        #region Fields

        // The error log viewmodel.
        private ErrorLogViewModel errorLogViewModel;

        // The game ViewModel.
        private NewGameViewModel newGameViewModel;

        // The options ViewModel.
        private OptionsViewModel optionsViewModel;

        // The dispacher timer.
        private DispatcherTimer timer;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GamePlayWindow"/> class.
        /// </summary>
        public GamePlayWindow()
        {
            try
            {
                InitializeComponent();

                errorLogViewModel = new ErrorLogViewModel();
                newGameViewModel = new NewGameViewModel(ref canvas);
                optionsViewModel = new OptionsViewModel();

                this.DataContext = newGameViewModel;

                timer = new DispatcherTimer();
                timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
                timer.Tick += Timer_Tick;
                timer.Start();
            }
            catch
            { }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Handles the KeyDown event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                newGameViewModel.KeyDown(e);
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        /// <summary>
        /// Handles the KeyUp event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                newGameViewModel.KeyUp(e);
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        /// <summary>
        /// Handles the MouseMove event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                newGameViewModel.MouseMove(canvas, e);
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        /// <summary>
        /// Handles the MouseLeftButtonDown event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                newGameViewModel.MouseLeftButtonDown(e);
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        /// <summary>
        /// Handles the Tick event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                // The game is not over.
                if (!newGameViewModel.GameIsOver)
                {
                    // The game is in session and the game is not paused.
                    if (newGameViewModel.GameInSession && !newGameViewModel.GameIsPaused)
                    {
                        // Move the game objects, search for contact, refresh the display and seach for the end of the game.
                        newGameViewModel.MoveObjects();
                        newGameViewModel.BallAtContact();
                        newGameViewModel.RacketAtContactWithBonus();
                        newGameViewModel.CleanListsFromDeleted();
                        newGameViewModel.RefreshDisplay();
                        newGameViewModel.CheckForGameOver();
                    }

                    // See if any actions are needed to be performed by the view.
                    if (newGameViewModel.ViewAction != NewGameViewModel.ViewActionStatus.DoNothing)
                    {
                        switch (newGameViewModel.ViewAction)
                        {
                            case NewGameViewModel.ViewActionStatus.OpenMenu:
                                newGameViewModel.ViewAction = NewGameViewModel.ViewActionStatus.DoNothing;
                                OpenMenu();
                                break;
                            case NewGameViewModel.ViewActionStatus.OpenHighscores:
                                newGameViewModel.ViewAction = NewGameViewModel.ViewActionStatus.DoNothing;
                                OpenHighscores();
                                break;
                            case NewGameViewModel.ViewActionStatus.NewMap:
                                newGameViewModel.ViewAction = NewGameViewModel.ViewActionStatus.DoNothing;
                                newGameViewModel.NewMap();
                                break;
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
        /// Handles the Loaded event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                newGameViewModel.WindowLoaded();
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        /// <summary>
        /// Opens the main view.
        /// </summary>
        private void OpenMenu()
        {
            try
            {
                timer.Stop();

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        /// <summary>
        /// Opens the highscores view.
        /// </summary>
        private void OpenHighscores()
        {
            try
            {
                timer.Stop();

                GameOverWindow gameOverWindow = new GameOverWindow(newGameViewModel.PlayerScorePoint);
                gameOverWindow.Show();
                this.Close();
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        #endregion Methods
    }
}
