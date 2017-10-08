using System.IO;
using Newtonsoft.Json;

namespace OfxTest.TestData
{
    public static class Utilies
    {
        public static CurrencyData Get()
        {
            const string jsonFilePath = @"TestData/Data/Prod_Data.json";
            
            using (var file = File.OpenText(string.Format(jsonFilePath)))
            {
                var serializer = new JsonSerializer();
                return (CurrencyData) serializer.Deserialize(file, typeof(CurrencyData));
            }
            
        }
    }
}
