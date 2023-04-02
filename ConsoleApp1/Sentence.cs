using System.Linq;

namespace ConsoleApp1
{
    public class BF2DHeader : GeneraHeader
    {
        public string Durchmesser; // Einheit: mm
        public string Stahlgüte;
        public string Biegerollendurchmesser; // Einheit: mm

        public string Lage;
        public string Delta;
        public string Staffelgruppe;

        public BF2DHeader(string line) : base(line)
        {
            string[] fields = line.Split('@');
            
            // remove H from first Field
            fields[0] = fields[0].Substring(1);

            foreach (string field in fields)
            {
                switch (field.FirstOrDefault())
                {
                case 'g': 
                    Stahlgüte = field.Substring(1);
                    break;
             
                case 's':
                    Biegerollendurchmesser = field.Substring(1);
                    break;
                
                case 'a':
                    Lage = field.Substring(1);
                    break;
                
                case 't':
                    Delta = field.Substring(1);
                    break;
                
                case 'c':
                    Staffelgruppe = field.Substring(1);
                    break;
                }
            }
        }
    }
}