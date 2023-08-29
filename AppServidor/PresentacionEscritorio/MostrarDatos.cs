using AccesoDatos;
using Entidades;
using LogicaDeNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionEscritorio
{
    public partial class MostrarDatos : Form
    {
        ManejodeDatos datos = new ManejodeDatos();
        public MostrarDatos()
        {
            InitializeComponent();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();

                dataGridView1.Columns.Add("id", "id");
                dataGridView1.Columns.Add("nombre", "nombre");
                dataGridView1.Columns.Add("direccion", "direccion");
                dataGridView1.Columns.Add("telefono", "telefono");
                dataGridView1.Columns.Add("estado", "estado");


                
                Tuple<bool, string> listaVacia = datos.comprobarListaVacia("Restaurante");

                List<Restaurante> restaurantes = datos.obtenerListaRestaurantes();

                if (!listaVacia.Item1)
                {

                    foreach (Restaurante dato in restaurantes.Where(elemento => elemento != null))
                    {
                        // agregar una fila para cada platorestaurante de plato y restaurante
                        int rowIndex = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[rowIndex];

                        // configurar los valores de las celdas en la fila
                        row.Cells["id"].Value = dato.Id;
                        row.Cells["nombre"].Value = dato.NombreRestaurante;
                        row.Cells["direccion"].Value = dato.DireccionRestaurante;
                        row.Cells["telefono"].Value = dato.TelefonoRestaurante;
                        row.Cells["estado"].Value = dato.EstadoRestaurante ? "activo" : "inactivo";

                    }
                }
                else
                {
                    label2.Text = "ups! no hay platos registrados";
                }
            } catch (Exception ex)
            {
                label2.Text = $"Surgio un error al cargar los datos: {ex.InnerException}";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();

                // Crear las columnas del DataGridView
                dataGridView1.Columns.Add("ID", "ID");
                dataGridView1.Columns.Add("Fecha", "Fecha");
                dataGridView1.Columns.Add("Restaurante", "Restaurante");
                dataGridView1.Columns.Add("Platos", "Platos");

                dataGridView1.Columns["Platos"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


                // Configurar las propiedades de las columnas
                dataGridView1.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                List<PlatoRestaurante> platoRestaurantes = datos.ObtenerListaPlatoRestaurante();

                Tuple<bool, string> listaVacia = datos.comprobarListaVacia("PlatoRestaurante");

                if (!listaVacia.Item1)
                {

                    foreach (PlatoRestaurante dato in platoRestaurantes.Where(elemento => elemento != null))
                    {
                        // Agregar una fila para cada platoRestaurante de plato y restaurante
                        int rowIndex = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[rowIndex];

                        // Configurar los valores de las celdas en la fila
                        row.Cells["ID"].Value = dato.Id;
                        row.Cells["Fecha"].Value = dato.FechaAsignacion.ToString("dd/MM/yyyy");
                        row.Cells["Restaurante"].Value = dato.RestaurantePlato.NombreRestaurante;

                        // Configurar la celda de la columna "Platos" para ocupar múltiples filas
                        DataGridViewCell cell = row.Cells["Platos"];
                        cell.Value = "";
                        cell.Style.WrapMode = DataGridViewTriState.True;
                        cell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

                        //se concatena los valores de los platos para que quepan en una sola celda
                        foreach (Plato plato in dato.Platos.Where(dato => dato != null))
                        {
                            cell.Value += $"id = {plato.Id}\n";
                            cell.Value += $"nombre = {plato.NombrePlato}\n";
                            cell.Value += $"precio = {plato.PrecioPlato}\n\n";
                        }

                    }
                }
                else
                {
                    label2.Text = listaVacia.Item2;
                }
            } catch (Exception ex)
            {
                label2.Text = $"Hubo un error al cargar los datos: {ex.InnerException}";
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();

                dataGridView1.Columns.Add("ID", "ID");
                dataGridView1.Columns.Add("Nombre", "Nombre");
                dataGridView1.Columns.Add("Categoria", "Categoria");
                dataGridView1.Columns.Add("Precio", "Precio");

                List<Plato> platos = datos.obtenerListaPlatos();

                Tuple<bool, string> listaVacia = datos.comprobarListaVacia("Plato");


                if (!listaVacia.Item1)
                {

                    foreach (Plato dato in platos.Where(elemento => elemento != null))
                    {
                        // Agregar una fila para cada platoRestaurante de plato y restaurante
                        int rowIndex = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[rowIndex];

                        // Configurar los valores de las celdas en la fila
                        row.Cells["ID"].Value = dato.Id;
                        row.Cells["Nombre"].Value = dato.NombrePlato;
                        row.Cells["Categoria"].Value = dato.CategoriaPlato.NombreCategoria;
                        row.Cells["Precio"].Value = dato.PrecioPlato;

                    }
                }
                else
                {
                    label2.Text = listaVacia.Item2;
                }
            } catch (Exception ex)
            {
                label2.Text = $"Hubo un error al recuperar los datos: {ex.InnerException}";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();

                dataGridView1.Columns.Add("ID", "ID");
                dataGridView1.Columns.Add("Nombre", "Nombre");
                dataGridView1.Columns.Add("Estado", "Estado");

                List<CategoriaPlato> platos = datos.obtenerListaCategorias();

                Tuple<bool, string> listaVacia = datos.comprobarListaVacia("CategoriaPlato");

                if (!listaVacia.Item1)
                {

                    foreach (CategoriaPlato dato in platos.Where(elemento => elemento != null))
                    {
                        // Agregar una fila para cada platoRestaurante de plato y restaurante
                        int rowIndex = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[rowIndex];

                        // Configurar los valores de las celdas en la fila
                        row.Cells["ID"].Value = dato.Id;
                        row.Cells["Nombre"].Value = dato.NombreCategoria;
                        row.Cells["Estado"].Value = dato.EstadoCategoria ? "Activo" : "Inactivo";

                    }
                }
                else
                {
                    label2.Text = listaVacia.Item2;
                }
            } catch(Exception ex)
            {
                label2.Text = $"Hubo un error obteniendo los datos: {ex.InnerException}";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();

                dataGridView1.Columns.Add("ID", "ID");
                dataGridView1.Columns.Add("Nombre", "Nombre");
                dataGridView1.Columns.Add("Categoria", "Categoria");
                dataGridView1.Columns.Add("Estado", "Estado");
                dataGridView1.Columns.Add("Precio", "Precio");

                List<Extras> extras = datos.ObtenerListaExtras();

                Tuple<bool, string> listaVacia = datos.comprobarListaVacia("Extra");

                if (!listaVacia.Item1)
                {

                    foreach (Extras dato in extras.Where(elemento => elemento != null))
                    {
                        // Agregar una fila para cada platoRestaurante de plato y restaurante
                        int rowIndex = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[rowIndex];

                        // Configurar los valores de las celdas en la fila
                        row.Cells["ID"].Value = dato.Id;
                        row.Cells["Nombre"].Value = dato.DescripcionCategoria;
                        row.Cells["Categoria"].Value = dato.CategoriaExtra.NombreCategoria;
                        row.Cells["Estado"].Value = dato.EstadoExtra ? "Activo" : "Inactivo";
                        row.Cells["Precio"].Value = dato.PrecioExtra;

                    }
                }
                else
                {
                    label2.Text = listaVacia.Item2;
                }
            } catch (Exception ex)
            {
                label2.Text = $"Hubo un error al acceder a los datos: {ex.InnerException}";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();


                dataGridView1.Columns.Add("ID", "ID");
                dataGridView1.Columns.Add("Nombre", "Nombre");
                dataGridView1.Columns.Add("Apellido1", "Apellido 1");
                dataGridView1.Columns.Add("Apellido2", "Apellido 2");
                dataGridView1.Columns.Add("Fecha", "Cumpleaños");
                dataGridView1.Columns.Add("Genero", "Genero");

                List<Clientes> clientes = datos.ObtenerListaClientes();

                Tuple<bool, string> listaVacia = datos.comprobarListaVacia("Cliente");

                if (!listaVacia.Item1)
                {
                    foreach (Clientes dato in clientes.Where(elemento => elemento != null))
                    {
                        // Agregar una fila para cada platoRestaurante de plato y restaurante
                        int rowIndex = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[rowIndex];

                        // Configurar los valores de las celdas en la fila
                        row.Cells["ID"].Value = dato.Id;
                        row.Cells["Nombre"].Value = dato.NombreCliente;
                        row.Cells["Apellido1"].Value = dato.PrimerApellidoCliente;
                        row.Cells["Apellido2"].Value = dato.SegundoApellidoCliente;
                        row.Cells["Fecha"].Value = dato.FechaNacimiento.ToString("dd/MM/yyyy");
                        row.Cells["Genero"].Value = dato.GeneroCliente;

                    }
                }
                else
                {
                    label2.Text = listaVacia.Item2;
                }

            } catch
            {
                label2.Text = "Hubo un error al recuperar los datos";
            }

        }
    }
}
