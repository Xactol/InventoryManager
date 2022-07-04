using InventoryManager.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Model.Infraestructure.Repository
{
    public interface IBaseRepository
    {
        public void init();
        public void close();
        public bool save(Element entity);
        public IEnumerable<Element> getAll();
        public int getNumElements();
        public bool remove(String name);
        public Element findByName(String name);
        public void initTable();
        public void fillTable();
    }
}
