﻿using System;
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
using System.Collections;

namespace InventoryManager.element.domain
{
    public class element : IEnumerable<element>
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

        public override string ToString()
        {
            if (name == null) return "No object";
            return "Name: " + name + " Expiry date: " + expiryDate + " Type: " + type + " Price: " + price + " Weight: " + weight;

        }

        public IEnumerator<element> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
