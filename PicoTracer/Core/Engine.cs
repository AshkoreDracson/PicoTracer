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
            new DefaultScene().Initialize();
            Thread t = new Thread(() => Start());
            t.Start();

            Debug.WriteLine("Done");
            Application.Run(Window);
        }

        void Start()
        {
            CallFlow(GameFlow.Start);
            Update();
        }

        void Update()
        {
            while (Running)
            {
                DateTime start = DateTime.Now;

                CallFlow(GameFlow.Update);
                Draw();

                DateTime end = DateTime.Now;

                double computedDeltaTime = (end - start).TotalSeconds;
                if (computedDeltaTime < 1.00 / TargetFramerate)
                {
                    Thread.Sleep((int)((1.00 / TargetFramerate - computedDeltaTime) * 1000)); // Sleep the correct amount of time for TargetFramerate
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

        void CallFlow(GameFlow flow)
        {
            GameObject[] gos = GameObject.GetAllGameObjects();

            switch (flow)
            {
                case GameFlow.Start:
                    foreach (GameObject go in gos)
                    {
                        Component[] comps = go.GetAllComponents();
                        foreach (Component comp in comps)
                        {
                            comp.Start();
                        }
                    }
                    break;
                case GameFlow.Update:
                    foreach (GameObject go in gos)
                    {
                        Component[] comps = go.GetAllComponents();
                        foreach (Component comp in comps)
                        {
                            comp.Update();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public void Quit()
        {
            Running = false;
            Environment.Exit(0);
        }
    }
}