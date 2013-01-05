using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    class ExampleCode
    {
        //Ereignis um z.B. die gewürfelte Zahl zu erhalten
        public event EventHandler<ExampleEventArgs> HandleMyEvent;

        //Instanz der Zufallsklasse
        Random random;

        //Konstruktor
        public ExampleCode()
        {
            random = new Random();
        }

        //Dummy Methode um ein wenig Arbeit zu simulieren
        public void Execute(bool triggerEvent)
        {
            //Eine Sekunde lang ruhen
            Thread.Sleep(1000);

            //Eine Zahl würfenln
            var z = random.Next(100);

            //Nochmal eine Sekunde ruhen
            Thread.Sleep(1000);

            //Möglicherweise ein Event auslösen
            if (triggerEvent && HandleMyEvent != null)
                HandleMyEvent(this, new ExampleEventArgs(z));
        }
    }

    //Unser Packet zur Lieferung bei Event-Behandlung definieren
    class ExampleEventArgs : EventArgs
    {
        public ExampleEventArgs (int zahl)
	    {
            Zahl = zahl;
	    }

        public int Zahl { get; private set; }
    }
}
