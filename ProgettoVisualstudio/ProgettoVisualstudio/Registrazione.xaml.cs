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
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(1);
            timer.Start();

            String nomeFile = "Utenti.csv";
            StreamWriter reader;

            try {
                reader = new StreamWriter(nomeFile, true);

                reader.WriteLine(txtNomeUtente.Text,0);
                utenti.Add(new Utente(txtNomeUtente.Text, 0.0f));
                MessageBox.Show("Utente salvato con successo");
                reader.Close();
            }

            catch(FileNotFoundException)
            {
                Console.WriteLine("File non trovato");

            }
            catch (IOException)
            {
                Console.WriteLine("Errore di I/O");
            }
        }
    }
}
