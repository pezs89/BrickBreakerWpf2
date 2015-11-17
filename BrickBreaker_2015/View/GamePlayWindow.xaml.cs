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
    enum Irany
    { bal,jobb}
    /// <summary>
    /// Interaction logic for GamePlayWindow.xaml.
    /// </summary>
    public partial class GamePlayWindow : Window
    {
        #region Fields

        // 
        NewGameViewModel newGameViewModel;

        // 
        DispatcherTimer timer;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GamePlayWindow"/> class.
        /// </summary>
        public GamePlayWindow()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Handles the Loaded event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            newGameViewModel = new NewGameViewModel((int)canvas.ActualWidth, (int)canvas.ActualHeight);

            this.DataContext = newGameViewModel;

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        /// <summary>
        /// Handles the Tick event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            newGameViewModel.LabdaMozgat((int)canvas.ActualWidth, (int)canvas.ActualHeight);
        }

<<<<<<< HEAD
        #endregion Methods
=======
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
            }
            else if (e.Key == Key.Right)
            {
            }
        }
>>>>>>> origin/master
    }
}
