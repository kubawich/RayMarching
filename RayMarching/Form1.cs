using System;
using System.Drawing;
using System.Windows.Forms;

namespace RayMarching
{
    public partial class Form1 : Form
    {
        //Jak coś popsuje się w kodzie foremki "matki", odkomnetować poniższą linijkę
        //Algorithm_Sandbox sandbox = new Algorithm_Sandbox();

        //Obiekty można dodawać metodą AddGeo
        public Form1()
        {
            InitializeComponent(); 

            sandbox.AddGeo(new RectBase((new PointF(0.6f, -0.5f)), Color.Pink, new SizeF(0.2f, 0.1f)));
            sandbox.AddGeo(new RectBase((new PointF(0.1f, 1.0f)), Color.PapayaWhip, new SizeF(0.7f, 0.3f)));
            sandbox.AddGeo(new RectBase((new PointF(0.5f, 0.5f)), Color.SkyBlue, new SizeF(0.5f, 0.2f)));
            sandbox.AddGeo(new RectBase((new PointF(-0.9f, -0.4f)), Color.SkyBlue, new SizeF(0.2f, 0.6f)));
        }

        private void MoveRayOnScroll(object sender, EventArgs e)
        {
            //Określa obrót wektora, trackbar ma 360 kroków, więc do pełnego obrotu dzielimy przez 180
            sandbox.RayAngle = -(float)trackBar.Value * (float)Math.PI / 180;
        }
    }
}
