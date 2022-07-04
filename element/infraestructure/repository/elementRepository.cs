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

        public void init() {
            initTable();
            fillTable();
        }
    
        public bool save(element entity) {
            String sql = "insert into element (name,expiryDate, type, price, weight) " +
                         "values (@name, @expiryDate, @type, @price, @weight)";
            SQLiteCommand command = new SQLiteCommand(sql, constants.conexion);
            command.Parameters.AddWithValue("@name", entity.name);
            command.Parameters.AddWithValue("@expiryDate", entity.expiryDate);
            command.Parameters.AddWithValue("@type", entity.type);
            command.Parameters.AddWithValue("@price", entity.price);
            command.Parameters.AddWithValue("@weight", entity.weight);
            return command.ExecuteNonQuery() > 0;
        }


        public IEnumerable<element> getAll() {
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM element", constants.conexion);
            SQLiteDataReader result = command.ExecuteReader();
            var tempEmployees = new List<element>();
            return sqlitecommandToEntityList(result);
        }


        public int getNumElements() {
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM element", constants.conexion);
            SQLiteDataReader result = command.ExecuteReader();
            var tempEmployees = new List<element>();
            return sqlitecommandToEntityList(result).Count();
        }

        public bool remove(String name) {
            try
            {
                findByName(name);
            }
            catch (Exception ex) {
                throw new KeyNotFoundException("No element with this name has been found");
            }
            SQLiteCommand command = new SQLiteCommand("DELETE FROM element WHERE name =@name", constants.conexion);
            command.Parameters.AddWithValue("@name", name);
            SQLiteDataReader result = command.ExecuteReader();
            return true;
        }

        public element findByName(String name) {
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM element WHERE name = @name", constants.conexion);
            command.Parameters.AddWithValue("@name",name);
            Console.WriteLine(command.CommandText);
            SQLiteDataReader result = command.ExecuteReader();
            try
            {
                return sqlitecommandToEntity(result);
            }
            catch (InvalidOperationException ex) {
                throw new KeyNotFoundException("No element found with this name: "+ name);
            }
            
            throw new ApplicationException("An exception ocurred when obtaining fields from database");
        }

        public void initTable()
        {

            string sql = "CREATE TABLE IF NOT EXISTS element" +
                " (name VARCHAR(45) PRIMARY KEY," +
                "  expiryDate SMALLDATETIME," +
                "  type VARCHAR(25)," +
                "  price NUMBER(10)," +
                "  weight NUMBER(10))";

            SQLiteCommand command = new SQLiteCommand(sql, constants.conexion);
            command.ExecuteNonQuery();

        }


        public void fillTable()
        {
            save(new element("Computer", new DateTime(2035, 12 ,12, 22,00,00), "Technology", 255, 120.56));
            save(new element("Mouse", new DateTime(2020, 10, 15, 13, 15, 00), "I/O Technology", 24, 0.34));
        
        }


        private element sqlitecommandToEntity(SQLiteDataReader reader) {
                while (reader.Read())
                {
                    return new element(Convert.ToString(reader[0])
                                                , Convert.ToDateTime(reader[1])
                                                , Convert.ToString(reader[2])
                                                , Convert.ToDouble(reader[3])
                                                , Convert.ToDouble(reader[4])
                                                );
                }
                throw new NullReferenceException("The datareader is null or unavaible");
        }

        private IEnumerable<element> sqlitecommandToEntityList(SQLiteDataReader reader)
        {
            var temp = new List<element>();
            while (reader.Read())
            {
                temp.Add(new element(Convert.ToString(reader[0])
                                            , Convert.ToDateTime(reader[1])
                                            , Convert.ToString(reader[2])
                                            , Convert.ToDouble(reader[3])
                                            , Convert.ToDouble(reader[4])
                                            )
                        ); 
            }
            return temp;
            throw new NullReferenceException("The datareader is null or unavaible");
        }



    }


}
