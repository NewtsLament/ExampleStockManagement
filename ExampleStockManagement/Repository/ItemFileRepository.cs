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
            IIdentifiable oldIdentifiable = storage.Find(x => (uint)x.Id == (uint)entity.Id);
            Item oldData = oldIdentifiable as Item;
            Item newData = entity as Item;
            oldData.Description = newData.Description;
        }
        public override void Create(IIdentifiable entity)
        {
            if (storage.Find(x => (uint)x.Id == (uint)entity.Id) == null)
            {
                storage.Add(entity);
            }
        }
        public override IIdentifiable Read(object id)
        {
            return storage.Find(x => (uint)x.Id == (uint)id);
        }
    }
}
