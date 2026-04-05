using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trakio.API
{
    internal class SearchContent
    {
        /// <summary>
        /// Список сервисов API
        /// </summary>
        private readonly List<IMediaAPI> _services;
        public SearchContent()
        {
            _services = new List<IMediaAPI>
            {
                new KinopoiskClient(), 
                new RawgClient()
            };
        }

        /// <summary>
        /// Выполняет глобальный поиск по всем API
        /// </summary>
        /// <param name="query">Поисковый запрос.</param>
        /// <returns>Объединенный список результатов.</returns>
        public async Task<List<MediaData>> SearchAsync(string query, MediaType? mediaType = null)
        {
            var results = new List<MediaData>();

            foreach (var service in _services)
            {
                if (mediaType.HasValue && mediaType.Value == MediaType.Game && !(service is RawgClient))
                    continue; //пропускаем Kinopoisk для игр

                if (mediaType.HasValue && mediaType.Value != MediaType.Game && service is RawgClient)
                    continue; //пропускаем RAWG для фильмов/сериалов

                var res = await service.SearchAsync(query);

                if (mediaType.HasValue)
                {
                    res = res
                        .Where(x => x.MediaType == mediaType.Value)
                        .ToList();
                }

                results.AddRange(res);
            }

            return results;
        }

    }
}
