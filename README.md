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

Для корректной работы поиска необходимо указать API-ключи:

- Kinopoisk API  
- RAWG API  

Есть два варианта:

### 1. Через файл `keyAPI.json`

Рядом с `.exe` файлом должен находиться файл `keyAPI.json` со следующим содержимым:

```json
{
  "KinopoiskApiKey": "YOUR_API_KINOPOISK",
  "RawgApiKey": "YOUR_API_RAWG"
}
```

### 2. Через класс ReadKeysAPI.cs

Вместо  DefaultKey напишите свои API ключи

```csharp
public static string Kinopoisk => _json?["KinopoiskApiKey"]?.ToString() ?? "DefaultKey";
public static string Rawg => _json?["RawgApiKey"]?.ToString() ?? "DefaultKey";
```