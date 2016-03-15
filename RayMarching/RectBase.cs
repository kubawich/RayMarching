using System;
using System.Drawing;

namespace RayMarching
{
    public class RectBase : Rect
    {
        private SizeF _size;
        /// <summary>
        /// Konstruktor obiektu
        /// </summary>
        /// <param name="center">Określa położenie obiektu w przestrzeni(float)</param>
        /// <param name="color">Określa kolor obiektu</param>
        /// <param name="size">Określa rozmiar obiektu(float)</param>
        public RectBase(PointF center, Color color, SizeF size) : base(center, color)
        {
            _size = size;
        }

        public SizeF Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public override float Distance(PointF xy)
        {
            return Math.Max(Math.Abs(xy.X - Center.X) - Size.Width, Math.Abs(xy.Y - Center.Y) - Size.Height);
        }

        public override void Draw(Graphics graphics, Rectangle container)
        {
            Point center = Position(container, new PointF(Center.X, Center.Y));
            Size size = new Size(Width(container, Size.Width), Height(container, Size.Height));
            graphics.FillRectangle(new SolidBrush(Color), center.X - size.Width / 2, center.Y - size.Height / 2, size.Width, size.Height);
        }

    }
}