using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ExampleStockManagement.Model;
using ExampleStockManagement.Interfaces;
using ExampleStockManagement.AbstractClasses;

namespace ExampleStockManagement.Repository
{
    class WarehouseFileRepository : ListRepository
    {
        public override void Update(IIdentifiable entity)
        {
            // Not applicable.
        }
    }
}
