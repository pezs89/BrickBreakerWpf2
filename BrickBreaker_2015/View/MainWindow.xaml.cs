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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BrickBreaker_2015.View;
using BrickBreaker_2015.ViewModel;

namespace BrickBreaker_2015
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OptionsViewModel optionsViewModel = new OptionsViewModel();
            this.Height = optionsViewModel.verticalScaleNumber;
            this.Width = optionsViewModel.horizontalScaleNumber;
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            NewGameWindow childWindow = new NewGameWindow();
            this.Close();
            childWindow.ShowDialog();
            
        }

        private void OptionsButton_Click(object sender, RoutedEventArgs e)
        {
            OptionsWindow childWindow = new OptionsWindow();
            this.Close();
            childWindow.ShowDialog();
            

        }

        private void CreditsButton_Click(object sender, RoutedEventArgs e)
        {
            CreditsWindow childWindow = new CreditsWindow();
            this.Close();
            childWindow.ShowDialog();
            
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            InformationsWindow childWindow = new InformationsWindow();
            this.Close();
            childWindow.ShowDialog();
        }

        private void ExitGameButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
