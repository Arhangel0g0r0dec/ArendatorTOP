using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagrammOfClasses
{
    class Rent
    {
        public ArendatorTOP arendatorTOP { get; set; }
        public Program programClass { get; set; }
        public int IdRent { get; set; }
        public int IdRetalOutlets { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public decimal PriceR { get; set; }
        public Customers Customers { get; internal set; }

        public Rent(ArendatorTOP arendatorClass, Program program) 
        {
            arendatorTOP = arendatorClass;
            programClass = program;
            if (programClass.isRent) 
            {
                Menu();
            }
        }

        private void SeeRent() 
        {
            Console.WriteLine("Результат:");
            arendatorTOP.SeeRents();
        }

        private void Menu() 
        {
            ConsoleKey key;
            Console.WriteLine("Клавиша 1 - Просмотреть все аренды\nКлавиша ECS - Назад.");
            key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.D1)
            {
                SeeRent();
            }
            else if (key == ConsoleKey.Escape)
            {
                Console.Clear();
                programClass.Menu(arendatorTOP);
            }
        }
    }
}
