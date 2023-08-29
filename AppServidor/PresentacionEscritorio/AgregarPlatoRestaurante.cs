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
    public partial class AgregarPlatoRestaurante : Form
    {
        ManejodeDatos datos = new ManejodeDatos();
        public AgregarPlatoRestaurante()
        {
            InitializeComponent();


        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void AgregarPlatoRestaurante_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            numericUpDown1.Text = "";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            try
            {
                ManejodeDatos datos = new ManejodeDatos();


                List<Restaurante> restaurantes = datos.obtenerListaRestaurantes();

                foreach (var restaurante in restaurantes.Where(item => item != null && item.EstadoRestaurante))
                {
                    comboBox1.Items.Add(restaurante.NombreRestaurante);
                }

            } catch (Exception ex)
            {

                label7.Text = "Hubo un error al obtener los Restaurantes";
            }
            

        }

        private void cargarDatos(int id)
        {
            try
            {
                List<Plato> platos = datos.obtenerListaPlatosSinAsignar(id);
                
                dataGridView1.DataSource = null;

                // Limpia las filas del DataGridView
                dataGridView1.Rows.Clear();
                BindingSource datosTabla = new BindingSource();

                if (platos.Count != 0)
                {

                    datosTabla.DataSource = platos.Where(plato => plato != null);

                    dataGridView1.DataSource = datosTabla;

                    dataGridView1.CellFormatting += dataGridView1_CellFormatting;

                    dataGridView2.CellFormatting += dataGridView1_CellFormatting;

                    label7.Text = "";
                } else
                {
                    label7.Text = "Ya ha agregado todos los platos disponibles a este restaurante";
                }
            } catch(Exception ex)
            {
                label7.Text = "Hubo un error al obtener los platos";
            }
        }

        private void cargarDatosSegundaTabla()
        {
            BindingSource datosTabla = new BindingSource();
            datosTabla.DataSource = AdministradorListas.platosAgregar.Where(plato => plato != null);

            dataGridView2.DataSource = datosTabla;
            if (!AdministradorListas.listaVacia(AdministradorListas.platosAgregar))
            {
                dataGridView2.Columns[0].HeaderText = "Nombre";
                dataGridView2.Columns[1].HeaderText = "Precio";

                label11.Text = "Platos seleccionados " + (AdministradorListas.IndicePlatosAgregar);
            }
            else
            {
                dataGridView2.RowHeadersVisible = false;
                dataGridView2.AllowUserToAddRows = false;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;

            if (dataGridView.Rows.Count > 0 && dataGridView.Columns[e.ColumnIndex].Name == "CategoriaPlato" && e.Value != null && e.Value is CategoriaPlato)
            {
                CategoriaPlato categoria = (CategoriaPlato)e.Value;
                e.Value = categoria.NombreCategoria;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Plato> listaPlatos = new List<Plato>();
            try
            {
                ManejodeDatos datos = new ManejodeDatos();

                listaPlatos = datos.obtenerListaPlatos();

            } catch (Exception ex)
            {
                label7.Text = "No se pudo acceder a los datos de los Platos";
            }

            try
            {
                // Obtener las filas seleccionadas de la primera tabla
                DataGridViewSelectedRowCollection filasSeleccionadas = dataGridView1.SelectedRows;
                if (filasSeleccionadas.Count < 10)
                {
                    int espaciosRestantes = 10 - AdministradorListas.IndicePlatosAgregar;

                    if (filasSeleccionadas.Count <= espaciosRestantes)
                    {
                        // Iterar sobre las filas seleccionadas
                        foreach (DataGridViewRow fila in filasSeleccionadas)
                        {
                            int id = Convert.ToInt32(fila.Cells["ID"].Value);
                            AdministradorListas.platosAgregar[AdministradorListas.IndicePlatosAgregar] = listaPlatos.Find(plato => plato != null && plato.Id == id);

                            AdministradorListas.IndicePlatosAgregar += 1;

                            dataGridView1.Rows.Remove(fila);
                        }

                        cargarDatosSegundaTabla();

                    }
                    else
                    {
                        label7.Text = "Solo puede agregar " + espaciosRestantes + " platos más";
                    }

                }
                else
                {
                    label7.Text = "Solo puede seleccionar 10 platos";
                }
            } catch (Exception ex)
            {
                label7.Text = "Hubo un error al agregar los platos";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Restaurante> listaRestaurantes = new List<Restaurante>();
            try
            {
                listaRestaurantes = datos.obtenerListaRestaurantes();

            }
            catch (Exception ex)
            {
                label7.Text = "No se pudo acceder a los datos de los Restaurantes";
            }

            try
            {

                int id = ((int)numericUpDown1.Value);
                DateTime fecha = dateTimePicker1.Value.ToUniversalTime();
                string texto = comboBox1.GetItemText(comboBox1.SelectedItem);



                if (AdministradorVariables.stringValido(texto))
                {
                    Restaurante restauranteSeleccionado = listaRestaurantes.Find(restaurante => restaurante != null && restaurante.NombreRestaurante == texto);


                    if (id != -1)
                    {
                        ManejodeDatos datos = new ManejodeDatos();
                        Tuple<bool, string> idRepetido = datos.comprobarIdRepetido("PlatoRestaurante", id, "IdAsignacion");

                        if (!idRepetido.Item1)
                        {
                            if (!AdministradorListas.listaVacia(AdministradorListas.platosAgregar))
                            {
                                string mensaje = AdministradorRestaurante.agregarPlatoRestaurante(id, fecha, restauranteSeleccionado, AdministradorListas.platosAgregar);
                                label7.Text = mensaje;
                                repetirProceso();
                            }
                            else
                            {
                                label7.Text = "No ha seleccionado ningun plato para asociar.";
                            }
                        }
                        else
                        {
                            label7.Text = idRepetido.Item2;
                        }
                    }
                    else
                    {
                        label7.Text = "Debe digitar un ID valido";
                    }
                }
                else
                {
                    label7.Text = "No puede dejar espacios en blanco";
                }
            } catch
            {
                label7.Text = "Hubo un error al asociar el plato";
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string texto = comboBox1.GetItemText(comboBox1.SelectedItem);
            try
            {
                List<Restaurante> listaRestaurantes = datos.obtenerListaRestaurantes();


                Restaurante restauranteSeleccionado = listaRestaurantes.Find(restaurante => restaurante != null && restaurante.NombreRestaurante == texto);
                label6.Text = "Datos del restaurante";
                label8.Text = "ID: " + restauranteSeleccionado.Id;
                label9.Text = "Nombre: " + restauranteSeleccionado.NombreRestaurante;
                label10.Text = "Telefono: " + restauranteSeleccionado.TelefonoRestaurante;

                dataGridView1.CellFormatting -= dataGridView1_CellFormatting;
                dataGridView2.CellFormatting -= dataGridView1_CellFormatting;

                cargarDatos(restauranteSeleccionado.Id);
            } catch
            {
                label7.Text = "Hubo un error al obtener los datos del restaurante";
            }
        }

        private void repetirProceso()
        {
            DialogResult result = MessageBox.Show("¿Desea asociar mas platos?", "Cerrar aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Acción a realizar si el usuario selecciona "Sí"
                dataGridView1.CellFormatting -= dataGridView1_CellFormatting;
                dataGridView2.CellFormatting -= dataGridView1_CellFormatting;
                dataGridView2.Rows.Clear();
                label11.Text = "Platos Seleccionados";
                AdministradorListas.borrarDatosLita(AdministradorListas.platosAgregar, ref AdministradorListas.IndicePlatosAgregar);
                cargarDatosSegundaTabla();
            }
            else if (result == DialogResult.No)
            {
                // Acción a realizar si el usuario selecciona "No"

                this.Close();

            }
        }

    }
}
