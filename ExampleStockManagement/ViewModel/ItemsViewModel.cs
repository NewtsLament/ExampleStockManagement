using System;
using System.Collections.Generic;
using System.Text;
using ExampleStockManagement.Repository;
using ExampleStockManagement.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using ExampleStockManagement.AbstractClasses;

namespace ExampleStockManagement.ViewModel
{
    class ItemsViewModel : ObservableObject
    {
        CoreRepository repository;

        private ObservableCollection<Item> items;

        public ObservableCollection<Item> Items
        {
            get { return items; }
            set { items = value; }
        }

        private Item choosen;

        public Item Choosen
        {
            get { return choosen; }
            set {
                OnPropertyChanged(nameof(Choosen));
                choosen = value; }
        }


        public ItemsViewModel()
        {
            repository = new CoreRepository("test");
            items = new ObservableCollection<Item>();
            foreach (var item in repository.ItemRepository.ReadAll())
            {
                items.Add(item as Item);
            }
        }

        internal void DeleteItem()
        {
            repository.ItemRepository.Delete(Choosen);
            items.Remove(Choosen);
        }

        public void CreateItem(string description)
        {
            Item tempItem = new Item(description);
            repository.ItemRepository.Create(tempItem);
            items.Add(tempItem);
        }

        internal void UpdateItem(string description)
        {
            Choosen.Description = description;
            repository.ItemRepository.Update(Choosen);
        }
    }
}
