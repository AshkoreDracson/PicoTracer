using FastBitmapLib;
namespace PicoTracer
{
    public struct Color
    {
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
        public float A { get; set; }

        public Color(float r, float g, float b)
        {
            R = r;
            G = g;
            B = b;
            A = 1.00f;
        }
        public Color(float r, float g, float b, float a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        // OPERATORS

        public static Color operator *(Color a, Color b)
        {
            return new Color(a.R * b.R, a.G * b.G, a.B * b.B, a.A * b.A);
        }
        public static Color operator *(Color a, float b)
        {
            return new Color(a.R * b, a.G * b, a.B * b, a.A);
        }

        public static implicit operator FastColor(Color a)
        {
            return new FastColor((byte)(Mathf.Clamp01(a.R) * 255), (byte)(Mathf.Clamp01(a.G) * 255), (byte)(Mathf.Clamp01(a.B) * 255));
        }
        public static implicit operator Color(FastColor a)
        {
            return new Color(a.R / 255f, a.G / 255f, a.B / 255f);
        }
    }
}