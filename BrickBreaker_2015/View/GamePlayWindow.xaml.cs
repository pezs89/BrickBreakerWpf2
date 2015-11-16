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
    /// Interaction logic for GamePlayWindow.xaml
    /// </summary>
    public partial class GamePlayWindow : Window
    {
        public GamePlayWindow()
        {
            InitializeComponent();
        }

        NewGameViewModel newGameViewModel;
        DispatcherTimer timer;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            newGameViewModel = new NewGameViewModel((int)canvas.ActualWidth, (int)canvas.ActualHeight);

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            newGameViewModel.LabdaMozgat((int)canvas.ActualWidth, (int)canvas.ActualHeight);
        }
    }
}
