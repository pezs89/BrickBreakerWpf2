﻿using System;
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

                newGameViewModel = new NewGameViewModel();
                optionsViewModel = new OptionsViewModel();
                this.Height = optionsViewModel.VerticalScaleNumber;
                this.Width = optionsViewModel.HorizontalScaleNumber;

                firstMap_Diff.IsEnabled = newGameViewModel.FindMap(newGameViewModel.FirstMapPath);
                secondMap_Diff.IsEnabled = newGameViewModel.FindMap(newGameViewModel.SecondMapPath);
                thirdMap_Diff.IsEnabled = newGameViewModel.FindMap(newGameViewModel.ThirdMapPath);
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
            catch
            { }
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
            catch
            { }
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
            catch
            { }
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
            catch
            { }
        }

        #endregion Methods
    }
}
