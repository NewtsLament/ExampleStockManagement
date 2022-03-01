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
        public override void Create(IIdentifiable entity)
        {
            if (storage.Find(x => (int)x.Id == (int)entity.Id) == null)
            {
                storage.Add(entity);
            }
        }
        public override IIdentifiable Read(object id)
        {
            return storage.Find(x => (int)x.Id == (int)id);
        }
    }
}
