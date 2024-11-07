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
            jugadores=new List<Jugador>();
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

        public void MostrarJuadoresPorClub()
        {
            Console.Clear();
            Console.WriteLine($"\nPacientes asignados al club. {Nombre}:");
            if (jugadores.Count == 0)
            {
                Console.WriteLine("No hay jugadores asignados.");
            }
            else
            {
                string coluNom = "Nombre";
                string coluCam = "Camiseta";
                Console.WriteLine($"{coluNom}\t{coluCam,10}");
                Console.WriteLine("-----------------------------------------");
                foreach (var jugador in jugadores)
                {
                    Console.WriteLine($"{jugador.Nombre}\t{jugador.Numero,10}");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Presione una Enter para continuar");
            Console.ReadLine();
        }
        
    }
}
