using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BlazorCompuTronica.Data.Model;

namespace BlazorCompuTronica.Data.Service
{
    public class ClienteService : IClienteService
    {
        //Connecction Sql Server
        private readonly SqlConnectionConfiguration _configuration;

        public ClienteService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> ClienteInsert(Cliente cliente)
        {

            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("id_usuario", cliente.id_usuario, DbType.Int32);
                parameters.Add("usuario", cliente.usuario, DbType.String);
                parameters.Add("producto", cliente.producto, DbType.String);
                parameters.Add("inventario_producto", cliente.inventario_producto, DbType.String);

                const string query = @"INSERT INTO Cliente (IdCliente, NombreCliente, ApellidoCliente) VALUES (@IdCliente, @NombreCliente, @ApellidoCliente)";
                await conn.ExecuteAsync(query, new { cliente.id_usuario, cliente.usuario, cliente.producto, cliente.inventario_producto }, commandType: CommandType.Text);
            }

            return true;
        }

    }
}
