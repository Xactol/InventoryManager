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


        public static void initTable()
        {

            string sql = "CREATE TABLE IF NOT EXISTS element" +
                " (name VARCHAR(45) PRIMARY KEY," +
                "  expiryDate SMALLDATETIME," +
                "  type VARCHAR(25)," +
                "  price NUMBER(10)," +
                "  weight NUMBER(10))";

            SQLiteCommand command = new SQLiteCommand(sql, constants.conexion);
            command.ExecuteNonQuery();
            fillTable();

        }


        public static void fillTable()
        {
            string sql = "insert into element (name,expiryDate, type, price, weight) " +
                         "values ('Computer','2035-12-12 22:00:00', 'Technology', 255, 120.56)";
            SQLiteCommand command = new SQLiteCommand(sql, constants.conexion);
            command.ExecuteNonQuery();
            sql = "insert into element (name,expiryDate, type, price, weight) " +
                  "values ('Mouse','2030-10-20 20:12:45', 'I/O Technology', 15, 0.80 )";
            command = new SQLiteCommand(sql, constants.conexion);
            command.ExecuteNonQuery();
        }

        public static IEnumerable<element> getAll()
        {

            SQLiteCommand command = new SQLiteCommand("SELECT * FROM element", constants.conexion);
            SQLiteDataReader result = command.ExecuteReader();
            IEnumerable<element> employees;
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
            employees = tempEmployees;
            return employees;

        }


    }
}
