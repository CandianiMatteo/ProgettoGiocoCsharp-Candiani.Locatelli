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
        // Lista delle celle cliccate in ordine
        private List<Point> percorso = new List<Point>();

        // Coordinate della partenza e della meta
        private Point partenza;
        private Point meta;

        private Random rnd = new Random();

        public Livello9()
        {
            InitializeComponent();

            GeneraPartenzaMeta();      // Crea partenza e meta
            CollegaClick();            // Collega i click ai rettangoli

            Evidenzia(partenza, Brushes.LightSkyBlue); // Colore partenza
            Evidenzia(meta, Brushes.LightGreen);       // Colore meta
        }

        // Collega l'evento di click a ogni cella della griglia
        private void CollegaClick()
        {
            foreach (UIElement child in GridLivello.Children)
                if (child is Rectangle rect)
                    rect.MouseDown += CellaCliccata;
        }

        // Quando clicchi una cella, ricavo riga e colonna
        private void CellaCliccata(object sender, MouseButtonEventArgs e)
        {
            Rectangle r = (Rectangle)sender;
            int row = Grid.GetRow(r);
            int col = Grid.GetColumn(r);

            GestisciClick(new Point(row, col));
        }

        // Genera una partenza e una meta semplici
        private void GeneraPartenzaMeta()
        {
            // Partenza casuale
            partenza = new Point(rnd.Next(0, 5), rnd.Next(0, 5));

            // Meta casuale ma lontana almeno 4 passi (distanza Manhattan)
            do
            {
                meta = new Point(rnd.Next(0, 5), rnd.Next(0, 5));
            }
            while (Distanza(partenza, meta) < 4);
        }

        // Distanza Manhattan (perfetta per griglie)
        private int Distanza(Point a, Point b)
        {
            return (int)(Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y));
        }

        // Logica principale del gioco
        private void GestisciClick(Point cella)
        {
            // Prima cella obbligatoria: la partenza
            if (percorso.Count == 0 && cella != partenza)
            {
                Reset();
                return;
            }

            // Non puoi cliccare due volte la stessa cella
            if (percorso.Contains(cella))
            {
                Reset();
                return;
            }

            // Se non è la prima, deve essere adiacente (solo verticale/orizzontale)
            if (percorso.Count > 0)
            {
                Point ultima = percorso[percorso.Count - 1];

                if (!Adiacenti(ultima, cella))
                {
                    Reset();
                    return;
                }
            }

            // Aggiungo la cella al percorso
            percorso.Add(cella);
            Colora(cella, Brushes.LightBlue);

            // Se arrivi alla meta → vittoria
            if (cella == meta)
            {
                MessageBox.Show("Livello 9 completato!");
                return;
            }

            // Se fai 5 passi senza arrivare → reset
            if (percorso.Count == 5)
                Reset();
        }

        // Controllo adiacenza SOLO verticale/orizzontale
        private bool Adiacenti(Point a, Point b)
        {
            // Stessa riga → movimento orizzontale
            bool orizzontale = a.X == b.X && Math.Abs(a.Y - b.Y) == 1;

            // Stessa colonna → movimento verticale
            bool verticale = a.Y == b.Y && Math.Abs(a.X - b.X) == 1;

            return orizzontale || verticale;
        }

        // Colora una cella normale
        private void Colora(Point p, Brush colore)
        {
            foreach (UIElement child in GridLivello.Children)
                if (child is Rectangle rect &&
                    Grid.GetRow(rect) == (int)p.X &&
                    Grid.GetColumn(rect) == (int)p.Y)
                    rect.Fill = colore;
        }

        // Evidenzia partenza o meta
        private void Evidenzia(Point p, Brush colore)
        {
            foreach (UIElement child in GridLivello.Children)
                if (child is Rectangle rect &&
                    Grid.GetRow(rect) == (int)p.X &&
                    Grid.GetColumn(rect) == (int)p.Y)
                {
                    rect.Fill = colore;
                    rect.StrokeThickness = 3;
                }
        }

        // Reset totale del livello
        private void Reset()
        {
            percorso.Clear();

            // Ripristina grafica base
            foreach (UIElement child in GridLivello.Children)
                if (child is Rectangle rect)
                {
                    rect.Fill = Brushes.White;
                    rect.StrokeThickness = 1.5;
                }

            // Rigenera partenza e meta
            GeneraPartenzaMeta();

            // Evidenzia di nuovo
            Evidenzia(partenza, Brushes.LightSkyBlue);
            Evidenzia(meta, Brushes.LightGreen);
        }
    }
}




