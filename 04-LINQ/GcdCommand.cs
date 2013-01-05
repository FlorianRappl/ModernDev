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
    /// Klasse um Größten Gemeinsamen Teiler (Greatest Common Divisor) mit LINQ zu ermitteln.
    /// </summary>
    class GcdCommand : LINQCommand
    {
        List<int> numbers;

        public GcdCommand() : base("GGT", "Berechnet die Faktoren von mehreren Zahlen und reduziert diese auf nur die größte Zahl der Schnittmenge.")
        {
            numbers = new List<int>();
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

            numbers.Add(n);
        }

        protected override void RunLINQ()
        {
            List<int[]> sets = new List<int[]>();

            foreach (var number in numbers)
                sets.Add(Helpers.CalculatePrimes(number));

            Console.WriteLine("Gefundene Mengen: " + PrintSource(sets));

            var intersection = sets[0].AsEnumerable();

            for(var i = 1; i < sets.Count; i++)
                intersection = intersection.Intersect(sets[i]);

            Console.WriteLine("Nach LINQ Abfrage (Schnittmenge): " + PrintSource(intersection));

            //Immer an Default Type denken!
            Console.WriteLine("Nach LINQ Abfrage (GGT): " + (intersection.Any() ? intersection.Max() : 1));
        }
    }
}
