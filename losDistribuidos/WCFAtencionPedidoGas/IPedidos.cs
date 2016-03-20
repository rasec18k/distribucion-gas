using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFAtencionPedidoGas.Dominio;

namespace WCFAtencionPedidoGas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPedidos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPedidos
    {
        [OperationContract]
        Pedido registrarPedido(Pedido pedidoARegistrar);

        [OperationContract]
        Pedido anularPedido();

        [OperationContract]
        Pedido actualizarPedido();

        [OperationContract]
        List<Pedido> listarPedidos();

    }
}
