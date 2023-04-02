using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
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
                if (validateChecksum(line))
                {
                    Console.WriteLine("Help Checksum not Matching");
                    return; //Help
                };

                string[] fields = line.Split('@');
                
                switch (fields[0])
                {
                    case "BF2D":
                        HandleBF2D(fields.Skip(1).ToArray());
                        break;
                    
                    case "BF3D": 
                        HandleBF3D(fields.Skip(1).ToArray());
                        break;
                    
                    case "BFWE":
                        HandleBFWE(fields.Skip(1).ToArray());
                        break;
                    
                    case "BFMA":
                        HandleBFMA(fields.Skip(1).ToArray());
                        break;
                }
            });
        }

        private static bool validateChecksum(string line)
        {
            int iSum = 0;
            // get Checksum from Sentence
            string[] fields = line.Split("@");

            

            foreach (char c in line)
            {
                iSum += (int)c;
            }

            return false;
        }

        private static void HandleBFWE(string[] fields)
        {
            throw new NotImplementedException();
        }

        private static void HandleBF3D(string[] fields)
        {
            throw new NotImplementedException();
        }

        private static void HandleBFMA(string[] fields)
        {
            Console.WriteLine("Matte");
        }

        private static void HandleBF2D(string[] fields)
        {
            BF2DHeader header = new (line);

            
            
            Console.WriteLine(JsonConvert.SerializeObject(header, Formatting.Indented));
        }
    }
}
