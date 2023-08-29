using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocios
{
    public class AdministradorPedidos
    {

        public static bool agregarPedido(int idPedido, string idCliente, int idPlato, DateTime fecha)
        {

            Pedido nuevoPedido = new Pedido(idPedido, idCliente, idPlato, fecha);

            AgregarDatos datos = new AgregarDatos();

            bool respuesta = datos.guardarPedido(nuevoPedido);

            return respuesta;
        }

        public static bool agregarPedidoExtra(int idPedido, int idPlato, int idExtra)
        {

            ExtraPedido nuevoPedidoExtra = new ExtraPedido(idPedido, idPlato, idExtra);

            AgregarDatos datos = new AgregarDatos();

            bool respuesta = datos.guardarPedidoExtra(nuevoPedidoExtra);

            return respuesta;
        }

    }
}
