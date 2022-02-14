using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ExampleStockManagement.Model;

namespace ExampleStockManagement.Repository
{
    class ItemFileRepository
    {
        private uint itemIdMax = 0;
        private string fileName;
        private List<Item> items;
        public ItemFileRepository(string fileName)
        {
            this.fileName = fileName;
            Read();
        }
        public Item Create(string description)
        {
            Item item = new Item(++itemIdMax, description.Replace(';',','));
            items.Add(item);
            Write();
            return item;
        }
        public Item Retrieve(uint itemId)
        {
            return items.Find(x => x.ItemId == itemId);
        }
        public void Update()
        {
            Write();
        }
        public void Delete(Item item)
        {
            items.Remove(item);
            Write();
        }
        private void Write()
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (Item item in items)
                {
                    sw.WriteLine(item.ToString());
                }
            }
        }
        private void Read()
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line,stringItemId,description;
                uint itemId;
                string[] stringArr;
                while ((line = sr.ReadLine())!=null)
                {
                    stringArr = line.Split(';');
                    stringItemId = stringArr[0];
                    description = stringArr[1];

                    itemId = uint.Parse(stringItemId);
                    items.Add(new Item(itemId, description));
                    if (this.itemIdMax < itemId)
                        this.itemIdMax = itemId;
                }
            }
        }
    }
}
