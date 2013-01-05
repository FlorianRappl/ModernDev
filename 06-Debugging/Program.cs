using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            //Wird nur angezeigt wenn das DEBUG Symbol definiert wurde
            Console.WriteLine("Debug Symbol aktiv!");
#endif
            //Eigenen Listener festlegen
            Trace.Listeners.Add(new MyTraceListener());

            //Methode aufrufen
            FirstMethod();

            //Hier mal einen normalen Breakpoint setzen und einen Konditionalen
            for (var i = 0; i < 1000; i++)
                if (i >> 5 == 20)
                    Console.WriteLine("Erfüllt !");

            Console.WriteLine("Fertig !");
        }

        private static void FirstMethod()
        {
            //Wird immer angezeigt
            Trace.WriteLine("(TRC) Erste Methode aufgerufen ...");
            //Wird nur im Debug Modus angezeigt
            Debug.WriteLine("(DBG) Erste Methode aufgerufen ...");

            //Skip im Release Mode
            SecondMethod();
        }

        //Wird nur im Debug Modus ausgeführt
        [Conditional("DEBUG")]
        private static void SecondMethod()
        {
            Trace.WriteLine("(TRC) Zweite Methode aufgerufen ...");

            Debug.WriteLine("(DBG) Zweite Methode aufgerufen ...");

            LastMethod();
        }

        private static void LastMethod()
        {
            Trace.WriteLine("(TRC) Letzte Methode aufgerufen ...");

            Debug.WriteLine("(DBG) Letzte Methode aufgerufen ...");
        }
    }
}
