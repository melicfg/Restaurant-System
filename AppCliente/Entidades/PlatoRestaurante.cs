using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PlatoRestaurante: Idble<int>
    {

        public PlatoRestaurante(int id, DateTime fecha, Restaurante restaurante, Plato[] listaPlatos) : base(id)
        {
            fechaAsignacion = fecha;
            restaurantePlato = restaurante;
            platos = listaPlatos;
        }


        private DateTime fechaAsignacion;
        public DateTime FechaAsignacion { get => fechaAsignacion; set => fechaAsignacion = value; }
        private Restaurante restaurantePlato;
        public Restaurante RestaurantePlato { get => restaurantePlato; set => restaurantePlato = value; }
        private Plato[] platos;
        public Plato[] Platos { get => platos; set => platos = value; }

    }
}
