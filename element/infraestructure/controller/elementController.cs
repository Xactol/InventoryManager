using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    public class elementController
    {
        private  elementRepository repository;

        public void init() {
            repository = new elementRepository();   
            repository.init();
        }

        public int count() {
            return repository.getNumElements();
        }
        public  IEnumerable<element> getAll(){
            return repository.getAll();
        }

        public element getByName(String name){
            return repository.findByName(name);
        }

        public bool deleteByName(String name) {
            return repository.remove(name);
        }

        public element addElement(String name, DateTime expiryDate, string type, double price, double weight) {
            var temp = new element(name, expiryDate, type, price, weight);
            if (repository.save(temp)) 
                return temp;
            
            throw new Exception ("The element can´t be added to the database");
        }


    }
}
