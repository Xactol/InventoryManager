
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace InventoryManager
{

    public class Inventory 
    {
        public static void Main()
        {

            database.initDDBB();
            elementController.initTable();
           // Employee.initTable();
            
      /*      var temp = element.getAll();
            var query = from e in temp  select e;
            Console.WriteLine(query.Last().name);
      */

            



            database.closeDDBB();
        }

       
      
        
    }

}