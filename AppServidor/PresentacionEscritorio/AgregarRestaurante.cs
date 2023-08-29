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
    public partial class AgregarRestaurante : Form
    {
        public AgregarRestaurante()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AgregarRestaurante_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            numericUpDown1.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = ((int)numericUpDown1.Value);
            string nombre = textBox1.Text;
            string direccion = textBox2.Text;
            string telefono = textBox3.Text;
            string[] telefonoModificado = AdministradorVariables.ingresoStringNumeral(telefono, 8, "telefono");
            string texto = comboBox1.GetItemText(comboBox1.SelectedItem);
            bool estado = texto == "Activo";


            try
            {

                if (AdministradorVariables.stringValido(nombre) && AdministradorVariables.stringValido(direccion) && AdministradorVariables.stringValido(telefono) && AdministradorVariables.stringValido(texto))
                {
                    if (id != -1)
                    {

                        if (string.IsNullOrEmpty(telefonoModificado[0]))
                        {
                            ManejodeDatos datos = new ManejodeDatos();
                            Tuple<bool, string> idRepetido = datos.comprobarIdRepetido("Restaurante", id, "IdRestaurante");

                            if (!idRepetido.Item1)
                            {
                                string mensaje = AdministradorRestaurante.agregarRestaurante(id, nombre, direccion, estado, telefono);
                                label7.Text = mensaje;
                            }
                            else
                            {
                                label7.Text = idRepetido.Item2;
                            }

                        }
                        else
                        {
                            label7.Text = telefonoModificado[0];
                        }
                    }
                    else
                    {
                        label7.Text = "Debe ingresar un id mayor o igual a 0";
                    }

                }
                else
                {
                    label7.Text = "No puede dejar espacios en blanco";
                }

            }
            catch (Exception ex) {
                label7.Text = "Ocurrió un error al registrar el restaurante: " + ex;
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
