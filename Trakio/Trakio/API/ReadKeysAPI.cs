using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trakio.API
{
    /// <summary>
    /// Чтение файла с ключами API при запуске приложения
    /// </summary>
    public static class ReadKeysAPI
    {
        private static JObject _json;

        public static string Kinopoisk => _json?["KinopoiskApiKey"]?.ToString() ?? "DefaultKey";
        public static string Rawg => _json?["RawgApiKey"]?.ToString() ?? "DefaultKey";

        static ReadKeysAPI()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "keyAPI.json");

            if (!File.Exists(path))
            {
                _json = null;
                MessageBox.Show("Файл с ключами API не найден");
            }
            else
            {
                string json = File.ReadAllText(path);
                _json = JObject.Parse(json);
            }
        }
    }
}
