using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ProgettoVisualstudio
{
    public partial class Livello4 : UserControl
    {
        List<Button> bottoniCorretti = new List<Button>();
        int clickCorretti = 0;
        Random rnd = new Random();

        public Livello4()
        {
            InitializeComponent();
            AvviaLivello();
        }

        async void AvviaLivello()
        {
            clickCorretti = 0;
            bottoniCorretti.Clear();

            //lista bottoni
            List<Button> tutti = new List<Button>
            {
                bottone1, bottone2, bottone3,
                bottone4, bottone5, bottone6,
                bottone7, bottone8, bottone9
            };

            //foreach che scorre tutti e mette elementi rossi
            foreach (Button b in tutti)
                CambiaColore(b, Colors.Red);

            //forza aggiornamento UI consiglio ai pk non andva
            await Task.Delay(50);


            //scelgo 3 bottoni a caso
            while (bottoniCorretti.Count < 3)
            {
                Button scelto = tutti[rnd.Next(tutti.Count)];
                if (!bottoniCorretti.Contains(scelto))
                    bottoniCorretti.Add(scelto);
            }

            //illumino i 3 bottoni
            foreach (Button b in bottoniCorretti)
                CambiaColore(b, Colors.Yellow);

            await Task.Delay(1000);

            //tornano normali
            foreach (Button b in bottoniCorretti)
                CambiaColore(b, Colors.Red);
        }

        private void Cella_Click(object sender, RoutedEventArgs e)
        {
            Button cliccato = sender as Button;

            if (bottoniCorretti.Contains(cliccato))
            {
                CambiaColore(cliccato, Colors.Green);
                clickCorretti++;

                if (clickCorretti == 3)
                {
                    MessageBox.Show("Livello 4 completato!");

                    MainWindow finestraPrincipale = (MainWindow)Application.Current.MainWindow;
                    finestraPrincipale.livello4.Visibility = Visibility.Hidden;
                    finestraPrincipale.gridlivello5.Visibility = Visibility.Visible;
                }
            }
            else
            {
                MessageBox.Show("Sbagliato! Riprova.");
                AvviaLivello();
            }
        }

        void CambiaColore(Button b, Color colore)
        {
            //aiuto ai pk ho provato altri metodi con grid ma non funzionavano
            Ellipse ellisse = b.Template.FindName("buttonEllipse", b) as Ellipse;

            if (ellisse != null)
                ellisse.Fill = new SolidColorBrush(colore);
        }
    }
}