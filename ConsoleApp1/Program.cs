using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
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
            BF2DSentence sentence = new BF2DSentence();

            // remove H from first Field
            fields[0] = fields[0].Substring(1);

            foreach (string field in fields)
            {
                switch (field.FirstOrDefault())
                {
                    case 'j':
                        sentence.Projektnummer = field.Substring(1);
                        break;
                    
                    case 'r':
                        sentence.Plannummer = field.Substring(1);
                        break;
                    
                    case 'i':
                        sentence.Planindex = field.Substring(1);
                        break;
                    
                    case 'p':
                        sentence.Position = field.Substring(1);
                        break;
                    
                    case 'l':
                        sentence.Länge = field.Substring(1);
                        break;
                    
                    case 'n':
                        sentence.Menge = field.Substring(1);
                        break;
                    
                    case 'e':
                        sentence.Gewicht = field.Substring(1);
                        break;
                    
                    case 'd':
                        sentence.Durchmesser = field.Substring(1);
                        break;
                    
                    case 'g': 
                        sentence.Stahlgüte = field.Substring(1);
                        break;
                 
                    case 's':
                        sentence.Biegerollendurchmesser = field.Substring(1);
                        break;
                    
                    case 'a':
                        sentence.Lage = field.Substring(1);
                        break;
                    
                    case 't':
                        sentence.Delta = field.Substring(1);
                        break;
                    
                    case 'c':
                        sentence.Staffelgruppe = field.Substring(1);
                        break;
                    
                    case 'C':
                        sentence.Prüfziffer = field.Substring(1);
                        break;
                }
            }
            
            Console.WriteLine(JsonConvert.SerializeObject(sentence, Formatting.Indented));
        }
    }
}
