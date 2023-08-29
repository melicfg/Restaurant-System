using AccesoDatos;
using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionEscritorio
{
    public partial class ConexionBD : Form
    {
        TcpListener escuchadorTcp;
        Thread subprocesoEscuchaClientes;
        bool servidorCorriendo = true;
        AgregarDatos datos = new AgregarDatos();
        ManejodeDatos manejoDatos = new ManejodeDatos();
        EscribirHistorial modificarTexto;
        ModificarLista modificarLista;
        Thread subprocesoParaEscuchar;

        private delegate void EscribirHistorial(string texto);
        private delegate void ModificarLista(string texto, bool agregar);
        public ConexionBD()
        {
            InitializeComponent();
            modificarTexto = new EscribirHistorial(escribirHistorial);
            modificarLista = new ModificarLista(ModificarListBox);
            button2.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress local = IPAddress.Parse("127.0.0.1");

            escuchadorTcp = new TcpListener(local, 30000);
            servidorCorriendo = true;

            subprocesoEscuchaClientes = new Thread(new ThreadStart(EscucharClientes));
            subprocesoEscuchaClientes.Start();
            subprocesoEscuchaClientes.IsBackground = true;

            label3.Text = "Escuchando clientes... en (127.0.0.1, 30000)";
            label3.ForeColor = Color.Green;
            button1.Enabled = false;
            button2.Enabled = true;

            textBox1.Text = "Servidor iniciado... en (127.0.0.1, 30000)";
            textBox1.AppendText(Environment.NewLine);


        }

        private void EscucharClientes()
        {
            escuchadorTcp.Start();
            try
            {
                while (servidorCorriendo)
                {
                    //Espera a que se conecte un cliente
                    TcpClient client = escuchadorTcp.AcceptTcpClient();
                    // creacion de hilo para comunicarse con los clientes que se conectan
                    Thread clientThread = new Thread(new ParameterizedThreadStart(ComunicacionCliente));
                    clientThread.Start(client);
                }
            }
            catch (SocketException)
            {
                return;
            }
            catch (Exception)
            {
                return;
            }

        }

        private void ComunicacionCliente(object cliente)
        {
            TcpClient clienteTCP = (TcpClient)cliente;
            StreamReader lector = new StreamReader(clienteTCP.GetStream());
            StreamWriter servidorStreamWriter = new StreamWriter(clienteTCP.GetStream());

            while (servidorCorriendo)
            {

                try
                {
                    //espera un mensaje del cliente
                    var mensaje = lector.ReadLine();

                    MsgSocket<object> mensajeRecibido = JsonConvert.DeserializeObject<MsgSocket<object>>(mensaje);//Se deserializa el objeto recibido mediante json
                    metodoSeleccionado(mensajeRecibido.Metodo, mensaje, ref servidorStreamWriter);
                }
                catch (Exception e)
                {
                    //Ocurrió un error en el socket 
                    break;
                }
            }



            clienteTCP.Close();
        }


        public void metodoSeleccionado(string metodo, string mensaje, ref StreamWriter servidorStreamWriter)
        {

            switch (metodo)
            {
                case "Conectar":
                    MsgSocket<string> mensajeConectar = JsonConvert.DeserializeObject<MsgSocket<string>>(mensaje);// Se deserializa el objeto recibido mediante json
                    Conectar(mensajeConectar.Entidad);
                    break;
                case "AgregarRestaurante":
                    MsgSocket<Restaurante> mensajeRestaurante = JsonConvert.DeserializeObject<MsgSocket<Restaurante>>(mensaje);// Se deserializa el objeto recibido mediante json
                    AgregarRestaurante(mensajeRestaurante.Entidad);
                    break;
                case "AgregarPlato":
                    MsgSocket<Plato> mensajePlato = JsonConvert.DeserializeObject<MsgSocket<Plato>>(mensaje);//Se deserializa el objeto recibido mediante json
                    AgregarPlato(mensajePlato.Entidad);
                    break;
                case "AgregarCategoria":
                    MsgSocket<CategoriaPlato> mensajeCategoria = JsonConvert.DeserializeObject<MsgSocket<CategoriaPlato>>(mensaje);//Se deserializa el objeto recibido mediante json
                    AgregarCategoria(mensajeCategoria.Entidad);
                    break;
                case "AgregarPedido":
                    MsgSocket<Pedido> mensajePedido = JsonConvert.DeserializeObject<MsgSocket<Pedido>>(mensaje);//Se deserializa el objeto recibido mediante json
                    AgregarPedido(mensajePedido.Entidad);
                    break;
                case "AgregarExtraPedido":
                    MsgSocket<ExtraPedido> mensajeExtraPedido = JsonConvert.DeserializeObject<MsgSocket<ExtraPedido>>(mensaje);//Se deserializa el objeto recibido mediante json
                    AgregarExtraPedido(mensajeExtraPedido.Entidad);
                    break;
                case "AgregarCliente":
                    MsgSocket<Clientes> mensajeCliente = JsonConvert.DeserializeObject<MsgSocket<Clientes>>(mensaje);//Se deserializa el objeto recibido mediante json
                    AgregarCliente(mensajeCliente.Entidad);
                    break;
                case "AgregarExtra":
                    MsgSocket<Extras> mensajeExtra = JsonConvert.DeserializeObject<MsgSocket<Extras>>(mensaje);//Se deserializa el objeto recibido mediante json
                    AgregarExtra(mensajeExtra.Entidad);
                    break;
                case "AgregarPlatoRestaurante":
                    MsgSocket<PlatoRestaurante> mensajePlatoRestaurante = JsonConvert.DeserializeObject<MsgSocket<PlatoRestaurante>>(mensaje);//Se deserializa el objeto recibido mediante json
                    AgregarPlatoRestaurante(mensajePlatoRestaurante.Entidad);
                    break;
                case "ObtenerRestaurantes":
                    ObtenerRestaurante(ref servidorStreamWriter);
                    break;
                case "ObtenerPlatosPorRestaurante":
                    MsgSocket<int> mensajeRestauranteId = JsonConvert.DeserializeObject<MsgSocket<int>>(mensaje);//Se deserializa el objeto recibido mediante json

                    ObtenerPlatoPorRestaurante(mensajeRestauranteId.Entidad, ref servidorStreamWriter);
                    break;
                case "ObtenerClienteId":
                    MsgSocket<string> mensajeObtenerCliente = JsonConvert.DeserializeObject<MsgSocket<string>>(mensaje);
                    ObtenerClienteId(mensajeObtenerCliente.Entidad, ref servidorStreamWriter);
                    break;
                case "ObtenerExtrasPorCategoria":
                    MsgSocket<int> mensajeExtras = JsonConvert.DeserializeObject<MsgSocket<int>>(mensaje);
                    ObtenerExtraId(mensajeExtras.Entidad, ref servidorStreamWriter);
                    break;
                case "ObtenerPedidos":
                    MsgSocket<string> mensajePedidos = JsonConvert.DeserializeObject<MsgSocket<string>>(mensaje);
                    ObtenerPedidos(mensajePedidos.Entidad, ref servidorStreamWriter);
                    break;
                case "ObtenerPlatos":
                    ObtenerPlatos(ref servidorStreamWriter);
                    break;
                case "Desconectar":
                    MsgSocket<string> mensajeDesconectar = JsonConvert.DeserializeObject<MsgSocket<string>>(mensaje);//Se deserializa el objeto recibido mediante json
                    Desconectar(mensajeDesconectar.Entidad);
                    break;
                default:
                    break;
            }

        }
        private void Conectar(string idCliente)
        {
            textBox1.Invoke(modificarTexto, new object[] { idCliente + " se ha conectado..." });
            listBox1.Invoke(modificarLista, new object[] { idCliente, true });

        }

        private void Desconectar(string idCliente)
        {
            textBox1.Invoke(modificarTexto, new object[] { idCliente + " se ha desconectado..." });
            listBox1.Invoke(modificarLista, new object[] { idCliente, false });

        }

        private void escribirHistorial(string texto)
        {
            textBox1.AppendText(DateTime.Now.ToString() + " - " + texto);
            textBox1.AppendText(Environment.NewLine);
        }

        private void ModificarListBox(string texto, bool agregar)
        {
            if (agregar)
            {
                listBox1.Items.Add(texto);
            }
            else
            {
                listBox1.Items.Remove(texto);
            }

        }

        private void AgregarRestaurante(Restaurante nuevoRestaurante)
        {
            datos.guardarRestaurante(nuevoRestaurante);
        }

        private void AgregarPlato(Plato nuevoPlato)
        {
            datos.guardarPlato(nuevoPlato);
        }

        private void AgregarCategoria(CategoriaPlato nuevaCategoria)
        {
            datos.guardarCategoria(nuevaCategoria);
        }

        private void AgregarPedido(Pedido nuevoPedido)
        {
            datos.guardarPedido(nuevoPedido);
        }

        private void AgregarCliente(Clientes nuevoCliente)
        {
            datos.guardarCliente(nuevoCliente);
        }

        private void AgregarExtra(Extras nuevaExtra)
        {
            datos.guardarExtra(nuevaExtra);
        }

        private void AgregarExtraPedido(ExtraPedido nuevaExtraPedido)
        {
            datos.guardarPedidoExtra(nuevaExtraPedido);
        }

        private void AgregarPlatoRestaurante(PlatoRestaurante nuevoPlatoRestaurante)
        {
            datos.guardarPlatoRestaurante(nuevoPlatoRestaurante);
        }
        private void ObtenerClienteId(string id, ref StreamWriter servidorStreamWriter)
        {
            Clientes cliente;

            cliente = manejoDatos.ObtenerListaClientesPorId(id);

            servidorStreamWriter.WriteLine(JsonConvert.SerializeObject(cliente));
            servidorStreamWriter.Flush();
        }

        private void ObtenerRestaurante(ref StreamWriter servidorStreamWriter)
        {
            List<Restaurante> listaRestaurante = manejoDatos.obtenerListaRestaurantes();


            servidorStreamWriter.WriteLine(JsonConvert.SerializeObject(listaRestaurante));
            servidorStreamWriter.Flush();
        }

        private void ObtenerPlatos(ref StreamWriter servidorStreamWriter)
        {
            List<Plato> listaPlatos = manejoDatos.obtenerListaPlatos();


            servidorStreamWriter.WriteLine(JsonConvert.SerializeObject(listaPlatos));
            servidorStreamWriter.Flush();
        }

        private void ObtenerPlatoPorRestaurante(int id, ref StreamWriter servidorStreamWriter)
        {
            List<Plato> listaRestaurante = manejoDatos.ObtenerListaPlatosPorRestaurante(id);


            servidorStreamWriter.WriteLine(JsonConvert.SerializeObject(listaRestaurante));
            servidorStreamWriter.Flush();
        }

        private void ObtenerExtraId(int id, ref StreamWriter servidorStreamWriter)
        {
            List<Extras> listaExtras = manejoDatos.ObtenerListaExtrasCategoria(id);


            servidorStreamWriter.WriteLine(JsonConvert.SerializeObject(listaExtras));
            servidorStreamWriter.Flush();
        }

        private void ObtenerPedidos(string id, ref StreamWriter servidorStreamWriter)
        {
            List<Tuple<Pedido, List<Extras>>> listaPedidos = manejoDatos.obtenerListaDePedidos(id);


            servidorStreamWriter.WriteLine(JsonConvert.SerializeObject(listaPedidos));
            servidorStreamWriter.Flush();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            servidorCorriendo = false;
            escuchadorTcp.Stop();

            label3.ForeColor = Color.Red;
            label3.Text = "Sin iniciar";
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ConexionBD_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
