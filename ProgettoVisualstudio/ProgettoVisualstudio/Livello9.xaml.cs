using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ProgettoVisualstudio
{
    public partial class Livello9 : UserControl
    {
        // Lista delle celle cliccate dal giocatore, in ordine
        private List<Cella> percorso = new List<Cella>();

        // Cella di partenza e cella di arrivo
        private Cella partenza;
        private Cella meta;

        // Generatore numeri casuali
        private Random rnd = new Random();

        public Livello9()
        {
            InitializeComponent();

            // Genera partenza e meta valide
            GeneraPartenzaMeta();

            // Collega l'evento click a tutti i rettangoli della griglia
            CollegaClick();

            // Evidenzia graficamente partenza e meta
            Evidenzia(partenza, Brushes.LightSkyBlue);
            Evidenzia(meta, Brushes.LightGreen);
        }

        // Collega l'evento MouseDown a ogni rettangolo della griglia
        private void CollegaClick()
        {
            foreach (UIElement child in GridLivello.Children)
                if (child is Rectangle rect)
                    rect.MouseDown += CellaCliccata;
        }

        // Quando clicchi una cella, ricavo riga e colonna e avvio la logica
        private void CellaCliccata(object sender, MouseButtonEventArgs e)
        {
            Rectangle r = (Rectangle)sender;

            int row = Grid.GetRow(r);    // Riga cliccata
            int col = Grid.GetColumn(r); // Colonna cliccata

            // Passo la cella alla logica del livello
            GestisciClick(new Cella(row, col));
        }

        // Genera partenza e meta con distanza Manhattan tra 4 e 5
        private void GeneraPartenzaMeta()
        {
            // Partenza casuale
            partenza = new Cella(rnd.Next(0, 5), rnd.Next(0, 5));

            // Meta casuale ma con distanza minima 4 e massima 5
            do
            {
                meta = new Cella(rnd.Next(0, 5), rnd.Next(0, 5));
            }
            while (Distanza(partenza, meta) != 4);
        }

        // Calcola la distanza Manhattan tra due celle
        private int Distanza(Cella a, Cella b)
        {
            return Math.Abs(a.R - b.R) + Math.Abs(a.C - b.C);
        }

        // Gestisce tutta la logica quando il giocatore clicca una cella
        private void GestisciClick(Cella cella)
        {
            // PRIMA REGOLA: la prima cella deve essere la partenza
            if (percorso.Count == 0 && !cella.Equals(partenza))
            {
                Reset();
                return;
            }

            // NON puoi cliccare due volte la stessa cella
            if (percorso.Contains(cella))
            {
                Reset();
                return;
            }

            // Se non è la prima cella, deve essere adiacente alla precedente
            if (percorso.Count > 0)
            {
                Cella ultima = percorso[percorso.Count - 1];

                if (!Adiacenti(ultima, cella))
                {
                    Reset();
                    return;
                }
            }

            // Aggiungo la cella al percorso
            percorso.Add(cella);

            // La coloro per far vedere il percorso
            Colora(cella, Brushes.LightBlue);

            // SE ARRIVI ALLA META → VITTORIA
            if (cella.Equals(meta))
            {
                MessageBox.Show("Livello 9 Completato!");

                MainWindow finestraPrincipale = (MainWindow)Application.Current.MainWindow;
                finestraPrincipale.livello9.Visibility = Visibility.Hidden;
                finestraPrincipale.gridlivello10.Visibility = Visibility.Visible;
                return;
            }

            // Se fai più di 5 passi → reset
            if (percorso.Count > 4)
            {
                Reset();
                return;
            }
        }

        // Controlla se due celle sono adiacenti (su/giù/sinistra/destra)
        private bool Adiacenti(Cella a, Cella b)
        {
            // Movimento orizzontale
            bool orizzontale = a.R == b.R && Math.Abs(a.C - b.C) == 1;

            // Movimento verticale
            bool verticale = a.C == b.C && Math.Abs(a.R - b.R) == 1;

            return orizzontale || verticale;
        }

        // Colora una cella della griglia
        private void Colora(Cella p, Brush colore)
        {
            foreach (UIElement child in GridLivello.Children)
                if (child is Rectangle rect &&
                    Grid.GetRow(rect) == p.R &&
                    Grid.GetColumn(rect) == p.C)
                {
                    rect.Fill = colore;
                }
        }

        // Evidenzia graficamente partenza e meta
        private void Evidenzia(Cella p, Brush colore)
        {
            foreach (UIElement child in GridLivello.Children)
                if (child is Rectangle rect &&
                    Grid.GetRow(rect) == p.R &&
                    Grid.GetColumn(rect) == p.C)
                {
                    rect.Fill = colore;
                    rect.StrokeThickness = 3;
                }
        }

        // Reset totale del livello
        private void Reset()
        {
            // Cancello il percorso
            percorso.Clear();

            // Ripristino grafica base
            foreach (UIElement child in GridLivello.Children)
                if (child is Rectangle rect)
                {
                    rect.Fill = Brushes.White;
                    rect.StrokeThickness = 1.5;
                }

            // Rigenero partenza e meta
            GeneraPartenzaMeta();

            // Evidenzio di nuovo partenza e meta
            Evidenzia(partenza, Brushes.LightSkyBlue);
            Evidenzia(meta, Brushes.LightGreen);
        }
    }
}
