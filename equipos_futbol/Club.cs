using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equipos_futbol
{
    public class Club
    {
        public string Nombre { get; set; }
        public List<Jugador> jugadores = new List<Jugador>();


        public Club()
        {

        }

        public Club(string nombre, List<Jugador> jugadores)
        {
            Nombre = nombre;
            this.jugadores = jugadores;
        }
    }
}
