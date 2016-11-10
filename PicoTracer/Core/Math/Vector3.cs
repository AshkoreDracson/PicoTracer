using System;
namespace PicoTracer
{
    public struct Vector3
    {
        // VARIABLES & PROPERTIES

        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public double sqrMagnitude
        {
            get
            {
                return (x * x + y * y + z * z);
            }
        }
        public double magnitude
        {
            get
            {
                return Math.Sqrt(x * x + y * y + z * z);
            }
        }
        public Vector3 normalized
        {
            get
            {
                return new Vector3(x / magnitude, y / magnitude, z / magnitude);
            }
        }

        public static Vector3 zero
        {
            get
            {
                return new Vector3(0, 0, 0);
            }
        }
        public static Vector3 one
        {
            get
            {
                return new Vector3(1, 1, 1);
            }
        }
        public static Vector3 down
        {
            get
            {
                return new Vector3(0, 1, 0);
            }
        }
        public static Vector3 right
        {
            get
            {
                return new Vector3(1, 0, 0);
            }
        }
        public static Vector3 forward
        {
            get
            {
                return new Vector3(0, 0, 1);
            }
        }

        // CLASS INSTANCE CONSTRUCTOR

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
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

                throw new InvalidVectorIndexException();
            }
        }

        // OPERATORS

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        public static Vector3 operator *(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }
        public static Vector3 operator /(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
        }
        public static Vector3 operator +(Vector3 a, double b)
        {
            return new Vector3(a.x + b, a.y + b, a.z + b);
        }
        public static Vector3 operator -(Vector3 a, double b)
        {
            return new Vector3(a.x - b, a.y - b, a.z - b);
        }
        public static Vector3 operator *(Vector3 a, double b)
        {
            return new Vector3(a.x * b, a.y * b, a.z * b);
        }
        public static Vector3 operator /(Vector3 a, double b)
        {
            return new Vector3(a.x / b, a.y / b, a.z / b);
        }
        public static Vector3 operator -(Vector3 a)
        {
            return new Vector3(-a.x, -a.y, -a.z);
        }
        public static bool operator ==(Vector3 a, Vector3 b)
        {
            if (a.x == b.x && a.y == b.y && a.z == b.z)
                return true;
            return false;
        }
        public static bool operator !=(Vector3 a, Vector3 b)
        {
            if (a.x != b.x || a.y != b.y || a.z != b.z)
                return true;
            return false;
        }

        public static implicit operator Vector2(Vector3 a)
        {
            return new Vector2(a.x, a.y);
        }
        public static implicit operator Vector4(Vector3 a)
        {
            return new Vector4(a.x, a.y, a.z, 0);
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

        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            return new Vector3(a.y * b.z - b.y * a.z,
                                 -(a.x * b.z - b.x * a.z),
                                 a.x * b.y - b.x * a.y);
        }
        public static double Dot(Vector3 a, Vector3 b)
        {
            return (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
        }
        public static double Distance(Vector3 a, Vector3 b)
        {
            return new Vector3(b.x - a.x, b.y - a.y, b.z - a.z).magnitude;
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
            return "{ " + x + ", " + y + ", " + z + " }";
        }
    }
}