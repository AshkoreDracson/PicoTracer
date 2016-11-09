using System;
namespace PicoTracer
{
    public struct Vector4
    {
        // VARIABLES & PROPERTIES

        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public double w { get; set; }

        public double sqrMagnitude
        {
            get
            {
                return (x * x + y * y + z * z + w * w);
            }
        }
        public double magnitude
        {
            get
            {
                return Math.Sqrt(x * x + y * y + z * z + w * w);
            }
        }
        public Vector4 normalized
        {
            get
            {
                return new Vector4(x / magnitude, y / magnitude, z / magnitude, w / magnitude);
            }
        }

        public static Vector4 zero
        {
            get
            {
                return new Vector4(0, 0, 0, 0);
            }
        }
        public static Vector4 one
        {
            get
            {
                return new Vector4(1, 1, 1, 1);
            }
        }

        // CLASS INSTANCE CONSTRUCTOR

        public Vector4(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public double this[int i]
        {
            get
            {
                if (i == 0)
                    return x;
                else if (i == 1)
                    return y;
                else if (i == 2)
                    return z;
                else if (i == 3)
                    return w;

                throw new InvalidVectorIndexException();
            }
            set
            {
                if (i == 0)
                    x = value;
                else if (i == 1)
                    y = value;
                else if (i == 2)
                    z = value;
                else if (i == 3)
                    w = value;

                throw new InvalidVectorIndexException();
            }
        }

        // OPERATORS

        public static Vector4 operator +(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        }
        public static Vector4 operator -(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        }
        public static Vector4 operator *(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        }
        public static Vector4 operator /(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
        }
        public static Vector4 operator +(Vector4 a, double b)
        {
            return new Vector4(a.x + b, a.y + b, a.z + b, a.w + b);
        }
        public static Vector4 operator -(Vector4 a, double b)
        {
            return new Vector4(a.x - b, a.y - b, a.z - b, a.w - b);
        }
        public static Vector4 operator *(Vector4 a, double b)
        {
            return new Vector4(a.x * b, a.y * b, a.z * b, a.w * b);
        }
        public static Vector4 operator /(Vector4 a, double b)
        {
            return new Vector4(a.x / b, a.y / b, a.z / b, a.w / b);
        }
        public static Vector4 operator -(Vector4 a)
        {
            return new Vector4(-a.x, -a.y, -a.z, -a.w);
        }
        public static bool operator ==(Vector4 a, Vector4 b)
        {
            if (a.x == b.x && a.y == b.y && a.z == b.z)
                return true;
            return false;
        }
        public static bool operator !=(Vector4 a, Vector4 b)
        {
            if (a.x != b.x || a.y != b.y || a.z != b.z)
                return true;
            return false;
        }
        public static implicit operator Vector2(Vector4 a)
        {
            return new Vector2(a.x, a.y);
        }

        // METHODS & PROPERTIES

        public void Normalize()
        {
            double magnitude = this.magnitude;
            x /= magnitude;
            y /= magnitude;
            z /= magnitude;
        }

        // STATIC METHODS & PROPERTIES

        public static double Distance(Vector4 a, Vector4 b)
        {
            return new Vector4(b.x - a.x, b.y - a.y, b.z - a.z, b.w - a.w).magnitude;
        }

        // OVERRIDES

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"{{{x}, {y}, {z}, {w}}}";
        }
    }
}