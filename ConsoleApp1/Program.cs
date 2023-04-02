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
            string fileName = "../../../TWPL-5-BW-02-620-A_BFD.abs";
            
            var lines = File.ReadLines(fileName);
            Parallel.ForEach(lines, line =>
            {
                if (!validateChecksum(line))
                {
                    Console.WriteLine("Help Checksum not Matching");
                    return; //Help
                };

                var obergruppe = line[..4];
                
                switch (obergruppe)
                {
                    case "BF2D":
                        BF2DSentence bf2DSentence = new(line);
                        Console.WriteLine(bf2DSentence.ToJson());
                        break;
                    
                    case "BF3D": 
                        //HandleBF3D(fields.Skip(1).ToArray());
                        break;
                    
                    case "BFWE":
                        //HandleBFWE(fields.Skip(1).ToArray());
                        break;
                    
                    case "BFMA":
                        //HandleBFMA(fields.Skip(1).ToArray());
                        break;
                }
            });
        }

        private static bool validateChecksum(string line)
        {
            int characterSum = 0;
            // get Checksum from Sentence
            string[] fields = line.Split("@");

            //determine given Checksum
            string givenChecksum = fields[^2].Substring(1);
            
            //remove given Checksum from Sentence
            string sentenceWithoutChecksum = line.Substring(0, line.Length - 3);

            foreach (char c in sentenceWithoutChecksum)
            {
                characterSum += c;
            }

            if (line.Contains("BFMA") && !line.Contains("@a"))
            {
                characterSum += '@' + 'a';
            }

            if (!line.Contains("@G"))
            {
                characterSum += '@' + 'G' + 'l' + '@' + 'r' + '@' + 'w';
            }

            int calculatedChecksum = 96 - characterSum % 32;
            
            return int.Parse(givenChecksum) == calculatedChecksum;
        }
    }
}
