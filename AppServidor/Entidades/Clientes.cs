using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Entidades
{
    public class Clientes : Idble<string>
    {

        public Clientes(string nombre, string id, string primerApellido, string segundoApellido, DateTime fecha, char genero) :base(id)
        {
            nombreCliente = nombre;
            primerApellidoCliente = primerApellido;
            segundoApellidoCliente = segundoApellido;
            fechaNacimiento = fecha;
            generoCliente = genero;
        }

        private string nombreCliente;
        public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }

        private string primerApellidoCliente;
        public string PrimerApellidoCliente { get => primerApellidoCliente; set => primerApellidoCliente = value; }

        private string segundoApellidoCliente;
        public string SegundoApellidoCliente { get => segundoApellidoCliente; set => segundoApellidoCliente = value; }

        private DateTime fechaNacimiento;
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }

        private char generoCliente;
        public char GeneroCliente { get => generoCliente; set => generoCliente = value; }
    
    }
}
