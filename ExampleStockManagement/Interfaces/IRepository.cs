using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleStockManagement.Interfaces
{
    interface IRepository
    {
        public void Create(IIdentifiable entity);
        public IIdentifiable Read(Object id);
        public IEnumerable<IIdentifiable> ReadAll();
        public void Update(IIdentifiable entity);
        public void Delete(IIdentifiable entity);
    }
}
