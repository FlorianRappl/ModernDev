using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        //Merken uns diese Instanz
        ExampleCode code;

        public MainWindow()
        {
            //Instanziieren
            code = new ExampleCode();
            InitializeComponent();
            //Ereignisbehandlung integrieren
            code.HandleMyEvent += code_HandleMyEvent;
        }

        void code_HandleMyEvent(object sender, ExampleEventArgs e)
        {
            //Ohne Dispatcher kann das hier problematisch werden

            //Dispatcher.Invoke(
            //() =>
            //{
                AddToList("Triggered");
                AddToList(e.Zahl);
            //});
        }

        async void OnButtonClick(object sender, RoutedEventArgs e)
        {
            //Auslesen der Checkbox
            var trigger = Trigger.IsChecked.Value;
            //Zurücksetzen der ListBox
            Liste.Items.Clear();
            //Hinzufügen der Started-Meldung
            AddToList("Started");

            //Führen den Code asynchron aus - um await verwenden zu können muss die Methode async sein
            await Task.Run(() => code.Execute(trigger));

            //Hier wirds dank der Magie von await nicht problematisch
            //Automatische Rückkehr in den UI Thread sei Dank!
            AddToList("Finished");
        }

        //Ein kleiner Helfer
        void AddToList(object o)
        {
            //Ein Element zur Liste hinzufügen
            Liste.Items.Add(string.Format("{0}: {1}!", DateTime.Now, o));
        }
    }
}
