using System.Drawing;
using System.Windows.Forms;
using FastBitmapLib;

namespace PicoTracer
{
    public class RenderWindow : Form
    {
        public PictureBox Viewport { get; private set; }

        public RenderWindow(string title, Size size)
        {
            ClientSize = size;
            StartPosition = FormStartPosition.CenterScreen;
            Text = title;

            Viewport = new PictureBox();
            Viewport.BackColor = System.Drawing.Color.Black;
            Viewport.Dock = DockStyle.Fill;
            Viewport.SizeMode = PictureBoxSizeMode.StretchImage;

            Controls.Add(Viewport);
            FormClosing += RenderWindow_FormClosing;

            Application.EnableVisualStyles();
        }

        public void UpdateViewport(FastBitmap renderedImage)
        {
            Viewport.Image = renderedImage;
        }

        private void RenderWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Engine.Instance.Quit();
        }
    }
}