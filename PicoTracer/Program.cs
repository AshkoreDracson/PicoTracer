using System;
namespace PicoTracer
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Engine.Instance.Initialize();
        }
    }
}