using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ProgettoVisualstudio
{
    public partial class Livello8 : UserControl
    {
        List<Button> bottoniTrappola = new List<Button>();
        int clickCorretti = 0;
        Random rnd = new Random();

        public Livello8()
        {
            InitializeComponent();
        }

        private void button_memorizza_Click(object sender, RoutedEventArgs e)
        {
            AvviaLivello();
        }

        async void AvviaLivello()
        {
            clickCorretti = 0;
            bottoniTrappola.Clear();

            List<Button> tutti = new List<Button>
            {
                b1, b2, b3,
                b4, b5, b6,
                b7, b8, b9
            };

            // Tutti VERDI
            foreach (Button b in tutti)
                CambiaColore(b, Colors.Green);

            await Task.Delay(100);

            // Scegli 3 trappole
            while (bottoniTrappola.Count < 3)
            {
                Button scelto = tutti[rnd.Next(tutti.Count)];
                if (!bottoniTrappola.Contains(scelto))
                    bottoniTrappola.Add(scelto);
            }

            // Mostra trappole GIALLE
            foreach (Button b in bottoniTrappola)
                CambiaColore(b, Colors.Yellow);

            await Task.Delay(1000);

            // Tornano VERDI
            foreach (Button b in bottoniTrappola)
                CambiaColore(b, Colors.Green);
        }

        private void Cella_Click(object sender, RoutedEventArgs e)
        {
            Button cliccato = sender as Button;

            // Se è una trappola → errore
            if (bottoniTrappola.Contains(cliccato))
            {
                MessageBox.Show("Hai cliccato una trappola! Riprova.");
                AvviaLivello();
                return;
            }

            // Se è corretto → verde scuro
            CambiaColore(cliccato, Colors.DarkGreen);
            clickCorretti++;

            if (clickCorretti == 3)
            {
                MessageBox.Show("Livello 8 completato!");

                MainWindow finestraPrincipale = (MainWindow)Application.Current.MainWindow;
                finestraPrincipale.livello8.Visibility = Visibility.Hidden;
            }
        }

        void CambiaColore(Button b, Color colore)
        {
            Ellipse ellisse = b.Template.FindName("buttonEllipse", b) as Ellipse;

            if (ellisse != null)
                ellisse.Fill = new SolidColorBrush(colore);
        }
    }
}

