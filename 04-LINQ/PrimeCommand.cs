using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 
 * (c) Florian Rappl, 2012-2013.
 * 
 * This work is a demonstration for training purposes and may be used freely for private purposes.
 * Usage for business training / workshops is prohibited without explicit permission from the author.
 * 
 */

namespace ModernDev
{
    /// <summary>
    /// Klasse um Primfaktoren mit LINQ zu vereinfachen.
    /// </summary>
    class PrimeCommand : LINQCommand
    {
        int number;

        public PrimeCommand() : base("Primzahlen", "Berechnet die Faktoren und reduziert diese auf nur eine Nennung.")
        {
        }

        protected override void AddObject(string input)
        {
            int n;

            if (!int.TryParse(input, out n))
            {
                Console.WriteLine("Fehler: Kann {0} nicht in eine ganze Zahl umwandeln!", input);
                return;
            }

            if (n < 1)
            {
                Console.WriteLine("Fehler: {0} ist keine positive ganze Zahl, welche ungleich 0 ist.", n);
                return;
            }

            number = n;
        }

        protected override void RunLINQ()
        {
            var numbers = Helpers.CalculatePrimes(number);

            Console.WriteLine("Gefundene Faktoren: " + PrintSource(numbers));

            Console.WriteLine("Nach LINQ Abfrage: " + PrintSource(numbers.Distinct()));
        }
    }
}
