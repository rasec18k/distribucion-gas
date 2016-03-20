using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCFAtencionPedidoGas.Dominio;

namespace WCFAtencionPedidoGas.Persistencia
{
    public class PedidoDAO
    {

         private String cadenaConexion = "Data Source=(local); Initial Catalog=BD_PEDIDOS;Integrated Security=SSPI";

        public Pedido Crear(Pedido pedidoACrear)
        {
            Pedido pedidoCreado = null;
            String sql = "INSET INTO t_Pedidos VALUES (@idPedido,@telefono)";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idPedido", pedidoACrear.idPedido));
                    comando.Parameters.Add(new SqlParameter("@idCliente", pedidoACrear.idCliente));
                    comando.ExecuteNonQuery();
                }
            }

            pedidoCreado = Obtener(pedidoACrear.idPedido);
            return pedidoCreado;
        }

        public Pedido Actualizar(Pedido pedidoAModificar)
        {

            Pedido pedidoModificado = null;
            String sql = "UPDATE t_pedidos SET telefono=@telefono WHERE idPedido=@idPedido";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idPedido", pedidoAModificar.idPedido));
                    comando.ExecuteNonQuery();
                }
            }

            pedidoModificado = Obtener(pedidoAModificar.idPedido);
            return pedidoModificado;
        }

        public Pedido Obtener(int idPedido)
        {
            Pedido pedidoEncontrado = null;

            String sql = "SELECT * FROM t_producto WHERE telefono=@telefono";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idPedido", idPedido));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            pedidoEncontrado = new Pedido()
                            {
                                idPedido = (int)resultado["idPedido"]
                            };
                        }
                    }
                }
            }

            return pedidoEncontrado;
        }

        public List<Pedido> ListarPedidos(int idPedido)
        {

            List<Pedido> listadoPedidos = new List<Pedido>();

            Pedido pedidoEncontrado = null;

            String sql = "SELECT * FROM t_pedidos";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idPedido", idPedido));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            pedidoEncontrado = new Pedido()
                            {
                                idPedido = (int)resultado["idPedido"]
                            };
                            listadoPedidos.Add(pedidoEncontrado);
                        }
                    }
                }
            }

            return listadoPedidos;
        }
    }
    
}