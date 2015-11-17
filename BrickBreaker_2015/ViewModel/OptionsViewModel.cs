using BrickBreaker_2015.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrickBreaker_2015.View;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Linq;
using System.Windows.Input;

namespace BrickBreaker_2015.ViewModel
{
    class OptionsViewModel : Bindable
    {
        public Options OptionModel { set; get; }
        public double horizontalScaleNumber { get; set; }
        public double verticalScaleNumber { get; set; }

        public OptionsViewModel()
        {
            OptionModel = new Options();

            switch (OptionModel.Resolution)
            {
                case "580x420":
                    horizontalScaleNumber = 580;
                    verticalScaleNumber = 420;
                    break;
                case "640x480":
                    horizontalScaleNumber = 640;
                    verticalScaleNumber = 480;
                    break;
                case "800x600":
                    horizontalScaleNumber = 800;
                    verticalScaleNumber = 600;
                    break;
            }
        }
    }
}
