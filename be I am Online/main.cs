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
using System.Threading;

namespace be_I_am_Online
{
    public partial class main : Form
    {
        void iv()
        {
            this.Invalidate();
        }
        public main()
        {
            InitializeComponent();
        }
        PaintEventArgs eg = null;
        int wid = 0, height = 0;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            wid = e.ClipRectangle.Width;
            height = e.ClipRectangle.Height;
            eg = e;
            paint();
        }
        public bool connected = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                IPHostEntry hostInfo = Dns.GetHostEntry("bing.com");
                connected = true;
            }
            catch (Exception ex)
            {
                connected = false;
            }
            iv();
        }

        void paint()
        {
            if (eg != null)
            {
                Color color = Color.Red;
                if (connected)
                {
                    color = Color.LightGreen;
                }
                Brush mb = new SolidBrush(color);
                eg.Graphics.Clear(Color.White);
                eg.Graphics.FillEllipse(mb, new Rectangle(new Point(0, 0), new Size(wid, height)));
                mb.Dispose();
            }
        }
    }
}
