using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrickBreaker_2015.Model;
using System.Collections.ObjectModel;

namespace BrickBreaker_2015.ViewModel
{
    class NewGameViewModel
    {
        public Racket Racket { get; set; }

        public ObservableCollection<Ball> BallList { get; set; }

        public NewGameViewModel(
            int canvasSzelesseg,
            int canvasMagassag)
        {
            Racket = new Racket(
                canvasSzelesseg / 2 - 40,
                canvasMagassag - 40,
                80,
                10);

            BallList = new ObservableCollection<Ball>();
            BallList.Add(
                new Ball(0, 0, 20, 20, 5, 5));

        }

        public void UtoMozgat(Direction direction)
        {
            Racket.Move(direction);
        }

        public void LabdaMozgat(int canvasSzelesseg,
            int canvasMagassag) //  összes labda!
        {
            foreach (Ball labda in BallList)
            {
                labda.Mozog(
                    canvasSzelesseg,
                    canvasMagassag,
                    Racket);
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
    }
}
