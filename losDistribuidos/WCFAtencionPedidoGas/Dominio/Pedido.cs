﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFAtencionPedidoGas.Dominio
{
    [DataContract]
    public class Pedido
    {
        [DataMember]
        public int idPedido { get; set; }
        [DataMember]
        public int idCliente { get; set; }
        [DataMember]
        public double montoTotql { get; set; }
        [DataMember]
        public int idEstado {get;set;}
        [DataMember]
        public string fechaPedido{get;set;}
    }
}