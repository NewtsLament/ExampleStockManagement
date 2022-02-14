using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleStockManagement.Model
{
    class Item
    {
        private uint itemId;

        public uint ItemId
        {
            get { return itemId; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private List<Order> orders;

        public List<Order> Orders
        {
            get { return orders; }
            set { orders = value; }
        }

        public Item(uint itemId, string description)
        {
            this.itemId = itemId;
            this.description = description;
            this.orders = new List<Order>();
        }
        public override string ToString()
        {
            return string.Format("{0};{1}",itemId,description);
        }
    }
}
