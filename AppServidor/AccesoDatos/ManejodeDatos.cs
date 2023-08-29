using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Entidades;
using System.ComponentModel;

namespace AccesoDatos
{
    public class ManejodeDatos
    {
        string cadenaConexion;

        private List<Plato> platos = new List<Plato>();
        private List<Plato> platosSinAgregar = new List<Plato>();
        private List<CategoriaPlato> categorias = new List<CategoriaPlato>();
        private List<Restaurante> restaurantes = new List<Restaurante>();
        private List<Clientes> clientes = new List<Clientes>();
        private List<Extras> extras = new List<Extras>();
        private List<PlatoRestaurante> platoRestaurantes = new List<PlatoRestaurante>();

        List<Tuple<Pedido, List<Extras>>> listaPedidos = new List<Tuple<Pedido, List<Extras>>>();
        public ManejodeDatos()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["conexionDatos"].ConnectionString;
        }

        public Tuple<bool, string> comprobarIdRepetido(string nombreTabla, dynamic id, string nombreColumna)
        {
            SqlConnection conexion;

            string codigoSql = $"select * from dbo.{nombreTabla} where {nombreColumna} = {id};";
            SqlDataReader lector;

            SqlCommand comando = new SqlCommand();
            bool hayDatos = false;
            string mensaje = "";

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = codigoSql;
                    comando.Connection = conexion;



                    //se abre conexion para leer datos

                    comando.Connection.Open();

                    lector = comando.ExecuteReader();

                    //regresa si hay o no datos

                    hayDatos = lector.Read();


                    comando.Connection.Close();


                }
            }
            catch (Exception e)
            {

                mensaje = "Hubo un error al conectarse a la base de datos";

            }

            if (hayDatos) { mensaje = "El id se encuentra repetio"; }

            Tuple<bool, string> resultado = new Tuple<bool, string>(hayDatos, mensaje);

            return resultado;

        }

        public Tuple<bool, string> comprobarListaVacia(string nombreTabla)
        {
            SqlConnection conexion;

            string codigoSql = $"select * from dbo.{nombreTabla}";
            SqlDataReader lector;

            SqlCommand comando = new SqlCommand();
            bool hayDatos = false;
            string mensaje = "";

            try
            {

                using (conexion = new SqlConnection(cadenaConexion))
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = codigoSql;
                    comando.Connection = conexion;



                    //se abre conexion para leer datos

                    comando.Connection.Open();

                    lector = comando.ExecuteReader();

                    //regresa si hay o no datos

                    hayDatos = lector.Read();


                    comando.Connection.Close();


                }
            }
            catch (Exception e)
            {

                mensaje = "Hubo un error al conectarse a la base de datos: ";

            }

            if (!hayDatos) { mensaje = $"Debe haber ingresado elementos {nombreTabla} primero"; }

            Tuple<bool, string> resultado = new Tuple<bool, string>(!hayDatos, mensaje);

            return resultado;

        }

        public List<CategoriaPlato> obtenerListaCategorias()
        {
            SqlConnection conexion;

            string codigoSql = $"select * from dbo.CategoriaPlato";
            SqlDataReader lector;

            SqlCommand comando = new SqlCommand();
            bool hayDatos = false;
            string mensaje = "";


            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = codigoSql;
                    comando.Connection = conexion;



                    //se abre conexion para leer datos

                    comando.Connection.Open();

                    lector = comando.ExecuteReader();

                    //regresa si hay o no datos

                    categorias.Clear();

                    while (lector.Read())
                    {
                        categorias.Add(new CategoriaPlato(
                            lector.GetInt32(0),
                            lector.GetString(1),
                            lector.GetBoolean(2)
                        ));
                    }


                    comando.Connection.Close();
                }
            }
            catch (Exception e)
            {

                mensaje = "Hubo un error al conectarse a la base de datos: ";

            }

            return categorias;

        }

        public List<Restaurante> obtenerListaRestaurantes()
        {
            SqlConnection conexion;

            string codigoSql = $"select * from dbo.Restaurante";
            SqlDataReader lector;

            SqlCommand comando = new SqlCommand();
            string mensaje = "";

            using (conexion = new SqlConnection(cadenaConexion))
            {
                comando.CommandType = CommandType.Text;
                comando.CommandText = codigoSql;
                comando.Connection = conexion;

                restaurantes.Clear();

                //se abre conexion para leer datos

                comando.Connection.Open();

                lector = comando.ExecuteReader();

                //regresa si hay o no datos

                while (lector.Read())
                {
                    restaurantes.Add(new Restaurante(
                        lector.GetInt32(0),
                        lector.GetString(1),
                        lector.GetString(2),
                        lector.GetBoolean(3),
                        lector.GetString(4)
                    ));
                }


                comando.Connection.Close();
            }

            return restaurantes;

        }

        public List<Plato> obtenerListaPlatos()
        {
            string mensaje = "";
            try
            {
                SqlConnection conexion;

                List<Plato> listaItems = new List<Plato>();

                string codigoSql = $"select * from dbo.Plato";
                SqlDataReader lector;

                SqlCommand comando = new SqlCommand();

                platos.Clear();

                obtenerListaCategorias();


                using (conexion = new SqlConnection(cadenaConexion))
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = codigoSql;
                    comando.Connection = conexion;



                    //se abre conexion para leer datos

                    comando.Connection.Open();

                    lector = comando.ExecuteReader();


                    //regresa si hay o no datos

                    while (lector.Read())
                    {
                        int id = lector.GetInt32(2);
                        CategoriaPlato categoria = categorias.Find(cat => cat.Id == id);
                        platos.Add(new Plato(
                            lector.GetInt32(0),
                            lector.GetString(1),
                            lector.GetInt32(3),
                            categoria
                        ));
                    }


                    comando.Connection.Close();
                }
            }
            catch (Exception e)
            {

                mensaje = "Hubo un error al conectarse a la base de datos: ";

            }

            return platos;

        }

        public List<Plato> obtenerListaPlatosSinAsignar(int id)
        {
            string mensaje = "";
            try
            {
                SqlConnection conexion;

                List<Plato> listaItems = new List<Plato>();

                string codigoSql = $"SELECT p.IdPlato, p.Nombre, p.IdCategoria, p.Precio" +
                    $" FROM dbo.Plato p" +
                    $" LEFT JOIN dbo.platoRestaurante pr ON p.IdPlato = pr.IdPlato AND pr.IdRestaurante = {id}" +
                    $" WHERE pr.IdPlato IS NULL";

                SqlDataReader lector;

                SqlCommand comando = new SqlCommand();

                platosSinAgregar.Clear();

                obtenerListaCategorias();


                using (conexion = new SqlConnection(cadenaConexion))
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = codigoSql;
                    comando.Connection = conexion;



                    //se abre conexion para leer datos

                    comando.Connection.Open();

                    lector = comando.ExecuteReader();


                    //regresa si hay o no datos

                    while (lector.Read())
                    {
                        int idPlato = lector.GetInt32(2);
                        CategoriaPlato categoria = categorias.Find(cat => cat.Id == idPlato);
                        platosSinAgregar.Add(new Plato(
                            lector.GetInt32(0),
                            lector.GetString(1),
                            lector.GetInt32(3),
                            categoria
                        ));
                    }


                    comando.Connection.Close();
                }
            }
            catch (Exception e)
            {

                mensaje = "Hubo un error al conectarse a la base de datos: ";

            }

            return platosSinAgregar;

        }

        public List<Clientes> ObtenerListaClientes()
        {
            string mensaje = "";
            try
            {
                SqlConnection conexion;

                string codigoSql = $"select * from dbo.Cliente";
                SqlDataReader lector;

                SqlCommand comando = new SqlCommand();

                clientes.Clear();


                using (conexion = new SqlConnection(cadenaConexion))
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = codigoSql;
                    comando.Connection = conexion;



                    //se abre conexion para leer datos

                    comando.Connection.Open();

                    lector = comando.ExecuteReader();


                    //regresa si hay o no datos

                    while (lector.Read())
                    {
                        char genero = lector.GetString(5) == "F" ? 'F' : 'M';
                        clientes.Add(new Clientes(
                            lector.GetString(1),
                            lector.GetString(0),
                            lector.GetString(2),
                            lector.GetString(3),
                            lector.GetDateTime(4),
                            genero
                        ));
                    }


                    comando.Connection.Close();
                }
            }
            catch (Exception e)
            {

                throw e;

            }

            return clientes;

        }

        public Clientes ObtenerListaClientesPorId(String id)
        {
            string mensaje = "";
            Clientes cliente = null;
            try
            {
                SqlConnection conexion;

                string codigoSql = $"select * from dbo.Cliente" +
                    $" WHERE idCliente = '{id}'";
                SqlDataReader lector;

                SqlCommand comando = new SqlCommand();

                clientes.Clear();


                using (conexion = new SqlConnection(cadenaConexion))
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = codigoSql;
                    comando.Connection = conexion;



                    //se abre conexion para leer datos

                    comando.Connection.Open();

                    lector = comando.ExecuteReader();


                    //regresa si hay o no datos

                    while (lector.Read())
                    {
                        char genero = lector.GetString(5) == "F" ? 'F' : 'M';
                        cliente = new Clientes(
                            lector.GetString(1),
                            lector.GetString(0),
                            lector.GetString(2),
                            lector.GetString(3),
                            lector.GetDateTime(4),
                            genero
                        );
                    }


                    comando.Connection.Close();
                }
            }
            catch (Exception e)
            {

                throw e;

            }

            return cliente;

        }

        public List<Extras> ObtenerListaExtras()
        {
            string mensaje = "";

            SqlConnection conexion;

            string codigoSql = $"select * from dbo.Extra";
            SqlDataReader lector;

            SqlCommand comando = new SqlCommand();

            extras.Clear();


            using (conexion = new SqlConnection(cadenaConexion))
            {
                comando.CommandType = CommandType.Text;
                comando.CommandText = codigoSql;
                comando.Connection = conexion;



                //se abre conexion para leer datos

                comando.Connection.Open();

                lector = comando.ExecuteReader();

                obtenerListaCategorias();

                //regresa si hay o no datos

                while (lector.Read())
                {
                    int id = lector.GetInt32(2);
                    CategoriaPlato categoria = categorias.Find(cat => cat.Id == id);

                    extras.Add(new Extras(
                        lector.GetInt32(0),
                        lector.GetString(1),
                        categoria,
                        lector.GetBoolean(3),
                        lector.GetInt32(4)
                    ));
                }


                comando.Connection.Close();


            }

            return extras;

        }

        public List<Extras> ObtenerListaExtrasCategoria(int idCategoria)
        {
            string mensaje = "";

            SqlConnection conexion;

            string codigoSql = $"select * from dbo.Extra" +
                $" WHERE idCategoria = {idCategoria}";
            SqlDataReader lector;

            SqlCommand comando = new SqlCommand();

            extras.Clear();


            using (conexion = new SqlConnection(cadenaConexion))
            {
                comando.CommandType = CommandType.Text;
                comando.CommandText = codigoSql;
                comando.Connection = conexion;



                //se abre conexion para leer datos

                comando.Connection.Open();

                lector = comando.ExecuteReader();

                obtenerListaCategorias();

                while (lector.Read())
                {
                    int id = lector.GetInt32(2);
                    CategoriaPlato categoria = categorias.Find(cat => cat.Id == id);

                    extras.Add(new Extras(
                        lector.GetInt32(0),
                        lector.GetString(1),
                        categoria,
                        lector.GetBoolean(3),
                        lector.GetInt32(4)
                    ));
                }


                comando.Connection.Close();


            }

            return extras;

        }

        public List<PlatoRestaurante> ObtenerListaPlatoRestaurante()
        {
            try
            {
                string mensaje = "";

                SqlConnection conexion;

                string codigoSql = @"
                SELECT
                    idAsignacion,
                    idRestaurante,
                    FechaAsignacion,
                    STRING_AGG(CAST(idPlato AS NVARCHAR(10)), ',') AS IdPlatos
                FROM
                    dbo.platoRestaurante
                GROUP BY
                    idAsignacion,
                    idRestaurante,
                    FechaAsignacion
                ";

                SqlDataReader lector;

                SqlCommand comando = new SqlCommand();

                extras.Clear();


                using (conexion = new SqlConnection(cadenaConexion))
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = codigoSql;
                    comando.Connection = conexion;



                    //se abre conexion para leer datos

                    comando.Connection.Open();

                    lector = comando.ExecuteReader();

                    obtenerListaPlatos();
                    obtenerListaRestaurantes();

                    //regresa si hay o no datos


                    while (lector.Read())
                    {
                        int idRestaurante = lector.GetInt32(1);
                        Restaurante restaurante = restaurantes.Find(rest => rest.Id == idRestaurante);

                        List<int> IdPlatosLista = lector.GetString(3).Split(',').Select(int.Parse).ToList();

                        Plato[] platosAgregados = new Plato[IdPlatosLista.Count];

                        for (int i = 0; i < IdPlatosLista.Count; i++)
                        {
                            Plato plato = platos.Find(plato => plato.Id == IdPlatosLista[i]);
                            platosAgregados[i] = plato;
                        }


                        platoRestaurantes.Add(new PlatoRestaurante(
                            lector.GetInt32(0),
                            lector.GetDateTime(2),
                            restaurante,
                            platosAgregados
                        ));
                    }


                    comando.Connection.Close();


                }

                return platoRestaurantes;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Plato> ObtenerListaPlatosPorRestaurante(int id)
        {
            try
            {
                string mensaje = "";

                SqlConnection conexion;

                string codigoSql = $"Select p.IdPlato, p.Nombre, p.IdCategoria,p.Precio" +
                    $" From dbo.Plato p" +
                    $" LEFT JOIN dbo.platoRestaurante pr ON p.IdPlato = pr.IdPlato AND pr.IdRestaurante = {id}" +
                    $" WHERE pr.IdPlato IS NOT NULL; ";

                SqlDataReader lector;

                SqlCommand comando = new SqlCommand();

                platos.Clear();

                obtenerListaCategorias();

                using (conexion = new SqlConnection(cadenaConexion))
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = codigoSql;
                    comando.Connection = conexion;



                    //se abre conexion para leer datos

                    comando.Connection.Open();

                    lector = comando.ExecuteReader();


                    //regresa si hay o no datos

                    while (lector.Read())
                    {
                        int idPlato = lector.GetInt32(2);
                        CategoriaPlato categoria = categorias.Find(cat => cat.Id == idPlato);
                        platos.Add(new Plato(
                            lector.GetInt32(0),
                            lector.GetString(1),
                            lector.GetInt32(3),
                            categoria
                        ));
                    }


                    comando.Connection.Close();


                }

                return platos;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public List<Tuple<Pedido,List<Extras>>> obtenerListaDePedidos(string id)
        {
            string mensaje = "";
            try
            {
                SqlConnection conexion;

                List<Plato> listaItems = new List<Plato>();

                string codigoSql = $"SELECT" +
                    $"    t1.idPedido," +
                    $"    t1.idPlato," +
                    $"    t1.FechaPedido," +
                    $"    STRING_AGG(t2.idExtra, ',') AS idExtras" +
                    $" FROM" +
                    $"    dbo.Pedido t1" +
                    $" LEFT JOIN" +
                    $"    dbo.ExtraPedido t2 ON t1.idPedido = t2.idPedido AND t1.idPlato = t2.idPlato" +
                    $" WHERE t1.IdCliente = {id}" +
                    $" GROUP BY" +
                    $"    t1.idPedido," +
                    $"    t1.idPlato," +
                    $"    t1.FechaPedido;";

                SqlDataReader lector;

                SqlCommand comando = new SqlCommand();

                listaPedidos.Clear();

                ObtenerListaExtras();

                obtenerListaPlatos();


                using (conexion = new SqlConnection(cadenaConexion))
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = codigoSql;
                    comando.Connection = conexion;



                    //se abre conexion para leer datos

                    comando.Connection.Open();

                    lector = comando.ExecuteReader();


                    //regresa si hay o no datos

                    while (lector.Read())
                    {
                        List<int> idExtras = lector.GetString(3).Split(',').Select(int.Parse).ToList();
                        List<Extras> extrasAgregadas = new List<Extras>();

                        idExtras.ForEach(extra => extrasAgregadas.Add(extras.Find(ex => ex.Id == extra)));

                        Pedido pedido = new Pedido(
                            lector.GetInt32(0),
                            id,
                            lector.GetInt32(1),
                            lector.GetDateTime(2)
                            );

                        Tuple<Pedido, List<Extras>> pedidoCompleto = new Tuple<Pedido, List<Extras>>(pedido,extrasAgregadas);

                        listaPedidos.Add(pedidoCompleto);
                    }


                    comando.Connection.Close();
                }
            }
            catch (Exception e)
            {

                mensaje = "Hubo un error al conectarse a la base de datos: ";

            }

            return listaPedidos;

        }

        public Tuple<Pedido, List<Extras>> obtenerListaDePedidosId(string id, int idPedido)
        {
            string mensaje = "";

            Tuple<Pedido, List<Extras>> pedidoCompleto = new Tuple<Pedido, List<Extras>>(null, null);

            try
            {
                SqlConnection conexion;

                List<Plato> listaItems = new List<Plato>();

                string codigoSql = $"SELECT" +
                    $"    t1.idPedido," +
                    $"    t1.idPlato," +
                    $"    t1.FechaPedido," +
                    $"    STRING_AGG(t2.idExtra, ',') AS idExtras" +
                    $" FROM" +
                    $"    dbo.Pedido t1" +
                    $" LEFT JOIN" +
                    $"    dbo.ExtraPedido t2 ON t1.idPedido = t2.idPedido AND t1.idPlato = t2.idPlato" +
                    $" WHERE t1.IdCliente = {id} AND t1.idPedido = {idPedido}" +
                    $" GROUP BY" +
                    $"    t1.idPedido," +
                    $"    t1.idPlato," +
                    $"    t1.FechaPedido;";

                SqlDataReader lector;

                SqlCommand comando = new SqlCommand();

                listaPedidos.Clear();

                ObtenerListaExtras();

                obtenerListaPlatos();
                

                using (conexion = new SqlConnection(cadenaConexion))
                {
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = codigoSql;
                    comando.Connection = conexion;



                    //se abre conexion para leer datos

                    comando.Connection.Open();

                    lector = comando.ExecuteReader();

                    

                    //regresa si hay o no datos

                    if (lector.Read())
                    {
                        List<int> idExtras = lector.GetString(3).Split(',').Select(int.Parse).ToList();
                        List<Extras> extrasAgregadas = new List<Extras>();

                        idExtras.ForEach(extra => extrasAgregadas.Add(extras.Find(ex => ex.Id == extra)));

                        Pedido pedido = new Pedido(
                            lector.GetInt32(0),
                            id,
                            lector.GetInt32(1),
                            lector.GetDateTime(2)
                            );

                        pedidoCompleto = new Tuple<Pedido, List<Extras>>(pedido, extrasAgregadas);
;
                    }


                    comando.Connection.Close();
                }
            }
            catch (Exception e)
            {

                mensaje = "Hubo un error al conectarse a la base de datos: ";

            }

            return pedidoCompleto;

        }

    }
}
