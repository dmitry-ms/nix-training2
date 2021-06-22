using System.Collections;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Task_2_Ado.net
{
    public class Serializer
    {

        public static async Task SaveData<T>(T entity) where T : ICollection
        {
            var options = new JsonSerializerOptions { WriteIndented = true };

            using (FileStream fs = new FileStream($"data\\{GetFileName(typeof(T).ToString())}.json", FileMode.Create))
            {
                await JsonSerializer.SerializeAsync(fs, entity, options);
                Thread.Sleep(5000);
            }
        }

        public static async Task<T> ReadData<T>()
        {
            using (FileStream fs = new FileStream($"data\\{GetFileName(typeof(T).ToString())}.json", FileMode.Open))
            {
                var res = await JsonSerializer.DeserializeAsync<T>(fs);
                Thread.Sleep(5000);
                return res;
            }
        }


        private static string GetFileName(string typeName)
        {
            var fileName = $"CollectionOf{Regex.Match(typeName, @"w*.(\w*)\]$").Groups[1].Value}";

            return fileName;
        }
    }
}
