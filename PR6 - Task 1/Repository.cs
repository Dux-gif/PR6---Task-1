using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR6___Task_1
{
    class Repository
    {
        private Worker[] workers;

        private string path;

        int index;
        //string[] titles;
        
        public Repository(string Path)
        {
            this.path = Path;
            this.index = 0;
            //this.titles = new string[7] { "ID", "Дата записи", "Ф.И.О.", "Возраст", "Рост", "День рождения", "Место рождения"};
            this.workers = new Worker[1];

            
        }

        public void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.workers, this.workers.Length * 2);
            }
        }

        public void AddWorker(Worker worker)
        {
            this.Resize(index >= this.workers.Length);
            this.workers[index] = worker;
            this.index++;
            
            // присваиваем worker уникальный ID,
            // дописываем нового worker в файл
        }


        public void CreateWorker()
        {
            string note = string.Empty;

                using (StreamWriter sr = new StreamWriter(this.path, true, Encoding.Unicode))
                {
                    Console.WriteLine("Заполните данные");
                    Console.WriteLine("ID: ");
                    int ID = Int32.Parse(Console.ReadLine());
                    note += $"{ID}";
                    string TIME = DateTime.Now.ToShortDateString();
                    note += $"{TIME}";
                    Console.WriteLine($"Дата записи: {TIME}");
                    Console.WriteLine("Введите ФИО");
                    string FIO = $"{Console.ReadLine()}";
                    note += $"{FIO}";
                    Console.WriteLine("Введите возраст: ");
                    int AGE = Int32.Parse(Console.ReadLine());
                    note += $"{AGE}";
                    Console.WriteLine("Введите рост: ");
                    int HEIGHT = Int32.Parse(Console.ReadLine());
                    note += $"{HEIGHT}";
                    Console.WriteLine("Введите день рождения: ");
                    string BirthDay = $"{Console.ReadLine()}";
                    note += $"{BirthDay}";
                    Console.WriteLine("Введите место рождения: ");
                    string PlaceBirthday = $"{Console.ReadLine()}";
                    note += $"{PlaceBirthday}";

                    sr.WriteLine(note);
                    Worker worker = new Worker(ID, TIME, FIO, AGE, HEIGHT, BirthDay, PlaceBirthday);
                    AddWorker(worker);
                }
            }   
              

        public void GetAllWorkers()
        {

            using (StreamReader sr = new StreamReader(this.path))
            {
                
                //titles = sr.ReadLine().Split(',');
                Worker[] workers = new Worker[3];

                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split(',');

                    AddWorker(new Worker(int.Parse(args[0]),
                                        args[1], 
                                        args[2],
                                        int.Parse(args[3]), 
                                        int.Parse(args[4]), 
                                        args[5], 
                                        args[6])); 
                    
                }
                
            }
            // здесь происходит чтение из файла
            // и возврат массива считанных экземпляров
        }

        public void PrintDB()
        {
            foreach(var worker in workers)
            {
                Console.WriteLine($"{worker.Id,15} |{worker.TIME,15} |{worker.FIO,15} |{worker.Age,15} |{worker.Height,15} |{worker.Birthday,15} |{worker.PlaceBirthday,15}");
            }
            

            for (int i = 1; i < index; i++)
            {
                Console.WriteLine(this.workers[i].Print());
            }
        }

        public void GetWorkerById(int id)
        {
            Console.WriteLine("Введите ID искомого сотрудника");
            string find_id = Console.ReadLine();
            string ident = find_id;

            using (StreamReader sr = new StreamReader(this.path))
            {
                //titles = sr.ReadLine().Split(',');



                while (!sr.EndOfStream && ident == find_id)
                {
                    string[] args = sr.ReadLine().Split(',');

                    AddWorker(new Worker(Convert.ToInt32(args[0]), (args[1]), args[2], Convert.ToInt32(args[3]), Convert.ToInt32(args[4]), args[5], args[6]));
                }
                
            }
            // происходит чтение из файла, возвращается Worker
            // с запрашиваемым ID
        }

        public void DeleteWorker(int id)
        {
            using (StreamReader sr = new StreamReader(this.path))
            {
                //titles = sr.ReadLine().Split(',');

                Console.WriteLine("Введите ID удаляемого сотрудника");
                string find_id = Console.ReadLine();
                string ident = find_id;

                while (!sr.EndOfStream && ident == find_id)
                {
                    string[] args = sr.ReadLine().Split(',');

                    AddWorker(new Worker(Convert.ToInt32(args[0]), (args[1]), args[2], Convert.ToInt32(args[3]), Convert.ToInt32(args[4]), args[5], args[6]));
                }
                // считывается файл, находится нужный Worker
                // происходит запись в файл всех Worker,
                // кроме удаляемого
            }





            Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
            {

                using (StreamReader sr = new StreamReader(this.path))
                {
                    //titles = sr.ReadLine().Split(',');

                    while (!sr.EndOfStream)
                    {
                        string[] args = sr.ReadLine().Split(',');

                        AddWorker(new Worker(Convert.ToInt32(args[0]), (args[1]), args[2], Convert.ToInt32(args[3]), Convert.ToInt32(args[4]), args[5], args[6]));
                        var sortedFiles = new DirectoryInfo(@"daj.csv").GetFiles()
                                                                        .OrderBy(f => f.LastWriteTime)
                                                                        .ToList();
                    }

                    return GetWorkersBetweenTwoDates(dateFrom, dateTo);
                }
                // здесь происходит чтение из файла
                // фильтрация нужных записей
                // и возврат массива считанных экземпляров
            }
        }
    }
}
