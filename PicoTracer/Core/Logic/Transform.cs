namespace PicoTracer
{
    public class Transform : Component
    {
        public enum Space
        {
            Local,
            World
        }

        private Vector3 _position = Vector3.zero;
        private Vector3 _eulerAngles = Vector3.zero;
        private Vector3 _scale = Vector3.one;

        private Vector3 _localPosition = Vector3.zero;
        private Vector3 _localEulerAngles = Vector3.zero;
        private Vector3 _localScale = Vector3.one;

        public Vector3 position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }
        public Vector3 eulerAngles
        {
            get
            {
                return _eulerAngles;
            }
            set
            {
                _eulerAngles = value;
            }
        }
        public Vector3 scale
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value;
            }
        }

        public Vector3 localPosition
        {
            get
            {
                return _localPosition;
            }
            set
            {
                _localPosition = value;
            }
        }
        public Vector3 localEulerAngles
        {
            get
            {
                return _localEulerAngles;
            }
            set
            {
                _localEulerAngles = value;
            }
        }
        public Vector3 localScale
        {
            get
            {
                return _localScale;
            }
            set
            {
                _localScale = value;
            }
        }

        public Matrix4x4 localToWorld
        {
            get
            {
                Matrix4x4 cur = new Matrix4x4();
                cur = (Matrix4x4)new Vector4[4]
                {
                    Vector4.one,
                    Vector4.one,
                    Vector4.one,
                    Vector4.one
                };
                return cur;
            }
        }
        public Matrix4x4 worldToLocal
        {
            get
            {
                Matrix4x4 cur = new Matrix4x4();
                cur = (Matrix4x4)new Vector4[4]
                {
                    Vector4.one,
                    Vector4.one,
                    Vector4.one,
                    Vector4.one
                };
                return cur;
            }
        }

        public void Translate(Vector3 a, Space space = Space.Local)
        {
            switch (space)
            {
                case Space.Local:
                    _localPosition += a;
                    break;
                case Space.World:
                    _position += a;
                    break;
                default:
                    break;
            }
        }
    }
}