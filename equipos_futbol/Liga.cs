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

        private bool EstaElJugadorEnElClub(string nombre)
        {
            return listaJugadores.Any(j => j.Nombre == nombre);
        }

        private void AsignarNumeroAJugador(string nomJugador, string numero)
        {
            Jugador jugador = BuscarJugador(nomJugador);
            bool existeNumero = true;

            if (jugador == null)
            {
                Console.WriteLine($"El jugador {nomJugador} no existe!!");
                return;
            }

            do
            {
                existeNumero = listaJugadores.Any(j => j.Numero == numero);

                if (existeNumero)
                {
                    Console.WriteLine($"El numero {numero} ya esta codigo por otro jugador!!. Debes elegir otro.");
                    Console.WriteLine("Dime un nuevo numero para la camiseta del jugador");
                    numero = Console.ReadLine();
                    numero = TratarEntradaString(numero);
                }
            }
            while (existeNumero);

            jugador.Numero = numero;
        }


        public void CrearJugador()
        {
            Console.WriteLine("Dime el nombre del jugador");
            string nombre = Console.ReadLine();
            nombre = TratarEntradaString(nombre);

            if (!EstaElJugadorEnElClub(nombre))
            {
                Jugador jugador = new Jugador(nombre);
                listaJugadores.Add(jugador);
                Console.WriteLine($"Se ha creado correctamente el jugador {nombre}");
            }
            else
                Console.WriteLine($"No se puede agregar el Jugador {nombre} pues ya existe en la BBDD.");
        }

        public bool ExisteElClub(string nombre)
        {
            return listaClubes.Any(c => c.Nombre == nombre);
        }

        public void CrearClubLiga()
        {
            Console.WriteLine("Dime el nombre del club");
            string nombre = Console.ReadLine();
            nombre = TratarEntradaString(nombre);

            if (!ExisteElClub(nombre))
            {
                Club club = new Club(nombre);
                listaClubes.Add(club);
                Console.WriteLine($"Se ha agregado el club {club.Nombre} correctamente a la liga.");
            }
            else
                Console.WriteLine($"No se puede agregar el club {nombre} pues ya existe en la BBDD.");
        }

        public Jugador BuscarJugador(string nombreJugador)
        {
            nombreJugador = TratarEntradaString(nombreJugador);
            Jugador jugadorEncontrado = listaJugadores.FirstOrDefault(j => j.Nombre == nombreJugador);

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
                if(jugador.Nombre == nombreJugador)
                {
                    jugador.Asignacion = true;
                }
            }
        }
       
        public void AgregarJugadorClub(string nombreJugador, string nombreClub, string numCamiseta)
        {
            // Buscar jugador y club
            Jugador jugador = BuscarJugador(nombreJugador);
            Club club = BuscarClub(nombreClub);

            if (jugador == null)
            {
                Console.WriteLine($"El jugador {nombreJugador} no existe en la BBDD!!");
                return;
            }

            if (club == null)
            {
                Console.WriteLine($"El club {nombreClub} no existe en la BBDD!!");
                return;
            }

            AsignarNumeroAJugador(nombreJugador, numCamiseta);
            club.jugadores.Add(jugador);
            Console.WriteLine($"El jugador {nombreJugador} se asigno correctamente al club {nombreClub}" +
                $" con el numero de camiseta {numCamiseta}");

        }
        
        public void BorrarJugadorClub(string nombreJugador, string nombreClub)
        {
            // Buscar jugador y club
            Jugador jugador = BuscarJugador(nombreJugador);
            Club club = BuscarClub(nombreClub);

            if (jugador == null)
            {
                Console.WriteLine($"El jugador {nombreJugador} no existe en la BBDD!!");
                return;
            }

            if (club == null)
            {
                Console.WriteLine($"El club {nombreClub} no existe en la BBDD!!");
                return;
            }

            club.jugadores.Remove(jugador);
            Console.WriteLine($"El jugador {nombreJugador} se borro correctamente del club {nombreClub}");
        }

        //TODO: al reasignar el jugador no deberia tambien quitar el
        //jugador de un club y ponerlo en otro?
        public void ReasignarJugadorClub(string nombreJugador)
        {
            // Buscar jugador
            Jugador jugador = BuscarJugador(nombreJugador);

            if (jugador != null)
                jugador.Asignacion = true;
        }

        public void BorrarClub(string nombreClub)
        {
            Club club = BuscarClub(nombreClub);

            if (club == null)
            {
                Console.WriteLine($"El club {nombreClub} no existe en la BBDD!!");
                return;
            }

            listaClubes.Remove(club);
            Console.WriteLine($"El club {nombreClub} se ha elimado correctamente de la liga!!");
        }

        public void ListarJudadoresPorClub()
        {
            Console.Clear();
            Console.Write("Ingrese el nombre del club: ");
            string nombreJugador = Console.ReadLine();
            Club club = null;

            foreach (var m in listaClubes)
            {
                if (m.Nombre.ToUpper() == nombreJugador.ToUpper())
                {
                    club = m;
                    break;
                }
            }

            if (club == null)
            {
                Console.WriteLine("Club no encontrado.");
                Console.WriteLine();
                Console.WriteLine("Presione una Enter para continuar");
                Console.ReadLine();
                return;
            }

            club.MostrarJuadoresPorClub();

        }
    }
}
