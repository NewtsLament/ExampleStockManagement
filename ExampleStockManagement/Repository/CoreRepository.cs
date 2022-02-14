using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleStockManagement.Repository
{
    class CoreRepository
    {
        private string fileName;
        private WarehouseFileRepository warehouseFileRepository;
        public WarehouseFileRepository WarehouseRepository
        {
            get { return warehouseFileRepository; }
        }
        private ItemFileRepository itemFileRepository;

        public ItemFileRepository ItemRepository
        {
            get { return itemFileRepository; }
        }
        private OrderFileRepository orderFileRepository;

        public OrderFileRepository OrderRepository
        {
            get { return orderFileRepository; }
        }
        private StockUnitFileRepository stockUnitFileRepository;

        public StockUnitFileRepository StockUnitRepository
        {
            get { return stockUnitFileRepository; }
        }
        public CoreRepository(string fileName)
        {
            this.fileName = fileName;
            warehouseFileRepository = new WarehouseFileRepository(fileName + "_warehouse.txt");
            itemFileRepository = new ItemFileRepository(fileName + "_item.txt");
            orderFileRepository = new OrderFileRepository(fileName + "_order.txt",warehouseFileRepository,itemFileRepository);
            stockUnitFileRepository = new StockUnitFileRepository(fileName + "_stockUnit.txt",itemFileRepository,warehouseFileRepository);
        }
    }
}
