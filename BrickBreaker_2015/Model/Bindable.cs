using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker_2015.Model
{
    /// <summary>
    /// Base class for Bindable.
    /// </summary>
    abstract class Bindable : INotifyPropertyChanged
    {
        #region Fields

        // The property that changed.
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Fields

        #region Properties

        #endregion Properties

        #region Constructors

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Refreshes the object if it's property is changed.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            try
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            catch
            { }
        }

        #endregion Methods
    }
}
