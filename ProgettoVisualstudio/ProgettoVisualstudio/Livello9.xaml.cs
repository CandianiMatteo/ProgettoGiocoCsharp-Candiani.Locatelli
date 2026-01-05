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
        private List<Tuple<int, int>> Percorso;
        private Tuple<int, int> Partenza;
        private Tuple<int, int> Meta;
        private Random rnd;

        public Livello9()
        {
            InitializeComponent();

            rnd = new Random();
            Percorso = new List<Tuple<int, int>>();

            GeneraPartenzaEMeta();
            CollegaClick();

            EvidenziaPartenza(Partenza.Item1, Partenza.Item2);
            EvidenziaMeta(Meta.Item1, Meta.Item2);
        }

        private void CollegaClick()
        {
            foreach (UIElement child in GridLivello.Children)
            {
                if (child is Rectangle rect)
                    rect.MouseDown += Rect_MouseDown;
            }
        }

        private void Rect_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            int r = Grid.GetRow(rect);
            int c = Grid.GetColumn(rect);

            ClickCella(r, c);
        }

        private void GeneraPartenzaEMeta()
        {
            // Quadranti della griglia 5x5
            List<(int r1, int r2, int c1, int c2)> quadranti = new List<(int r1, int r2, int c1, int c2)>
            {
                (0, 1, 0, 1), // Q1
                (0, 1, 3, 4), // Q2
                (3, 4, 0, 1), // Q3
                (3, 4, 3, 4)  // Q4
            };

            // Scegli quadrante partenza
            int qp = rnd.Next(0, 4);

            // Quadrante opposto
            int qm = (qp + 2) % 4;

            var QP = quadranti[qp];
            var QM = quadranti[qm];

            // Genera partenza nel quadrante scelto
            int r1 = rnd.Next(QP.r1, QP.r2 + 1);
            int c1 = rnd.Next(QP.c1, QP.c2 + 1);
            Partenza = new Tuple<int, int>(r1, c1);

            int r2, c2;

            // Genera meta nel quadrante opposto
            do
            {
                r2 = rnd.Next(QM.r1, QM.r2 + 1);
                c2 = rnd.Next(QM.c1, QM.c2 + 1);

                int dr = Math.Abs(r2 - r1);
                int dc = Math.Abs(c2 - c1);

                // distanza minima 4
                if (dr + dc >= 4)
                    break;

            } while (true);

            Meta = new Tuple<int, int>(r2, c2);
        }


        private void Reset()
        {
            Percorso.Clear();
            ResetGrafica();
            GeneraPartenzaEMeta();
            EvidenziaPartenza(Partenza.Item1, Partenza.Item2);
            EvidenziaMeta(Meta.Item1, Meta.Item2);
        }

        private bool SonoAdiacenti(Tuple<int, int> a, Tuple<int, int> b)
        {
            int dr = Math.Abs(a.Item1 - b.Item1);
            int dc = Math.Abs(a.Item2 - b.Item2);

            return dr <= 1 && dc <= 1 && !(a.Item1 == b.Item1 && a.Item2 == b.Item2);
        }

        private void ClickCella(int r, int c)
        {
            var cella = new Tuple<int, int>(r, c);

            // 1) Prima cella deve essere la partenza
            if (Percorso.Count == 0)
            {
                if (cella.Item1 != Partenza.Item1 || cella.Item2 != Partenza.Item2)
                {
                    Reset();
                    return;
                }
            }

            // 2) Non puoi cliccare due volte la stessa cella
            if (Percorso.Contains(cella))
            {
                Reset();
                return;
            }

            // 3) Se non è la prima, controlla adiacenza
            if (Percorso.Count > 0)
            {
                var ultima = Percorso[Percorso.Count - 1];

                if (!SonoAdiacenti(ultima, cella))
                {
                    Reset();
                    return;
                }
            }

            // 4) Aggiungi cella
            Percorso.Add(cella);
            ColoraCella(r, c, Brushes.LightBlue);

            // 5) Se arrivi alla meta → livello superato
            if (cella.Item1 == Meta.Item1 && cella.Item2 == Meta.Item2)
            {
                MessageBox.Show("Livello 9 completato!");
                return;
            }

            // 6) Se arrivi a 5 celle senza meta → reset
            if (Percorso.Count == 5)
            {
                Reset();
            }
        }

        private void ColoraCella(int r, int c, Brush colore)
        {
            foreach (UIElement child in GridLivello.Children)
            {
                if (child is Rectangle rect &&
                    Grid.GetRow(rect) == r &&
                    Grid.GetColumn(rect) == c)
                {
                    rect.Fill = colore;
                }
            }
        }

        private void ResetGrafica()
        {
            foreach (UIElement child in GridLivello.Children)
            {
                if (child is Rectangle rect)
                {
                    rect.Fill = Brushes.White;
                    rect.Stroke = Brushes.Black;
                    rect.StrokeThickness = 1.5;
                }
            }
        }

        private void EvidenziaPartenza(int r, int c)
        {
            foreach (UIElement child in GridLivello.Children)
            {
                if (child is Rectangle rect &&
                    Grid.GetRow(rect) == r &&
                    Grid.GetColumn(rect) == c)
                {
                    rect.Fill = Brushes.LightSkyBlue;
                    rect.Stroke = Brushes.DarkBlue;
                    rect.StrokeThickness = 3;
                }
            }
        }

        private void EvidenziaMeta(int r, int c)
        {
            foreach (UIElement child in GridLivello.Children)
            {
                if (child is Rectangle rect &&
                    Grid.GetRow(rect) == r &&
                    Grid.GetColumn(rect) == c)
                {
                    rect.Fill = Brushes.LightGreen;
                    rect.Stroke = Brushes.DarkGreen;
                    rect.StrokeThickness = 3;
                }
            }
        }
    }
}




