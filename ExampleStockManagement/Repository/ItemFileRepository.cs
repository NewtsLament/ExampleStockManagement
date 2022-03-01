using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ExampleStockManagement.Model;
using ExampleStockManagement.Interfaces;
using ExampleStockManagement.AbstractClasses;

namespace ExampleStockManagement.Repository
{
    class ItemFileRepository : ListRepository
    {
        public override void Update(IIdentifiable entity)
        {
            Item oldData = storage.Find(x => x.Id == entity.Id) as Item;
            Item newData = entity as Item;
            oldData.Description = newData.Description;
        }
    }
}
