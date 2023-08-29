using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Entidades
{
    internal class ClienteTCP
    {

        private static IPAddress servidorIp;
        private static TcpClient cliente;
        private static IPEndPoint serverEndPoint;
        private static StreamWriter clienteStreamWriter;
        private static StreamReader clienteStreamReader;

        public static bool Conectar(string clienteId)
        {
            try
            {
                servidorIp = IPAddress.Parse("127.0.0.1");
                cliente = new TcpClient();
                serverEndPoint = new IPEndPoint(servidorIp, 30000);
                cliente.Connect(serverEndPoint);
                MsgSocket<string> mensajeConectar = new MsgSocket<string> { Metodo = "Conectar", Entidad = clienteId };

                clienteStreamReader = new StreamReader(cliente.GetStream());
                clienteStreamWriter = new StreamWriter(cliente.GetStream());
                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeConectar));
                clienteStreamWriter.Flush();


            }
            catch (SocketException)
            {

                return false;
            }

            return true;
        }

        public static void Desconectar(string idCliente)
        {
            MsgSocket<string> mensajeDesconectar = new MsgSocket<string> { Metodo = "Desconectar", Entidad = idCliente };

            clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeDesconectar));
            clienteStreamWriter.Flush();
            //Se cierra la conexión del cliente
            cliente.Close();

        }

        public static Clientes ObtenerClientePorId(string id)
        {
            Clientes cliente = null;

            try
            {
                MsgSocket<string> mensajeObtenerCliente = new MsgSocket<string> { Metodo = "ObtenerClienteId" , Entidad = id};

                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeObtenerCliente));
                clienteStreamWriter.Flush();

                var mensaje = clienteStreamReader.ReadLine();
                cliente = JsonConvert.DeserializeObject<Clientes>(mensaje);

                return cliente;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public static List<Restaurante> ObtenerRestaurantes()
        {
            List<Restaurante> listaRestaurantes = new List<Restaurante>();

            try
            {
                MsgSocket<string> mensajeObtenerRestaurantes = new MsgSocket<string> { Metodo = "ObtenerRestaurantes" };

                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeObtenerRestaurantes));
                clienteStreamWriter.Flush();

                var mensaje = clienteStreamReader.ReadLine();
                listaRestaurantes = JsonConvert.DeserializeObject<List<Restaurante>>(mensaje);

                return listaRestaurantes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Plato> ObtenerPlatosPorId(int id)
        {
            List<Plato> listaPlatos = new List<Plato>();

            try
            {
                MsgSocket<int> mensajeObtenerRestaurantes = new MsgSocket<int> { Metodo = "ObtenerPlatosPorRestaurante" , Entidad = id};

                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeObtenerRestaurantes));
                clienteStreamWriter.Flush();

                var mensaje = clienteStreamReader.ReadLine();
                listaPlatos = JsonConvert.DeserializeObject<List<Plato>>(mensaje);

                return listaPlatos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Extras> ObtenerExtrasPorId(int id)
        {
            List<Extras> listaExtras = new List<Extras>();

            try
            {
                MsgSocket<int> mensajeObtenerExtras = new MsgSocket<int> { Metodo = "ObtenerExtrasPorCategoria", Entidad = id };

                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeObtenerExtras));
                clienteStreamWriter.Flush();

                var mensaje = clienteStreamReader.ReadLine();
                listaExtras = JsonConvert.DeserializeObject<List<Extras>>(mensaje);

                return listaExtras;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool AgregarPedido(Pedido nuevoPedido)
        {
            try
            {
                MsgSocket<Pedido> mensajePedido = new MsgSocket<Pedido> { Metodo = "AgregarPedido", Entidad = nuevoPedido };
                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajePedido));
                clienteStreamWriter.Flush();
                return true;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public static bool AgregarPedidoExtra(ExtraPedido nuevoPedidoExtra)
        {
            try
            {
                MsgSocket<ExtraPedido> mensajePedidoExtra = new MsgSocket<ExtraPedido> { Metodo = "AgregarExtraPedido", Entidad = nuevoPedidoExtra };
                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajePedidoExtra));
                clienteStreamWriter.Flush();
                return true;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public static List<Tuple<Pedido, List<Extras>>> ObtenerPedidos(string id)
        {
            List<Tuple<Pedido, List<Extras>>> listaPedidos = new List<Tuple<Pedido, List<Extras>>>();

            try
            {
                MsgSocket<string> mensajeObtenerPedidos = new MsgSocket<string> { Metodo = "ObtenerPedidos", Entidad = id };

                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajeObtenerPedidos));
                clienteStreamWriter.Flush();

                var mensaje = clienteStreamReader.ReadLine();
                listaPedidos = JsonConvert.DeserializeObject<List<Tuple<Pedido, List<Extras>>>>(mensaje);

                return listaPedidos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Plato> ObtenerPlatos()
        {
            List<Plato> listaPlatos = new List<Plato>();

            try
            {
                MsgSocket<string> mensajePlatos = new MsgSocket<string> { Metodo = "ObtenerPlatos"};

                clienteStreamWriter.WriteLine(JsonConvert.SerializeObject(mensajePlatos));
                clienteStreamWriter.Flush();

                var mensaje = clienteStreamReader.ReadLine();
                listaPlatos = JsonConvert.DeserializeObject<List<Plato>>(mensaje);

                return listaPlatos;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
