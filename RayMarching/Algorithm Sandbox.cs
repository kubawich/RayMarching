using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

//TODO: Algorytm wciąż działa jak chce, brak precyzji i dop. jak wyjdzie dalej niż 0.1 jednostki
//to widzi krawędź obiektu, problem z odświerzaniem po maksymalizacji ekranu, nastepuje
//dop. po przesunieciu wektora, obiekty nie skalują się wraz z interfejsem.
//Należałoby dodać informacje o tym czy wektor dotyka aktualnie obiektu, licznik fps, oraz możliwość
//dodawania obiektów z poziomu aplikacji. Wersja 0.1

//Algorytm stworzony z pomocą artykułów na wiki, bloga Inigo Quileza, bloga Aleksandra Mutela,
//oraz kilku mniejszych publikacji i artykułów na msdn.

namespace RayMarching
{
    public partial class Algorithm_Sandbox : UserControl
    {
        private List<Rect> RectList = new List<Rect>();
        public Algorithm_Sandbox()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        }

        public void AddGeo(Rect rect)
        {
            RectList.Add(rect);
            Refresh();
        }

        PointF rayPos;
        float rayAngle;

        public PointF RayPos
        {
            get { return rayPos; }
            set { rayPos = value; Refresh(); }

        }

        public float RayAngle { get {return rayAngle; }
            set { rayAngle = value; Refresh(); } }

        public bool CzyWyszło(PointF point)
        {
            return (point.X < -1 || point.X > 1 || point.Y < -1 || point.Y > 1);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Point rayPosition = Rect.Position(ClientRectangle, rayPos);
            SizeF rayDirection = new SizeF((float)Math.Cos(rayAngle), (float)Math.Sin(rayAngle));

            float minDistance = float.MaxValue;

            // Algorytm
            PointF currentRay = rayPos;
            int numberOfSteps = 0;
            Rect selectedGeometry = null;
            float minDist = 0.1f;
            while (RectList.Count > 0 && minDistance > minDist && !CzyWyszło(currentRay))
            {
                // Obliczanie dystansu od obiektu
                minDistance = float.MaxValue;
                selectedGeometry = null;
                foreach (Rect geometryBase in RectList)
                {
                    float newDistance = geometryBase.Distance(currentRay);
                    if (newDistance < minDistance)
                    {
                        minDistance = newDistance;
                        selectedGeometry = geometryBase;
                    }
                }


                if (minDistance > minDist)
                {
                    Point currentRaySc = Rect.Position(ClientRectangle, currentRay);
                    int minDistanceX =Rect.Width(ClientRectangle, minDistance / 2);
                    int minDistanceY = Rect.Height(ClientRectangle, minDistance / 2);

                    // Raymarching do najbliższej powierzchni 
                    e.Graphics.DrawEllipse(new Pen(Color.White), new Rectangle(currentRaySc.X - minDistanceX, currentRaySc.Y - minDistanceY,minDistanceX * 2, minDistanceY * 2));


                    rayPosition = Rect.Position(ClientRectangle, currentRay);
                    Rectangle rayBox = new Rectangle(rayPosition.X - 4, rayPosition.Y - 4, 8, 8);

                    e.Graphics.FillEllipse(new SolidBrush(Color.Red), rayBox);
                    e.Graphics.DrawLine(new Pen(Color.Red, 2), rayPosition,Rect.Position(ClientRectangle, selectedGeometry.Center));

                    Size rayFullDirectionSc = new Size((int)(rayDirection.Width * minDistanceX), -(int)(rayDirection.Height * minDistanceY));e.Graphics.DrawLine(new Pen(Color.Red, 2), rayPosition, Point.Add(rayPosition, rayFullDirectionSc));

                    currentRay = PointF.Add(currentRay,new SizeF(rayDirection.Width * minDistance, rayDirection.Height * minDistance));
                }
                numberOfSteps++;
            }

            // Renderuje obiekty
            foreach (Rect geometryBase in RectList)
            {
                geometryBase.Draw(e.Graphics, ClientRectangle);
            }
        }

    }
}
