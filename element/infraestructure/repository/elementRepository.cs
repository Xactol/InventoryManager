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
    public class elementRepository
    {
        public bool save(String name, DateTime expiryDate, string type, double price, double weight) {
            String sql = "insert into element (name,expiryDate, type, price, weight) " +
                         "values ('" + name + "','" + expiryDate + "','" + type + "'," + price + "," + weight + ")";
            SQLiteCommand command = new SQLiteCommand(sql, constants.conexion);
            return command.ExecuteNonQuery() > 0;
        }


        public IEnumerable<element> getAll() {
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM element", constants.conexion);
            SQLiteDataReader result = command.ExecuteReader();
            var tempEmployees = new List<element>();
            while (result.Read())
            {
                tempEmployees.Add(new element(Convert.ToString(result[0])
                                                , Convert.ToDateTime(result[1])
                                                , Convert.ToString(result[2])
                                                , Convert.ToDouble(result[3])
                                                , Convert.ToDouble(result[4])
                                                ));
            }
            return tempEmployees;
        }


        public bool remove() {

            return false;
        }



    }


}
