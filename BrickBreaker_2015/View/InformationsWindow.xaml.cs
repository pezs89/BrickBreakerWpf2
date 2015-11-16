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
    /// Interaction logic for InformationsWindow.xaml
    /// </summary>
    public partial class InformationsWindow : Window
    {
        public InformationsWindow()
        {
            InitializeComponent();

            OptionsViewModel optionsViewModel = new OptionsViewModel();
            this.Height = optionsViewModel.verticalScaleNumber;
            this.Width = optionsViewModel.horizontalScaleNumber;

            InfoTxtBlock.Text = "Name: Péter Zsolt" + "\n" + "Neptun: GZOG8N" + "\n" +"App: BrickBreaker";
            PressKeyTxtBlock.Text = "Press Esc to the Main Menu";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                MainWindow parent = new MainWindow();
                this.DialogResult = true;
                parent.ShowDialog();
            }
        }
    }
}
