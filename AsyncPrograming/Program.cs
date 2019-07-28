using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncPrograming
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentBag<string> files = new ConcurrentBag<string>();
            string[] directoreis = {
                @"C:\Users\suphi\Desktop\SetBlobProperty",
                @"C:\Users\suphi\Desktop",
                @"C:\Users\suphi\Desktop\sonarqube-7.5",
                @"C:\Users\suphi\Desktop\MVC"
            };

            List<Task> tasks = new List<Task>();

            foreach (var item in directoreis)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    AddFiles(item, files);
                }));
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine(string.Format("{0} files found.", files.Count()));
            foreach (var item in files)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        static void AddFiles(string directory,ConcurrentBag<string> files)
        {
            foreach (var item in Directory.GetFiles(directory))
            {
                files.Add(item);
            }
        }
    }
}
