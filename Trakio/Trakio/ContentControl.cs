using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trakio.API;

namespace Trakio
{
    public partial class ContentControl : UserControl
    {
        ComboBox _type;
        CustomTextBox.CustomTextBox _description;
        CustomTextBox.CustomTextBox _year;
        CustomTextBox.CustomTextBox _url_image;
        CustomTextBox.CustomTextBox _title;

        /// <summary>
        /// Менеджер поиска (объединяет все API)
        /// </summary>
        private SearchContent _searchManager = new SearchContent();

        /// <summary>
        /// Поле поиска
        /// </summary>
        private CustomTextBox.CustomTextBox _searchBox;

        /// <summary>
        /// Список результатов
        /// </summary>
        private ListBox _resultsList;

        /// <summary>
        /// Панель для отображения контента
        /// </summary>
        private Panel _contentPanel;

        /// <summary>
        /// Наименование выбранной категории (раздела)
        /// </summary>
        private string _name_category;

        /// <summary>
        /// Выбранная категория
        /// </summary>
        MediaType _mediaType = MediaType.Movie;

        /// <summary>
        /// Выбранные (отображаемые) данные
        /// </summary>
        MediaData _mediaData;

        public ContentControl(string name_category)
        {
            InitializeComponent();
            _name_category = name_category;
            LoadData();
        }

        /// <summary>
        /// Метод для подгрузки данных из БД для выбранной категории,
        /// для создания элементов интерфейса для тх отображения
        /// </summary>
        private void LoadData()
        {

            if(_name_category.ToLower() == "главная")
            {
                ShowMainContent();
            }
            else if (_name_category.ToLower() == "просмотр")
            {
                ShowDB();
            }
            else if (_name_category.ToLower() == "свое")
            {
                ShowMy();
            }
            else
            {
                switch (_name_category.ToLower())
                {
                    case "фильмы":
                        _mediaType = MediaType.Movie;                        
                        break;
                    case "сериалы":
                        _mediaType = MediaType.Series;
                        break;
                    case "мультфильмы":
                        _mediaType = MediaType.Cartoon;
                        break;
                    case "аниме":
                        _mediaType = MediaType.Anime;
                        break;
                    case "шоу":
                        _mediaType = MediaType.Show;
                        break;
                    case "игры":
                        _mediaType = MediaType.Game;
                        break;
                }
                InitSearchUI();
            }
        }

        /// <summary>
        /// Метод отображающий главную страницу
        /// </summary>
        private void ShowMainContent()
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(950, 633);
            pictureBox.Left = (this.ClientSize.Width - pictureBox.Width) / 2;
            pictureBox.Top = (this.ClientSize.Height - pictureBox.Height) / 2;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Image = Properties.Resources.welcome;
            Controls.Add(pictureBox);
        }



        /// <summary>
        /// Инициализация UI поиска
        /// </summary>
        private void InitSearchUI()
        {
            //Поиск

            Label textSearch = new Label()
            {
                Size = new Size(60, 30),
                Location = new Point(20, 27),
                ForeColor = Color.Fuchsia,
                Font = new Font("Segoe UI", 11),
                Text = "Поиск: "
            };

            _searchBox = new CustomTextBox.CustomTextBox()
            {
                Size = new Size(400, 40),
                Location = new Point(85, 20),
                UnderlinedStyle = true,
                BackColor = Color.FromArgb(34, 33, 74),
                BorderColor = Color.Fuchsia,
                ForeColor = Color.Fuchsia,
                Font = new Font("Segoe UI", 11)
            };
            _searchBox.TextChanged += SearchBox_TextChanged;

            // Список результатов
            _resultsList = new ListBox
            {
                Width = 500,
                Height = 600,
                Location = new Point(20, 60),
                BackColor = Color.FromArgb(34, 33, 74),
                ForeColor = Color.Fuchsia,
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 11),
            };
            _resultsList.SelectedIndexChanged += ResultsList_SelectedIndexChanged;


            // Панель для карточки
            _contentPanel = new Panel
            {
                Width = 600,
                Height = 550,
                Location = new Point(550, 20),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.None
            };


            Button _add = new Button()
            {
                Text = "Добавить",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Size = new Size(110, 40),
                Location = new Point(1040, 590),
                ForeColor = Color.Fuchsia,
                BackColor = Color.White,
            };
            _add.Click += add_Click;


            Controls.Add(textSearch);
            Controls.Add(_searchBox);
            Controls.Add(_resultsList);
            Controls.Add(_contentPanel);
            Controls.Add(_add);
        }


        /// <summary>
        /// Поиск при вводе текста (автокомплит)
        /// </summary>
        private async void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string query = _searchBox.Text;

            if (query.Length < 1)
                return;

            var results = await _searchManager.SearchAsync(query, _mediaType);

            _resultsList.DataSource = results;
            _resultsList.DisplayMember = "Title";
        }

        /// <summary>
        /// Срабатывает при выборе элемента из списка
        /// </summary>
        private void ResultsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_resultsList.SelectedItem is MediaData content)
            {
                _mediaData = content;
                ShowContent(content);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки добавить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_Click(object sender, EventArgs e)
        {          
            bool added = MainForm.db.Add(_mediaData);

            if (added)
            {
                MessageBox.Show(_mediaData.Title + " добавлен в БД");
            }
            else
            {
                MessageBox.Show(_mediaData.Title + " уже добавлен");
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки добавить свое
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addMy_Click(object sender, EventArgs e)
        {
            try
            {
                _mediaData = new MediaData();
                _mediaData.Title = _title.Text;
                _mediaData.Year = Convert.ToInt32(_year.Text);
                _mediaData.PosterUrl = _url_image.Text;
                _mediaData.Description = _description.Text;
                _mediaData.ApiId = "1";
                _mediaData.Genres = new List<string>() { "---" };
                _mediaData.OriginalTitle = _title.Text;
                _mediaData.MediaType = (MediaType)_type.SelectedIndex;

                bool added = MainForm.db.Add(_mediaData);

                if (added)
                {
                    MessageBox.Show(_mediaData.Title + " добавлен в БД");
                }
                else
                {
                    MessageBox.Show(_mediaData.Title + " уже добавлен");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка! Проверьте данные.");
            }
            
        }



        /// <summary>
        /// Обработчик нажатия кнопки УДАЛИТЬ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_Click(object sender, EventArgs e)
        {
            string _title = _mediaData.Title;

            bool added = MainForm.db.DeleteMediaById(_mediaData.Id);

            if (added)
            {
                MessageBox.Show($"{_title} успешно удален из БД", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"{_title } не найден в БД", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Controls.Clear();
            ShowDB();
        }

        /// <summary>
        /// Отображает выбранный контент
        /// </summary>
        private void ShowContent(MediaData content)
        {
            _contentPanel.Controls.Clear();

            var card = CreateContentCard(content);

            _contentPanel.Controls.Add(card);
        }

        /// <summary>
        /// Создает визуальную карточку контента
        /// </summary>
        private Panel CreateContentCard(MediaData content)
        {
            Panel panel = new Panel
            {
                Width = 600,
                Height = 520,
                BorderStyle = BorderStyle.FixedSingle
            };

            PictureBox poster = new PictureBox
            {
                Width = 120,
                Height = 180,
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            Label title = new Label
            {
                Text = $"{content.Title} ({content.Year})",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(140, 10),
                AutoSize = true
            };

            CustomTextBox.CustomTextBox description = new CustomTextBox.CustomTextBox
            {
                Text = WrapText(content.Description, 50),
                Multiline = true,
                Size = new Size(450, 500),
                Location = new Point(140, 60),
                UnderlinedStyle = true,
                BackColor = Color.FromArgb(34, 33, 74),
                BorderColor = Color.FromArgb(34, 33, 74),
                ForeColor = Color.White,
                WordWrap = true,
                Font = new Font("Segoe UI", 11)
            };

            CustomTextBox.CustomTextBox genres = new CustomTextBox.CustomTextBox
            {
                Text = string.Join(", ", (content.Genres ?? new List<string>()).Take(3)).ToUpper(),
                Multiline = true,
                Size = new Size(450, 400),
                Location = new Point(140, 30),
                UnderlinedStyle = true,
                BackColor = Color.FromArgb(34, 33, 74),
                BorderColor = Color.Fuchsia,
                ForeColor = Color.White,
                WordWrap = true,
                Font = new Font("Segoe UI", 11)
            };

            // Загрузка постера
            if (!string.IsNullOrEmpty(content.PosterUrl))
            {
                try
                {
                    using (var wc = new WebClient())
                    {
                        var stream = wc.OpenRead(content.PosterUrl);
                        poster.Image = Image.FromStream(stream);
                    }
                }
                catch
                {
                    // если ошибка загрузки — игнорируем
                }
            }

            panel.Controls.Add(poster);
            panel.Controls.Add(title);
            panel.Controls.Add(description);
            panel.Controls.Add(genres);

            return panel;
        }


        /// <summary>
        /// Выравнивание текста по ширине для корректно отображения
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxLineLength"></param>
        /// <returns></returns>
        private string WrapText(string text, int maxLineLength)
        {
            try
            {
                var words = text.Split(' ');
                var lines = new List<string>();
                string currentLine = "";

                foreach (var word in words)
                {
                    if ((currentLine + word).Length > maxLineLength)
                    {
                        lines.Add(currentLine);
                        currentLine = word + " ";
                    }
                    else
                    {
                        currentLine += word + " ";
                    }
                }

                if (!string.IsNullOrWhiteSpace(currentLine))
                    lines.Add(currentLine);

                return string.Join(Environment.NewLine, lines);
            }
            catch
            {
                return "Описание отсутствует";
            }
        }


        /// <summary>
        /// Отображение вкладки ПРОСМОТР
        /// </summary>
        private void ShowDB()
        {
            _type = new ComboBox()
            {
                //Text = "Фильмы",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Size = new Size(150, 40),
                Location = new Point(30, 20),
                ForeColor = Color.Fuchsia,
                BackColor = Color.White,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            _type.Items.AddRange(new string[] { "Фильмы", "Сериалы", "Мультфильмы", "Аниме", "Шоу", "Игры"});
            _type.SelectedIndex = 0;
            _type.SelectedIndexChanged += _type_SelectedIndexChanged1;


            var items = MainForm.db.GetByType(MediaType.Movie).OrderBy(m => m.Title).ToList();

            _resultsList = new ListBox
            {
                Width = 500,
                Height = 500,
                Location = new Point(30, 80),
                BackColor = Color.FromArgb(34, 33, 74),
                ForeColor = Color.Fuchsia,
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 11),
            };

            _resultsList.DataSource = items;
            _resultsList.DisplayMember = "Title";

            _resultsList.SelectedIndexChanged += ResultsList_SelectedIndexChanged;


            _contentPanel = new Panel
            {
                Width = 600,
                Height = 550,
                Location = new Point(550, 20),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            if(items.Count > 0)
            {
                _mediaData = items[0];
                ShowContent(items[0]);
            }

            Button _delete = new Button()
            {
                Text = "Удалить",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Size = new Size(110, 40),
                Location = new Point(1040, 590),
                ForeColor = Color.Fuchsia,
                BackColor = Color.White,
            };
            _delete.Click += delete_Click;


            Controls.Add(_type);
            Controls.Add(_resultsList);
            Controls.Add(_contentPanel);
            Controls.Add(_delete);
        }

        /// <summary>
        /// Отображение вкладки СВОЕ
        /// </summary>
        private void ShowMy()
        {
            Label text_title = new Label()
            {
                Size = new Size(120, 30),
                Location = new Point(20, 27),
                ForeColor = Color.Fuchsia,
                Font = new Font("Segoe UI", 11),
                Text = "Наименование: "
            };

            _title = new CustomTextBox.CustomTextBox()
            {
                Text = "Наименование",
                Size = new Size(400, 40),
                Location = new Point(145, 20),
                UnderlinedStyle = true,
                BackColor = Color.FromArgb(34, 33, 74),
                BorderColor = Color.Fuchsia,
                ForeColor = Color.Fuchsia,
                Font = new Font("Segoe UI", 11)
            };

            Label text_url_image = new Label()
            {
                Size = new Size(200, 30),
                Location = new Point(20, 550),
                ForeColor = Color.Fuchsia,
                Font = new Font("Segoe UI", 11),
                Text = "Ссылка на изображение: "
            };

            _url_image = new CustomTextBox.CustomTextBox()
            {
                Text = "https://avatars.mds.yandex.net/i?id=534c74a2861bbb221dc75523d5bd4075_l-1992980-images-thumbs&n=13",
                Size = new Size(900, 40),
                Location = new Point(220, 544),
                UnderlinedStyle = true,
                BackColor = Color.FromArgb(34, 33, 74),
                BorderColor = Color.Fuchsia,
                ForeColor = Color.Fuchsia,
                Font = new Font("Segoe UI", 11)
            };

            Label text_year = new Label()
            {
                Size = new Size(110, 30),
                Location = new Point(20, 600),
                ForeColor = Color.Fuchsia,
                Font = new Font("Segoe UI", 11),
                Text = "Год выпуска: "
            };

            _year = new CustomTextBox.CustomTextBox()
            {
                Text = "2026",
                Size = new Size(60, 40),
                Location = new Point(125, 594),
                UnderlinedStyle = true,
                BackColor = Color.FromArgb(34, 33, 74),
                BorderColor = Color.Fuchsia,
                ForeColor = Color.Fuchsia,
                Font = new Font("Segoe UI", 11)
            };

            Label text_description = new Label()
            {
                Size = new Size(82, 30),
                Location = new Point(20, 80),
                ForeColor = Color.Fuchsia,
                Font = new Font("Segoe UI", 11),
                Text = "Описание: "
            };

            _description = new CustomTextBox.CustomTextBox()
            {
                Text = "Описание отсутствует",
                Multiline = true,
                Size = new Size(450, 400),
                Location = new Point(110, 73),
                BackColor = Color.FromArgb(34, 33, 74),
                BorderColor = Color.Fuchsia,
                ForeColor = Color.Fuchsia,
                WordWrap = true,
                Font = new Font("Segoe UI", 11)
            };

            Label text_type = new Label()
            {
                Size = new Size(90, 30),
                Location = new Point(20, 500),
                ForeColor = Color.Fuchsia,
                Font = new Font("Segoe UI", 11),
                Text = "Категория: "
            };

            _type = new ComboBox()
            {
                //Text = "Фильмы",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Size = new Size(150, 40),
                Location = new Point(120, 500),
                ForeColor = Color.Fuchsia,
                BackColor = Color.White,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            _type.Items.AddRange(new string[] { "Фильм", "Сериал", "Мультфильм", "Аниме", "Шоу", "Игра" });
            _type.SelectedIndex = 0;

            Button _add = new Button()
            {
                Text = "Добавить",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Size = new Size(110, 40),
                Location = new Point(1040, 590),
                ForeColor = Color.Fuchsia,
                BackColor = Color.White,
            };
            _add.Click += addMy_Click;

            Controls.Add(_add);
            Controls.Add(text_title);
            Controls.Add(_title);
            Controls.Add(text_description);
            Controls.Add(_description);
            Controls.Add(_type);
            Controls.Add(text_type);
            Controls.Add(text_url_image);
            Controls.Add(_url_image);
            Controls.Add(text_year);
            Controls.Add(_year);
        }

        /// <summary>
        /// Обработчик выбора типа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _type_SelectedIndexChanged1(object sender, EventArgs e)
        {
            MediaType selectedMediaType = (MediaType)_type.SelectedIndex;

            var items = MainForm.db.GetByType(selectedMediaType).OrderBy(m => m.Title).ToList();

            _resultsList.DataSource = items;
            _resultsList.DisplayMember = "Title";
        }




    }
}
