using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Restaurante : Idble<int>
    {

        public Restaurante(int id, string nombre, string direccion, bool estado, string telefono) : base(id)
        {
            nombreRestaurante = nombre;
            direccionRestaurante = direccion;
            estadoRestaurante = estado;
            telefonoRestaurante = telefono;
        }

        private string nombreRestaurante;
        public string NombreRestaurante { get => nombreRestaurante; set => nombreRestaurante = value; }


        private string direccionRestaurante;
        public string DireccionRestaurante { get => direccionRestaurante; set => direccionRestaurante = value; }


        private bool estadoRestaurante;
        public bool EstadoRestaurante { get => estadoRestaurante; set => estadoRestaurante = value; }

        private string telefonoRestaurante;
        public string TelefonoRestaurante { get => telefonoRestaurante; set => telefonoRestaurante = value; }

    }
}
