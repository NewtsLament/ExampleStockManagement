using System;
using System.Collections.Generic;
using System.Text;
using ExampleStockManagement.Repository;
using ExampleStockManagement.Model;
using System.Collections.ObjectModel;

namespace ExampleStockManagement.ViewModel
{
    class StockManagementViewModel
    {
        CoreRepository coreRepository;
        private ObservableCollection<Warehouse> warehouses;

        public ObservableCollection<Warehouse> Warehouses
        {
            get { return warehouses; }
            set { warehouses = value; }
        }

        private ObservableCollection<StockUnit> stockUnits;

        public ObservableCollection<StockUnit> StockUnits
        {
            get { return stockUnits; }
            set { stockUnits = value; }
        }


        public StockManagementViewModel()
        {
            coreRepository = new CoreRepository("test");
            warehouses = new ObservableCollection<Warehouse>(coreRepository.WarehouseRepository.Warehouses);
            stockUnits = new ObservableCollection<StockUnit>(coreRepository.StockUnitRepository.StockUnits);
        }

        public void CreateItem(string name)
        {
            warehouses.Add(coreRepository.WarehouseRepository.Create(name));
        }
    }
}
