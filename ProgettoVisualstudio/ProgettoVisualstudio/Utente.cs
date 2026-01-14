using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoVisualstudio
{
    public class Utente
    {
        public string Username { get; set; }
        public float TempoGioco { get; set; }

        public Utente(string username, float tempoGioco)
        {
            this.Username = username;
            this.TempoGioco = tempoGioco;   
        }
    }
}
