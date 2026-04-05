using System.Drawing;
using System.Drawing.Drawing2D;

namespace Trakio.ToggleButton
{
    /// <summary>
    /// Расширения для класса Graphics
    /// Исп. для отрисовки округленных прямо-уг
    /// </summary>
    public static class GraphicsExtensions
    {
        /// <summary>
        /// Рисуем закрашенный прямо-уг со скругленными углами
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="brush">Кисть для заливки</param>
        /// <param name="bounds">Границы прямо-уг</param>
        /// <param name="radius">Радиус округления</param>
        public static void FillRoundedRectangle(this Graphics graph, Brush brush, Rectangle bounds, int radius)
        {
            using(GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
                path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
                path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();
                graph.FillPath(brush, path);
            }
        }
    }
}
