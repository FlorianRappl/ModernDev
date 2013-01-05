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
    /// Klasse um Einträge einer Liste zu sortieren.
    /// </summary>
    class SortCommand : LINQCommand
    {
        List<string> entries;

        public SortCommand() : base("Sortierung", "Sortiert Wörter nach Länge (Primär) und Alphabetisch (Sekundär).")
        {
            entries = new List<string>();
        }

        protected override void AddObject(string input)
        {
            entries.Add(input);
        }

        protected override void RunLINQ()
        {
            Console.WriteLine("Wörter: " + PrintSource(entries));

            var sorted = entries.OrderBy(m => m);

            Console.WriteLine("Nur Alphabetisch: " + PrintSource(sorted));

            var complexSorted = entries.OrderBy(m => m.Length).ThenBy(m => m).AsEnumerable();

            Console.WriteLine("Länge und alphabetisch: " + PrintSource(complexSorted));
        }
    }
}
