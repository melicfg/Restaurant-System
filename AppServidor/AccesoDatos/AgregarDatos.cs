using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Entidades;
using System.Data;

namespace AccesoDatos
{
    public class AgregarDatos
    {
        private string cadenaConexion = string.Empty;

        public AgregarDatos()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["conexionDatos"].ConnectionString;   
        }


        public Tuple<bool, string> guardarRestaurante (Restaurante pRestaurante)
        {
            bool registroExitoso = false;

            SqlConnection conexion;

            string mensaje = "";

            string codigoSql = "Insert into dbo.Restaurante(IdRestaurante, Nombre, Direccion, Estado, Telefono)" +
                                "values (@IdRestaurante, @Nombre, @Direccion, @Estado, @Telefono);";

            SqlCommand comando = new SqlCommand();

            using (conexion = new SqlConnection(cadenaConexion))
            {
                comando.CommandType = CommandType.Text;
                comando.CommandText = codigoSql;
                comando.Connection = conexion;

                comando.Parameters.AddWithValue("@IdRestaurante", pRestaurante.Id);
                comando.Parameters.AddWithValue("@Nombre", pRestaurante.NombreRestaurante);
                comando.Parameters.AddWithValue("@Direccion", pRestaurante.DireccionRestaurante);
                comando.Parameters.AddWithValue("@Estado", pRestaurante.EstadoRestaurante ? 1 : 0);
                comando.Parameters.AddWithValue("@Telefono", pRestaurante.TelefonoRestaurante);


                try
                {
                    //se abre conexion
                    comando.Connection.Open();
                    //se registra el resultado
                    registroExitoso = comando.ExecuteNonQuery() > 0;
                    mensaje = "El restaurante fue guardado exitosamente";

                    //se cierra la conexion
                    comando.Connection.Close();

                } catch (Exception ex)
                {
                    mensaje = "Hubo un error al conectarse a la base de datos";
                }
            }
            Tuple<bool, string> resultado = new Tuple<bool, string>(registroExitoso, mensaje);
            return resultado;
        }

        public Tuple<bool, string> guardarCategoria(CategoriaPlato pCategoria)
        {
            bool registroExitoso = false;

            SqlConnection conexion;

            string mensaje = "";

            string codigoSql = "Insert into dbo.CategoriaPlato(IdCategoria, Descripcion, Estado)" +
                                "values (@IdCategoria, @Descripcion, @Estado);";

            SqlCommand comando = new SqlCommand();

            using (conexion = new SqlConnection(cadenaConexion))
            {
                comando.CommandType = CommandType.Text;
                comando.CommandText = codigoSql;
                comando.Connection = conexion;

                comando.Parameters.AddWithValue("@IdCategoria", pCategoria.Id);
                comando.Parameters.AddWithValue("@Descripcion", pCategoria.NombreCategoria);
                comando.Parameters.AddWithValue("@Estado", pCategoria.EstadoCategoria ? 1 : 0);


                try
                {
                    //se abre conexion
                    comando.Connection.Open();
                    //se registra el resultado
                    registroExitoso = comando.ExecuteNonQuery() > 0;
                    mensaje = "La Categoria fue guardada exitosamente";

                    //se cierra la conexion
                    comando.Connection.Close();

                }
                catch (Exception ex)
                {
                    mensaje = "Hubo un error al conectarse a la base de datos";
                }
            }
            Tuple<bool, string> resultado = new Tuple<bool, string>(registroExitoso, mensaje);
            return resultado;
        }

        public Tuple<bool, string> guardarCliente(Clientes pCliente)
        {
            bool registroExitoso = false;

            SqlConnection conexion;

            string mensaje = "";

            string codigoSql = "Insert into dbo.Cliente(IdCliente, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Genero)" +
                                "values (@IdCliente, @Nombre, @PrimerApellido, @SegundoApellido, @FechaNacimiento, @Genero);";

            SqlCommand comando = new SqlCommand();

            using (conexion = new SqlConnection(cadenaConexion))
            {
                comando.CommandType = CommandType.Text;
                comando.CommandText = codigoSql;
                comando.Connection = conexion;

                comando.Parameters.AddWithValue("@IdCliente", pCliente.Id);
                comando.Parameters.AddWithValue("@Nombre", pCliente.NombreCliente);
                comando.Parameters.AddWithValue("@PrimerApellido", pCliente.PrimerApellidoCliente);
                comando.Parameters.AddWithValue("@SegundoApellido", pCliente.SegundoApellidoCliente);
                comando.Parameters.AddWithValue("@FechaNacimiento", pCliente.FechaNacimiento);
                comando.Parameters.AddWithValue("@Genero", pCliente.GeneroCliente);


                try
                {
                    //se abre conexion
                    comando.Connection.Open();
                    //se registra el resultado
                    registroExitoso = comando.ExecuteNonQuery() > 0;
                    mensaje = "El cliente fue guardado exitosamente";

                    //se cierra la conexion
                    comando.Connection.Close();

                }
                catch (Exception ex)
                {
                    mensaje = "Hubo un error al conectarse a la base de datos";
                }
            }
            Tuple<bool, string> resultado = new Tuple<bool, string>(registroExitoso, mensaje);
            return resultado;
        }

        public Tuple<bool, string> guardarPlato(Plato pPlato)
        {
            string mensaje = "";
            bool registroExitoso = false;

            try { 
            

                SqlConnection conexion;

                string codigoSql = "Insert into dbo.Plato(IdPlato, Nombre, IdCategoria, Precio)" +
                                    "values (@IdPlato, @Nombre, @IdCategoria, @Precio);";

                SqlCommand comando = new SqlCommand();

                using (conexion = new SqlConnection(cadenaConexion))
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = codigoSql;
                    comando.Connection = conexion;

                    comando.Parameters.AddWithValue("@IdPlato", pPlato.Id);
                    comando.Parameters.AddWithValue("@Nombre", pPlato.NombrePlato);
                    comando.Parameters.AddWithValue("@IdCategoria", pPlato.CategoriaPlato.Id);
                    comando.Parameters.AddWithValue("@Precio", pPlato.PrecioPlato);


                    //se abre conexion
                    comando.Connection.Open();
                    //se registra el resultado
                    registroExitoso = comando.ExecuteNonQuery() > 0;
                    mensaje = "El plato fue guardado exitosamente";

                    //se cierra la conexion
                    comando.Connection.Close();

                }

            } catch (Exception ex)
            {
                mensaje = "Hubo un error al conectarse a la base de datos";
            }


            Tuple<bool, string> resultado = new Tuple<bool, string>(registroExitoso, mensaje);
            return resultado;
        }

        public Tuple<bool, string> guardarExtra(Extras pExtra)
        {
            string mensaje = "";
            bool registroExitoso = false;

            try
            {
                

                SqlConnection conexion;


                string codigoSql = "Insert into dbo.Extra(IdExtra, Descripcion, IdCategoria, Estado, Precio)" +
                                    "values (@IdExtra, @Descripcion, @IdCategoria, @Estado, @Precio);";

                SqlCommand comando = new SqlCommand();

                using (conexion = new SqlConnection(cadenaConexion))
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = codigoSql;
                    comando.Connection = conexion;

                    comando.Parameters.AddWithValue("@IdExtra", pExtra.Id);
                    comando.Parameters.AddWithValue("@Descripcion", pExtra.DescripcionCategoria);
                    comando.Parameters.AddWithValue("@IdCategoria", pExtra.CategoriaExtra.Id);
                    comando.Parameters.AddWithValue("@Estado", pExtra.EstadoExtra);
                    comando.Parameters.AddWithValue("@Precio", pExtra.PrecioExtra);


                    //se abre conexion
                    comando.Connection.Open();
                    //se registra el resultado
                    registroExitoso = comando.ExecuteNonQuery() > 0;
                    mensaje = "La extra fue guardada exitosamente";

                    //se cierra la conexion
                    comando.Connection.Close();

                }
            } catch (Exception ex)
                {
                    mensaje = "Hubo un error al conectarse a la base de datos";
                }

            Tuple<bool, string> resultado = new Tuple<bool, string>(registroExitoso, mensaje);
            return resultado;
        }

        public Tuple<bool, string> guardarPlatoRestaurante(PlatoRestaurante pPlatoRestaurante)
        {
            string mensaje = "";
            bool registroExitoso = false;

            try
            {


                SqlConnection conexion;


                string codigoSql = "Insert into dbo.PlatoRestaurante(IdAsignacion, IdRestaurante, IdPlato, FechaAsignacion)" +
                                    "values (@IdAsignacion, @IdRestaurante, @IdPlato, @FechaAsignacion);";

                SqlCommand comando = new SqlCommand();


                using (conexion = new SqlConnection(cadenaConexion))
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = codigoSql;
                    comando.Connection = conexion;

                    comando.Connection.Open();

                    foreach (Plato plato in pPlatoRestaurante.Platos.Where(plato => plato != null))
                    {

                        comando.Parameters.AddWithValue("@IdAsignacion", pPlatoRestaurante.Id);
                        comando.Parameters.AddWithValue("@IdRestaurante", pPlatoRestaurante.RestaurantePlato.Id);
                        comando.Parameters.AddWithValue("@IdPlato", plato.Id);
                        comando.Parameters.AddWithValue("@FechaAsignacion", pPlatoRestaurante.FechaAsignacion);

                        
                        //se registra el resultado
                        registroExitoso = comando.ExecuteNonQuery() > 0;

                        comando.Parameters.Clear();

                    }
                    //se cierra la conexion
                    comando.Connection.Close();
                    mensaje = "Los´platos fueron asociados exitosamente";


                }
            }
            catch (Exception ex)
            {
                mensaje = $"Hubo un error al conectarse a la base de datos {ex.Message}";
            }

            Tuple<bool, string> resultado = new Tuple<bool, string>(registroExitoso, mensaje);
            return resultado;
        }

        public bool guardarPedido(Pedido pPedido)
        {
            string mensaje = "";
            bool registroExitoso = false;

            try
            {


                SqlConnection conexion;


                string codigoSql = "Insert into dbo.Pedido(IdPedido, IdCliente, IdPlato, FechaPedido)" +
                                    "values (@IdPedido, @IdCliente, @IdPlato, @FechaPedido);";

                SqlCommand comando = new SqlCommand();


                using (conexion = new SqlConnection(cadenaConexion))
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = codigoSql;
                    comando.Connection = conexion;

                    comando.Connection.Open();


                    comando.Parameters.AddWithValue("@IdPedido", pPedido.IdPedido);
                    comando.Parameters.AddWithValue("@IdCliente", pPedido.IdCliente);
                    comando.Parameters.AddWithValue("@IdPlato", pPedido.IdPlato);
                    comando.Parameters.AddWithValue("@FechaPedido", pPedido.FechaPedido);


                    //se registra el resultado
                    registroExitoso = comando.ExecuteNonQuery() > 0;

                    comando.Parameters.Clear();

                    //se cierra la conexion
                    comando.Connection.Close();
                    mensaje = "Los  fueron asociados exitosamente";


                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return registroExitoso;
        }

        public bool guardarPedidoExtra(ExtraPedido pedidoExtra)
        {
            string mensaje = "";
            bool registroExitoso = false;

            try
            {


                SqlConnection conexion;


                string codigoSql = "Insert into dbo.ExtraPedido(IdPedido, IdPlato, IdExtra)" +
                                    "values (@IdPedido, @IdPlato, @IdExtra);";

                SqlCommand comando = new SqlCommand();


                using (conexion = new SqlConnection(cadenaConexion))
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = codigoSql;
                    comando.Connection = conexion;

                    comando.Connection.Open();
                    

                    comando.Parameters.AddWithValue("@IdPedido", pedidoExtra.IdPedido);
                    comando.Parameters.AddWithValue("@IdPlato", pedidoExtra.IdPlato);
                    comando.Parameters.AddWithValue("@IdExtra", pedidoExtra.IdExtra);


                    //se registra el resultado
                    registroExitoso = comando.ExecuteNonQuery() > 0;

                    comando.Parameters.Clear();

                    //se cierra la conexion
                    comando.Connection.Close();
                    mensaje = "Los extras fueron asociados exitosamente";


                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return registroExitoso;
        }
    }
}
