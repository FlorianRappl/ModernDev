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
    class Program
    {
        static void Main(string[] args)
        {
            //Typen analog zu C
            int a = 5;
            //var um den Typ vom Compiler bestimmen zu lassen
            var list = new List<int>();

            for (var i = 0; i < 10; i++)
            {
                list.Add(a * i);
                //Verwenden einer Extension Methode
                Console.WriteLine("{0} x {1} = {2}", a, i, list.CustomLast());
            }

            //Jeder Typ erbt von object, d.h. jede Instanz (also jedes Objekt) ist ein object
            object b = 7;

            if (b is double)
                Console.WriteLine("b ist eigentlich vom Typ double!");
            else if (b is int)
                Console.WriteLine("b ist eigentlich vom Typ int!");
            else
                Console.WriteLine("b ist ganz was anderes ... ");

            //Ein anonymes Objekt anlegen
            object anonym1 = new
            {
                Date = new DateTime(2013, 1, 31),
                Location = "Regenstauf"
            };

            //Da nur der Compiler den Namen weiß können wir nicht auf die Elemente zugreifen...
            //... oder gehts doch?!
            var properties = anonym1.GetType().GetProperties();

            foreach (var property in properties)
                Console.WriteLine("{0} = {1}", property.Name, property.GetValue(anonym1));

            //Analog könnte man im Code noch folgendes machen:
            dynamic anonym2 = (dynamic)anonym1;
            Console.WriteLine("In {0} findet am {1} dieser Kurs statt!", anonym2.Location, anonym2.Date);

            //Man hätte auch einfach mit "var" arbeiten können, z.B.
            var anonym3 = new
            {
                Date = new DateTime(2013, 2, 14),
                Location = "weltweit"
            };
            
            //Problem am 3. Ansatz ist, dass man diese Objekte nicht übergeben kann (da sind anonym sind)
            //d.h. wir müssen hierzu Möglichkeit 1 oder 2 verwenden (Reflection oder dynamic).
            Console.WriteLine("Am {0} ist {1} wie immer Valentinstag!", anonym3.Date, anonym3.Location);
        }
    }

    //Eine eigene (statische) Klasse anlegen (für Extension Methoden)
    static class CustomExtensions
    {
        //Generische (Extension) Methode bauen
        public static T CustomLast<T>(this List<T> list)
        {
            if (list.Count == 0)
                //Default um Standardwert (bei Referenztypen: null, ansonsten bitweise 0) zurückzugeben
                return default(T);

            return list[list.Count - 1];
        }
    }
}
