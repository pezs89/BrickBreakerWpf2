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
<<<<<<< HEAD
=======
    /// 

>>>>>>> origin/master
    public partial class OptionsWindow : Window
    {
        #region Fields

        // The options ViewModel.
        OptionsViewModel optionsVM;

        // The dispacher timer.
        DispatcherTimer SettingsUpdatedLabelHide = new DispatcherTimer();

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionsWindow"/> class.
        /// </summary>
        public OptionsWindow()
        {
            InitializeComponent();

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

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Handles the Tick event of the SettingsUpdatedLabelHide control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SettingsUpdatedLabelHide_Tick(object sender, EventArgs e)
        {
            StatusLabel.Content = "";
            SettingsUpdatedLabelHide.Stop();
        }

        /// <summary>
        /// Handles the Click event of the BackToMainButto control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void BackToMainButton_Click(object sender, RoutedEventArgs e)
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

        /// <summary>
        /// Handles the Click event of the ApplyButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            optionsVM.SaveToXml(ResolutionComboBox.SelectedItem.ToString(),LeftMoveTextBox.Text, RightMoveTextBox.Text, PauseTextBox.Text, 
                FireTextBox.Text, MouseCheckBox.IsChecked.Value, KeyboardCheckBox.IsChecked.Value, SoundCheckBox.IsChecked.Value);
            
            if (optionsVM.IsChanged)
=======
            optionsVM.OptionModel.SaveToXml(ResolutionComboBox.SelectedItem.ToString(), LeftMoveTextBox.Text, RightMoveTextBox.Text, PauseTextBox.Text, FireTextBox.Text, MouseCheckBox.IsChecked.Value, KeyboardCheckBox.IsChecked.Value, SoundCheckBox.IsChecked.Value);
            if (optionsVM.OptionModel.IsChanged)
>>>>>>> origin/master
            {
                StatusLabel.Content = "Settings has been updated!";
                SettingsUpdatedLabelHide.Start();

                optionsVM.IsChanged = false;
            }
        }

        /// <summary>
        /// Handles the KeyUp event of the LeftMoveTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void LeftMoveTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (!optionsVM.Check(LeftMoveTextBox.Text))
            {
                StatusLabel.Content = "Key has been already assigned!";
                SettingsUpdatedLabelHide.Start();
                LeftMoveTextBox.Text = optionsVM.OptionModel.LeftMove;
            }

            if (!string.IsNullOrEmpty(optionsVM.SpecKeys(e.Key)))
            {
                LeftMoveTextBox.Text = optionsVM.SpecKeys(e.Key);
            }
            
        }

        /// <summary>
        /// Handles the KeyUp event of the RightMoveTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void RightMoveTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(!optionsVM.Check(RightMoveTextBox.Text))
            {
                StatusLabel.Content = "Key has been already assigned!";
                SettingsUpdatedLabelHide.Start();
                RightMoveTextBox.Text = optionsVM.OptionModel.RightMove;
            }

            if (!string.IsNullOrEmpty(optionsVM.SpecKeys(e.Key)))
            {
                RightMoveTextBox.Text = optionsVM.SpecKeys(e.Key);
            }

        }

        /// <summary>
        /// Handles the KeyUp event of the PauseTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void PauseTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(!optionsVM.Check(PauseTextBox.Text))
            {
                StatusLabel.Content = "Key has been already assigned!";
                SettingsUpdatedLabelHide.Start();
                PauseTextBox.Text = optionsVM.OptionModel.PauseButton;
            }

            if (!string.IsNullOrEmpty(optionsVM.SpecKeys(e.Key)))
            {
                PauseTextBox.Text = optionsVM.SpecKeys(e.Key);
            }

        }

        /// <summary>
        /// Handles the KeyUp event of the FireTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void FireTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(!optionsVM.Check(FireTextBox.Text))
            {
                StatusLabel.Content = "Key has been already assigned!";
                SettingsUpdatedLabelHide.Start();
                FireTextBox.Text = optionsVM.OptionModel.FireButton;
            }

            if (!string.IsNullOrEmpty(optionsVM.SpecKeys(e.Key)))
            {
                FireTextBox.Text = optionsVM.SpecKeys(e.Key);
            }
        }

        #endregion Methods
    }
}
