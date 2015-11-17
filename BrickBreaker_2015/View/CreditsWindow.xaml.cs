﻿using BrickBreaker_2015.ViewModel;
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
    /// Interaction logic for CreditsWindow.xaml.
    /// </summary>
    public partial class CreditsWindow : Window
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditsWindow"/> class.
        /// </summary>
        public CreditsWindow()
        {
            InitializeComponent();

            OptionsViewModel optionsViewModel = new OptionsViewModel();
<<<<<<< HEAD
            this.Height = optionsViewModel.VerticalScaleNumber;
            this.Width = optionsViewModel.HorizontalScaleNumber;

            //var xml = XDocument.Load(@"..\..\Resources\Scores.xml").Root;
            ScoresXmlAccess scoresXmlAccess = new ScoresXmlAccess(@"..\..\Resources\Scores.xml");
            var items = scoresXmlAccess.LoadScores();
            dataGrid1.DataContext = items;
=======
            this.Height = optionsViewModel.verticalScaleNumber;
            this.Width = optionsViewModel.horizontalScaleNumber;

            var xml = XDocument.Load("Scores.xml").Root;
            dataGrid1.DataContext = xml;
>>>>>>> origin/master
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
            if (e.Key == Key.Escape)
            {
                MainWindow parent = new MainWindow();
                this.DialogResult = true;
                parent.ShowDialog();
            }
        }

        #endregion Methods
    }
}
