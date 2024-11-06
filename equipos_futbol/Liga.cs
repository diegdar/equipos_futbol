using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equipos_futbol
{
    internal class Liga
    {
        List<Jugador> listaJugadores = new List<Jugador>();
        List<Club> listaClubes = new List<Club>();

        public void AgregarClub(Club club)
        {
            if (!listaClubes.Contains(club))
                listaClubes.Add(club);
            else
                Console.WriteLine($"No se puede agregar el club {club.Nombre} pues ya existe en la BBDD.");
        }

        public string TratarEntradaString(string input)
        {//Convierte la primera letra a mayusculas y el resto lo deja en minusculas, ademas de quitar espacios del principio y final
            input = input.Trim();
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }

        public Club BuscarClub(string nombreClub)
        {
            nombreClub = TratarEntradaString(nombreClub);  
            Club clubEncontrado = listaClubes.FirstOrDefault(c => c.Nombre == nombreClub);

            if (clubEncontrado == null)
                return null;
            else 
                return clubEncontrado;
        }


        public void AgregarJugador(Jugador jugador)
        {
            if (!listaJugadores.Contains(jugador))
                listaJugadores.Add(jugador);
            else
                Console.WriteLine($"No se puede agregar el Jugador {jugador.Nombre} pues ya existe en la BBDD.");
        }

        public Jugador BuscarJugador(string nombreJugador)
        {
            nombreJugador = TratarEntradaString(nombreJugador);
            Jugador jugadorEncontrado = listaJugadores.FirstOrDefault(c => c.Nombre == nombreJugador);

            if (jugadorEncontrado == null)
                return null;
            else
                return jugadorEncontrado;
        }

        public void CambioAsignacion(string nombreJugador)
        {
            nombreJugador = TratarEntradaString(nombreJugador);
            foreach(var jugador in listaJugadores)
            {
                if(jugador.Nombre==nombreJugador)
                {
                    jugador.Asignacion = true;
                }
            }
        }
        public void AgregarJugadorClub(string nombreJugador, string nombreClub)
        {
            // Buscar jugador y club
            Jugador jugador = BuscarJugador(nombreJugador);
            Club club = BuscarClub(nombreClub);

            if (jugador != null && club != null)
            {
                club.jugadores.Add(jugador);
            }
        }
        public void BorrarJugadorClub(string nombreJugador, string nombreClub)
        {
            // Buscar jugador y club
            Jugador jugador = BuscarJugador(nombreJugador);
            Club club = BuscarClub(nombreClub);

            if (jugador != null && club != null)
            {
                club.jugadores.Remove(jugador);
            }
        }
        public void ReasignarJugadorClub(string nombreJugador)
        {
            // Buscar jugador
            Jugador jugador = BuscarJugador(nombreJugador);

            if (jugador != null)
                jugador.Asignacion = true;
        }

        public void BorrarClub(string nombreClub)
        {
            // Buscar Club
            foreach (Club club in listaClubes)
            {
                if (club.Nombre == nombreClub)
                {
                    listaClubes.Remove(club);
                    return;
                }
            }
        }
    }
}
