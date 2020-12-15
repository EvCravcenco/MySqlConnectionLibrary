using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class DataAccess : IDataAccess
    {
        /// <summary>
        /// for general select operations
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public async Task<List<T>> LoadDataAsync<T, U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(sql, parameters);

                return rows.ToList();
            }
        }

        /// <summary>
        /// Can be user for Insert, Update,  Delete statements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">sql query to be executed</param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public Task ModifyDataAsync<T>(string sql, T parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
               return connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
