using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NunitDemo.Library
{
    public static class JsonHelper
    {
        public static IEnumerable<object[]> GetTestDataFromJson(string jsonFile, string propertyName)
        {
            var path = Path.IsPathRooted(jsonFile)
                ? jsonFile
                : Path.GetRelativePath(Directory.GetCurrentDirectory(), jsonFile);

            var fileData = File.ReadAllText(jsonFile);

            if (string.IsNullOrEmpty(propertyName))
            {
                return JsonConvert.DeserializeObject<List<object[]>>(fileData);
            }

            var allData = JObject.Parse(fileData);
            var data = allData[propertyName];
            return data.ToObject<List<object[]>>();
        }
    }
}
