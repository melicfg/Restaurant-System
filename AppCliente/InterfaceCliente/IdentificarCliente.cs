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
    public partial class IdentificarCliente : Form
    {
        bool clienteConectado = false;

        private static Clientes cliente = null;
        public IdentificarCliente()
        {
            InitializeComponent();
            button3.Enabled = false;
            button4.Enabled = false;
        }

        public static string getIdCliente()
        {
            return cliente.Id;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;

            try
            {
                if (!id.Equals(string.Empty))
                {
                    if (ClienteTCP.Conectar(id))
                    {
                        cliente = ClienteTCP.ObtenerClientePorId(id);
                    }
                    else
                    {
                        MessageBox.Show("Verifique que el servidor esté escuchando clientes...", "No es posible conectarse", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    if (cliente != null)
                    {

                        label4.Text = "Conectado al servidor... en (127.0.0.1, 30000)";
                        label4.ForeColor = Color.Green;
                        clienteConectado = true;
                        button1.Enabled = false;
                        button2.Enabled = true;
                        textBox1.ReadOnly = true;
                        label3.Text = $"Bienvenido/a {cliente.NombreCliente}";
                        button3.Enabled = true;
                        button4.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado ese cliente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ClienteTCP.Desconectar(id);
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar el identificador del cliente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                label3.Text = "Error";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClienteTCP.Desconectar(textBox1.Text);

            label4.Text = "Desconectado";
            label4.ForeColor = Color.Red;
            button2.Enabled = false;
            button1.Enabled = true;
            clienteConectado = false;
            textBox1.ReadOnly = false;

            label3.Text = "";

            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AgregarPedido agregarPedido = new AgregarPedido();
            agregarPedido.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MostrarPedidos mostrarPedidos = new MostrarPedidos();
            mostrarPedidos.ShowDialog();
        }
    }
}
