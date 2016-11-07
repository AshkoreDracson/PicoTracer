using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using FastBitmapLib;

namespace PicoTracer
{
    public class Engine : Singleton<Engine>
    {
        public RenderPool RenderPool { get; private set; }
        public bool Running { get; private set; } = true;
        public uint TargetFramerate { get; set; } = 60;
        public RenderWindow Window { get; private set; }
        public PictureBox Viewport
        {
            get
            {
                return Window.Viewport;
            }
        }

        public void Initialize()
        {
            Debug.Write("Initializing Engine...");
            Window = new RenderWindow("PicoTracer", new Size(640, 480));
            RenderPool = new RenderPool();
            Thread t = new Thread(() => Start());
            t.Start();
            Debug.WriteLine("Done");
            Application.Run(Window);
        }

        void Start()
        {
            Update();
        }

        void Update()
        {
            while (Running)
            {
                DateTime start = DateTime.Now;

                // Update stuff
                Draw(); // Draw

                DateTime end = DateTime.Now;

                double computedDeltaTime = (end - start).TotalSeconds;
                if (computedDeltaTime < 1.00 / TargetFramerate)
                {
                    Thread.Sleep((int)((1.00 / TargetFramerate - computedDeltaTime) * 1000));
                    computedDeltaTime = (1.00 / TargetFramerate);
                }
                
                var setDeltaTimeMethod = typeof(Time).GetMethod("SetDeltaTime", BindingFlags.Static | BindingFlags.NonPublic);
                setDeltaTimeMethod.Invoke(null, new object[] { computedDeltaTime }); // Super hacky way of calling a method, but for the greater good in the means of the user not setting his own delta time.

                Debug.WriteLine($"Current time: {Time.unscaledTime}, elapsed: {Time.unscaledDeltaTime} (FPS: {Time.FPS})");
            }
        }

        void Draw()
        {
            FastBitmap renderedImage = RenderPool.Fetch(Viewport.Width, Viewport.Height);
            Window.UpdateViewport(renderedImage);
        }

        public void Quit()
        {
            Running = false;
            Environment.Exit(0);
        }
    }
}