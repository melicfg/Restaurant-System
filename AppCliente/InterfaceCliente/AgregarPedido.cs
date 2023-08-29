using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace InterfaceCliente
{
    public partial class AgregarPedido : Form
    {
        List<Restaurante> listaRestaurante = new List<Restaurante>();
        List<Plato> listaPlatos = new List<Plato>();
        List<Extras> listaExtras = new List<Extras>();
        Plato platoSeleccionado = null;

        

        int precioTotal = 0;

        List<Tuple<Plato, List<Extras>>> listaPedido = new List<Tuple<Plato, List<Extras>>>();
        public AgregarPedido()
        {
            InitializeComponent();

            listaRestaurante = ClienteTCP.ObtenerRestaurantes();
            comboBox1.Items.Clear();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (Restaurante rest in listaRestaurante.Where(rest => rest.EstadoRestaurante))
            {
                comboBox1.Items.Add(rest.NombreRestaurante);
            }

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;

            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.RowHeadersVisible = false;

            dataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.RowHeadersVisible = false;

            dataGridView3.DataSource = null;
            dataGridView3.Columns.Clear();

            dataGridView3.Columns.Add("Item", "Item");
            dataGridView3.Columns.Add("Precio", "Precio");



            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Agregar enfoque al DataGridView para asegurarse de que esté listo para detectar los clics
            dataGridView1.Focus();

        }

        private void AgregarPedido_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaPedido.Count > 0)
                {
                    Random rand = new Random();
                    int numeroAleatorio = rand.Next(1001);

                    listaPedido.ForEach(
                        dato =>
                        {
                            Pedido nuevoPedido = new Pedido(numeroAleatorio, IdentificarCliente.getIdCliente(), dato.Item1.Id, DateTime.Now);
                            ClienteTCP.AgregarPedido(nuevoPedido);
                            if (dato.Item2 != null)
                            {
                                dato.Item2.ForEach(
                                    extra =>
                                    {
                                        ExtraPedido nuevoExtraPedido = new ExtraPedido(numeroAleatorio, platoSeleccionado.Id, extra.Id);
                                        bool resultado = ClienteTCP.AgregarPedidoExtra(nuevoExtraPedido);
                                        dataGridView3.Rows.Clear();
                                    }
                                    );
                            }
                        }
                    );
                }
            } catch (Exception ex)
            {
                label3.Text = ex.Message;
            }
        }

        private void cargarDatosPedido()
        {
            dataGridView3.DataSource = null;
            dataGridView3.Columns.Clear();

            dataGridView3.Columns.Add("Item", "Item");
            dataGridView3.Columns.Add("Precio", "Precio");

            precioTotal = 0;


            foreach (Tuple<Plato, List<Extras>> datos in listaPedido.Where(elemento => elemento != null))
            {
                // Agregar una fila para cada platoRestaurante de plato y restaurante
                int rowIndex = dataGridView3.Rows.Add();
                DataGridViewRow row = dataGridView3.Rows[rowIndex];

                // Configurar los valores de las celdas en la fila

                int precio = datos.Item1.PrecioPlato;
                row.Cells["Item"].Value = datos.Item1.NombrePlato;
                row.Cells["Precio"].Value = precio;


                precioTotal += precio;
                if (datos.Item2 != null)
                {

                    foreach (Extras extra in datos.Item2)
                    {
                        int rowIndex2 = dataGridView3.Rows.Add();
                        DataGridViewRow row2 = dataGridView3.Rows[rowIndex2];

                        // Configurar los valores de las celdas en la fila
                        row2.Cells["Item"].Value = extra.DescripcionCategoria;
                        row2.Cells["Precio"].Value = extra.PrecioExtra;

                        precioTotal += extra.PrecioExtra;

                    }
                }


                label6.Text = "Precio Total: " + precioTotal.ToString();

            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                string nombre = comboBox1.SelectedItem.ToString();

                Restaurante restaurante = listaRestaurante.Find(rest => rest.NombreRestaurante.Equals(nombre));

                listaPlatos = ClienteTCP.ObtenerPlatosPorId(restaurante.Id);

                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();

                dataGridView1.Columns.Add("ID", "ID");
                dataGridView1.Columns.Add("Nombre", "Nombre");
                dataGridView1.Columns.Add("Categoria", "Categoria");
                dataGridView1.Columns.Add("Precio", "Precio");

                if (listaPlatos.Count > 0)
                {

                    foreach (Plato dato in listaPlatos.Where(elemento => elemento != null))
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
                    label3.Text = "Este restaurante no cuenta con Platos";
                }

            }
            catch (Exception ex)
            {
                label3.Text = ex.Message;
            }
        }

        private void cargarDatosTablaExtras()
        {
            try
            {
                dataGridView2.DataSource = null;
                dataGridView2.Columns.Clear();

                dataGridView2.Columns.Add("ID", "ID");
                dataGridView2.Columns.Add("Nombre", "Nombre");
                dataGridView2.Columns.Add("Categoria", "Categoria");
                dataGridView2.Columns.Add("Estado", "Estado");
                dataGridView2.Columns.Add("Precio", "Precio");

                listaExtras = ClienteTCP.ObtenerExtrasPorId(platoSeleccionado.CategoriaPlato.Id);

                if (listaExtras.Count > 0)
                {

                    foreach (Extras dato in listaExtras.Where(elemento => elemento != null))
                    {
                        // Agregar una fila para cada platoRestaurante de plato y restaurante
                        int rowIndex = dataGridView2.Rows.Add();
                        DataGridViewRow row = dataGridView2.Rows[rowIndex];

                        // Configurar los valores de las celdas en la fila
                        row.Cells["ID"].Value = dato.Id;
                        row.Cells["Nombre"].Value = dato.DescripcionCategoria;
                        row.Cells["Categoria"].Value = dato.CategoriaExtra.NombreCategoria;
                        row.Cells["Estado"].Value = dato.EstadoExtra ? "Activo" : "Inactivo";
                        row.Cells["Precio"].Value = dato.PrecioExtra;

                    }

                    label5.Text = "";
                }
                else
                {
                    label5.Text = "Este plato no contiene extras";
                }
            }
            catch (Exception ex)
            {
                label3.Text = ex.Message;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegúrate de que se hizo clic en una fila válida (no en el encabezado)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];
                // Acceder a los datos seleccionados
                string nombre = filaSeleccionada.Cells["Nombre"].Value.ToString();

                //obtener el plato seleccionado

                platoSeleccionado = listaPlatos.Find(elemento => elemento.NombrePlato.Equals(nombre));

                cargarDatosTablaExtras();

            }
            dataGridView1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                List<Extras> extras = new List<Extras>();
                if (dataGridView1.SelectedRows.Count > 0 && platoSeleccionado != null)
                {
                    // Verificar si hay fila seleccionada
                    if (dataGridView2.SelectedRows.Count > 0)
                    {
                        //almacenar las filas seleccionadas
                        List<DataGridViewRow> filasSeleccionadas = new List<DataGridViewRow>();

                        // Iterar sobre las filas seleccionadas y agregarlas a la lista
                        foreach (DataGridViewRow fila in dataGridView2.SelectedRows)
                        {
                            string nombre = fila.Cells["Nombre"].Value.ToString();
                            Extras extra = listaExtras.Find(elemento => elemento.DescripcionCategoria.Equals(nombre));
                            extras.Add(extra);
                        }

                    }
                    else
                    {
                        extras = null;
                    }

                    Tuple<Plato, List<Extras>> pedido = new Tuple<Plato, List<Extras>>(platoSeleccionado, extras);

                    listaPedido.Add(pedido);

                    cargarDatosPedido();
                }
                else
                {
                    label6.Text = "No ha seleccionado ningun plato";
                }



            } catch (Exception ex)
            {
                label6.Text = ex.Message;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
