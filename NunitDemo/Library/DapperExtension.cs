using System.Data.OleDb;

namespace NunitDemo.Library
{
    public static class DapperExtension
    {
        public static IEnumerable<IDictionary<string, string>> QueryDictionary(this OleDbConnection connection, string query)
        {
            var data = Dapper.SqlMapper.Query(connection, query) as IEnumerable<IDictionary<string, object>>;
            return data.Select(r => r.ToDictionary(d => d.Key, d => d.Value?.ToString()));
        }
    }
}