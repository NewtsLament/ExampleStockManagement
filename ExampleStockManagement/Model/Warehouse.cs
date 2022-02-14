using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleStockManagement.Model
{
    class Warehouse
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Warehouse(string name)
        {
            this.name = Name;
        }
    }
}
