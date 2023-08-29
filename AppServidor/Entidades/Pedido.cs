using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedido
    {

        public Pedido(int idPedido, string idCliente, int idPlato, DateTime fechaPedido)
        {

            IdPedido = idPedido;
            IdCliente = idCliente;
            IdPlato = idPlato;
            FechaPedido = fechaPedido;

        }


        private int idPedido;
        public int IdPedido { get => idPedido; set => idPedido = value; }

        private string idCliente;
        public string IdCliente { get => idCliente; set => idCliente = value; }

        private int idPlato;
        public int IdPlato { get => idPlato; set => idPlato = value; }

        private DateTime fechaPedido;
        public DateTime FechaPedido { get => fechaPedido; set => fechaPedido = value; }

    }
}

