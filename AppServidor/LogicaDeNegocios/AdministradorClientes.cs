using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace LogicaDeNegocios
{
    public class AdministradorClientes
    {

        public static string agregarCliente (
            string nombreCliente, 
            string idCliente, 
            string apellidoCliente, 
            string sedundoApellidoCliente, 
            DateTime fechaNacimeinto, 
            char genero)
        {
            Clientes nuevoCliente = new Clientes(
                nombreCliente, 
                idCliente, 
                apellidoCliente, 
                sedundoApellidoCliente, 
                fechaNacimeinto, 
                genero
            );

            AgregarDatos datos = new AgregarDatos();

            Tuple<bool, string> respuesta = datos.guardarCliente(nuevoCliente);


            return respuesta.Item2;

            AdministradorListas.clientesLista[AdministradorListas.indiceCliente] = nuevoCliente;
            AdministradorListas.indiceCliente += 1;

        }

    }
}
