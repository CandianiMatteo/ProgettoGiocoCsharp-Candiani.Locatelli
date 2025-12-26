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
using System.Windows.Threading;

namespace ProgettoVisualstudio
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int contatoreClick = 0;
        public MainWindow()
        {
            InitializeComponent();
            livello2.Visibility = Visibility.Hidden;

        }

        private void Livello2_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void button_start_Click_1(object sender, RoutedEventArgs e)
        {
            contatoreClick++;

            if (contatoreClick == 3)
            {
                livello2.Visibility = Visibility.Visible;
            }

            if (contatoreClick  > 3)
            {
                contatoreClick = 0;
            }
        }


        private void ApriRegistrazione_Click(object sender, RoutedEventArgs e)
        {
            Registrazione finestra = new Registrazione();
            finestra.Show();
        }
    }
}
