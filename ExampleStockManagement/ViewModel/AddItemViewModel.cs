using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleStockManagement.ViewModel
{
    class AddItemViewModel : ObservableObject
    {
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

    }
}
