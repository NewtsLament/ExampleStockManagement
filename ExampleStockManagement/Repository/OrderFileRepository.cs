using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ExampleStockManagement.Model;
using ExampleStockManagement.Interfaces;
using ExampleStockManagement.AbstractClasses;

namespace ExampleStockManagement.Repository
{
    class OrderFileRepository : ListRepository
    {
        public override void Update(IIdentifiable entity)
        {
            Order oldData = storage.Find(x => x.Id == entity.Id) as Order;
            Order newData = entity as Order;
            oldData.Location = newData.Location;
        }
    }
}
