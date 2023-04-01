using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\Users\leoge\RiderProjects\ConsoleApp1\ConsoleApp1\TWPL-5-BW-02-620-A_BFD.abs";
            
            var lines = File.ReadLines(fileName);
            Parallel.ForEach(lines, line =>
            {
                string[] fields = line.Split('@');

                Console.WriteLine(fields[0]);

                switch (fields[0])
                {
                    case "BF2D":
                        Console.WriteLine();
                }
                
            });
        }
    }
}
