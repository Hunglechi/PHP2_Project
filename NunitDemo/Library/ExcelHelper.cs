using System.Data.OleDb;

namespace NunitDemo.Library;

public class ExcelHelper
{
    public static IEnumerable<IDictionary<string, string>> GetTestData(string fileName, string sheetName, string columnName, string columnValue)
    {
        var connectionString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);
        using (var connection = new OleDbConnection(connectionString))
        {
            connection.Open();
            var query = string.Format("select * from [{0}$] where {1}='{2}'", sheetName, columnName, columnValue);
            var testData = connection.QueryDictionary(query);
            connection.Close();
            return testData;
        }
    }
}