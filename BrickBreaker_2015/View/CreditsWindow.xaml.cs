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
using System.Xml.Linq;

namespace BrickBreaker_2015.View
{
    /// <summary>
    /// Interaction logic for CreditsWindow.xaml
    /// </summary>
    public partial class CreditsWindow : Window
    {
        public CreditsWindow()
        {
            InitializeComponent();

            OptionsViewModel optionsViewModel = new OptionsViewModel();
            this.Height = optionsViewModel.verticalScaleNumber;
            this.Width = optionsViewModel.horizontalScaleNumber;

            var xml = XDocument.Load("Scores.xml").Root;
            dataGrid1.DataContext = xml;

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
