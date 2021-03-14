using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace be_I_am_Online
{
    public partial class main : Form
    {
        void iv()
        {
            this.Invalidate();//TRIGGER REPAINT
        }
        public main()
        {
            InitializeComponent();
        }
        int wid = 0, height = 0;//VAR FOR WINDOW SIZE
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            wid = e.ClipRectangle.Width;
            height = e.ClipRectangle.Height;
            paint(e);//START PAINTING
        }
        public bool connected = false;//STORE CONNECTION STATE
        private void timer1_Tick(object sender, EventArgs e)//TRIGGERED BY TIMER
        {
            try
            {
                IPHostEntry hostInfo = Dns.GetHostEntry("bing.com");//SEND DNS TO BING
                connected = true;
            }
            catch (Exception ex)
            {//IF DNS FAILED:
                connected = false;
            }
            iv();//TRIGGER REPAINT FUNCTION
        }

        void paint(PaintEventArgs eg)
        {
            if (eg != null)
            {
                Color color = Color.Red;
                if (connected)
                {
                    color = Color.LightGreen;
                }
                Brush mb = new SolidBrush(color);
                eg.Graphics.Clear(Color.White);//REMOVE OLD PAINTED THINGS AND MAKE THE WINDOW TRANSPARENT
                eg.Graphics.FillEllipse(mb, new Rectangle(new Point(0, 0), new Size(wid, height)));//PAINT ECLIPSE
                mb.Dispose();
            }
        }
    }
}
