using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagrammOfClasses
{/// <summary>
/// Реализует интерфейс IRent
/// </summary>
    class Customers : Interface_IRent
    {
        public int IdCustomer { get; set; }
        public string Title { get; set; }
        public string Requisites { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactPerson { get; set; }
        public string Adress { get; set; }
        public Program program { get; set;}
        public ArendatorTOP arendator { get; set;}
        public Rent rent { get; set; }

        public Customers customers;

        public RetalOutlets outlets;

        public Customers(RetalOutlets retal ,ArendatorTOP arendatorTOP, Program programClass, Rent rent2, Customers customersClass) 
        {
            outlets = retal;
            customers = customersClass;
            program = programClass;
            arendator = arendatorTOP;
            rent = rent2;
            if (program.isCustomer) 
            {
                Menu();
            }
        }
        /// <summary>
        /// Основное меню
        /// </summary>
        public void Menu() 
        {
            ConsoleKey key;

            Console.WriteLine("---------------------------");
            Console.WriteLine("Клавиша 1 - Получить список всех клиентов\nКлавиша 2 - Найти определенного клиента\nКлавиша Escape - Назад.");
            Console.WriteLine("---------------------------");

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.D1)
            {
                if (arendator == null)
                {
                    Console.WriteLine("Список клиентов пуст!");
                    Menu();
                }
                else 
                {
                    SeeCustomers();
                    Menu();
                }       
            }
            else if (key == ConsoleKey.D2)
            {
                if (arendator == null)
                {
                    Console.WriteLine("Список клиентов пуст!");
                    Menu();
                }
                else
                {
                    SearchCustomers();
                    Menu();
                }
            }
            else if (key == ConsoleKey.Escape)
            {
                Console.Clear();
                program.Menu(arendator);
            }
        }
        public void SeeCustomers() 
        {
            Console.WriteLine("Результат:");
            arendator.SeeCustomers();
        }
        /// <summary>
        /// Функлионал поиска клиента по различным данным о нем
        /// </summary>
        public void SearchCustomers()
        {
            ConsoleKey key;

            Console.WriteLine("---------------------------");
            Console.WriteLine("Для поиска клиента необходимо ввести один из следующих фактов о клиенте:\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-Название фирмы клиента;\n-ФИО заказчика;\n-или ИНН.");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("После нажать Enter!");
            Console.WriteLine("Для отмены необходимо нажать ESC!");
            Console.ResetColor();
            Console.WriteLine("---------------------------");

            Console.Write("Поиск:");
            string search = Console.ReadLine();

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Enter)
            {
                var customer = arendator.CustomersList.Where(p => p.ContactPerson == search || p.Title == search || p.Requisites == search).ToList();
                if (customer.Count != 0)
                {
                    foreach (Customers c in customer)
                    {
                        Console.WriteLine("-------------------------------------------------------------------");
                        Console.WriteLine("Id:{0}\nНазвание:{1}\nИНН:{2}\nТелфон:{3}\nФИО:{4}\nАдрес:{5}", c.IdCustomer, c.Title, c.Requisites, c.PhoneNumber, c.ContactPerson, c.Adress);
                        Console.WriteLine("-------------------------------------------------------------------");
                    }
                }
                else 
                {
                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Клиент не найден!");
                    Console.ResetColor();
                }
            }
            else if (key != ConsoleKey.Enter)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Команда не расспознана!");
                Console.WriteLine("Попробуйте снова!");
                Console.ResetColor();
                SearchCustomers();
            }
        }
    }
}
