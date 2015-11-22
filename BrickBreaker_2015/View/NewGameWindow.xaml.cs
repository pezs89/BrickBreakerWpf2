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
    /// Interaction logic for NewGameWindow.xaml.
    /// </summary>
    public partial class NewGameWindow : Window
    {
        #region Fields

        // The error log viewmodel.
        private ErrorLogViewModel errorLogViewModel;

        // The options viewmodel.
        private OptionsViewModel optionsViewModel;

        // The game viewmodel.
        private NewGameViewModel newGameViewModel;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NewGameWindow"/> class.
        /// </summary>
        public NewGameWindow()
        {
            try
            {
                InitializeComponent();

                errorLogViewModel = new ErrorLogViewModel();
                newGameViewModel = new NewGameViewModel();
                optionsViewModel = new OptionsViewModel();
                this.Height = optionsViewModel.VerticalScaleNumber;
                this.Width = optionsViewModel.HorizontalScaleNumber;

                firstMap_Diff.IsEnabled = newGameViewModel.FindMap(newGameViewModel.FirstMapPath);
                secondMap_Diff.IsEnabled = newGameViewModel.FindMap(newGameViewModel.SecondMapPath);
                thirdMap_Diff.IsEnabled = newGameViewModel.FindMap(newGameViewModel.ThirdMapPath);
                fourthmapMap_Diff.IsEnabled = newGameViewModel.FindMap(newGameViewModel.ForthMapPath);
                fifthmap_Diff.IsEnabled = newGameViewModel.FindMap(newGameViewModel.FifthMapPath);
            }
            catch
            { }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Handles the Click event of the firstMap_Diff control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void firstMap_Diff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                optionsViewModel.OptionModel.MapNumber = 1;
                optionsViewModel.SaveToXml();

                DifficultySelectionWindow childWindow = new DifficultySelectionWindow();
                this.Close();
                childWindow.ShowDialog();
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        /// <summary>
        /// Handles the Click event of the secondMap_Diff control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void secondMap_Diff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                optionsViewModel.OptionModel.MapNumber = 2;
                optionsViewModel.SaveToXml();

                DifficultySelectionWindow childWindow = new DifficultySelectionWindow();
                this.Close();
                childWindow.ShowDialog();
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        /// <summary>
        /// Handles the Click event of the thirdMap_Diff control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void thirdMap_Diff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                optionsViewModel.OptionModel.MapNumber = 3;
                optionsViewModel.SaveToXml();

                DifficultySelectionWindow childWindow = new DifficultySelectionWindow();
                this.Close();
                childWindow.ShowDialog();
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        /// <summary>
        /// Handles the Click event of the fourthmapMap_Diff control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void fourthmapMap_Diff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                optionsViewModel.OptionModel.MapNumber = 4;
                optionsViewModel.SaveToXml();

                DifficultySelectionWindow childWindow = new DifficultySelectionWindow();
                this.Close();
                childWindow.ShowDialog();
            }
            catch(Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        /// <summary>
        /// Handles the Click event of the fifthmap_Diff control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void fifthmap_Diff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                optionsViewModel.OptionModel.MapNumber = 5;
                optionsViewModel.SaveToXml();

                DifficultySelectionWindow childWindow = new DifficultySelectionWindow();
                this.Close();
                childWindow.ShowDialog();
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        /// <summary>
        /// Handles the Click event of the Back control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow parent = new MainWindow();
                this.DialogResult = true;
                parent.ShowDialog();
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        #endregion Methods
    }
}
