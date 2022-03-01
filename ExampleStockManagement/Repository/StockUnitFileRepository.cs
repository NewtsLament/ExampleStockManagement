using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ExampleStockManagement.Model;
using ExampleStockManagement.Interfaces;
using ExampleStockManagement.AbstractClasses;

namespace ExampleStockManagement.Repository
{
    class StockUnitFileRepository : ListRepository
    {
        public override void Update(IIdentifiable entity)
        {
            StockUnit oldData = storage.Find(x => x.Id == entity.Id) as StockUnit;
            StockUnit newData = entity as StockUnit;
            oldData.ItemIsIn = newData.ItemIsIn;
            oldData.Quantity = newData.Quantity;
        }
    }
}
