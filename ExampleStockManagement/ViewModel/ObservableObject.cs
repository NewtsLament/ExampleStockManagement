using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleStockManagement.ViewModel
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Implements the INotifyPropertyChanged interface, so we can inherit the implementation to our viewmodels.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Notifies all ecent watchers of a change in the properties.
        /// </summary>
        /// <param name="propertyName">Name of the affected property.</param>
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
