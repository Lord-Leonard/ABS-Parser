using System.Linq;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class GeneraHeader
    {
        public string Projektnummer;
        public string Plannummer;
        public string Planindex;
        public string Position;
        public string Länge; // Einheit: mm
        public string Menge; 
        public string Gewicht; // Einheit: kg

        public GeneraHeader(string line)
        {
            string[] fields = line.Split('@');

            // remove H from first Field
            fields[1] = fields[1][1..];

            foreach (string field in fields)
            {
                switch (field.FirstOrDefault())
                {
                    case 'j':
                        Projektnummer = field[1..];
                        break;
                    
                    case 'r':
                        Plannummer = field[1..];
                        break;
                    
                    case 'i':
                        Planindex = field[1..];
                        break;
                    
                    case 'p':
                        Position = field[1..];
                        break;
                    
                    case 'l':
                        Länge = field[1..];
                        break;
                    
                    case 'n':
                        Menge = field[1..];
                        break;
                    
                    case 'e':
                        Gewicht = field[1..];
                        break;
                }
            }
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);

        }
        
    }
}