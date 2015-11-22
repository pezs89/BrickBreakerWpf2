using BrickBreaker_2015.ViewModel;
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

namespace BrickBreaker_2015.View
{
    /// <summary>
    /// Interaction logic for DifficultySelectionWindow.xaml.
    /// </summary>
    public partial class DifficultySelectionWindow : Window
    {
        #region Fields

        // The options viewmodel.
        private OptionsViewModel optionsViewModel;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DifficultySelectionWindow"/> class.
        /// </summary>
        public DifficultySelectionWindow()
        {
            try
            {
                InitializeComponent();

                optionsViewModel = new OptionsViewModel();
                this.Height = optionsViewModel.VerticalScaleNumber;
                this.Width = optionsViewModel.HorizontalScaleNumber;
            }
            catch
            { }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Handles the Click event of the EasyButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void EasyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                optionsViewModel.OptionModel.Difficulty = 1;
                optionsViewModel.SaveToXml();

                GamePlayWindow childWindow = new GamePlayWindow();
                this.Close();
                childWindow.ShowDialog();
            }
            catch
            { }
        }

        /// <summary>
        /// Handles the Click event of the NormalButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void NormalButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                optionsViewModel.OptionModel.Difficulty = 2;
                optionsViewModel.SaveToXml();

                GamePlayWindow childWindow = new GamePlayWindow();
                this.Close();
                childWindow.ShowDialog();
            }
            catch
            { }
        }

        /// <summary>
        /// Handles the Click event of the HardButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void HardButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                optionsViewModel.OptionModel.Difficulty = 3;
                optionsViewModel.SaveToXml();

                GamePlayWindow childWindow = new GamePlayWindow();
                this.Close();
                childWindow.ShowDialog();
            }
            catch
            { }
        }

        #endregion Methods
    }
}
