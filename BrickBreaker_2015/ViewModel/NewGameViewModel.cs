using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrickBreaker_2015.Model;
using System.Collections.ObjectModel;

namespace BrickBreaker_2015.ViewModel
{
    /// <summary>
    /// Interaction logic for NewGameViewModel.
    /// </summary>
    class NewGameViewModel
    {
        #region Properties

        public Racket Racket { get; set; }

        public ObservableCollection<Ball> BallList { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NewGameViewModel"/> class.
        /// </summary>
        public NewGameViewModel(int canvasSzelesseg, int canvasMagassag)
        {
            Racket = new Racket(canvasSzelesseg / 2 - 40, canvasMagassag - 40, 80, 10);

            BallList = new ObservableCollection<Ball>();
<<<<<<< HEAD
            BallList.Add(new Ball(0, 0, 20, 20, 5, 5));
=======
            BallList.Add(
                new Ball(0, 0, 15, 15, 5, 5));

>>>>>>> origin/master
        }

        #endregion Constructors

        #region Methods

        public void UtoMozgat(Direction direction)
        {
            Racket.Move(direction);
        }

        public void LabdaMozgat(int canvasSzelesseg, int canvasMagassag) //  összes labda!
        {
            foreach (Ball labda in BallList)
            {
                labda.Mozog(canvasSzelesseg, canvasMagassag, Racket);
            }
        }

        public bool Vege(int canvasMagassag)
        {
            foreach (Ball labda in BallList)
            {
                if (labda.Area.Top > canvasMagassag)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion Methods
    }
}
