using System;
using System.Collections.Generic;
using System.Text;
using ExampleStockManagement.Repository;
using ExampleStockManagement.Model;
using System.Collections.ObjectModel;
using ExampleStockManagement.Interfaces;

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

            warehouses = new ObservableCollection<Warehouse>();
            foreach (var item in coreRepository.WarehouseRepository.ReadAll())
            {
                warehouses.Add(item as Warehouse);
            }
            stockUnits = new ObservableCollection<StockUnit>();
            foreach (var item in coreRepository.StockUnitRepository.ReadAll())
            {
                stockUnits.Add(item as StockUnit);
            }
        }

        public void CreateItem(string name)
        {
            Warehouse tempWarehouse = new Warehouse(name);
            coreRepository.WarehouseRepository.Create(tempWarehouse);
            warehouses.Add(tempWarehouse);
        }
    }
}
