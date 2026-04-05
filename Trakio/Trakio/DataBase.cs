using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trakio.API;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Trakio
{
    public class DataBase
    {
        /// <summary>
        /// Наименование и версия БД
        /// </summary>
        private readonly string _connectionString = "Data Source=media.db";

        public DataBase()
        {
            InitializeDatabase();
        }

        /// <summary>
        /// Создание БД и таблицы
        /// </summary>
        private void InitializeDatabase()
        {
            using (var connection = new  SQLiteConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                    @"
                    CREATE TABLE IF NOT EXISTS Media (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        ApiId TEXT,
                        Title TEXT,
                        OriginalTitle TEXT,
                        Description TEXT,
                        Year INTEGER,
                        PosterUrl TEXT,
                        MediaType TEXT,
                        Genres TEXT
                    );
                    ";

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Проверяем есть ли запись уже в БД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(string id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT COUNT(*) FROM Media WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", id);

                    long count = (long)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        /// <summary>
        /// Добавление значения в БД
        /// </summary>
        /// <param name="media"></param>
        /// <returns></returns>
        public bool Add(MediaData media)
        {
            if (Exists(media.Id))
                return false;

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                    @"
                    INSERT INTO Media 
                    (ApiId, Title, OriginalTitle, Description, Year, PosterUrl, MediaType, Genres)
                    VALUES 
                    (@apiId, @title, @originalTitle, @description, @year, @poster, @type, @genres)
                    ";

                    command.Parameters.AddWithValue("@apiId", media.Id);
                    command.Parameters.AddWithValue("@title", media.Title ?? "");
                    command.Parameters.AddWithValue("@originalTitle", media.OriginalTitle ?? "");
                    command.Parameters.AddWithValue("@description", media.Description ?? "");
                    command.Parameters.AddWithValue("@year", media.Year);
                    command.Parameters.AddWithValue("@poster", media.PosterUrl ?? "");
                    command.Parameters.AddWithValue("@type", media.MediaType.ToString());
                    command.Parameters.AddWithValue("@genres", string.Join(",", media.Genres ?? new List<string>()));

                    command.ExecuteNonQuery();
                }
            }

            return true;
        }



        /// <summary>
        /// Получить всё по типу (фильмы, сериалы, игры)
        /// </summary>
        public List<MediaData> GetByType(MediaType type)
        {
            var list = new List<MediaData>();

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Media WHERE MediaType = @type";
                    command.Parameters.AddWithValue("@type", type.ToString());

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new MediaData
                            {
                                Id = reader["Id"].ToString(),
                                Title = reader["Title"].ToString(),
                                OriginalTitle = reader["OriginalTitle"].ToString(),
                                Description = reader["Description"].ToString(),
                                Year = reader["Year"] != DBNull.Value ? Convert.ToInt32(reader["Year"]) : 0,
                                PosterUrl = reader["PosterUrl"].ToString(),
                                MediaType = (MediaType)Enum.Parse(typeof(MediaType), reader["MediaType"].ToString()),
                                Genres = reader["Genres"].ToString().Split(',').ToList()
                            });
                        }
                    }
                }
            }

            return list;
        }


        /// <summary>
        /// Удаляем элемент из БД
        /// </summary>
        /// <param name="id">Id элемента</param>
        public bool DeleteMediaById(string id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Media WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                        return false;                    
                    else
                        return true;
                }
            }
        }

    }
}
