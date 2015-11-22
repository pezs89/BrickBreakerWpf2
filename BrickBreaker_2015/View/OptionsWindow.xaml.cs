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

namespace BrickBreaker_2015.View
{
    /// <summary>
    /// Interaction logic for OptionsWindow.xaml.
    /// </summary>
    public partial class OptionsWindow : Window
    {
        #region Fields

        // The error log viewmodel.
        private ErrorLogViewModel errorLogViewModel;

        // The options ViewModel.
        private OptionsViewModel optionsVM;

        // The dispacher timer.
        private DispatcherTimer SettingsUpdatedLabelHide = new DispatcherTimer();

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionsWindow"/> class.
        /// </summary>
        public OptionsWindow()
        {
            try
            {
                InitializeComponent();

                errorLogViewModel = new ErrorLogViewModel();

                ResolutionComboBox.Items.Add("580x420");
                ResolutionComboBox.Items.Add("640x480");
                ResolutionComboBox.Items.Add("800x600");

                optionsVM = new OptionsViewModel();
                this.DataContext = optionsVM;
                this.Width = optionsVM.HorizontalScaleNumber;
                this.Height = optionsVM.VerticalScaleNumber;

                ResolutionComboBox.SelectedItem = optionsVM.OptionModel.Resolution;

                SettingsUpdatedLabelHide.Interval = TimeSpan.FromSeconds(3);
                SettingsUpdatedLabelHide.Tick += SettingsUpdatedLabelHide_Tick;
            }
            catch
            { }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Handles the Tick event of the SettingsUpdatedLabelHide control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SettingsUpdatedLabelHide_Tick(object sender, EventArgs e)
        {
            try
            {
                StatusLabel.Content = "";
                SettingsUpdatedLabelHide.Stop();
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        /// <summary>
        /// Handles the Click event of the BackToMainButto control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void BackToMainButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MouseCheckBox.IsChecked == false && KeyboardCheckBox.IsChecked == false)
                {
                    e.Handled = false;
                    StatusLabel.Content = "At least one control" + "\n" + "has to be checked in!";
                    SettingsUpdatedLabelHide.Start();
                }
                else
                {
                    MainWindow parent = new MainWindow();
                    this.DialogResult = true;
                    parent.ShowDialog();
                }
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        /// <summary>
        /// Handles the Click event of the ApplyButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                optionsVM.SaveToXml();

                if (optionsVM.IsChanged)
                {
                    StatusLabel.Content = "Settings has been updated!";
                    SettingsUpdatedLabelHide.Start();

                    optionsVM.IsChanged = false;
                }
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        /// <summary>
        /// Handles the KeyUp event of the LeftMoveTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void LeftMoveTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (!optionsVM.Check(optionsVM.SpecKeys(e.Key)))
                {
                    StatusLabel.Content = "Key has been already assigned!";
                    SettingsUpdatedLabelHide.Start();
                    LeftMoveTextBox.Text = optionsVM.OptionModel.LeftMove;
                }
                else
                {
                    if (!string.IsNullOrEmpty(optionsVM.SpecKeys(e.Key)))
                    {
                        LeftMoveTextBox.Text = optionsVM.SpecKeys(e.Key);
                    }
                }
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        /// <summary>
        /// Handles the KeyUp event of the RightMoveTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void RightMoveTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (!optionsVM.Check(optionsVM.SpecKeys(e.Key)))
                {
                    StatusLabel.Content = "Key has been already assigned!";
                    SettingsUpdatedLabelHide.Start();
                    RightMoveTextBox.Text = optionsVM.OptionModel.RightMove;
                }
                else
                {
                    if (!string.IsNullOrEmpty(optionsVM.SpecKeys(e.Key)))
                    {
                        RightMoveTextBox.Text = optionsVM.SpecKeys(e.Key);
                    }
                }
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        /// <summary>
        /// Handles the KeyUp event of the PauseTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void PauseTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (!optionsVM.Check(optionsVM.SpecKeys(e.Key)))
                {
                    StatusLabel.Content = "Key has been already assigned!";
                    SettingsUpdatedLabelHide.Start();
                    PauseTextBox.Text = optionsVM.OptionModel.PauseButton;
                }
                else
                {
                    if (!string.IsNullOrEmpty(optionsVM.SpecKeys(e.Key)))
                    {
                        PauseTextBox.Text = optionsVM.SpecKeys(e.Key);
                    }
                }
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        /// <summary>
        /// Handles the KeyUp event of the FireTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void FireTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (!optionsVM.Check(optionsVM.SpecKeys(e.Key)))
                {
                    StatusLabel.Content = "Key has been already assigned!";
                    SettingsUpdatedLabelHide.Start();
                    FireTextBox.Text = optionsVM.OptionModel.FireButton;
                }
                else
                {
                    if (!string.IsNullOrEmpty(optionsVM.SpecKeys(e.Key)))
                    {
                        FireTextBox.Text = optionsVM.SpecKeys(e.Key);
                    }
                }
            }
            catch (Exception error)
            {
                errorLogViewModel.LogError(error);
            }
        }

        #endregion Methods
    }
}
