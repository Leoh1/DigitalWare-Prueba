//Entidad Facturas
using System;
using System.Collections.Generic;
using System.Text;
namespace Framework.Domain.Entity
{
    public class Factura { 
        public int? Codigo { get; set; }
        public DateTime? Fecha { get; set; }
        public string Cliente { get; set; }
    }
}