using InventoryManager.Model.Domain;
using InventoryManager.Model.Infraestructure.Repository;

namespace InventoryManager.Model.Infraestrucure.Controller
{
    public class ElementController
    {
        private IBaseRepository repository;

        public void init(DatabaseType DBType)
        {
            switch (DBType)
            {
                case DatabaseType.Sqlite:
                    repository = new SQLiteElementRepository();
                    break;
                case DatabaseType.SQLServer:
                    break;
            }

            repository.init();
        }

        public int count()
        {
            return repository.getNumElements();
        }

        public IEnumerable<Element> getAll()
        {
            return repository.getAll();
        }

        public Element getByName(String name)
        {
            return repository.findByName(name);
        }

        public bool deleteByName(String name)
        {
            return repository.remove(name);
        }

        public Element addElement(String name, DateTime expiryDate, string type, double price, double weight)
        {
            var temp = new Element(name, expiryDate, type, price, weight);

            if (repository.save(temp))
                return temp;

            return null;
        }
    }
}
