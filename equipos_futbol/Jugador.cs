using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace equipos_futbol
{
    public class Jugador
    {
        public string Nombre { get; set; }
        public string Numero { get; set; }
        public bool Asignacion { get; set; }


        public Jugador()
        {

        }
        public Jugador(string nombre, string numero, bool asignacion)
        {
            Nombre = nombre;
            Numero = numero;
            Asignacion = false;
        }
    }
}
