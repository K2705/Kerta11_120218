using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esim2
{
    class DelegaattiDemo
    {
        delegate void FormatoiLuku(double luku);

        public static void Main(string[] args)
        {
            //kysytään käyttäjältä jokin desimaaliluku
            Console.WriteLine("Anna desimaaliluku");
            string syote = Console.ReadLine();
            double aluku;
            if (double.TryParse(syote, out aluku))
            {
                //kiinnitetään useita metodeja delegaatille
                FormatoiLuku formatoija = FormatoiValuutaksi;
                formatoija += FormatoiKolmelleDesimaalille;
                //kutsutaan kiinnitetyt delegaatit
                formatoija(aluku);
            }

            List<string> nimet = new List<string> { "Arska", "Kalle", "Cecilia", "Jack" };
            string foo = nimet.FirstOrDefault(x => x.StartsWith("Ja"));
            Console.WriteLine(foo); //this prints Jack
        }

        //metodit
        static void FormatoiValuutaksi(double luku)
        {
            Console.WriteLine("Annettu luku valuuttana {0:C}", luku);
        }
        static void FormatoiKolmelleDesimaalille(double luku)
        {
            Console.WriteLine("Annettu luku kolmen desimaalin tarkkuudella {0:.###}", luku);
        }

    }
}
