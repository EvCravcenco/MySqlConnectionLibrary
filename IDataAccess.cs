using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IDataAccess
    {
        Task<List<T>> LoadDataAsync<T, U>(string sql, U parameters, string connectionString);
        Task ModifyDataAsync<T>(string sql, T parameters, string connectionString);
    }
}