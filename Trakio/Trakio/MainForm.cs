using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Trakio
{
    public partial class MainForm : Form
    {
        public static DataBase db = new DataBase();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWndd, int wMsg, int wParam, int iParam);

        CheckEthernet checkEthernet;

        /// <summary>
        /// Создание экземпляра ToggleButton
        /// </summary>
        ToggleButton.ToggleButton toggle = new ToggleButton.ToggleButton
        {
            Location = new Point(120, 27),
            OnBackColor = Color.FromArgb(0, 128, 0),
            OffBackColor = Color.Gray
        };

        //Поля для подсветки нажатой кнопки
        private Button currentBtn;
        private Panel leftBorderBtn;

        /// <summary>
        /// Флаг полноэкранного режима (при запуске всегда оконный режим)
        /// </summary>
        bool isFullScreen = false;

        /// <summary>
        /// Цвета подстветки соответствующей выюранной категории боковой панели
        /// </summary>           
        private readonly Color[] RGBColors = new Color[]
        {
            Color.FromArgb(172, 126, 241),
            Color.FromArgb(249, 118, 176),
            Color.FromArgb(253, 138, 114),
            Color.FromArgb(95, 77, 221),
            Color.FromArgb(249, 88, 155),
            Color.FromArgb(24, 161, 251),
            Color.FromArgb(249, 118, 76),
            Color.FromArgb(241, 18, 176),
        };


        public MainForm()
        {
            InitializeComponent();

            //Настройки формы при запуске
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panel_Menu.Controls.Add(leftBorderBtn);
            this.FormBorderStyle = FormBorderStyle.None;
            toggle.CheckedChanged += Toggle_Click;
            panel_TitleBar.Controls.Add(toggle);
            checkEthernet = new CheckEthernet();
            checkEthernet.EthernetStatusChanged += status =>
            {
                UpdateEthernetStatus(status);
            };
            ContentControl content = new ContentControl("Главная");
            LoadControl(content);
        }


        /// <summary>
        /// Метод отображения активной кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="color"></param>
        private void ActivateButtom(object sender, Color color)
        {
            if(sender != null)
            {
                DisableButton();
                currentBtn = (Button)sender;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;

                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        /// <summary>
        /// Метод возвращения исходного состояния кнопки
        /// </summary>
        private void DisableButton()
        {
            if(currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
            }
        }

        /// <summary>
        /// Метод отвечающий за вход/выход в/из режим "Во весь экран" 
        /// </summary>
        private void FullScreen()
        {
            if (!isFullScreen)
            {
                this.Bounds = Screen.PrimaryScreen.Bounds;
                isFullScreen = true;
            }
            else
            {
                this.ClientSize = new Size(1400, 747);
                this.CenterToScreen();
                isFullScreen = false;
            }
        }

        /// <summary>
        /// Загружаем переданный элемент в panel_Content, очищая ее перд этим
        /// </summary>
        /// <param name="control"></param>
        private void LoadControl(UserControl control)
        {
            panel_Content.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panel_Content.Controls.Add(control);
        }

        /// <summary>
        /// Метод обновления статуса Ethernet подключения
        /// </summary>
        /// <param name="status"></param>
        private void UpdateEthernetStatus(bool status)
        {
            panel_StatusEthernet.BackColor = status
                ? Color.FromArgb(46, 204, 113) //Если есть подключение, то зеленый
                : Color.FromArgb(231, 76, 60); //Если нет поджключения, то красный

            lbl_StatusEthernet.Text = status
                ? "Есть подключение"
                : "Нет подключения";
        }


        /// <summary>
        /// Обработчик нажатия кнопок: ФИЛЬМЫ, СЕРИАЛЫ, МУЛЬТФИЛЬМЫ, АНИМЕ, ИГРЫ, ПРОВЕРКА
        /// Подсвечиваем выбранную кнопку и загружаем ссотв. контент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OpenCat_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Button btn = sender as Button;            
            int indexRGB = 0;
            int.TryParse(btn.Tag?.ToString(), out indexRGB);
            ActivateButtom(sender, RGBColors[indexRGB]);

            ContentControl content = new ContentControl(btn.Text);
            LoadControl(content);
            Cursor = Cursors.Default;
        }
                

        /// <summary>
        /// Обработчик нажатия иконки приложения (переход на главную страницу)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Home_Click(object sender, EventArgs e)
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            ContentControl content = new ContentControl("Главная");
            LoadControl(content);
        }

        /// <summary>
        /// Обработчик зажатой кнопки мыши на панели TitleBar
        /// В данном обработчике организована возможность перемещения формы, путем нажатия по панели и ёё перетаскивания
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isFullScreen)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки закрытия приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Обработчик клика Toggle во весь экран
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Toggle_Click(object sender, EventArgs e)
        {
            ToggleButton.ToggleButton toggle = sender as ToggleButton.ToggleButton;

            if (toggle == null)
                return;
            else
                FullScreen();

        }
    }
}
