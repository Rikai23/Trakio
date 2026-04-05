using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Trakio.ToggleButton
{
    /// <summary>
    /// ToggleButton (On/Off)
    /// </summary>
    class ToggleButton : UserControl
    {
        /// <summary>
        /// Событиае вызываемое при изменении состояния Checked
        /// </summary>
        public event EventHandler CheckedChanged;

        /// <summary>
        /// Цвет фона переключателя в состоянии On
        /// </summary>
        [Category("Appearance")]
        public Color OnBackColor { get; set; } = Color.MediumSlateBlue;

        /// <summary>
        /// Цвет фона переключателя в состоянии Off
        /// </summary>
        [Category("Appearance")]
        public Color OffBackColor { get; set; } = Color.DarkGray;

        /// <summary>
        /// Цвет бегунка
        /// </summary>
        [Category("Appearance")]
        public Color ToggleColor { get; set; } = Color.White;

        /// <summary>
        /// Флаг состояния кнопки (On/Off)
        /// </summary>
        private bool isChecked = false;

        /// <summary>
        /// Состояние переключателя (On/Off) вызывается перерисовка и событие CheckedChange
        /// </summary>
        [Category("Behavior")]
        public bool Checked
        {
            get
            {
                return isChecked;
            }
            set
            {
                isChecked = value;
                Invalidate();
                CheckedChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Установка размеров, курсора и двойной буфеоизации
        /// </summary>
        public ToggleButton()
        {
            this.MinimumSize = new Size(45, 22);
            this.Size = new Size(50, 25);
            this.Cursor = Cursors.Hand;
            this.DoubleBuffered = true;
        }

        /// <summary>
        /// Метод ресмует фон и бегунок
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int toggleSize = Height - 4;

            Rectangle backRect = new Rectangle(0, 0, Width - 1, Height - 1);
            
            using(Brush backBrush = new SolidBrush(isChecked ? OnBackColor : OffBackColor))
            {
                graph.FillRoundedRectangle(backBrush, backRect, Height);
            }

            int toggleX = isChecked ? Width - toggleSize - 2 : 2;
            Rectangle toggleRect = new Rectangle(toggleX, 2, toggleSize, toggleSize);

            using (Brush toggleBrush = new SolidBrush(ToggleColor))
            {
                graph.FillEllipse(toggleBrush, toggleRect);
            }
        }

        /// <summary>
        /// Обработчик клика по форме
        /// Осуществляет инвертациюю состояния переключателя
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
            Checked = !Checked;
            base.OnClick(e);
        }

    }
}
