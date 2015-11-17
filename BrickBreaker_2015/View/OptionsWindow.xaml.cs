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
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    /// 
    
    public partial class OptionsWindow : Window
    {
        OptionsViewModel optionsVM;
        DispatcherTimer SettingsUpdatedLabelHide = new DispatcherTimer();
        public OptionsWindow()
        {
            InitializeComponent();

            ResolutionComboBox.Items.Add("580x420");
            ResolutionComboBox.Items.Add("640x480");
            ResolutionComboBox.Items.Add("800x600");

            optionsVM = new OptionsViewModel();
            this.DataContext = optionsVM;
            this.Width = optionsVM.horizontalScaleNumber;
            this.Height = optionsVM.verticalScaleNumber;

            ResolutionComboBox.SelectedItem = optionsVM.OptionModel.Resolution;

            SettingsUpdatedLabelHide.Interval = TimeSpan.FromSeconds(3);
            SettingsUpdatedLabelHide.Tick += SettingsUpdatedLabelHide_Tick;
        }

        private void SettingsUpdatedLabelHide_Tick(object sender, EventArgs e)
        {
            StatusLabel.Content = "";
            SettingsUpdatedLabelHide.Stop();
        }

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

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            optionsVM.OptionModel.SaveToXml(ResolutionComboBox.SelectedItem.ToString(),LeftMoveTextBox.Text, RightMoveTextBox.Text, PauseTextBox.Text, FireTextBox.Text, MouseCheckBox.IsChecked.Value, KeyboardCheckBox.IsChecked.Value, SoundCheckBox.IsChecked.Value);
            if (optionsVM.OptionModel.IsChanged)
            {
                StatusLabel.Content = "Settings has been updated!";
                SettingsUpdatedLabelHide.Start();

                optionsVM.OptionModel.IsChanged = false;
            }
           
        }

        private void LeftMoveTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (!optionsVM.OptionModel.Check(LeftMoveTextBox.Text))
            {
                StatusLabel.Content = "Key has been already assigned!";
                SettingsUpdatedLabelHide.Start();
                LeftMoveTextBox.Text = optionsVM.OptionModel.LeftMove;
            }
            if (!string.IsNullOrEmpty(optionsVM.OptionModel.SpecKeys(e.Key)))
            {
                LeftMoveTextBox.Text  = optionsVM.OptionModel.retVal.ToString();
            }
            
        }

        private void RightMoveTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(!optionsVM.OptionModel.Check(RightMoveTextBox.Text))
            {
                StatusLabel.Content = "Key has been already assigned!";
                SettingsUpdatedLabelHide.Start();
                RightMoveTextBox.Text = optionsVM.OptionModel.RightMove;
            }
            if (!string.IsNullOrEmpty(optionsVM.OptionModel.SpecKeys(e.Key)))
            {
                RightMoveTextBox.Text = optionsVM.OptionModel.retVal.ToString();
            }

        }

        private void PauseTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(!optionsVM.OptionModel.Check(PauseTextBox.Text))
            {
                StatusLabel.Content = "Key has been already assigned!";
                SettingsUpdatedLabelHide.Start();
                PauseTextBox.Text = optionsVM.OptionModel.PauseButton;
            }
            if (!string.IsNullOrEmpty(optionsVM.OptionModel.SpecKeys(e.Key)))
            {
                PauseTextBox.Text = optionsVM.OptionModel.retVal.ToString();
            }

        }

        private void FireTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(!optionsVM.OptionModel.Check(FireTextBox.Text))
            {
                StatusLabel.Content = "Key has been already assigned!";
                SettingsUpdatedLabelHide.Start();
                FireTextBox.Text = optionsVM.OptionModel.FireButton;
            }
            if (!string.IsNullOrEmpty(optionsVM.OptionModel.SpecKeys(e.Key)))
            {
                FireTextBox.Text = optionsVM.OptionModel.retVal.ToString();
            }
        }
    }
}
