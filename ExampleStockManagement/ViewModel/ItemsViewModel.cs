using System;
using System.Collections.Generic;
using System.Text;
using ExampleStockManagement.Repository;
using ExampleStockManagement.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ExampleStockManagement.ViewModel
{
    class ItemsViewModel
    {
        CoreRepository repository;

        private ObservableCollection<Item> items;

        public ObservableCollection<Item> Items
        {
            get { return items; }
            set { items = value; }
        }

        public ItemsViewModel()
        {
            repository = new CoreRepository("test");
            items = new ObservableCollection<Item>(repository.ItemRepository.Items);
        }

        public void CreateItem(string description)
        {
            items.Add(repository.ItemRepository.Create(description));
        }
    }
}
