using System;
using System.IO;
using System.Collections.Generic;
using lab3;

namespace ConsoleApp2
{
    class Program
    {
        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine($"Ошибки:\n{logMessage}");
            w.WriteLine("-------------------------------");
        }
        static void Main(string[] args)
        {
            var storage1Processors = new[]
            {
                new Processors("intel core i5", 15, new DateTime(2015, 7, 20)),
                new Processors("intel core i3", 20, new DateTime(2016, 8, 19)),
                new Processors("intel core i9", 10, new DateTime(2077, 11, 4)),
                new Processors("intel core i7", 12, new DateTime(2023, 6, 6)),
                new Processors("amd ryzen 3", 21, new DateTime(2023, 6, 6))
            };
            var storage2Processors = new[]
            {
                new Processors("amd ryzen 5", 24, new DateTime(2007, 3, 4)),
                new Processors("amd ryzen 7", 14, new DateTime(2077, 11, 4)),
                new Processors("amd ryzen 9", 2, new DateTime(2015, 7, 20)),
                new Processors("amd ryzen threadripper", 1, new DateTime(2015, 7, 20)),
                new Processors("intel celeron", 40, new DateTime(2013, 7, 5))
            };
            var maxQuantity = Methods.MaxQuantity(storage1Processors);
            var nameSearch = Methods.NameSearch(storage1Processors, "кулер");
            var dateSort = Methods.DateSort(storage1Processors);
            Storages storage1 = new Storages("Склад 1", storage1Processors);
            Storages storage2 = new Storages("Склад 2", storage2Processors);
            Console.WriteLine("Максимальное количество:");
            foreach (Processors s in maxQuantity)
            {
                Console.WriteLine(s.name + " " + s.quantity + " " + $"{s.dateTime.ToString("d")}");
            }
            Console.WriteLine("Поиск по имени:");
            foreach (Processors s in nameSearch)
            {
                Console.WriteLine(s.name + " " + s.quantity + " " + $"{s.dateTime.ToString("d")}");
            }
            Console.WriteLine("Сортировка по дате:");
            foreach (Processors s in dateSort)
            {
                Console.WriteLine(s.name + " " + s.quantity + " " + $"{s.dateTime.ToString("d")}");
            }
            var storageManagers = new List<StorageManager>();

            

            try
            {
                storageManagers.Add(new StorageManager("Kalatuhin", -19, "pon@gmail.com", storage1));
            }
            catch (ArgumentException exc)
            {
                //exc.InnerExceptions
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    Log(exc.Message, w);
                }

            }

            try
            {
                storageManagers.Add(new StorageManager("Leonid Viktorovich", 45, "leonidviktorovich@gmail.com", storage1));
            }
            catch (ArgumentException exc)
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    Log(exc.Message, w);
                }

            }

            try
            {
                storageManagers.Add(new StorageManager("Михаил Зубeнко", -52, "michailzubenko@gmail.com", storage2));
            }
            catch (ArgumentException exc)
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    Log(exc.Message, w);
                }

            }

            try
            {
                storageManagers.Add(new StorageManager("Петр Иванович", 27, "ivasilievich@gmail.com", storage2));
            }
            catch (ArgumentException exc)
            {
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    Log(exc.Message, w);
                }

            }
            Console.WriteLine("Вывод по менеджерам:");
            for (int i = 0; i < storageManagers.Count; i++)
            {
                if (storageManagers[i].email != default)
                {
                    Console.WriteLine(storageManagers[i].Name + " " + storageManagers[i].email + " " + storageManagers[i].age + " " + storageManagers[i].storages.Name);
                }

            }
        }
    }
}
