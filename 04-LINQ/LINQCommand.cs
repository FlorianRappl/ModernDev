using System;
using System.Collections;
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
    abstract class LINQCommand : BaseCommand
    {
        string _name;
        string _description;

        public LINQCommand(string name, string description)
        {
            _name = name;
            _description = description;

            //Standardoptionen für LINQ Befehle

            AddOption("set", args =>
            {
                if (args.Length > 0)
                    AddObjects(args);
                else
                {
                    Console.WriteLine("Objekt eingeben:");
                    var input = Console.ReadLine();

                    while (!string.IsNullOrEmpty(input))
                    {
                        AddObject(input);
                        Console.WriteLine("Objekt eingeben:");
                        input = Console.ReadLine();
                    }
                }

                return true;
            });

            AddOption("run", () =>
            {
                RunLINQ();
                return false;
            });
        }

        //Objekte zur Liste hinzufügen
        protected virtual void AddObjects(string list)
        {
            var objs = list.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var obj in objs)
                AddObject(obj);
        }

        //Objekt zur Liste hinzufügen
        protected abstract void AddObject(string input);

        protected abstract void RunLINQ();

        public static string PrintSource(IEnumerable source)
        {
            var sb = new StringBuilder();
            sb.Append("{ ");
            var str = new List<string>();

            foreach (var element in source)
            {
                if (element is IEnumerable)
                    str.Add(PrintSource((IEnumerable)element));
                else
                    str.Add(element.ToString());
            }

            sb.Append(string.Join(", ", str.ToArray()));
            sb.Append(" }");
            return sb.ToString();
        }

        protected override void WelcomeMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Betrete " + _name);
            Console.WriteLine("Beschreibung: " + _description);
            Console.WriteLine();
        }

        protected override void LeaveMessage()
        {
            Console.WriteLine("Beende Routine ...");
        }
    }
}
