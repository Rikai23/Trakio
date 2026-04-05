using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Trakio.API
{
    /// <summary>
    /// Сервис для работы с Kinopoisk API
    /// Используется для поиска фильмов и сериалов.
    /// </summary>
    internal class KinopoiskClient : IMediaAPI
    {
        private readonly string _apiKey = ReadKeysAPI.Kinopoisk;

        private readonly HttpClient _http = new HttpClient();

        /// <inheritdoc/>
        public async Task<List<MediaData>> SearchAsync(string query)
        {
            var list = new List<MediaData>();

            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://kinopoiskapiunofficial.tech/api/v2.1/films/search-by-keyword?keyword={query}"
            );

            request.Headers.Add("X-API-KEY", _apiKey);

            var response = await _http.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                return list;

            string json = await response.Content.ReadAsStringAsync();

            JObject obj = JObject.Parse(json);

            foreach (var item in obj["films"])
            {
                var genres = new List<string>();

                if (item["genres"] != null)
                {
                    foreach (var g in item["genres"])
                    {
                        genres.Add(g["genre"]?.ToString());
                    }
                }

                string type = item["type"]?.ToString();
                var mediaType = DetectMediaType(type, genres);

                list.Add(new MediaData
                {
                    Id = item["filmId"]?.ToString(),
                    Title = item["nameRu"]?.ToString() ?? item["nameEn"]?.ToString(),
                    OriginalTitle = item["nameEn"]?.ToString(),
                    Description = item["description"]?.ToString(),
                    Year = int.TryParse(item["year"]?.ToString(), out int y) ? y : 0,
                    PosterUrl = item["posterUrl"]?.ToString(),
                    MediaType = mediaType,
                    Genres = genres
                });
            }

            return list;
        }

        private MediaType DetectMediaType(string type, List<string> genres)
        {
            string lowerGenres = string.Join(",", genres).ToLower();

            // Аниме
            if (lowerGenres.Contains("аниме") || lowerGenres.Contains("anime"))
                return MediaType.Anime;

            // Мультфильмы
            if (lowerGenres.Contains("мульт") || lowerGenres.Contains("animation"))
                return MediaType.Cartoon;

            // Сериалы
            if (type == "TV_SERIES" || type == "MINI_SERIES")
                return MediaType.Series;

            // Шоу
            if (type == "TV_SHOW")
                return MediaType.Show;

            // Фильмы
            if (type == "FILM")
                return MediaType.Movie;

            return MediaType.Other;
        }

        /// <inheritdoc/>
        public async Task<MediaData> GetDetailsAsync(string id)
        {
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://kinopoiskapiunofficial.tech/api/v2.2/films/{id}"
            );

            request.Headers.Add("X-API-KEY", _apiKey);

            var response = await _http.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                return null;

            string json = await response.Content.ReadAsStringAsync();

            JObject item = JObject.Parse(json);

            var genres = new List<string>();

            foreach (var g in item["genres"])
                genres.Add(g["genre"].ToString());

            string type = item["type"]?.ToString();
            var mediaType = DetectMediaType(type, genres);

            return new MediaData
            {
                Id = item["kinopoiskId"]?.ToString(),
                Title = item["nameRu"]?.ToString(),
                OriginalTitle = item["nameOriginal"]?.ToString(),
                Description = item["description"]?.ToString(),
                Genres = genres,
                Year = item["year"]?.ToObject<int>() ?? 0,
                PosterUrl = item["posterUrl"]?.ToString(),
                MediaType = mediaType
            };
        }
    }
}
