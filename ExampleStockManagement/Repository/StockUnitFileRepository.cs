using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ExampleStockManagement.Model;

namespace ExampleStockManagement.Repository
{
    class StockUnitFileRepository
    {
        private string fileName;
        private ItemFileRepository itemFileRepository;
        private WarehouseFileRepository warehouseFileRepository;

        private List<StockUnit> stockUnits;

        public List<StockUnit> StockUnits
        {
            get { return stockUnits; }
            set { stockUnits = value; }
        }


        public StockUnitFileRepository(string fileName, ItemFileRepository itemFileRepository, WarehouseFileRepository warehouseFileRepository)
        {
            this.itemFileRepository = itemFileRepository;
            this.warehouseFileRepository = warehouseFileRepository;
            this.fileName = fileName;
            this.stockUnits = new List<StockUnit>();
            Read();
        }
        public StockUnit Create(uint quaintity, uint itemId, string warehouseName)
        {
            if (stockUnits.Find(x => x.CountsItem.ItemId == itemId && x.ItemIsIn.Name == warehouseName) != null)
            {
                StockUnit stockUnit = new StockUnit(quaintity, itemFileRepository.Retrieve(itemId), warehouseFileRepository.Retrieve(warehouseName));
                stockUnits.Add(stockUnit);
                Write();
                return stockUnit;
            }
            else
            {
                return null;
            }
        }
        public StockUnit Retrieve(uint itemId, string warehouseName)
        {
            return stockUnits.Find(x => x.CountsItem.ItemId == itemId && x.ItemIsIn.Name == warehouseName);
        }
        public void Update()
        {
            Write();
        }
        public void Delete(StockUnit stockUnit)
        {
            stockUnits.Remove(stockUnit);
            Write();
        }
        private void Write()
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (StockUnit stockUnit in stockUnits)
                {
                    sw.WriteLine(stockUnit.ToString());
                }
            }
        }
        private void Read()
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                string[] lineArr;
                uint quantity, itemId;
                string warehouseName;

                StockUnit stockUnit;

                while ((line = sr.ReadLine())!=null)
                {
                    lineArr = line.Split(';');
                    quantity = uint.Parse(lineArr[0]);
                    itemId = uint.Parse(lineArr[1]);
                    warehouseName = lineArr[2];

                    stockUnit = new StockUnit(quantity, itemFileRepository.Retrieve(itemId), warehouseFileRepository.Retrieve(warehouseName));
                    stockUnits.Add(stockUnit);
                }
            }
        }
    }
}
