using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ProgettoVisualstudio
{
    public partial class Livello3 : UserControl
    {
        // Ordine richiesto: Rosso(A) -> Blu(B) -> Verde(C) 
        // Se la tua label dice ROSSO BLU VERDE, l'ordine deve essere A, B, C
        List<string> ordineGiusto = new List<string> { "A", "B", "C" };
        List<string> ordineGiocatore = new List<string>();
        DispatcherTimer timer;

        public Livello3()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            MostraAiuto();
        }

        // Deve essere PUBLIC così la MainWindow può chiamarlo
        public void MostraAiuto()
        {
            ordineGiocatore.Clear();
            labelsequenza.Visibility = Visibility.Visible;
            timer.Stop();
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            labelsequenza.Visibility = Visibility.Hidden;
            timer.Stop();
        }

        private void ControllaClick(string lettera)
        {
            ordineGiocatore.Add(lettera);
            int pos = ordineGiocatore.Count - 1;

            if (ordineGiocatore[pos] != ordineGiusto[pos])
            {
                MessageBox.Show("Sbagliato Riprova");
                MostraAiuto();
            }
            else if (ordineGiocatore.Count == ordineGiusto.Count)
            {
                MessageBox.Show("Livello 3 Superato");

                //non andava aiuti ia
                MainWindow main = (MainWindow)Application.Current.MainWindow;

                main.livello3.Visibility = Visibility.Hidden;
                main.Livello4.Visibility = Visibility.Visible;
            }
        }

        // COLLEGA I TUOI BOTTONI XAML
        private void BOTTONE1_Click(object sender, RoutedEventArgs e) { ControllaClick("A"); } // ROSSO
        private void Button_Click(object sender, RoutedEventArgs e) { ControllaClick("B"); } // BLU
        private void BOTTONE2_Click(object sender, RoutedEventArgs e) { ControllaClick("C"); } // VERDE
    }
}