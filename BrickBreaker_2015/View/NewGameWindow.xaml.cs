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

        // The options viewmodel.
        private OptionsViewModel optionsViewModel;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NewGameWindow"/> class.
        /// </summary>
        public NewGameWindow()
        {
            InitializeComponent();

            optionsViewModel = new OptionsViewModel();
            this.Height = optionsViewModel.VerticalScaleNumber;
            this.Width = optionsViewModel.HorizontalScaleNumber;
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
            optionsViewModel.OptionModel.MapNumber = 1;
            optionsViewModel.SaveToXml();
            DifficultySelectionWindow childWindow = new DifficultySelectionWindow();
            this.Close();
            childWindow.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the secondMap_Diff control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void secondMap_Diff_Click(object sender, RoutedEventArgs e)
        {
            optionsViewModel.OptionModel.MapNumber = 2;
            optionsViewModel.SaveToXml();
            DifficultySelectionWindow childWindow = new DifficultySelectionWindow();
            this.Close();
            childWindow.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the thirdMap_Diff control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void thirdMap_Diff_Click(object sender, RoutedEventArgs e)
        {
            optionsViewModel.OptionModel.MapNumber = 3;
            optionsViewModel.SaveToXml();
            DifficultySelectionWindow childWindow = new DifficultySelectionWindow();
            this.Close();
            childWindow.ShowDialog();
            
        }

        /// <summary>
        /// Handles the Click event of the Back control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parent = new MainWindow();
            this.DialogResult = true;
            parent.ShowDialog();
        }

        #endregion Methods
    }
}
