using System.Drawing;
namespace PicoTracer
{
    public abstract class Component 
    {
        public GameObject gameObject { get; internal set; }

        public virtual void Start() { }
        public virtual void Update() { }
    }
}