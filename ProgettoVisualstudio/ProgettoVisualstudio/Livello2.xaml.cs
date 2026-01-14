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
using System.Windows.Threading; //per timer

namespace ProgettoVisualstudio
{
    /// <summary>
    /// Logica di interazione per livello2.xaml
    /// </summary>
    public partial class Livello2 : UserControl
    {
        //variabile numero click
        int cont = 0;

        DispatcherTimer timerAttesa;      //aggiunta timer
        int secondiPassati = 0;           //tiene conto dei secondi

        public Livello2()
        {
            InitializeComponent();
            //questa riga impedisce di scrivere con la tastiera (cercato online)
            textboxcontatore.IsReadOnly = true;


            //impostazioni base timer
            timerAttesa = new DispatcherTimer();            
            timerAttesa.Interval = TimeSpan.FromSeconds(1); 
            timerAttesa.Tick += TimerAttesa_Tick;           
        }

        private void button_livello2_Click(object sender, RoutedEventArgs e)
        {
            cont++;

            //scrittura nel textbox del numero di premute
            textboxcontatore.Text = cont.ToString();

            //se sono 3 vinco
            if (cont == 3)
            {
                secondiPassati = 0;        //reset secondi
                timerAttesa.Start();       //start timer
            }
            else
            {
                timerAttesa.Stop();        
            }
        }

        private void TimerAttesa_Tick(object sender, EventArgs e)
        {
            if (cont != 3)
            {
                timerAttesa.Stop();        //SE NON È PIÙ 3, STOP (corretto ai)
                return;
            }

            secondiPassati++;//1 secondo        

            if (secondiPassati == 3) //3 secondi vinto      
            {
                timerAttesa.Stop();

                MessageBox.Show("Livello 2 Completato!");

                
                var finestraPrincipale = Window.GetWindow(this) as MainWindow;

                if (finestraPrincipale != null)
                {
                    finestraPrincipale.livello2.Visibility = Visibility.Hidden;
                    finestraPrincipale.livello3.Visibility = Visibility.Visible;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //rimetto a zero la variabile numerica
            cont = 0;

            //aggiorno graficamente la textbox per mostrare lo zero
            textboxcontatore.Text = cont.ToString();

            //opzionale: fermo il timer se era in esecuzione
            timerAttesa.Stop();
            secondiPassati = 0;
        }
    }
}