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

namespace BrickBreaker_2015.View
{
    /// <summary>
    /// Interaction logic for GameOverWindow.xaml.
    /// </summary>
    public partial class GameOverWindow : Window
    {
        #region Fields

        // The options viewmodel.
        private OptionsViewModel optionsViewModel;

        // The game over viewmodel.
        private GameOverViewModel gameOverViewModel;

        // The error log viewmodel.
        private ErrorLogViewModel errorLogVireModel;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GameOverWindow"/> class.
        /// </summary>
        public GameOverWindow(int playerScore)
        {
            InitializeComponent();

            errorLogVireModel = new ErrorLogViewModel();
            gameOverViewModel = new GameOverViewModel();
            optionsViewModel = new OptionsViewModel();
            this.Width = optionsViewModel.HorizontalScaleNumber;
            this.Height = optionsViewModel.VerticalScaleNumber;
            ScoreLabel.Content = playerScore;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Handles the Click event of the CancelButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow parent = new MainWindow();
                parent.Show();
                this.Close();
            }
            catch (Exception error)
            {
                errorLogVireModel.LogError(error);
            }
        }

        /// <summary>
        /// Handles the Click event of the OkButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (gameOverViewModel.CheckScore(int.Parse(ScoreLabel.Content.ToString())) && !string.IsNullOrEmpty(NameTextBox.Text))
                {
                    gameOverViewModel.SaveScore(NameTextBox.Text, int.Parse(ScoreLabel.Content.ToString()));
                }

                MainWindow parent = new MainWindow();
                parent.Show();
                this.Close();
            }
            catch (Exception error)
            {
                errorLogVireModel.LogError(error);
            }
        }

        #endregion Methods
    }
}