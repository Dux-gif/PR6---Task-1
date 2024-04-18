﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR6___Task_1
{
    internal class Program
    {
        static void Read()
        {
            using (StreamReader sr = new StreamReader("db.csv", Encoding.Unicode)) // 
            {
                string line; // Считываем строчку
                int id = 1;
                Console.WriteLine($"{"ID"} {" Дата и время"} {" Ф.И.О."} {" Возраст"} {" Рост"} {" Дата рождения"} {"Место рождения"}\n"); // Подготавливаем интерфейс

                while ((line = sr.ReadLine()) != null) // Пока, считывание текущей строки не будет нулем(пустой строкой)
                {
                    string[] data = line.Split('\t'); // Разбираем текущую строку 
                    Console.WriteLine($"{id++} {data[0],20} {data[1],30} {data[2],10} {data[3],10} {data[4],15} {data[5],10}"); // Вывод на экран
                }
            }
        }
        static void Write()
        {
            using (StreamWriter sw = new StreamWriter("db.csv", true, Encoding.Unicode)) // Открываем поток - указываем файл - говорим, что нужно будет ДОзаписывать - в какой кодировке
            {
                char key = 'д';
                
                do // бесконечный цикл на добавление записи
                {
                    string note = string.Empty;
                    string date = DateTime.Now.ToShortDateString();
                    string time = DateTime.Now.ToShortTimeString();
                    Console.WriteLine($"Дата и время: {date} {time}");
                    note += $"{date} {time}\t";

                    Console.Write("\nВведите Ф.И.О.: ");
                    note += $"{Console.ReadLine()}\t";

                    Console.Write("\nВведите возраст: ");
                    note += $"{Console.ReadLine()}\t";

                    Console.Write("\nВведите рост: ");
                    note += $"{Console.ReadLine()}\t";

                    Console.Write("\nВведите дату рождения: ");
                    note += $"{Console.ReadLine()}\t";

                    Console.Write("\nВведите место рождения: ");
                    note += $"{Console.ReadLine()}\t";

                    sw.WriteLine(note); // пишем заметку в поток
                    Console.Write("Продолжить н/д\n"); key = Console.ReadKey(true).KeyChar; // проверка на кнопку
                } while (char.ToLower(key) == 'д');
            }
        }
        static void Main(string[] args)
        {
            char choice = 'д';
            Console.WriteLine("Добавить новую запись? н/д\n");
            choice = Console.ReadKey(true).KeyChar;
            if (char.ToLower(choice) == 'д')
            {
                Write();
            }
            
                Console.WriteLine("Вывести данные на экран? н/д\n");
                choice = Console.ReadKey(true).KeyChar;
                if (char.ToLower(choice) == 'д')
                {
                    Read();
                    Console.ReadKey();
                }
        }
    }
}
