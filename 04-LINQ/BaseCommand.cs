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
    abstract class BaseCommand
    {
        //Optionen speichern
        Dictionary<string, Func<string, bool>> _options;

        public BaseCommand()
        {
            _options = new Dictionary<string, Func<string, bool>>();
        }

        //Optionen erhalten
        public string[] Options
        {
            get { return _options.Keys.ToArray(); }
        }

        /// <summary>
        /// Optionen hinzufügen - mit Argumenten.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="action"></param>
        protected void AddOption(string key, Func<string, bool> action)
        {
            _options.Add(key, action);
        }

        /// <summary>
        /// Optionen hinzufügen - ohne Argumente.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="action"></param>
        protected void AddOption(string key, Func<bool> action)
        {
            _options.Add(key, args => action());
        }

        /// <summary>
        /// Optionen hinzufügen - mit Standardrückgabewert ("true").
        /// </summary>
        /// <param name="key"></param>
        /// <param name="action"></param>
        protected void AddOption(string key, Action action)
        {
            _options.Add(key, args => { action(); return true; });
        }

        //Enthält eine bestimmte Option?!
        public bool ContainsOption(string input)
        {
            var cmd = GetCommand(input);
            return _options.ContainsKey(cmd);
        }

        //Kommando von input erhalten
        protected virtual string GetCommand(string input)
        {
            var c = input.ToLower();

            if (c.Contains(' '))
                return c.Substring(0, c.IndexOf(' '));

            return c;
        }

        //Argumente von input erhalten
        protected virtual string GetArguments(string input)
        {
            var cmd = GetCommand(input);
            return cmd.Length < input.Length ? input.Substring(cmd.Length + 1) : string.Empty;
        }

        protected abstract void WelcomeMessage();

        protected abstract void LeaveMessage();

        //Optionen ausgeben
        protected virtual bool ShowOptions()
        {
            Console.WriteLine("Verfügbare Optionen:");

            foreach (var _opt in _options)
                Console.WriteLine(">> " + _opt.Key);

            return true;
        }

        //Eingabe evaluieren (interpretieren)
        protected virtual bool Evaluate(string input)
        {
            if (ContainsOption(input))
            {
                var cmd = GetCommand(input);
                var args = GetArguments(input);
                return _options[cmd](args);
            }

            return true;
        }

        //Bestimmte Klasse ausführen (muss parameterlosen Konstruktor haben)
        protected void RunCommand(Type type)
        {
            var ctor = type.GetConstructor(Type.EmptyTypes);

            if (ctor != null)
            {
                var child = ctor.Invoke(null) as BaseCommand;

                if (child != null)
                    child.Run();
            }
        }

        //Optionsklasse ausführen
        public virtual void Run()
        {
            var __cont = true;
            WelcomeMessage();
            ShowOptions();

            while(__cont)
            {
                Console.Write(": ");
                var cmd = Console.ReadLine();

                if (cmd.Equals("q"))
                    break;
                else if (string.IsNullOrEmpty(cmd))
                    continue;
                else if (ContainsOption(cmd))
                    __cont = Evaluate(cmd);
                else
                {
                    Console.Write("Option nicht gefunden. ");
                    __cont = ShowOptions();
                }
            }

            LeaveMessage();
        }
    }
}
