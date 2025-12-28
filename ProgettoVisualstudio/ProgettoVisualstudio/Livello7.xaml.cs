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

namespace ProgettoVisualstudio
{
    /// <summary>
    /// Logica di interazione per Livello7.xaml
    /// </summary>
    public partial class Livello7 : UserControl
    {
        
        public Livello7()
        {
            InitializeComponent();
        }

        private void btnConferma_Click(object sender, RoutedEventArgs e)
        {
            if (txtRisposta.Text == "Buco" || txtRisposta.Text == "buco")
            {
                MessageBox.Show("Livello 7 Superato");
                MainWindow finestraPrincipale = (MainWindow)Application.Current.MainWindow;
                finestraPrincipale.livello7.Visibility = Visibility.Hidden;
                // Qui puoi aggiungere la logica per mostrare il livello successivo
            }
            else
            {
                MessageBox.Show("Risposta sbagliata, riprova.");
            }
        }
    }
}
