using AccesoDatos;
using LogicaDeNegocios;

namespace PresentacionEscritorio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            //AdministradorListas.crearDatosRandom();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!AdministradorListas.listaLlena(AdministradorListas.restaurantesLista))
            {
                AgregarRestaurante agregarRestaurante = new AgregarRestaurante();
                agregarRestaurante.ShowDialog();
            }
            else
            {
                label2.Text = "Ha alcanzado el maximo de restaurantes registrados";
            }
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            ManejodeDatos datos = new ManejodeDatos();

            Tuple<bool, string> listaVacia = datos.comprobarListaVacia("CategoriaPlato");

            if (!AdministradorListas.listaLlena(AdministradorListas.platosLista))
            {

                if (!listaVacia.Item1)
                {
                    AgregarPlato agregarPlato = new AgregarPlato();
                    agregarPlato.ShowDialog();
                }
                else
                {
                    label2.Text = "Error: Debe ingresar alguna categoria primero";
                    await Task.Delay(4000);
                    label2.Text = "";
                }
            }
            else
            {
                label2.Text = "Ha alcanzado el maximo de platos registrados";
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!AdministradorListas.listaLlena(AdministradorListas.categoriasLista))
            {
                AgregarCategoria agregarCategoria = new AgregarCategoria();
                agregarCategoria.ShowDialog();
            }
            else
            {
                label2.Text = "Ha alcanzado el maximo de categorias registrados";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!AdministradorListas.listaLlena(AdministradorListas.clientesLista))
            {
                AgregarCliente agregarCliente = new AgregarCliente();
                agregarCliente.ShowDialog();
            }
            else
            {
                label2.Text = "Ha alcanzado el maximo de Clientes registrados";
            }
        }

        private async void button5_ClickAsync(object sender, EventArgs e)
        {
            ManejodeDatos datos = new ManejodeDatos();

            Tuple<bool, string> listaVacia = datos.comprobarListaVacia("CategoriaPlato");

            if (AdministradorListas.listaLlena(AdministradorListas.extrasListas))
            {
                label2.Text = "Error: Ya ha ingresado el maximo de Extras";
                await Task.Delay(3000);
                label2.Text = "";

            }
            else
            {
                if (!listaVacia.Item1)
                {
                    AgregarExtra agregarExtra = new AgregarExtra();
                    agregarExtra.ShowDialog();
                }
                else
                {
                    label2.Text = "Error: Debe ingresar alguna categoria primero";
                    await Task.Delay(3000);
                    label2.Text = "";
                }

            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            ManejodeDatos datos = new ManejodeDatos();
            if (!AdministradorListas.listaLlena(AdministradorListas.platoRestaurantesLista))
            {
                Tuple<bool, string> listaVacia = datos.comprobarListaVacia("Plato");

                if (!listaVacia.Item1)
                {
                    Tuple<bool, string> listaVacia2 = datos.comprobarListaVacia("Restaurante");
                    if (!listaVacia2.Item1)
                    {
                        AgregarPlatoRestaurante agregarPlatosRestaurante = new AgregarPlatoRestaurante();
                        agregarPlatosRestaurante.ShowDialog();
                        AdministradorListas.borrarDatosLita(AdministradorListas.platosAgregar, ref AdministradorListas.IndicePlatosAgregar);
                    }
                    else
                    {
                        label2.Text = "Error: No hay restaurantes registrados";
                        await Task.Delay(2000);
                        label2.Text = "";
                    }

                }
                else
                {
                    label2.Text = "Error: No hay platos registrados";
                    await Task.Delay(2000);
                    label2.Text = "";
                }
            }
            else
            {
                label2.Text = "Ha alcanzado el maximo de asignaciones";
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            MostrarDatos mostrarDatos = new MostrarDatos();
            mostrarDatos.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ConexionBD conexion = new ConexionBD();
            conexion.Show();
        }
    }
}