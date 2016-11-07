using FastBitmapLib;
namespace PicoTracer
{
    public class RenderPool
    {
        public int Size { get; private set; }

        int curIndex = 0;
        FastBitmap[] pool;

        public RenderPool(int size = 8)
        {
            this.pool = new FastBitmap[size];
            Size = size;
        }

        public FastBitmap Fetch(int width, int height)
        {
            if (curIndex >= Size - 1)
            {
                ResetPool();
                curIndex = 0;
                pool[curIndex] = new FastBitmap(width, height);
                return pool[curIndex];
            }
            else
            {
                curIndex++;
                pool[curIndex] = new FastBitmap(width, height);
                return pool[curIndex];
            }
        }

        public void ResetPool()
        {
            for (int i = 0; i < Size; i++)
            {
                pool[i] = null;
            }
        }
    }
}