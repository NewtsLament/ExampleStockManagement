using ExampleStockManagement.Interfaces;
using ExampleStockManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleStockManagement.Model
{
    class Item:ObservableObject,IIdentifiable
    {
        private static uint count = 0;
        private uint itemId;

        public uint ItemId
        {
            get { return itemId; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set {
                OnPropertyChanged(nameof(Description));
                description = value; }
        }
        private List<Order> orders;

        public List<Order> Orders
        {
            get { return orders; }
            set { orders = value; }
        }

        public object Id => itemId;

        public Item(string description) : this(description, count++) {}
        public Item(string description, uint itemId)
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
