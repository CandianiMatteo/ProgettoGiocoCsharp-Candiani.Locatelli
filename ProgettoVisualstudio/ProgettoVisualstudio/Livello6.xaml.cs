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
using System.Windows.Threading;

namespace ProgettoVisualstudio
{
    /// <summary>
    /// Logica di interazione per Livello6.xaml
    /// </summary>
    public partial class Livello6 : UserControl
    {
        public Livello6()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ControllaCombinazione();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ControllaCombinazione();
        }

        private void ControllaCombinazione()
        {
            // combinazione corretta:
            // MELE = true
            // CAROTE = false
            // BANANE = true

            if (CECKBOXMELE.IsChecked == true &&
                CECKBOXCAROTE.IsChecked == false &&
                CECKBOXBANANE.IsChecked == true)
            {
                // vittoria
                MessageBox.Show("Livello 6 completato!");

                // recupero MainWindow per cambio livello
                MainWindow finestraPrincipale =
                    (MainWindow)Application.Current.MainWindow;

                finestraPrincipale.livello6.Visibility = Visibility.Hidden;
                finestraPrincipale.livello7.Visibility = Visibility.Visible;
            }
        }
    }
}
