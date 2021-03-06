﻿using System;
namespace PicoTracer
{
    public struct Vector2
    {
        // VARIABLES & PROPERTIES

        public double x { get; set; }
        public double y { get; set; }

        public double sqrMagnitude
        {
            get
            {
                return (x * x + y * y);
            }
        }
        public double magnitude
        {
            get
            {
                return Math.Sqrt(x * x + y * y);
            }
        }
        public Vector2 normalized
        {
            get
            {
                return new Vector2(x / magnitude, y / magnitude);
            }
        }

        public static Vector2 zero
        {
            get
            {
                return new Vector2(0, 0);
            }
        }
        public static Vector2 one
        {
            get
            {
                return new Vector2(1, 1);
            }
        }
        public static Vector2 down
        {
            get
            {
                return new Vector2(0, 1);
            }
        }
        public static Vector2 right
        {
            get
            {
                return new Vector2(1, 0);
            }
        }

        // CLASS INSTANCE CONSTRUCTOR

        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double this[int i]
        {
            get
            {
                if (i == 0)
                    return x;
                else if (i == 1)
                    return y;

                throw new InvalidVectorIndexException();
            }
            set
            {
                if (i == 0)
                    x = value;
                else if (i == 1)
                    y = value;

                throw new InvalidVectorIndexException();
            }
        }

        // OPERATORS

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }
        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x * b.x, a.y * b.y);
        }
        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x / b.x, a.y / b.y);
        }
        public static Vector2 operator +(Vector2 a, float b)
        {
            return new Vector2(a.x + b, a.y + b);
        }
        public static Vector2 operator -(Vector2 a, float b)
        {
            return new Vector2(a.x - b, a.y - b);
        }
        public static Vector2 operator *(Vector2 a, float b)
        {
            return new Vector2(a.x * b, a.y * b);
        }
        public static Vector2 operator /(Vector2 a, float b)
        {
            return new Vector2(a.x / b, a.y / b);
        }
        public static Vector2 operator -(Vector2 a)
        {
            return new Vector2(-a.x, -a.y);
        }
        public static bool operator ==(Vector2 a, Vector2 b)
        {
            if (a.x == b.x && a.y == b.y)
                return true;
            return false;
        }
        public static bool operator !=(Vector2 a, Vector2 b)
        {
            if (a.x != b.x || a.y != b.y)
                return true;
            return false;
        }

        public static implicit operator Vector3(Vector2 a)
        {
            return new Vector3(a.x, a.y, 0);
        }
        public static implicit operator Vector4(Vector2 a)
        {
            return new Vector4(a.x, a.y, 0, 0);
        }

        // METHODS & PROPERTIES

        public void Normalize()
        {
            double magnitude = this.magnitude;
            if (magnitude != 0)
            {
                x /= magnitude;
                y /= magnitude;
            }
        }

        // STATIC METHODS & PROPERTIES

        public static double Dot(Vector2 a, Vector2 b)
        {
            return (a.x * b.x) + (a.y * b.y);
        }
        public static double Distance(Vector2 a, Vector2 b)
        {
            return new Vector2(b.x - a.x, b.y - a.y).magnitude;
        }
        public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
        {
            return new Vector2(Mathf.Lerp(a.x, b.x, t), Mathf.Lerp(a.y, b.y, t));
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
            return "{ " + x + ", " + y + " }";
        }
    }
}