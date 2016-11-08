using FastBitmapLib;
namespace PicoTracer
{
    public class Material
    {
        public FastBitmap texture;
        public FastColor color;

        public delegate FastColor ShaderProgram(ShaderInputInfo i);
    }
}