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
    class MainCommand : BaseCommand
    {
        //Optionen fürs Hauptmenü
        public MainCommand()
        {
            //Primzahl berechnen und Faktoren ausgeben
            AddOption("prim", () =>
            {
                RunCommand(typeof(PrimeCommand));
            });

            //Größten Gemeinsamen Teiler ermitteln mit LINQ
            AddOption("ggt", () =>
            {
                RunCommand(typeof(GcdCommand));
            });

            //Sortieren mit LINQ
            AddOption("sort", () =>
            {
                RunCommand(typeof(SortCommand));
            });

            //Beenden !
            AddOption("exit", () => false);
        }

        //Startnachricht
        protected override void WelcomeMessage()
        {
            Console.WriteLine("*******************************");
            Console.WriteLine("*                             *");
            Console.WriteLine("*   LINQ TEST PROGRAMM v1.0   *");
            Console.WriteLine("*                             *");
            Console.WriteLine("*******************************");
        }

        //Beenden
        protected override void LeaveMessage()
        {
            Console.WriteLine("Beende Programm ...");
        }
    }
}
