using ExampleStockManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleStockManagement.Model
{
    class Order:IIdentifiable
    {
        private static uint count = 0;
        private uint orderId;

        public uint OrderId
        {
            get { return orderId; }
        }
        private List<Item> items;

        public List<Item> Items
        {
            get { return items; }
            set { items = value; }
        }
        private Warehouse location;

        public Warehouse Location
        {
            get { return location; }
            set { location = value; }
        }

        public object Id => orderId;

        public Order(Warehouse location) : this(location, count++) { }
        public Order(Warehouse location, uint orderId)
        {
            this.orderId = orderId;
            this.location = location;
            this.items = new List<Item>();
        }
        public override string ToString()
        {
            string stringItems = "";
            foreach (Item item in Items)
            {
                stringItems += item.ItemId + ";";
            }
            stringItems = stringItems.Substring(0, stringItems.Length - 1);
            return string.Format("{0};{1};"+stringItems,orderId,location);
        }
    }
}
