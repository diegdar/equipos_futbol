﻿using System;
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

        private string TratarEntradaString(string input)
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


    }
}