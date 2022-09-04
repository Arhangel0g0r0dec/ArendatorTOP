using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagrammOfClasses
{
    class Program
    {
        public bool isRent = false;
        public bool isRetalAdd = false;
        public bool isCustomer = false;
        public bool isArendator = false;
        public bool isNewArendator = true;
        public bool isRetalOutlet = false;
        public static Rent rentClass;
        public static ArendatorTOP arendatorClass;
        public static RetalOutlets retal;
        public static Customers customersClass;
        public static Program program;
        public Program(ArendatorTOP arendatorTOP, RetalOutlets outlets, Rent rent, Customers customers)
        { 
            customersClass = customers;
            rentClass = rent;
            retal = outlets;
            arendatorClass = arendatorTOP;
            Menu(arendatorClass);
            
        }

        public static void Main()
        {
            program = new Program(arendatorClass, retal, rentClass, customersClass);
        }

        

        public void Menu(ArendatorTOP arendatorTOP)
        {
            arendatorClass = arendatorTOP;
            ConsoleKey key;
            Console.WriteLine($"Меню:\nКлавиша 1 - Клиенты\nКлавиша 2 - Помещения\nКлавиша 3 - Аренда\nКлавиша 4 - Функции ArendatorTOP\nEcs - Выход.");

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.D1)
            {
                isCustomer = true;
                customersClass = new Customers(retal, arendatorClass, this, rentClass, customersClass);
            }
            else if (key == ConsoleKey.D2)
            {
                isArendator = false;
                isCustomer = false;
                isRetalOutlet = true;
                isRetalAdd = false;
                RetalOutlets  retal = new RetalOutlets(this, arendatorClass);
            }
            else if (key == ConsoleKey.D3)
            {
                isCustomer = false;
                isRetalOutlet = false;
                isRent = true;
                rentClass = new Rent(arendatorClass, this);
            }
            else if (key == ConsoleKey.D4)
            {
                isRetalAdd = true;
                isCustomer = false;
                isArendator = true;

                if (isNewArendator)
                {
                    arendatorClass = new ArendatorTOP(this, arendatorClass);
                }
                else
                    arendatorClass.MainMenu();
            }
            else if (key == ConsoleKey.Escape)
            {
                Console.WriteLine("Вы уверены, что хотите выйти?\nДа - Enter Нет - ESC");
                key = Console.ReadKey().Key;

                if (key == ConsoleKey.Enter)
                {
                    Environment.Exit(0);
                }
                else if (key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Main();
                }
            }
            else
            {
                Console.WriteLine("Введенная команда не расспознана!");
                Main();
            }
            Console.ReadLine();
        } 
    }
}
