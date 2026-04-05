# 🎬 Trakio
Приложение для поиска и управления медиаконтентом с возможностью сохранения данных в локальную базу данных.

## 📌 Описание
Данный проект разработан на языке C# с использованием Windows Forms в Visual Studio.
Приложение позволяет пользователю находить медиаконтент через внешние API и сохранять его в локальную базу данных SQLite, а также добавлять записи вручную.

### 🚀 Основные возможности
- 🔍 Поиск контента через API (Kinopoisk и RAWG)
- 💾 Сохранение данных в локальную базу SQLite
- ✍️ Ручное добавление записей
- 📚 Просмотр всей добавленной библиотеки

### 🧩 Используемые технологии
- C#
- Windows Forms (WinForms)
- SQLite
- REST API (Kinopoisk, RAWG)

## 🔑 Настройка API
Для корректной работы поиска необходимо указать API-ключи: Kinopoisk API и RAWG API
Есть два варианта как это сделать:
- Рядом с exe файлом должен быть файл keyAPI.json со слекдующим содержимым:
{
  "KinopoiskApiKey": "YOUR_API_KINOPOISK",
  "RawgApiKey": "YOUR_API_RAWG"
}
- В классе ReadKeysAPI.cs вместо DefaultKey напишите свои API ключи
public static string Kinopoisk => _json?["KinopoiskApiKey"]?.ToString() ?? "DefaultKey";
public static string Rawg => _json?["RawgApiKey"]?.ToString() ?? "DefaultKey";