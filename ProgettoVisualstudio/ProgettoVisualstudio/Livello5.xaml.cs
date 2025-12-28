using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ProgettoVisualstudio
{
    /// <summary>
    /// Logica di interazione per Livello5.xaml
    /// </summary>
    public partial class Livello5 
    {
        //consiglio ia cronometro
        Stopwatch cronometro = new Stopwatch();

        bool primoPremuto = false;

        public Livello5()
        {
            InitializeComponent();
        }

        private void bottone_Click(object sender, RoutedEventArgs e)
        {
            //sender passa come premuto 
            Button cliccato = sender as Button;

            //primo click
            if (!primoPremuto)
            {
                primoPremuto = true;
                cronometro.Restart();   //parte il timer
                return;
            }

            //econdo click stop timer
            cronometro.Stop();

            //controllo secondi del cronometro con mezzo secondo
            if (cronometro.ElapsedMilliseconds <= 500)
            {
                //vittoria
                MessageBox.Show("livello 5 completato!");

                //come al solito recupero mainwindow pk far apparire e sparire grid 
                MainWindow finestraPrincipale = (MainWindow)Application.Current.MainWindow;
                finestraPrincipale.gridlivello5.Visibility = Visibility.Hidden;
                finestraPrincipale.livello6.Visibility = Visibility.Visible;
            }
            else
            {
                //sconfitta
                MessageBox.Show("fallito hai sbagliato,riprova");

                primoPremuto = false;
                cronometro.Reset();
            }
        }
    }

}
