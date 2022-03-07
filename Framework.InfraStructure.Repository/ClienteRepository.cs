//Repository Clientes
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
    public class ClienteRepository : IClienteRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public ClienteRepository(IConnectionFactory connectionFactory) => _connectionFactory = connectionFactory;


        public bool Eliminar(string Identificacion)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query =
                    "DELETE FROM CLIENTES " +
                    "WHERE Identificacion = @Identificacion";

                var parameters = new DynamicParameters();
                parameters.Add("Identificacion", Identificacion);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.Text);
                return result > 0;
            }
        }
        
        public IEnumerable<Cliente> ObtenerTodos()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query =
                    "SELECT * " +
                    "FROM CLIENTES " +
                    "ORDER BY Identificacion DESC";

                var result = connection.Query<Cliente>(query, commandType: CommandType.Text);
                return result;
            };
        }

        public IEnumerable<Cliente> ObtenerPorIdentificacion(string Identificacion)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query =
                    "SELECT * " +
                    "FROM CLIENTES " +
                    "WHERE Identificacion LIKE " + "'" + @Identificacion + "%'" +
                    "ORDER BY Identificacion DESC";

                var parameters = new DynamicParameters();
                
                parameters.Add("Identificacion", Identificacion);

                var result = connection.Query<Cliente>(query, param: parameters, commandType: CommandType.Text);
                return result;
            };
        }
        
                
        public bool Actualizar(Cliente Cliente)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query =
                    "UPDATE CLIENTES " +
                    "SET " +
                        "Identificacion = @Identificacion, " +
                        "Nombre = @Nombre, " +
                        "Apellido = @Apellido, " +
                        "FechaNacimiento = @FechaNacimiento " +
                    "WHERE Identificacion = @Identificacion";

                var parameters = new DynamicParameters();
                
                parameters.Add("Identificacion", Cliente.Identificacion);
                parameters.Add("Nombre", Cliente.Nombre);
                parameters.Add("Apellido", Cliente.Apellido);
                parameters.Add("FechaNacimiento", Cliente.FechaNacimiento);
                
                var result = connection.Execute(query, param: parameters, commandType: CommandType.Text);
                return result > 0;
            }
        } 
        
        public bool Insertar(Cliente Cliente)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query =
                    "INSERT INTO CLIENTES (" +
                        "Identificacion, " +
                        "Nombre, " +
                        "Apellido, " +
                        "FechaNacimiento " +
                    ") " +
                    "VALUES(" +
                        "@Identificacion, " +
                        "@Nombre, " +
                        "@Apellido, " +
                        "@FechaNacimiento " +
                    ")";

                var parameters = new DynamicParameters();
                
                parameters.Add("Identificacion", Cliente.Identificacion);
                parameters.Add("Nombre", Cliente.Nombre);
                parameters.Add("Apellido", Cliente.Apellido);
                parameters.Add("FechaNacimiento", Cliente.FechaNacimiento);
                
                var result = connection.Execute(query, param: parameters, commandType: CommandType.Text);
                return result > 0;
            }
        } 
            
    }
}