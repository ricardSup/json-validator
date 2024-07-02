using System;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace jsonParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\richard.suprayogi\source\repos\jsonParser\data.json"; // Ubah ke path file JSON kamu

            try
            {
                // Membaca konten file JSON
                string jsonWithComments = File.ReadAllText(filePath);

                // Menghapus komentar dari JSON (// atau /* */)
                string jsonWithoutComments = RemoveJsonComments(jsonWithComments);

                // Memparsing JSON yang sudah bersih dari komentar
                var parsedData = JsonConvert.DeserializeObject(jsonWithoutComments);

                // Mengonversi hasil parsing ke format JSON standar
                string jsonString = JsonConvert.SerializeObject(parsedData, Formatting.Indented);

                // Menampilkan hasil JSON
                Console.WriteLine(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing JSON: {ex.Message}");
            }
        }

        static string RemoveJsonComments(string json)
        {
            // Menghapus single line comments // dan multi line comments /* */
            var regexSingleLineComments = new Regex(@"\/\/.*?$|\/\*.*?\*\/", RegexOptions.Multiline);
            return regexSingleLineComments.Replace(json, string.Empty);
        }
    }
}
