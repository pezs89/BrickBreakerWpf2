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
    /// Interaction logic for DifficultySelectionWindow.xaml
    /// </summary>
    public partial class DifficultySelectionWindow : Window
    {
        public DifficultySelectionWindow()
        {
            InitializeComponent();

            OptionsViewModel optionsViewModel = new OptionsViewModel();
            this.Height = optionsViewModel.verticalScaleNumber;
            this.Width = optionsViewModel.horizontalScaleNumber;
        }

        private void NormalButton_Click(object sender, RoutedEventArgs e)
        {
            GamePlayWindow childWindow = new GamePlayWindow();
            this.Close();
            childWindow.ShowDialog();
            
        }

        private void HardButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
