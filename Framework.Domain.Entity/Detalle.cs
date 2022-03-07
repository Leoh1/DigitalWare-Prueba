//Entidad Detalles
using System;
using System.Collections.Generic;
using System.Text;
namespace Framework.Domain.Entity
{
    public class Detalle { 
        public int Codigo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int Factura { get; set; }
        public int Producto { get; set; }
    }
}