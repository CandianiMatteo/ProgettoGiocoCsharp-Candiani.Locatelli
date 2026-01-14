using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoVisualstudio
{
        // Classe che rappresenta una cella della griglia (riga, colonna)
        public class Cella
        {
            // Riga della cella
            public int R { get; set; }

            // Colonna della cella
            public int C { get; set; }

            // Costruttore: crea una cella con riga e colonna
            public Cella(int r, int c)
            {
                R = r;
                C = c;
            }

            // Serve per confrontare due celle.
            public override bool Equals(object obj)
            {
                // Controllo che l'oggetto sia una Cella
                if (obj is Cella altra)
                {
                    // Confronto riga e colonna
                    return this.R == altra.R && this.C == altra.C;
                }

                return false;
            }

            // Serve per far funzionare correttamente:
            // - Contains()
            // - Liste
            // - Confronti tra oggetti
            //
            // Se due celle sono uguali, devono avere lo stesso hash.
            public override int GetHashCode()
            {
                // Combino gli hash di R e C
                return R.GetHashCode() ^ C.GetHashCode();
            }
        }
}
