using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ProgettoVisualstudio
{
    /// <summary>
    /// Logica di interazione per Registrazione.xaml
    /// </summary>
    public partial class Registrazione : Window
    {
        List<Utente> utenti = new List<Utente>();

        public Registrazione()
        {
            InitializeComponent();
        }

        private void button_salva_Click(object sender, RoutedEventArgs e)
        {
            // Prendo il nome scritto nella TextBox
            string nome = txtNomeUtente.Text;

            // Controllo che non sia vuoto
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Inserisci un nome!");
                return;
            }

            // Creo un nuovo utente con tempo iniziale = 0
            Utente nuovo = new Utente(nome, 0);

            // Recupero la MainWindow
            MainWindow main = (MainWindow)Application.Current.MainWindow;

            // Salvo l'utente nella MainWindow
            main.UtenteCorrente = nuovo;

            // Avvio il timer globale
            main.timer.Start();

            // Salvo il nome nel file Utenti.csv
            using (StreamWriter w = new StreamWriter("Utenti.csv", true))
            {
                w.WriteLine(nome);
            }

            MessageBox.Show("Utente salvato con successo!");

            // Chiudo la finestra di registrazione
            this.Close();
        }

    }
}
