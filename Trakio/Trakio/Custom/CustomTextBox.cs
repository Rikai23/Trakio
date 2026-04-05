using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trakio.CustomTextBox
{
    public partial class CustomTextBox : UserControl
    {
        /// <summary>
        /// Цвет границы
        /// </summary>
        private Color borderColor = Color.MediumSlateBlue;
        /// <summary>
        /// Толщина границы
        /// </summary>
        private int borderSize = 2;
        /// <summary>
        /// Стиль поля
        /// </summary>
        private bool underlinedStyle = false;

        public CustomTextBox()
        {
            InitializeComponent();
            textBox1.TextChanged += TextBox1_TextChanged;
            textBox1.Click += TextBox1_Click;
            textBox1.MouseEnter += TextBox1_MouseEnter;
            textBox1.MouseLeave += TextBox1_MouseLeave;
        }


        //Св-ва

        [Category("UserProperties")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("UserProperties")]
        public int BorderSize
        {
            get
            {
                return borderSize;
            }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("UserProperties")]
        public bool UnderlinedStyle
        {
            get
            {
                return underlinedStyle;
            }
            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }

        [Category("UserProperties")]
        public bool Multiline
        {
            get
            {
                return textBox1.Multiline;
            }
            set
            {
                textBox1.Multiline  = value;
            }
        }

        [Category("UserProperties")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }

        [Category("UserProperties")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }

        [Category("UserProperties")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                textBox1.Font = value;
                if(this.DesignMode)
                    UpdateControlHeight();
            }
        }

        [Category("UserProperties")]
        public string Text
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }

        [Category("UserProperties")]
        public bool WordWrap
        {
            get
            {
                return textBox1.WordWrap;
            }
            set
            {
                textBox1.WordWrap = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                if (underlinedStyle) //Рисуем просто внизу линию
                    graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                else //Рисуем прямо-уг в качестве границы
                    graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
                UpdateControlHeight();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        /// <summary>
        /// Обновляем высоту на основе высоты текста в текстовом поле
        /// </summary>
        private void UpdateControlHeight()
        {
            if (textBox1.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline = false;

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            this.OnTextChanged(e);
        }

        private void TextBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void TextBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void TextBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }
    }
}
