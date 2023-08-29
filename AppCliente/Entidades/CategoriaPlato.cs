using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CategoriaPlato : Idble<int>
    {

        public CategoriaPlato(int id, string nombre, bool estado) : base(id)
        {
            nombreCategoria = nombre;
            estadoCategoria = estado;
        }

        private string nombreCategoria;
        public string NombreCategoria { get => nombreCategoria; set => nombreCategoria = value; }

        private bool estadoCategoria;
        public bool EstadoCategoria { get => estadoCategoria; set => estadoCategoria = value; }

    }
}
