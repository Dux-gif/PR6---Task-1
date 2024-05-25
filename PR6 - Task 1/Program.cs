using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR6___Task_1
{

    class Program
    {
        static void Main(string[] args)
        {
            //char key = 'и';
            string path = @"ght.csv";
            

            Repository rep = new Repository(path);

            //rep.CreateWorker();
            rep.GetAllWorkers();
            rep.PrintDB();
            Console.ReadKey();


            //Console.Write("Вывести на экран список сотрудников? (н/д)"); key = Console.ReadKey(true).KeyChar;
            //if (char.ToLower(key) == 'д')
            //{
            //    rep.GetAllWorkers();
            //}




        }
        
        
    }
}
