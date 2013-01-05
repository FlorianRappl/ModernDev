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
        Dictionary<string, Func<string, string>> fragments;
        Func<string, string> fragment;

        public MainWindow()
        {
            //Alles laden
            LoadFragments();
            InitializeComponent();

            //Das Dictionary nutzen um die ComboBox zu füllen
            MyLanguages.ItemsSource = fragments.Keys;
        }

        void LoadFragments()
        {
            //Standardwert ist die Identität
            fragment = x => x;
            //Neues Dictionary anlegen
            fragments = new Dictionary<string, Func<string, string>>();
            //Werte einfügen
            fragments.Add("Deutsch", x => "Mein Name ist " + x);
            fragments.Add("Englisch", x => "My name is " + x);
            fragments.Add("Französisch", x => "Je m'appelle " + x);
        }

        void OnButtonClick(object sender, RoutedEventArgs e)
        {
            //Den Satz mithilfe der ausgewählten Methode konstruieren
            var sentence = fragment(MyName.Text);
            //Anzeigen (einfach in MessageBox)
            MessageBox.Show(sentence);
        }

        void OnSelected(object sender, RoutedEventArgs e)
        {
            //Sobald wir was auswählen, soll die Auswahl referenziert werden
            fragment = fragments[(string)MyLanguages.SelectedItem];
        }
    }
}
