using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagrammOfClasses
{
    class ArendatorTOP : Interface_IRent //Класс с основным функционалом
    {
        public Program programClass { get; set; }
        public Rent rentClass { get; set; }
        public ArendatorTOP Arendator { get; set; }
        public Customers customers;
        public RetalOutlets retal;
        /// <summary>
        /// Список Аренд
        /// </summary>
        public List<Rent> Rents { get; set; } = new List<Rent>();
        /// <summary>
        /// Список Клиентов
        /// </summary>
        public List<Customers> CustomersList { get; set; } = new List<Customers>();
        /// <summary>
        /// Сmписок Торговых Площадей
        /// </summary>
        public List<RetalOutlets> retalOutlets { get; set; } = new List<RetalOutlets>();
        /// <summary>
        ///Список для финансовой ствтистики
        /// </summary>
        public List<decimal> profit { get; set; } = new List<decimal>();
        public string Adress { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int ID { get; set; }
        
        public bool IsArendator = false;
        /// <summary>
        /// Конструктор класса, в конструкторе автоматически добавляются 3 помещения (некая имитация БД), в следующих версиях бд будет добавлена!
        /// </summary>
        /// <param name="program"></param>
        /// <param name="arendatorTOP"></param>
        public ArendatorTOP(Program program, ArendatorTOP arendatorTOP)
        {
            IsArendator = true;
            Arendator = arendatorTOP;
            programClass = program;
            programClass.isNewArendator = false;

            if (programClass.isRetalAdd) 
            {
                retalOutlets.Insert(0, new RetalOutlets(programClass, this) 
                {
                    IdPoint = 1,
                    Floor = 1,
                    IsConditioner = false,
                    Price = 40000,
                    Purpose = "Торговое помещение",
                    Relevance = true,
                    Square = 50
                });

                retalOutlets.Insert(1, new RetalOutlets(programClass, this)
                {
                    IdPoint = 2,
                    Floor = 2,
                    IsConditioner = true,
                    Price = 70000,
                    Purpose = "Производственное помещение",
                    Relevance = true,
                    Square = 80
                });

                retalOutlets.Insert(2, new RetalOutlets(programClass, this)
                {
                    IdPoint = 3,
                    Floor = 3,
                    IsConditioner = true,
                    Price = 50000,
                    Purpose = "Торговое помещение",
                    Relevance = true,
                    Square = 60
                });

                programClass.isRetalAdd = false;
            }
            

            if (programClass.isArendator)
            {
                MainMenu();
            }
        }
        /// <summary>
        /// Основное меню
        /// </summary>
        public void MainMenu() 
        {
            ConsoleKey key;

            Console.WriteLine("\nФИРМА ArendatorTOP");
            Console.WriteLine("Клавиша 1 - Создать договор аренды\nКлавиша 2 - Добавить торговое помещение\nКлавиша 3 - Финансовая статистика\nКлавиша Escape - Назад");
            
            key = Console.ReadKey(true).Key;
            
            if (key == ConsoleKey.D1)
            {
                Console.WriteLine("-------------------------------------------------------------------");
                AddRent();
            }
            else if (key == ConsoleKey.D2)
            {
                Console.WriteLine("-------------------------------------------------------------------");
                AddOutlet();
            }
            else if (key == ConsoleKey.D3)
            {
                foreach (var data in Rents)
                {
                    Console.WriteLine(data);
                    Console.WriteLine("-------------------------------------------------------------------");
                }
                Console.ReadLine();
            }
            else if (key == ConsoleKey.Escape)
            {
                Console.Clear();
                programClass.isArendator = false;
                programClass.Menu(this);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введенная команда не расспознана!");
                Console.ResetColor();
                MainMenu();
            }
        }

        /// <summary>
        /// Меню для выбора периода финансовой статистики в качестве параметра указывается 
        /// </summary>
        /// <param name="dateStart">дата начала отсчета статики</param>
        /// TO DO
        private void CalcStatistic(DateTime dateStart)
        {
            ConsoleKey key;

            Console.WriteLine($"Получить отчет о финансах за:\nКлавиша 1 - Неделю\nКлавиша 2 - Месяц\nКлавиша 3 - Год\nКлавиша Escape - Назад");

            key = Console.ReadKey(true).Key;
            int time;

            if (key == ConsoleKey.D1)
            {
                Console.WriteLine("Финансовая статистика за неделю:");
                time = 7;
                CalcStatistic(time);
            }
            else if (key == ConsoleKey.D2)
            {
                Console.WriteLine("Финансовая статистика за месяц:");
                time = 30;
                CalcStatistic(time);
            }
            else if (key == ConsoleKey.D3)
            {
                Console.WriteLine("Финансовая статистика за год:");
                time = 360;
                CalcStatistic(time);
            }
            else if (key == ConsoleKey.Escape)
            {
                MainMenu();
                Console.Clear();
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введенная команда не расспознана!");
                Console.ResetColor();
            }
        }
        /// <summary>
        /// Рассчет статистики в зависимости от выбранного срока
        /// </summary>
        /// <param name="i">Срок на который нужно произвести рассчет</param>
        /// TODO
        private void CalcStatistic(int i)
        {
            foreach (RetalOutlets r in retalOutlets) 
            {
                for (int c = 0; c < i; c++) 
                {
                    r.Price += r.Price;
                    if (c == i) 
                    {
                        Console.WriteLine(r.Price);
                    }
                }
            }
        }
        /// <summary>
        /// Доьавление помещения
        /// </summary>
        private void AddOutlet() 
        {
            Console.WriteLine("Введите следующие данные о помещении:\n" +
               "1) Этаж,\n" +
               "2) Есть ли кондиционер,\n" +
               "3) Стоимость,\n" +
               "4) Назначение,\n" +
               "5) Актуально,\n" +
               "6) Площадь");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Чтобы продолжить нажмите Enter\nили для отмены нажмите клавишу ESC");
            Console.ResetColor();
            Console.WriteLine("-------------------------------------------------------------------");
            ConsoleKey key;

            key = Console.ReadKey(true).Key;

            retal = new RetalOutlets(programClass, this);

            if (key == ConsoleKey.Escape)
            {
                Console.Clear();
                MainMenu();
            }
            else if (key == ConsoleKey.Enter) 
            {
                Console.Write("Этаж:");
                retal.Floor = Convert.ToInt32(Console.ReadLine());

                Console.Write("Наличие кондиционера(+/-):");
                string IsCond = Console.ReadLine();
                if (IsCond == "+")
                {
                    retal.IsConditioner = true;
                }
                else if (IsCond == "-")
                {
                    retal.IsConditioner = false;
                }
                else 
                {
                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данная команда не расспознана!");
                    AddOutlet();
                    Console.ResetColor();
                    Console.WriteLine("-------------------------------------------------------------------");
                }

                Console.Write("Цена за месяц:");
                retal.Price = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Назначение:");
                retal.Purpose = Console.ReadLine();

                Console.Write("Актуально(+/-):");
                string IsRele = Console.ReadLine();
                if (IsRele == "+")
                {
                    retal.Relevance = true;
                }
                else if (IsRele == "-") 
                {
                    retal.Relevance = false;
                }
                else
                {
                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данная команда не расспознана!");
                    Console.ResetColor();
                    Console.WriteLine("-------------------------------------------------------------------");
                }

                Console.Write("Площадь:");
                retal.Square = Convert.ToInt32(Console.ReadLine());
                retal.IdPoint = retalOutlets.Count + 1;

                retalOutlets.Add(retal);
                Console.WriteLine("-------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Помещение успешно добавлено!");
                Console.ResetColor();
                ThirdMenu();
            }
        }

        /// <summary>
        /// Добавление договора об аренде
        /// </summary>
        private void AddRent()
        {
            Console.WriteLine("Введите следующие данные о клиенте:\n" +
                "1) Название фирмы клиента,\n" +
                "2) Реквизиты (ИНН),\n" +
                "3) Номер телефона,\n" +
                "4) ФИО Контактного лица,\n" +
                "5) Адрес");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Чтобы продолжить нажмите Enter\nили для отмены нажмите клавишу ESC");
            Console.ResetColor();
            Console.WriteLine("-------------------------------------------------------------------");
            ConsoleKey key;

            key = Console.ReadKey(true).Key;

            customers = new Customers(retal ,this, programClass, rentClass, customers);

            if (key == ConsoleKey.Escape)
            {
                Console.Clear();
                MainMenu();
            }
            else if (key == ConsoleKey.Enter) 
            {
                Console.Write("Название фирмы заказчика:");
                customers.Title = Console.ReadLine();

                Console.Write("Реквизиты (ИНН):");
                customers.Requisites = Console.ReadLine();

                Console.Write("Номер телефона:");
                customers.PhoneNumber = Console.ReadLine();

                Console.Write("ФИО Контактного лица:");
                customers.ContactPerson = Console.ReadLine();

                Console.Write("Адрес:");
                customers.Adress = Console.ReadLine();

                ID++;

                Rent rent = new Rent(this, programClass);

                rent.DateStart = DateTime.Now;
                string date = rent.DateStart.ToLongDateString();

                rent.IdRent = Rents.Count + 1;
                string Id = rent.IdRent.ToString();
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("Все имеющиеся помещения:");
                SeeRetalOutlets();
                Console.WriteLine("-------------------------------------------------------------------");
                
                Console.Write("Введите номер помещения: ");
                rent.IdRetalOutlets = Convert.ToInt32(Console.ReadLine());

                var IdO = retalOutlets.Where(p => p.IdPoint == rent.IdRetalOutlets && p.Relevance).ToList();

                if (IdO != null)
                {
                    var RelO = IdO.Where(p => p.Relevance == true).ToList();

                    if (RelO != null)
                    {
                        Console.Write("Введите стоимость аренды: ");
                        rent.PriceR = Convert.ToDecimal(Console.ReadLine());
                        string PriceRent = rent.PriceR.ToString();
                        rent.Customers = customers;

                        CustomersList.Add(rent.Customers);
                        Rents.Add(rent);

                        if (!string.IsNullOrEmpty(customers.Title) && !string.IsNullOrEmpty(customers.Requisites)
                        && !string.IsNullOrEmpty(customers.PhoneNumber) && !string.IsNullOrEmpty(customers.ContactPerson) && !string.IsNullOrEmpty(customers.Adress)
                        && !string.IsNullOrEmpty(date) && !string.IsNullOrEmpty(Id) && !string.IsNullOrEmpty(PriceRent))
                        {
                            if (Rents.Count != 0 && CustomersList.Count != 0)
                            {
                                Console.WriteLine("-------------------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Клиент и договор успешно созданы!");
                                Console.WriteLine("Дата аренды:" + rent.DateStart.ToLongDateString());
                                Console.ResetColor();
                                ThirdMenu();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Не удалось добавить новый договор или клинта проверьте правильность введенных данных и повторите попытку!");
                                Console.ResetColor();
                                AddRent();
                            }
                        }
                        else
                        {
                            Console.WriteLine("-------------------------------------------------------------------");
                            Console.WriteLine("Не все поля заполнены, перепроверьте введенные данные!");
                            Console.WriteLine("-------------------------------------------------------------------");
                            AddRent();
                        }
                    }
                    else 
                    {
                        Console.WriteLine("-------------------------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Данное помещение занято!");
                        Console.ResetColor();
                        Console.WriteLine("-------------------------------------------------------------------");
                    }
                }
                else 
                {
                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы ввели неверный Id или даднное помещение занято (Поле Актуально)!");
                    Console.ResetColor();
                    Console.WriteLine("-------------------------------------------------------------------");
                }
            }            
        }

        /// <summary>
        /// Меню после того как договор аренды добавлен
        /// </summary>
        private void ThirdMenu()
        {
            ConsoleKey key;

            Console.WriteLine($"Клавиша 1 - Просмотр клиентов\nКлавиша 2 - Просмотр аренд\nКлавиша 3 - Просмотр всех помещений\nКлавиша Escape - Назад");

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.D1)
            {
                SeeCustomers();
                ThirdMenu();
            }
            else if (key == ConsoleKey.D2)
            {
                SeeRents();
                ThirdMenu();
            }
            else if (key == ConsoleKey.D3)
            {
                SeeRetalOutlets();
                ThirdMenu();
            }
            else if (key == ConsoleKey.Escape)
            {
                Console.Clear();
                MainMenu();  
            }
            else 
            {
                Console.WriteLine("-------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введенная команда не расспознана!");
                Console.ResetColor();
                ThirdMenu();
            }
        }
        
        /// <summary>
        /// Просмотр имеющихся помещений
        /// </summary>

        public void SeeRetalOutlets() 
        {
            foreach (RetalOutlets r in retalOutlets)
            {
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("Id:{0}\nЭтаж:{1}\nЦена:{2}\nКондиционер:{3}\nНазначение:{4}\nАктуальность:{5}\nПлощадь:{6}", r.IdPoint, r.Floor, r.Price,r.IsConditioner, r.Purpose, r.Relevance, r.Square);
                Console.WriteLine("-------------------------------------------------------------------");
            }
        }

        /// <summary>
        /// Просмотр имеющихся клиентов
        /// </summary>
        
        public void SeeCustomers()
        {
            CustomersList = Rents.Select(p => p.Customers).Distinct().ToList();
            foreach (Customers c in CustomersList)
            {
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("Id:{0}\nНазвание:{1}\nИНН:{2}\nТелфон:{3}\nФИО:{4}\nАдрес:{5}", c.IdCustomer, c.Title, c.Requisites, c.PhoneNumber, c.ContactPerson, c.Adress);
                Console.WriteLine("-------------------------------------------------------------------");
            }
        }

        /// <summary>
        /// Просмотр имеющихся аренд
        /// </summary>

        public void SeeRents() 
        {
            foreach (Rent r in Rents) 
            {
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("Id {0}\nСтоимость:{1} руб.\nДата начала:{2}", r.IdRent, r.PriceR, r.DateStart);
                Console.WriteLine("-------------------------------------------------------------------");
            }
        }
    }
}
