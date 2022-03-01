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
        public override void Create(IIdentifiable entity)
        {
            if (storage.Find(x => (x.Id as string) == (entity.Id as string)) == null)
            {
                storage.Add(entity);
            }
        }
        public override IIdentifiable Read(object id)
        {
            return storage.Find(x => (x.Id as string) == (id as string));
        }
    }
}
