using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ExampleStockManagement.Model;

namespace ExampleStockManagement.Repository
{
    class OrderFileRepository
    {
        private string fileName;
        WarehouseFileRepository warehouseFileRepository;
        ItemFileRepository itemFileRepository;
        private List<Order> orders;
        private uint orderIdMax = 0;
        public OrderFileRepository(string fileName,WarehouseFileRepository warehouseFileRepository, ItemFileRepository itemFileRepository)
        {
            this.fileName = fileName;
            this.warehouseFileRepository = warehouseFileRepository;
            this.itemFileRepository = itemFileRepository;
            orders = new List<Order>();
            Read();
        }
        public Order Create(string warehousName)
        {
            Order order = new Order(++orderIdMax, warehouseFileRepository.Retrieve(warehousName));
            orders.Add(order);
            Write();
            return order;
        }
        public Order Retrieve(uint orderId)
        {
            return orders.Find(x => x.OrderId == orderId);
        }
        public void Update()
        {
            Write();
        }
        public void Delete(Order order)
        {
            orders.Remove(order);
            Write();
        }
        private void Write()
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (Order order in orders)
                {
                    sw.WriteLine(order.ToString());
                }
            }
        }
        private void Read()
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                string[] lineArr;

                string stringOrderId, stringWarehouse;

                uint orderId;
                Warehouse warehouse;
                Item tempItem;
                List<Item> items;
                Order order;

                while ((line = sr.ReadLine())!= null)
                {
                    lineArr = line.Split(';');
                    stringOrderId = lineArr[0];
                    stringWarehouse = lineArr[1];

                    orderId = uint.Parse(stringOrderId);
                    warehouse = warehouseFileRepository.Retrieve(stringWarehouse);

                    order = new Order(orderId, warehouse);
                    if (orderIdMax < orderId)
                    {
                        orderIdMax = orderId;
                    }

                    items = new List<Item>();
                    for (int i = 2; i < lineArr.Length; i++)
                    {
                        tempItem = itemFileRepository.Retrieve(uint.Parse(lineArr[i]));
                        items.Add(tempItem);
                        tempItem.Orders.Add(order);
                    }
                }
            }
        }
    }
}
