using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trakio.API
{
    /// <summary>
    /// Интерфейс для поиска данных для разных API
    /// </summary>
    public interface IMediaAPI
    {
        /// <summary>
        /// Поиск контента по наз.
        /// </summary>
        /// <param name="query">Название контента</param>
        /// <returns>Список найденых фильмов, сериалов и т.д.</returns>
        Task<List<MediaData>> SearchAsync(string query);

        /// <summary>
        /// Инф. о контента
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Полная инф.</returns>
        Task<MediaData> GetDetailsAsync(string id);
    }
}
