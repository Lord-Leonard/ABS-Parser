using System.Linq;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    public class GeneraHeader
    {
        public string? Projektnummer;
        public string Plannummer;
        public string Planindex;
        public string Position;
        public string Länge; // Einheit: mm
        public string Menge; 
        public string Gewicht; // Einheit: kg
        public string Checksum; 

        public GeneraHeader(string line)
        {
            string[] fields = line.Split('@');
            
            // remove H from first Field
            fields[0] = fields[0].Substring(1);

            foreach (string field in fields)
            {
                switch (field.FirstOrDefault())
                {
                    case 'j':
                        Projektnummer = field.Substring(1);
                        break;
                    
                    case 'r':
                        Plannummer = field.Substring(1);
                        break;
                    
                    case 'i':
                        Planindex = field.Substring(1);
                        break;
                    
                    case 'p':
                        Position = field.Substring(1);
                        break;
                    
                    case 'l':
                        Länge = field.Substring(1);
                        break;
                    
                    case 'n':
                        Menge = field.Substring(1);
                        break;
                    
                    case 'e':
                        Gewicht = field.Substring(1);
                        break;
                    
                    case 'C':
                        Checksum = field.Substring(1);
                        break;
                }
            }
        }
    }
}