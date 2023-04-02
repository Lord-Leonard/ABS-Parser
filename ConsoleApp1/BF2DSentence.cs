using System.Linq;

namespace ConsoleApp1
{
    public class BF2DSentence : GeneraHeader
    {
        public string Durchmesser; // Einheit: mm
        public string Stahlgüte;
        public string Biegerollendurchmesser; // Einheit: mm
        public string Lage;
        public string Delta;
        public string Staffelgruppe;

        public BF2DSentence(string line) : base(line)
        {
            string[] fields = line.Split('@');
            
            foreach (string field in fields)
            {
                switch (field.FirstOrDefault())
                {
                    case 'd':
                        Durchmesser = field[1..];
                        break;
                    
                    case 'g': 
                        Stahlgüte = field[1..];
                        break;
             
                    case 's':
                        Biegerollendurchmesser = field[1..];
                        break;
                    
                    case 'a':
                        Lage = field[1..];
                        break;
                    
                    case 't':
                        Delta = field[1..];
                        break;
                    
                    case 'c':
                        Staffelgruppe = field[1..];
                        break;
                }
            }
        }
    }
}