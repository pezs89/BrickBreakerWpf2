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
    /// Interaction logic for NewGameWindow.xaml
    /// </summary>
    public partial class NewGameWindow : Window
    {
        
        public NewGameWindow()
        {
            InitializeComponent();
            OptionsViewModel optionsViewModel = new OptionsViewModel();
            this.Height = optionsViewModel.verticalScaleNumber;
            this.Width = optionsViewModel.horizontalScaleNumber;
        }

        private void firstMap_Diff_Click(object sender, RoutedEventArgs e)
        {
            DifficultySelectionWindow childWindow = new DifficultySelectionWindow();
            this.Close();
            childWindow.ShowDialog();
        }

        private void secondMap_Diff_Click(object sender, RoutedEventArgs e)
        {
            DifficultySelectionWindow childWindow = new DifficultySelectionWindow();
            this.Close();
            childWindow.ShowDialog();
        }

        private void thirdMap_Diff_Click(object sender, RoutedEventArgs e)
        {
            DifficultySelectionWindow childWindow = new DifficultySelectionWindow();
            this.Close();
            childWindow.ShowDialog();
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parent = new MainWindow();
            this.DialogResult = true;
            parent.ShowDialog();
        }
    }
}
