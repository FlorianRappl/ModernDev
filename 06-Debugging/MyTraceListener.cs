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
    /// <summary>
    /// Schreiben unseren eigenen TraceListener (könnten auch einen vorhandenen verwenden).
    /// </summary>
    class MyTraceListener : TraceListener
    {
        public override void Write(string message)
        {
            Console.Write(message);
        }

        public override void WriteLine(string message)
        {
            Console.WriteLine("[{1}:{2}.{3}] TRACE >> {0}", message, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }
    }
}
