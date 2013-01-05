using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Members

        List<int> quadSource;
        List<string> statSource;
        CancellationTokenSource cancelToken;

        #endregion

        #region ctor

        public MainWindow()
        {
            InitializeComponent();
            InitializeSources();
        }

        async void InitializeSources()
        {
            var r = new Random();

            //Mal einen Blick auf die schlechten Seiten von PLINQ?
            //Immer dran denken: was ist Thread-Safe und kann verwendet werden!
            //Das vom .NET-Framework gestellte Random ist leider nicht
            //Thread-Safe und muss daher leider Sequentiell genutzt werden...

            await Task.Run(() =>
            {
                quadSource = Enumerable
                    .Range(1, 10000000)
                    //.AsParallel()
                    .Select(i => r.Next(1, 30))
                    .ToList();

                statSource = Enumerable
                    .Range(1, 100000)
                    //.AsParallel()
                    .Select(i => Generate(r))
                    .ToList();
            });

            SourceQuad.ItemsSource = quadSource;
            SourceStat.ItemsSource = statSource;
            Tabs.Visibility = System.Windows.Visibility.Visible;
            Loading.Visibility = System.Windows.Visibility.Collapsed;
        }

        #endregion

        #region Methods

        async void RunQuad(object sender, RoutedEventArgs e)
        {
            //Aufbohren der Funktion um mehr Arbeit zu simulieren
            Func<int, double> f = m => Math.Sqrt(Math.Sqrt(Math.Sqrt(Math.Pow(m, 16.0))));
            EnableWait(sender);

            //Messen der Zeit
            var sw = Stopwatch.StartNew();

            //Parallele LINQ Abfrage - vorsicht: Würde nach wie vor den (UI) Thread bei ToList() blockieren!
            //Daher verwenden wir zusätzlich dazu noch async und await!
            ResultQuad.ItemsSource = await Task.Run(() => quadSource
                .AsParallel()
                .Select(f).ToList());

            Debug.WriteLine(sw.ElapsedMilliseconds + "ms");
            DisableWait(sender);
        }

        async void RunStat(object sender, RoutedEventArgs e)
        {
            EnableWait(sender);

            //Messen der Zeit
            var sw = Stopwatch.StartNew();

            //Analog RunQuad
            ResultStat.ItemsSource = await Task.Run(() => statSource
                .AsParallel()
                .OrderBy(m => m.Length).ThenBy(m => m).ToList());

            //Hier machen wir noch ein wenig Statistik - sind die Längen ungefähr "gleichverteilt"?
            var hist = await Task.Run(() => statSource
                .AsParallel()
                .GroupBy(m => m.Length).Select(m => new
                {
                    Length = m.Key,
                    Entries = m.Count()
                }).ToList());

            Debug.WriteLine(sw.ElapsedMilliseconds + "ms");

            //Die Statistik geben wir nur in der Debug-Konsole aus
            foreach (var bin in hist)
                Debug.WriteLine("{0} : {1}", bin.Length, bin.Entries);

            DisableWait(sender);
        }

        async void RunCancel(object sender, RoutedEventArgs e)
        {
            EnableWait(sender);
            //Zum Abbrechen brauchen wir so eine CancellationTokenSource
            cancelToken = new CancellationTokenSource();

            try
            {
                //Nachdem das Abbrechen eine Exception werfen wird, brauchen wir dies
                var sum = await Task.Run(() => quadSource.AsParallel().WithCancellation(cancelToken.Token).Where(m => m % 2 == 0)
                     .Select(m => { Task.Delay(10); return m; }).Sum());

                //Die künstliche Verzögerung macht das Abbrechen notwendig
                MessageBox.Show("Fertig! Die Summe ist ... " + sum);
            }
            catch (Exception ex)
            {
                //Nachricht im Falle eines Abbruchs ausgeben
                MessageBox.Show("Abgebrochen ... ");
                Debug.WriteLine(ex.Message);
            }

            //Anfangszustand wiederherstellen
            cancelToken = null;
            DisableWait(sender);
        }

        void CancelCancel(object sender, RoutedEventArgs e)
        {
            //Falls wir abbrechen können --> abbrechen
            if (cancelToken != null)
                cancelToken.Cancel();
        }

        #endregion

        #region Helpers

        void ResetStat(object sender, RoutedEventArgs e)
        {
            ResultStat.ItemsSource = null;
        }

        void ResetQuad(object sender, RoutedEventArgs e)
        {
            ResultQuad.ItemsSource = null;
        }

        void DisableWait(object sender)
        {
            var bt = sender as Button;

            if (bt != null)
            {
                bt.Content = "Ausführen";
                bt.IsEnabled = true;
            }
        }

        void EnableWait(object sender)
        {
            var bt = sender as Button;

            if (bt != null)
            {
                bt.Content = new Spinner();
                bt.IsEnabled = false;
            }
        }

        string Generate(Random r)
        {
            var length = r.Next(1, 16);
            var word = new char[length];

            for (var i = 0; i < length; i++)
            {
                word[i] = (char)(r.Next(97, 123));
            }

            return new String(word);
        }

        #endregion
    }
}
