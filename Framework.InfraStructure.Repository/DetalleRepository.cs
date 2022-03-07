//Repository Detalles
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using Framework.Domain.Entity;
using Framework.InfraStructure.Interface;
using Framework.Transversal.Common;

namespace Framework.InfraStructure.Repository
{
    public class DetalleRepository : IDetalleRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public DetalleRepository(IConnectionFactory connectionFactory) => _connectionFactory = connectionFactory;


        public bool Eliminar(int Codigo)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query =
                    "DELETE FROM DETALLES " +
                    "WHERE Codigo = @Codigo";

                var parameters = new DynamicParameters();
                parameters.Add("Codigo", Codigo);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.Text);
                return result > 0;
            }
        }
        
        public IEnumerable<Detalle> ObtenerTodos()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query =
                    "SELECT * " +
                    "FROM DETALLES " +
                    "ORDER BY Codigo DESC";

                var result = connection.Query<Detalle>(query, commandType: CommandType.Text);
                return result;
            };
        }

        public IEnumerable<Detalle> ObtenerPorCodigo(int Codigo)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query =
                    "SELECT * " +
                    "FROM DETALLES " +
                    "WHERE Codigo LIKE " + "'" + @Codigo + "%'" +
                    "ORDER BY Codigo DESC";

                var parameters = new DynamicParameters();
                
                parameters.Add("Codigo", Codigo);

                var result = connection.Query<Detalle>(query, param: parameters, commandType: CommandType.Text);
                return result;
            };
        }
        
                
        public bool Actualizar(Detalle Detalle)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query =
                    "UPDATE DETALLES " +
                    "SET " +
                        "Codigo = @Codigo, " +
                        "Cantidad = @Cantidad, " +
                        "Precio = @Precio, " +
                        "Factura = @Factura, " +
                        "Producto = @Producto " +
                    "WHERE Codigo = @Codigo";

                var parameters = new DynamicParameters();
                
                parameters.Add("Codigo", Detalle.Codigo);
                parameters.Add("Cantidad", Detalle.Cantidad);
                parameters.Add("Precio", Detalle.Precio);
                parameters.Add("Factura", Detalle.Factura);
                parameters.Add("Producto", Detalle.Producto);
                
                var result = connection.Execute(query, param: parameters, commandType: CommandType.Text);
                return result > 0;
            }
        } 
        
        public bool Insertar(Detalle Detalle)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query =
                    "INSERT INTO DETALLES (" +
                        "Codigo, " +
                        "Cantidad, " +
                        "Precio, " +
                        "Factura, " +
                        "Producto " +
                    ") " +
                    "VALUES(" +
                        "@Codigo, " +
                        "@Cantidad, " +
                        "@Precio, " +
                        "@Factura, " +
                        "@Producto " +
                    ")";

                var parameters = new DynamicParameters();
                
                parameters.Add("Codigo", Detalle.Codigo);
                parameters.Add("Cantidad", Detalle.Cantidad);
                parameters.Add("Precio", Detalle.Precio);
                parameters.Add("Factura", Detalle.Factura);
                parameters.Add("Producto", Detalle.Producto);
                
                var result = connection.Execute(query, param: parameters, commandType: CommandType.Text);
                return result > 0;
            }
        }

        public bool Insertar(Detalle[] Detalle)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query =
                    "INSERT INTO DETALLES (" +
                        "Codigo, " +
                        "Cantidad, " +
                        "Precio, " +
                        "Factura, " +
                        "Producto " +
                    ") " +
                    "VALUES(" +
                        "@Codigo, " +
                        "@Cantidad, " +
                        "@Precio, " +
                        "@Factura, " +
                        "@Producto " +
                    ")";

                var parameters = new DynamicParameters();

                var ListaDetalles = Detalle.AsList<Detalle>();

                foreach (var variable in ListaDetalles)
                {
                    parameters.Add("Codigo", variable.Codigo);
                    parameters.Add("Cantidad", variable.Cantidad);
                    parameters.Add("Precio", variable.Precio);
                    parameters.Add("Factura", variable.Factura);
                    parameters.Add("Producto", variable.Producto);

                    var result = connection.Execute(query, param: parameters, commandType: CommandType.Text);
                    if (result != 1) return false; 
                }
                return true;
            }
        }

        public bool UnidadesDisponibles(Detalle[] Detalle)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = 
                    "SELECT 1  " +
                    "FROM   Productos " +
                    "WHERE  Codigo = @Producto AND Unidades >= @Cantidad";

                var parameters = new DynamicParameters();

                var ListaDetalles = Detalle.AsList<Detalle>();

                foreach (var variable in ListaDetalles)
                {
                    parameters.Add("Producto", variable.Producto);
                    parameters.Add("Cantidad", variable.Cantidad);

                    var result = connection.QuerySingle<int>(query, param: parameters, commandType: CommandType.Text);
                    if (result != 1) return false;
                }
                return true;
            }
        }
    }
}
