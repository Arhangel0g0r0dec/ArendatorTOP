using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagrammOfClasses
{
    class RetalOutlets
    {
        public Program program { get; set; }
        public int IdPoint { get; set; }
        public int Floor { get; set; }
        public bool IsConditioner { get; set; }
        public decimal Price { get; set; }
        public string Purpose { get; set; }
        public bool Relevance { get; set; }
        public int Square { get; set; }

        public ArendatorTOP arendator { get; set; }

        public RetalOutlets(Program programClass, ArendatorTOP arendatorTOP) 
        {
            arendator = arendatorTOP;
            program = programClass;

            if (program.isRetalOutlet && !program.isRetalAdd)
            {
                Menu();
            }
        }

        private void Menu()
        {
            ConsoleKey key;
            Console.WriteLine("Клавиша 1 - Просмотреть все помещения\nКлавиша ECS - Назад.");
            key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.D1)
            {
                SeeRetal();
            }
            else if (key == ConsoleKey.Escape) 
            {
                Console.Clear();
                program.Menu(arendator);
            }
        }
    
        private void SeeRetal() 
        {
            Console.WriteLine("Результат:");
            arendator.SeeRetalOutlets();
            Menu();
        }
    }
}
