
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using InventoryManager.Model.Infraestrucure.Controller;
using InventoryManager.Model;

namespace InventoryManager
{
    public class Inventory 
    {
        /*    public delegate void alertSender(Object sender, alerts alert);
            public event alertSender alertDetected;
        */
        public static void Main()
        {
            String welcomeMessage = "Hello, welcome to your personal invetory manager, \n" +
                                    "Press e to exit from the application \n" +
                                    "Press a to add a new object to your inventory \n" +
                                    "Press d to delete an object from the inventory \n" +
                                    "Press l to get a list of all objects \n"
                                    ;
            bool running = true;
            
            ElementController controller = new();
            controller.init();

            while (running)
            {
                Console.WriteLine(welcomeMessage);
                char temp = Convert.ToChar(Console.ReadLine());
                switch (temp)
                {
                    case 'e':
                        running = false;
                        break;
                    case 'a':
                        addItem();
                        break;
                    case 'd':
                        deleteItem();
                        break;
                    case 'l':
                        getAllObjects();
                        break;
                }
            }

            void addItem()
            {
                try
                {
                    String name, type;
                    DateTime expire;
                    double price, weight;
                    Console.WriteLine("Please, introduce the name of your item, and press 'enter'  ");
                    name = Console.ReadLine();
                    Console.WriteLine("Please, introduce the type of your item, and press 'enter'  ");
                    type = Console.ReadLine();
                    Console.WriteLine("Please, introduce the weight of your item, and press 'enter'  ");
                    weight = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Please, introduce the price of your item, and press 'enter'  ");
                    price = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Please, introduce the expiration date for your price, and press 'enter' \n Note: Use the next sintax  '2022,06,10' ");
                    expire = Convert.ToDateTime(Console.ReadLine());
                    controller.addElement(name, expire, type, price, weight);
                    Console.WriteLine("You added a new item to manager successfull");
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Error: " + exp.Message);
                }
            }

            /*
            protected virtual void RaiseAlertEvent() {
            alertDetected?.Invoke(this, new alerts());
            }
            */

            void deleteItem()
            {
                Console.WriteLine("Please, insert the name of the object that you want to delete");
                var name = Console.ReadLine();
                controller.deleteByName(name);
                Console.WriteLine("Your object was deleted successfull");
            }

            void getAllObjects()
            {
                foreach (var item in controller.getAll())
                {
                    Console.WriteLine(item);
                }

            }

            controller.count();
        }
    }
}