using System.Data.SQLite;
using System.Collections.Generic;

namespace InventoryManager.Data
{
    public class Database
    {
        public Database() { }
        public static void initDDBB() {
            SQLiteConnection.CreateFile("ddbbInventory.sqlite");

            constants.conexion = new SQLiteConnection("Data Source=ddbbInventory.sqlite;Version=3;");
            constants.conexion.Open();

            Console.WriteLine(" Database has been opened successfull ");
        }
        public static void closeDDBB()
        {
            constants.conexion.Close();

            Console.WriteLine(" Database has been closed successfull ");
        }
    }
}