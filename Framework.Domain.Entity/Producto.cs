//Entidad Productos
using System;
using System.Collections.Generic;
using System.Text;
namespace Framework.Domain.Entity
{
    public class Producto { 
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Unidades { get; set; }
    }
}