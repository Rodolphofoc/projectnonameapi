using Dapper;
using Microsoft.Extensions.Options;
using project.noname.core;
using project.noname.data.Helpers;
using project.noname.data.Interface;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace project.noname.data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ConfigurationManager _configurationManager;

        public string ConnectionString { get; set; }


        public Repository(ConfigurationManager configuration)
        {
            ConnectionString = new DbSettings("projectnoname").SqlConnectionString();
        }

        /// <summary>
        /// Realiza uma consulta no banco de dados
        /// </summary>
        /// <typeparam name="TEntity">Objeto experado</typeparam>
        /// <param name="query">query a ser executada</param>
        /// <param name="param">parametros</param>
        /// <returns>Retorna o primeiro item da consulta ou null</returns>
        public TEntity FirstOfDefault<TEntity>(string query, object param = null)
        {
            using (var conexao = new SqlConnection(ConnectionString))
            {
                return conexao.QueryFirstOrDefault<TEntity>(query, param);
            }
        }

        public IEnumerable<TEntity> GetAll<TEntity>(string query, object param = null)
        {
            using (var conexao = new SqlConnection(ConnectionString))
            {
                return conexao.Query<TEntity>(query, param);
            }
        }

        public void Execute(string query, object param = null)
        {
            using (var conexao = new SqlConnection(ConnectionString))
            {
                conexao.ExecuteScalar(query, param);
            }

        }



    }
}
