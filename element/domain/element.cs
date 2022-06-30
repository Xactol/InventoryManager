using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Data.SQLite;

namespace InventoryManager
{
    public class element
    {
        public string name { get; set; }
        public DateTime expiryDate { get; set; }
        public string type { get; set; }
        public double price { get; set; }
        public double weight { get; set; }

        public element(string name, string type)
        {
            this.name = name;
            this.type = type;
        }

        public element(string name, DateTime expiryDate, string type, double price, double weight)
        {
            this.name = name;
            this.expiryDate = expiryDate;
            this.type = type;
            this.price = price;
            this.weight = weight;
        }

    }
}
