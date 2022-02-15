using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ExampleStockManagement.Model;

namespace ExampleStockManagement.Repository
{
    class WarehouseFileRepository
    {
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        private List<Warehouse> wareHouses;

        public List<Warehouse> Warehouses
        {
            get { return wareHouses; }
            set { wareHouses = value; }
        }

        public WarehouseFileRepository(string fileName)
        {
            this.fileName = fileName;
            Read();
        }

        public Warehouse Create(string name)
        {
            if (null != wareHouses.Find(x => x.Name == name))
            {
                Warehouse warehouse = new Warehouse(name);
                wareHouses.Add(warehouse);
                Write();
                return warehouse;
            }
            else
            {
                return null;
            }
        }

        public Warehouse Retrieve(string name)
        {
            return wareHouses.Find(x => x.Name == name);
        }

        public void Update()
        {
            Write();
        }

        public void Delete(Warehouse warehouse)
        {
            wareHouses.Remove(warehouse);
            Write();
        }

        private void Write()
        {
            using (StreamWriter sw = new StreamWriter("fileName"))
            {
                foreach (Warehouse item in wareHouses)
                {
                    sw.WriteLine(item.Name);
                }
            }
        }

        private void Read()
        {
            this.wareHouses = new List<Warehouse>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    wareHouses.Add(new Warehouse(line));
                }
            }
        }
    }
}
