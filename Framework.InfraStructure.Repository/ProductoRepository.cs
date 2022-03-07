//Repository Productos
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
    public class ProductoRepository : IProductoRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public ProductoRepository(IConnectionFactory connectionFactory) => _connectionFactory = connectionFactory;


        public bool Eliminar(int Codigo)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query =
                    "DELETE FROM PRODUCTOS " +
                    "WHERE Codigo = @Codigo";

                var parameters = new DynamicParameters();
                parameters.Add("Codigo", Codigo);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.Text);
                return result > 0;
            }
        }
        
        public IEnumerable<Producto> ObtenerTodos()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query =
                    "SELECT * " +
                    "FROM PRODUCTOS " +
                    "ORDER BY Codigo DESC";

                var result = connection.Query<Producto>(query, commandType: CommandType.Text);
                return result;
            };
        }

        public IEnumerable<Producto> ObtenerPorCodigo(int Codigo)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query =
                    "SELECT * " +
                    "FROM PRODUCTOS " +
                    "WHERE Codigo LIKE " + "'" + @Codigo + "%'" +
                    "ORDER BY Codigo DESC";

                var parameters = new DynamicParameters();
                
                parameters.Add("Codigo", Codigo);

                var result = connection.Query<Producto>(query, param: parameters, commandType: CommandType.Text);
                return result;
            };
        }
        
                
        public bool Actualizar(Producto Producto)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query =
                    "UPDATE PRODUCTOS " +
                    "SET " +
                        "Codigo = @Codigo, " +
                        "Nombre = @Nombre, " +
                        "Precio = @Precio, " +
                        "Unidades = @Unidades " +
                    "WHERE Codigo = @Codigo";

                var parameters = new DynamicParameters();
                
                parameters.Add("Codigo", Producto.Codigo);
                parameters.Add("Nombre", Producto.Nombre);
                parameters.Add("Precio", Producto.Precio);
                parameters.Add("Unidades", Producto.Unidades);
                
                var result = connection.Execute(query, param: parameters, commandType: CommandType.Text);
                return result > 0;
            }
        } 
        
        public bool Insertar(Producto Producto)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query =
                    "INSERT INTO PRODUCTOS (" +
                        "Codigo, " +
                        "Nombre, " +
                        "Precio, " +
                        "Unidades " +
                    ") " +
                    "VALUES(" +
                        "@Codigo, " +
                        "@Nombre, " +
                        "@Precio, " +
                        "@Unidades " +
                    ")";

                var parameters = new DynamicParameters();
                
                parameters.Add("Codigo", Producto.Codigo);
                parameters.Add("Nombre", Producto.Nombre);
                parameters.Add("Precio", Producto.Precio);
                parameters.Add("Unidades", Producto.Unidades);
                
                var result = connection.Execute(query, param: parameters, commandType: CommandType.Text);
                return result > 0;
            }
        } 
            
    }
}