using AccesoDatos;
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
    public partial class AgregarCliente : Form
    {
        public AgregarCliente()
        {
            InitializeComponent();
        }

        private void AgregarCliente_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string id = textBox4.Text;
                string nombre = textBox1.Text;
                string apellido1 = textBox2.Text;
                string apellido2 = textBox3.Text;
                DateTime fecha = dateTimePicker1.Value.ToUniversalTime();
                string texto = comboBox1.GetItemText(comboBox1.SelectedItem);

                if (AdministradorVariables.stringValido(id) && AdministradorVariables.stringValido(nombre) && AdministradorVariables.stringValido(apellido1) && AdministradorVariables.stringValido(apellido2) && AdministradorVariables.stringValido(texto))
                {
                    string[] idModificado = AdministradorVariables.ingresoStringNumeral(id, 9, "idenfitificacion");
                    char genero = char.Parse(texto);

                    if (string.IsNullOrEmpty(idModificado[0]))
                    {
                        ManejodeDatos datos = new ManejodeDatos();
                        Tuple<bool, string> idRepetido = datos.comprobarIdRepetido("Cliente", id, "IdCliente");

                        if (!idRepetido.Item1)
                        {

                            string mensaje = AdministradorClientes.agregarCliente(nombre, id, apellido1, apellido2, fecha, genero);
                            label7.Text = mensaje;
                        }
                        else
                        {
                            label7.Text = idRepetido.Item2;
                        }

                    }
                    else
                    {
                        label7.Text = idModificado[0];
                    }
                }
                else
                {
                    label7.Text = "No puede dejar espacios en blanco";
                }

            } catch (Exception ex)
            {
                label7.Text = "Hubo un error al ingresar el usuario";
            }

        }
    }
}
