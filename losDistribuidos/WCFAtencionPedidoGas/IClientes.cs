﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFAtencionPedidoGas.Dominio;

namespace WCFAtencionPedidoGas
{
    
    [ServiceContract]
    public interface IClientes
    {
        [OperationContract]
        Cliente CrearCliente(Cliente clienteACrear);
    }
}
