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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PresentacionEscritorio
{
    public partial class AgregarPlato : Form
    {
        List<CategoriaPlato> categorias = new List<CategoriaPlato>();
        public AgregarPlato()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void AgregarPlato_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            numericUpDown1.Text = "";
            numericUpDown2.Text = "";
            ManejodeDatos datos = new ManejodeDatos();
            try
            {

                categorias = datos.obtenerListaCategorias();

                foreach (var categoria in categorias)
                {
                    comboBox1.Items.Add(categoria.NombreCategoria);
                }

                if (categorias.Count == 0)
                {

                    label7.Text = "Hubo un error al obtener las categorias, Reinicie la aplicacion.";
                }
            } catch
            {
                label7.Text = "Hubo un error al obtener las categorias, Reinicie la aplicacion.";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                int id = ((int)numericUpDown1.Value);
                string nombre = textBox1.Text;
                int precio = ((int)numericUpDown2.Value);
                string texto = comboBox1.GetItemText(comboBox1.SelectedItem);


                if (id != -1 && precio != -1)
                {
                    if (AdministradorVariables.stringValido(nombre) && AdministradorVariables.stringValido(texto))
                    {
                        ManejodeDatos datos = new ManejodeDatos();
                        Tuple<bool, string> idRepetido = datos.comprobarIdRepetido("Plato", id, "IdPlato");

                        if (!idRepetido.Item1)
                        {
                            CategoriaPlato categoria = categorias.Find(categoria => categoria != null && categoria.NombreCategoria.Equals(texto));

                            string mensaje = AdministradorPlatos.agregarPlato(id, nombre, precio,categoria);

                            label7.Text = mensaje;
                        }
                        else
                        {
                            label7.Text = idRepetido.Item2;
                        }
                    }
                    else
                    {
                        label7.Text = "No puede dejar espacios en blanco";
                    }
                }
                else
                {
                    label7.Text = "Ingrese un numero valido para el ID y precio";
                }

            } catch (Exception ex) {
                label7.Text = "Hubo un error al ingresar el plato";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
