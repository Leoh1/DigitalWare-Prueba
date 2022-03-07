//Repository Facturas
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Framework.Domain.Entity;
using Framework.InfraStructure.Interface;
using Framework.Transversal.Common;

namespace Framework.InfraStructure.Repository
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public FacturaRepository(IConnectionFactory connectionFactory) => _connectionFactory = connectionFactory;


        public bool Eliminar(int Codigo)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query =
                    "DELETE FROM FACTURAS " +
                    "WHERE Codigo = @Codigo";

                var parameters = new DynamicParameters();
                parameters.Add("Codigo", Codigo);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.Text);
                return result > 0;
            }
        }
        
        public IEnumerable<Factura> ObtenerTodos()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query =
                    "SELECT * " +
                    "FROM FACTURAS " +
                    "ORDER BY Codigo DESC";

                var result = connection.Query<Factura>(query, commandType: CommandType.Text);
                return result;
            };
        }

        public IEnumerable<Factura> ObtenerPorCodigo(int Codigo)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query =
                    "SELECT * " +
                    "FROM FACTURAS " +
                    "WHERE Codigo LIKE " + "'" + @Codigo + "%'" +
                    "ORDER BY Codigo DESC";

                var parameters = new DynamicParameters();
                
                parameters.Add("Codigo", Codigo);

                var result = connection.Query<Factura>(query, param: parameters, commandType: CommandType.Text);
                return result;
            };
        }
        
                
        public bool Actualizar(Factura Factura)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query =
                    "UPDATE FACTURAS " +
                    "SET " +
                        "Codigo = @Codigo, " +
                        "Fecha = @Fecha, " +
                        "Cliente = @Cliente " +
                    "WHERE Codigo = @Codigo";

                var parameters = new DynamicParameters();
                
                parameters.Add("Codigo", Factura.Codigo);
                parameters.Add("Fecha", Factura.Fecha);
                parameters.Add("Cliente", Factura.Cliente);
                
                var result = connection.Execute(query, param: parameters, commandType: CommandType.Text);
                return result > 0;
            }
        } 
        
        public bool Insertar(Factura Factura)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query =
                    "INSERT INTO FACTURAS (" +
                        "Codigo, " +
                        "Fecha, " +
                        "Cliente " +
                    ") " +
                    "VALUES(" +
                        "@Codigo, " +
                        "@Fecha, " +
                        "@Cliente " +
                    ")";

                var parameters = new DynamicParameters();
                parameters.Add("Codigo", Factura.Codigo);
                parameters.Add("Fecha", Factura.Fecha.HasValue ? Factura.Fecha : Factura.Fecha = DateTime.Now);
                parameters.Add("Cliente", Factura.Cliente);
                
                var result = connection.Execute(query, param: parameters, commandType: CommandType.Text);
                return result > 0;
            }
        }
    }
}