using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCFAtencionPedidoGas.Dominio;

namespace WCFAtencionPedidoGas.Persistencia
{
    public class ClienteDAO
    {

        private String cadenaConexion = "Data Source=(local); Initial Catalog=BD_PEDIDOS;Integrated Security=SSPI";

        public Cliente Crear(Cliente clienteACrear)
        {
            Cliente clienteCreado = null;
            String sql = "INSET INTO t_clientes VALUES (@idCliente,@telefono)";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idCliente", clienteACrear.idCliente));
                    comando.Parameters.Add(new SqlParameter("@telefono", clienteACrear.telefono));
                    comando.ExecuteNonQuery();
                }
            }

            clienteCreado = Obtener(clienteACrear.telefono);
            return clienteCreado;
        }

        public Cliente Actualizar(Cliente clienteAModificar)
        {

            Cliente clienteModificado = null;
            String sql = "UPDATE t_clientes SET telefono=@telefono WHERE idCliente=@idCliente";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idCliente", clienteAModificar.idCliente));
                    comando.Parameters.Add(new SqlParameter("@telefono", clienteAModificar.telefono));
                    comando.ExecuteNonQuery();
                }
            }

            clienteModificado = Obtener(clienteAModificar.telefono);
            return clienteModificado;
        }

        public Cliente Obtener(String telefono)
        {
            Cliente clienteEncontrado = null;

            String sql = "SELECT * FROM t_producto WHERE telefono=@telefono";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@telefono", telefono));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            clienteEncontrado = new Cliente()
                            {
                                idCliente = (int)resultado["idCliente"],
                                telefono = (string)resultado["telefono"]
                            };
                        }
                    }
                }
            }

            return clienteEncontrado;
        }

       
    }
}