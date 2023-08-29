using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfaceCliente
{
    public partial class MostrarPedidos : Form
    {
        List<Tuple<Pedido, List<Extras>>> listaDatos = new List<Tuple<Pedido, List<Extras>>>();
        List<Plato> platos = new List<Plato>();
        public MostrarPedidos()
        {
            InitializeComponent();

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

            try
            {
                platos = ClienteTCP.ObtenerPlatos();
            }
            catch (Exception ex)
            {
                label3.Text = "No se pudo recuperar los platos";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listaDatos = ClienteTCP.ObtenerPedidos(IdentificarCliente.getIdCliente());


                if (listaDatos.Count > 0)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.Columns.Clear();

                    dataGridView1.Columns.Add("Id", "Id");

                    dataGridView1.Columns.Add("Fecha Pedido", "Fecha Pedido");
                    dataGridView1.Columns.Add("Costo", "Costo");

                    foreach (Tuple<Pedido, List<Extras>> dato in listaDatos.Where(elemento => elemento != null))
                    {
                        Plato plato = platos.Find(pl => pl.Id == dato.Item1.IdPlato);
                        int precio = plato.PrecioPlato;

                        foreach (Extras extra in dato.Item2)
                        {
                            precio += extra.PrecioExtra;
                        }
                        // Agregar una fila para cada platoRestaurante de plato y restaurante
                        int rowIndex = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[rowIndex];

                        // Configurar los valores de las celdas en la fila
                        row.Cells["Id"].Value = dato.Item1.IdPedido;
                        row.Cells["Fecha Pedido"].Value = dato.Item1.FechaPedido.ToString("dd/MM/yyyy");
                        row.Cells["Costo"].Value = precio;




                    }


                }

            }
            catch (Exception ex)
            {
                label3.Text = "Error: " + ex.Message;
            }
        }

        private void MostrarPedidos_Load(object sender, EventArgs e)
        {

        }
    }
}
