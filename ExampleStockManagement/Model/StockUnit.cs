using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleStockManagement.Model
{
    class StockUnit
    {
        private uint quantity;

        public uint Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        private Item countsItem;

        public Item CountsItem
        {
            get { return countsItem; }
        }
        private Warehouse itemIsIn;

        public Warehouse ItemIsIn
        {
            get { return itemIsIn; }
            set { itemIsIn = value; }
        }


        public StockUnit(uint quantity,Item countsItem, Warehouse itemIsIn)
        {
            this.quantity = quantity;
            this.countsItem = countsItem;
            this.itemIsIn = itemIsIn;
        }

        public override string ToString()
        {
            return string.Format("{0};{1};{2}",quantity,countsItem.ItemId,itemIsIn.Name);
        }
    }
}
