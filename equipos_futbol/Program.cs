using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace equipos_futbol
{
    internal class Program
    {
       static Liga liga = new Liga();
        static void Main(string[] args)
        {
           
            while (true)
            {
                Console.WriteLine(@"
                 >>>Eligue una de las siguientes opciones:
                0: Salir del menu.
                1: Crear un jugador.
                2: Crear un club en la liga.
                3: Asignar un jugador a un club.
                4: Borrar un jugador de un club.
                5: Borrar un club de la liga.
                ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 0: return;
                    case 1:
                        liga.CrearJugador();
                        break;
                    case 2:
                        liga.CrearClubLiga();
                        break;
                    case 3:
                        AsignarJugadorAClub();
                        break;
                    case 4:
                        BorrarJugadorClub();
                        break;
                    case 5:
                        BorrarClubLiga();
                        break;
                    default:
                        Console.WriteLine("Opcion no valida!!");
                        break;
                }


                Console.WriteLine("Press any button to continue");
                Console.ReadKey();
                Console.WriteLine(); //para empezar el menu de nueva linia
            }
        }

        public static void AsignarJugadorAClub()
        {
            Console.WriteLine("Dime el nombre del jugador");
            string nomJugador = Console.ReadLine();
            nomJugador = liga.TratarEntradaString(nomJugador);
            Console.WriteLine("Dime el nombre del club");
            string nomClub = Console.ReadLine();
            nomClub = liga.TratarEntradaString(nomClub);
            Console.WriteLine("Dime el numero de la camiseta que se le asignará al jugador en el club");
            string numCamiseta = Console.ReadLine();
            numCamiseta = liga.TratarEntradaString(numCamiseta);

            liga.AgregarJugadorClub(nomJugador, nomClub, numCamiseta);
        }

        public static void BorrarJugadorClub()
        {
            Console.WriteLine("Dime el nombre del jugador");
            string nomJugador = Console.ReadLine();
            nomJugador = liga.TratarEntradaString(nomJugador);
            Console.WriteLine("Dime el nombre del club");
            string nomClub = Console.ReadLine();
            nomClub = liga.TratarEntradaString(nomClub);

            liga.BorrarJugadorClub(nomJugador, nomClub);
        }

        public static void BorrarClubLiga()
        {
            Console.WriteLine("Dime el nombre del club");
            string nomClub = Console.ReadLine();
            nomClub = liga.TratarEntradaString(nomClub);

            liga.BorrarClub(nomClub);
        }
    }
}
