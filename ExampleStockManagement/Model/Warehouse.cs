using ExampleStockManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleStockManagement.Model
{
    class Warehouse:IIdentifiable
    {
        private string name;

        public string Name
        {
            get { return name; }
        
        }

        public object Id => name;

        public Warehouse(string name)
        {
            this.name = name;
        }
    }
}
