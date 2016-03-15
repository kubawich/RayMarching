using System;
using System.Drawing;


namespace RayMarching
{
    public abstract class Rect
    {
        PointF _center;
        Color _color;

        protected Rect(PointF center, Color color)
        {
            _center = center;
            _color = color;
        }

        public PointF Center
        {
            get { return _center; }
            set { _center = value; }
        }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public static  int Width(Rectangle container, float width)
        {
            return (int)(container.Width * width);
        }

        public static  int Height(Rectangle container, float height)
        {
            return (int)(container.Height * height);
        }

        public static int PosX(Rectangle container, float x)
        {
            return (int)(container.Width * (x + 1) / 2);
        }

        public static int PosY(Rectangle container, float y)
        {
            return (int)(container.Height * (1 - (y + 1) / 2));
        }

        public abstract float Distance(PointF xy);

        public abstract void Draw(Graphics graphics, Rectangle container);


        public static PointF ScreenPositionToGeometry(Rectangle container, Point positionSc)
        {
            return new PointF((float)positionSc.X * 2 / container.Width - 1,
                              (float)2 * (1 - (float)positionSc.Y / container.Height) - 1);
        }

        public static Point Position(Rectangle container, PointF pos)
        {
            return new Point(PosX(container, pos.X), PosY(container, pos.Y));
        }
    }
}
