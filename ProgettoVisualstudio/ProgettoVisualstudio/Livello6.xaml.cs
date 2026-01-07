using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProgettoVisualstudio
{
    public partial class Livello6 : UserControl
    {
        public Livello6()
        {
            InitializeComponent();
            //metto il massimo della progress bar a 6
            BarraProgresso.Minimum = 0;
            BarraProgresso.Maximum = 7;//ho messo 7 pk con 6 si riempe 1 prima della vinmcita
            AggiornaBarra(); //lo chiamiamo subito per dare i primi 2 punti dei ceck box non selezionati e giusti perciò
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AggiornaBarra();
            ControllaCombinazione();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            AggiornaBarra();
            ControllaCombinazione();
        }

        private void AggiornaBarra()
        {
            int punteggio = 0;

            //punti per i frutti giusti selezionati
            if (CECKBOXMELE.IsChecked == true) punteggio++;
            if (CECKBOXBANANE.IsChecked == true) punteggio++;
            if (CECKBOXPERE.IsChecked == true) punteggio++;
            if (CECKBOXMIRTILLI.IsChecked == true) punteggio++;

            //se non è selezionato (false), il giocatore sta facendo bene, quindi +1
            if (CECKBOXCAROTE.IsChecked == false) punteggio++;
            if (CECKBOXUVA.IsChecked == false) punteggio++;

            BarraProgresso.Value = punteggio;

            BarraProgresso.Foreground =
                (punteggio == 6) ? Brushes.Lime : Brushes.Orange;
        }

        private void ControllaCombinazione()
        {
            //per vincere deve essere 6 la barra
            if (BarraProgresso.Value == 6)
            {
                MessageBox.Show("Livello 6 completato! La barra è piena!");

                MainWindow finestraPrincipale = (MainWindow)Application.Current.MainWindow;
                finestraPrincipale.livello6.Visibility = Visibility.Hidden;
                finestraPrincipale.livello7.Visibility = Visibility.Visible;
            }
        }
    }
}