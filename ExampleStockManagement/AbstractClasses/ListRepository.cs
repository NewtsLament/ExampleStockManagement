using ExampleStockManagement.Interfaces;
using ExampleStockManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleStockManagement.AbstractClasses
{
    public abstract class ListRepository : IRepository
    {
        protected static List<IIdentifiable> storage = new List<IIdentifiable>();

        public virtual void Create(IIdentifiable entity)
        {
            if (storage.Find(x => x.Id == entity.Id) == null)
            {
                storage.Add(entity);
            }
        }

        public void Delete(IIdentifiable entity)
        {
            storage.Remove(entity);
        }

        public virtual IIdentifiable Read(object id)
        {
            return storage.Find(x => x.Id == id);
        }

        public IEnumerable<IIdentifiable> ReadAll()
        {
            return storage;
        }

        public abstract void Update(IIdentifiable entity);
    }
}
