using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFAtencionPedidoGas.Dominio;
using WCFAtencionPedidoGas.Persistencia;

namespace WCFAtencionPedidoGas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Clientes" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Clientes.svc o Clientes.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Clientes : IClientes
    {
        private ClienteDAO clienteDAO = new ClienteDAO();



        public Cliente CrearCliente(Cliente clienteACrear)
        {
            
                return clienteDAO.Crear(clienteACrear);
            

        }
    }
}
