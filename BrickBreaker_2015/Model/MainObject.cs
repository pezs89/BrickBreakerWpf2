using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BrickBreaker_2015.Model
{
    abstract class MainObject : Bindable
    {
        protected Rect area;
        public Rect Area
        {
            get { return area; }
            set { area = value; }
        }

        public MainObject(int posX, int posY, int width, int height)
        {
            Area = new Rect(posX, posY, width, height);
        }
    }
}
