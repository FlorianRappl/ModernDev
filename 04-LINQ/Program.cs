﻿using System;
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
            //Neue Kommandoklasse erstellen (Hauptmenübefehle)
            var cmd = new MainCommand();
            //Abspielen
            cmd.Run();
        }
    }
}
