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
    /// Interaction logic for InformationsWindow.xaml.
    /// </summary>
    public partial class InformationsWindow : Window
    {
        #region Fields

        // The error log viremodel.
        private ErrorLogViewModel errorLogViewModel;

        // The options viewmodel.
        private OptionsViewModel optionsViewModel;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InformationsWindow"/> class.
        /// </summary>
        public InformationsWindow()
        {
            try
            {
                InitializeComponent();

                errorLogViewModel = new ErrorLogViewModel();
                optionsViewModel = new OptionsViewModel();
                this.Height = optionsViewModel.VerticalScaleNumber;
                this.Width = optionsViewModel.HorizontalScaleNumber;

                InfoTxtBlock.Text = "Name: Péter Zsolt" + "\n" + "Neptun: GZOG8N" + "\n" + "App: BrickBreaker";
                PressKeyTxtBlock.Text = "Press Esc to the Main Menu";
            }
            catch
            { }
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Handles the KeyDown event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Escape)
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

        #endregion Methods
    }
}
