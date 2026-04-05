using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Trakio.API
{
    internal class RawgClient : IMediaAPI
    {
        private readonly string _apiKey = ReadKeysAPI.Rawg;
        private readonly HttpClient _http = new HttpClient();


        /// <inheritdoc/>
        public async Task<List<MediaData>> SearchAsync(string query)
        {
            var list = new List<MediaData>();

            var response = await _http.GetAsync($"https://api.rawg.io/api/games?key={_apiKey}&search={Uri.EscapeDataString(query)}");
            if (!response.IsSuccessStatusCode)
                return list;

            string json = await response.Content.ReadAsStringAsync();
            JObject obj = JObject.Parse(json);

            foreach (var item in obj["results"])
            {
                var genres = item["genres"]?.Select(g => g["name"].ToString()).ToList() ?? new List<string>();

                string released = item["released"]?.ToString();
                string rating = item["rating"]?.ToString();

                string shortDescription =
                    $"Жанры: {string.Join(", ", genres)}    " +
                    $"Дата выхода: {released}   " +
                    $"Рейтинг: {rating}";

                list.Add(new MediaData
                {
                    Id = item["id"]?.ToString(),
                    Title = item["name"]?.ToString(),
                    OriginalTitle = item["name"]?.ToString(),
                    Description = shortDescription,
                    Year = item["released"] != null && DateTime.TryParse(item["released"].ToString(), out var date) ? date.Year : 0,
                    PosterUrl = item["background_image"]?.ToString(),
                    Genres = genres,
                    MediaType = MediaType.Game
                });
            }

            return list;
        }

        /// <inheritdoc/>
        public async Task<MediaData> GetDetailsAsync(string id)
        {
            var response = await _http.GetAsync($"https://api.rawg.io/api/games/{id}?key={_apiKey}");
            if (!response.IsSuccessStatusCode)
                return null;

            string json = await response.Content.ReadAsStringAsync();
            JObject item = JObject.Parse(json);

            var genres = item["genres"]?.Select(g => g["name"].ToString()).ToList() ?? new List<string>();

            string released = item["released"]?.ToString();
            string rating = item["rating"]?.ToString();

            string shortDescription =
                $"Жанры: {string.Join(", ", genres)}    " +
                $"Дата выхода: {released}\n     " +
                $"Рейтинг: {rating}";

            return new MediaData
            {
                Id = item["id"]?.ToString(),
                Title = item["name"]?.ToString(),
                OriginalTitle = item["name"]?.ToString(),
                Description = shortDescription,
                Year = item["released"] != null && DateTime.TryParse(item["released"].ToString(), out var date) ? date.Year : 0,
                PosterUrl = item["background_image"]?.ToString(),
                Genres = genres,
                MediaType = MediaType.Game
            };
        }
    }
}
