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
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(@"
                 >>>Eligue una de las siguientes opciones:
                0: Salir del menu.
                1: Crear un jugador.
                2: Crear un club.
                3: Agregar un jugador a un club.
                4: Agregar un club a la liga.
                5: Buscar un jugador.
                ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 0: return;
                    case 1:
                        CrearJugador();
                        break;
                    case 2:
                        CrearClub();
                        break;
                    case 3:
                        AgregarJugadorAClub();
                        break;
                    case 4:
                        AgregarClubALiga();
                        break;
                    case 5:
                        BuscarJugador();
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

        private static string TratarEntradaString(string input)
        {//Convierte la primera letra a mayusculas y el resto lo deja en minusculas, ademas de quitar espacios del principio y final
            input = input.Trim();
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }


        static public void CrearJugador()
        {
            Console.WriteLine("Dime el nombre del jugador");
            string nombre = Console.ReadLine();
            nombre = TratarEntradaString(nombre);
            Console.WriteLine("Dime el numero de la camiseta del jugador");
            string numero = Console.ReadLine();
            numero = TratarEntradaString(numero);

            Jugador jugador = new Jugador(nombre, numero);

            Console.WriteLine("El jugador se ha creado correctamente");
        }
    }
}
