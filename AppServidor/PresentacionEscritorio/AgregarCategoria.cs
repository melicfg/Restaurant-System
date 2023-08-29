using AccesoDatos;
using Entidades;
using LogicaDeNegocios;
using System;
using System.Collections;
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
    public partial class AgregarCategoria : Form
    {
        public AgregarCategoria()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((int)numericUpDown1.Value);
                string nombre = textBox1.Text;
                string texto = comboBox1.GetItemText(comboBox1.SelectedItem);
                bool estado = texto == "Activo";

                if (id != -1)
                {
                    if (AdministradorVariables.stringValido(nombre) && AdministradorVariables.stringValido(texto))
                    {

                        ManejodeDatos datos = new ManejodeDatos();
                        Tuple<bool, string> idRepetido = datos.comprobarIdRepetido("CategoriaPlato", id, "IdCategoria");

                        if (!idRepetido.Item1)
                        {
                            string mensaje = AdministradorCategorias.agregarCategoria(id, nombre, estado);
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
                    label7.Text = "Debe seleccionar un ID valido";
                }
            } catch (Exception ex)
            {
                label7.Text = "Hubo un error al agregar la categoría.";
            }


        }

        private void AgregarCategoria_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            numericUpDown1.Text = "";
        }
    }
}
