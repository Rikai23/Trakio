using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trakio.API
{
    public enum MediaType
    {
        Movie,
        Series,
        Cartoon,
        Anime,
        Show,
        Game,
        Other
    }


    /// <summary>
    /// Модель с данными для разных API
    /// </summary>
    public class MediaData
    {
        /// <summary>
        /// Индентификатор контента в БД
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Индентификатор контента в API
        /// </summary>
        public string ApiId { get; set; }

        /// <summary>
        /// Название контента
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Альтернативное название (например оригинальное)
        /// </summary>
        public string OriginalTitle { get; set; }

        /// <summary>
        /// Краткое описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Список жанров
        /// </summary>
        public List<string> Genres { get; set; }

        /// <summary>
        /// Год выпуска
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// URL постера
        /// </summary>
        public string PosterUrl { get; set; }

        /// <summary>
        /// Тип контента
        /// Movie, Anime, Game, Seriesб Show
        /// </summary>
        public MediaType MediaType { get; set; }
    }
}
