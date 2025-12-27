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
    /// Logica di interazione per livello2.xaml
    /// </summary>
    public partial class Livello2 : UserControl
    {
        //variabile numero click
        int cont = 0;

        public Livello2()
        {
            InitializeComponent();
            // Questa riga impedisce di scrivere con la tastiera (cercato online)
            textboxcontatore.IsReadOnly = true;
        }

        private void button_livello2_Click(object sender, RoutedEventArgs e)
        {
            
            cont++;

            //scrittura nel textbox del numero di premute
            textboxcontatore.Text = cont.ToString();

            //se sono 3 vinco
            if (cont == 3)
            {
                MessageBox.Show("hai vinto il Livello 2");

                // 1. Cerchiamo la finestra principale (MainWindow)
                var finestraPrincipale = Window.GetWindow(this) as MainWindow;

                if (finestraPrincipale != null)
                {
                    // 2. Nascondiamo la Grid del livello 2
                    finestraPrincipale.livello2.Visibility = Visibility.Hidden;

                    // 3. Rendiamo visibile la Grid del livello 3
                    finestraPrincipale.livello3.Visibility = Visibility.Visible;
                }

            }
        }
    }
}


