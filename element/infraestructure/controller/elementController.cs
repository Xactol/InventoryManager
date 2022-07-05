using InventoryManager.element.infraestructure.repository;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.element.infraestructure.controller
{
    public class elementController
    {
        private elementRepository repository;

        public void init()
        {
            repository = new elementRepository();
            repository.init();
        }

        public int count()
        {
            return repository.getNumElements();
        }
        public IEnumerable<domain.element> getAll()
        {
            return repository.getAll();
        }

        public domain.element getByName(string name)
        {
            return repository.findByName(name);
        }

        public bool deleteByName(string name)
        {
            return repository.remove(name);
        }

        public domain.element addElement(string name, DateTime expiryDate, string type, double price, double weight)
        {
            var temp = new domain.element(name, expiryDate, type, price, weight);
            if (repository.save(temp))
                return temp;

            throw new Exception("The element can´t be added to the database");
        }


    }
}
