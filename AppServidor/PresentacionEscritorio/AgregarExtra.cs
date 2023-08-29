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
    public partial class AgregarExtra : Form
    {
        List<CategoriaPlato> categorias = new List<CategoriaPlato>();
        public AgregarExtra()
        {
            InitializeComponent();




            ManejodeDatos datos = new ManejodeDatos();

            categorias = datos.obtenerListaCategorias();

            try
            {
                foreach (var categoria in categorias)
                {
                    comboBox2.Items.Add(categoria.NombreCategoria);
                }
            } catch (Exception ex) {
                label7.Text = "Hubo un error al obtener las categorias, Reinicie la aplicacion.";
            }

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            numericUpDown1.Text = "";
            numericUpDown2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                int id = ((int)numericUpDown1.Value);
                string descripcion = textBox1.Text;
                int precio = ((int)numericUpDown2.Value);
                string textoEstado = comboBox1.GetItemText(comboBox1.SelectedItem);
                string textoCategoria = comboBox2.GetItemText(comboBox2.SelectedItem);
                bool estado = textoEstado.Equals("Activo");


                if (id != -1 && precio != -1)
                {
                    if (AdministradorVariables.stringValido(descripcion) && AdministradorVariables.stringValido(textoEstado) && AdministradorVariables.stringValido(textoCategoria))
                    {
                        ManejodeDatos datos = new ManejodeDatos();
                        Tuple<bool, string> idRepetido = datos.comprobarIdRepetido("Extra", id, "IdExtra");

                        if (!idRepetido.Item1)
                        {
                            CategoriaPlato categoria = categorias.Find(categoria => categoria != null && categoria.NombreCategoria.Equals(textoCategoria));

                            string mensaje = AdministrarExtras.agregarExtra(id, descripcion, categoria, estado, precio);

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
            } catch
            {
                label7.Text = "Hubo un error al ingresar el Extra";
            }

        }

        private void AgregarExtra_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
