namespace PicoTracer
{
    public static class Time
    {
        public static double deltaTime { get; private set; }
        public static double unscaledDeltaTime { get; private set; }

        public static double time { get; private set; }
        public static double unscaledTime { get; private set; }

        public static double timeScale { get; set; } = 1.00f;

        public static uint FPS
        {
            get
            {
                return (uint)(1f / unscaledDeltaTime);
            }
        }

        static void SetDeltaTime(double dt)
        {
            deltaTime = dt * timeScale;
            unscaledDeltaTime = dt;

            time += deltaTime;
            unscaledTime += unscaledDeltaTime;
        }
    }
}