using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    class MyWorker
    {
        string path;

        public MyWorker()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        public async Task<IEnumerable<FileResult>> StartSearching(string search)
        {
            //Nur in C# Quellcode suchen
            var wildCards = new[] { path + @"\GitHub\*.cs" };

            //Schön asynchron
            return await Task.Run(() => Grep(search, wildCards));
        }

        IEnumerable<FileResult> Grep(string regexString, IEnumerable<string> wildcards, bool recursive = true, bool ignoreCase = true)
        {
            var regexOptions = RegexOptions.Compiled | (ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None);

            //Das ist Fancy um jedem Thread eine Kopie dieses Objekts zu geben
            var regex = new ThreadLocal<Regex>(() =>
                new Regex(regexString, regexOptions));

            //Zur Abwechslung mal wieder SQL Syntax
            var files = from wc in wildcards
                            let dirName = Path.GetDirectoryName(wc)
                            let fileName = Path.GetFileName(wc)
                        from file in Directory.EnumerateFiles(
                            String.IsNullOrWhiteSpace(dirName) ? "." : dirName,
                            String.IsNullOrWhiteSpace(fileName) ? "*.*" : fileName,
                            recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
                        select file;

            //Hier machen wir ein wenig parallele Suche
            var matches = from file in files
                              .AsParallel()
                              .AsOrdered()
                              .WithMergeOptions(ParallelMergeOptions.NotBuffered)
                          from line in File.ReadLines(file)
                              .Zip(Enumerable.Range(1, int.MaxValue), (s, i) => new { 
                                  Num = i,
                                  Text = s,
                                  File = file
                              })
                          where regex.Value.IsMatch(line.Text)
                          select line;

            //Für jede Zeile in den Ergebnissen wollen wir ein entsprechendes FileResult erstellen
            foreach (var line in matches)
            {
                yield return new FileResult() {
                    File = line.File, 
                    Line = line.Num, 
                    Text = line.Text 
                };
            }
        }
    }
}
