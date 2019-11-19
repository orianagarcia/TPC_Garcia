﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
        public long id { get; set; }
        public long idProveedor { get; set; }
        public double total { get; set; }
        public DateTime fechaCompra { get; set; }
        public string estadoCompra { get; set; }
        public string formaPago { get; set; }

        public List<Detallecompra> detalle { get; set; }
        public string estado { get; set; }
    }
}
