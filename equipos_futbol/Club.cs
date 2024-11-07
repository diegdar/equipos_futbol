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


        public Club(string nombre)
        {
            Nombre = nombre;
        }

        public void AgregarJugador(Jugador jugador)
        {
            if (jugadores.Contains(jugador))
                Console.WriteLine($"El club {this.Nombre} ya tenia al jugador {jugador.Nombre}.");
            else
            {
                jugadores.Add(jugador);
                jugador.Asignacion = true;
            }
        }
    }
}
