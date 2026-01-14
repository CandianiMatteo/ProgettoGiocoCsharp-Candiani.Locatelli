using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ProgettoVisualstudio
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int cont = 0;

        public Utente UtenteCorrente;   // Utente attualmente registrato
        public float TempoGioco = 0;    // Tempo in secondi

        public DispatcherTimer timer = new DispatcherTimer();


        public MainWindow()
        {
            InitializeComponent();
            livello2.Visibility = Visibility.Hidden;
            livello3.Visibility = Visibility.Hidden;
            livello4.Visibility = Visibility.Hidden;
            livello5.Visibility = Visibility.Hidden;
            livello6.Visibility = Visibility.Hidden;
            livello7.Visibility = Visibility.Hidden;
            livello8.Visibility = Visibility.Hidden;
            livello9.Visibility = Visibility.Hidden;
            gridlivello10.Visibility = Visibility.Hidden;

            // Imposto il timer a 1 secondo
            timer.Interval = TimeSpan.FromSeconds(1);

            // Ogni secondo viene chiamato Timer_Tick
            timer.Tick += Timer_Tick;


        }

        private void Livello2_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void button_start_Click_1(object sender, RoutedEventArgs e)
        {
            if (cont == 0)
            {
                cont = cont + 1;
                livello2.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("ei... nessuno ti ha detto di ricliccare ;( ");
            }
        }


        private void ApriRegistrazione_Click(object sender, RoutedEventArgs e)
        {
            Registrazione finestra = new Registrazione();
            finestra.Show();
        }

        private void Livello3_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Livello10_Loaded(object sender, RoutedEventArgs e)
        {

        }

        // Metodo chiamato ogni secondo dal timer
        private void Timer_Tick(object sender, EventArgs e)
        {
            TempoGioco++; // Aumento il tempo di gioco
        }

        public void MostraClassifica()
        {
            // Pulisco la ListBox prima di riempirla
            listaClassifica.Items.Clear();

            // Se il file non esiste, non ci sono punteggi
            if (!File.Exists("classifica.txt"))
            {
                listaClassifica.Items.Add("Nessun punteggio.");
                return;
            }

            // Leggo tutte le righe del file
            string[] righe = File.ReadAllLines("classifica.txt");

            // Creo due array: uno per i nomi e uno per i tempi
            string[] nomi = new string[righe.Length];
            float[] tempi = new float[righe.Length];

            // Riempio gli array con i dati del file
            for (int i = 0; i < righe.Length; i++)
            {
                string[] parti = righe[i].Split(';'); // Divido "nome;tempo"

                nomi[i] = parti[0];                  // Nome utente
                tempi[i] = float.Parse(parti[1]);    // Tempo in secondi
            }

            // Confronta ogni elemento con il successivo
            for (int i = 0; i < tempi.Length - 1; i++)
            {
                for (int j = 0; j < tempi.Length - 1 - i; j++)
                {
                    // Se il tempo attuale è maggiore del successivo → scambio
                    if (tempi[j] > tempi[j + 1])
                    {
                        // Scambio i tempi
                        float tempT = tempi[j];
                        tempi[j] = tempi[j + 1];
                        tempi[j + 1] = tempT;

                        // Scambio anche i nomi per mantenere l'abbinamento corretto
                        string tempN = nomi[j];
                        nomi[j] = nomi[j + 1];
                        nomi[j + 1] = tempN;
                    }
                }
            }

            // -------------------------------
            // MOSTRO LA CLASSIFICA ORDINATA
            // -------------------------------
            for (int i = 0; i < nomi.Length; i++)
            {
                // Converto i secondi in minuti e secondi
                int minuti = (int)(tempi[i] / 60);
                int secondi = (int)(tempi[i] % 60);

                // Aggiungo la riga nella ListBox
                listaClassifica.Items.Add(nomi[i] + " - " + minuti + "m " + secondi + "s");
            }

            // Rendo visibile la griglia della classifica
            gridClassifica.Visibility = Visibility.Visible;
        }


    }
}
