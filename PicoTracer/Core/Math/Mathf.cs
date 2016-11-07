﻿using System;
namespace PicoTracer
{
    public static class Mathf
    {
        private static Random rnd = new Random();

        public static int Clamp(int val, int min, int max)
        {
            if (val < min)
                return min;
            else if (val > max)
                return max;
            return val;
        }
        public static float Clamp(float val, float min, float max)
        {
            if (val < min)
                return min;
            else if (val > max)
                return max;
            return val;
        }
        public static float Spreader(float val, float min, float max)
        {
            float mid = (max + min) / 2;
            if (val > min && val <= mid)
                return min;
            else if (val < max && val > mid)
                return max;
            return val;
        }

        public static float Sqrt(float val)
        {
            return (float)Math.Sqrt(val);
        }

        public static float Lerp(float a, float b, float t)
        {
            return (1 - t) * a + t * b;
        }
        public static double Lerp(double a, double b, double t)
        {
            return (1 - t) * a + t * b;
        }
        public static decimal Lerp(decimal a, decimal b, decimal t)
        {
            return (1 - t) * a + t * b;
        }

        public static bool Approx(float a, float b, float interval)
        {
            if (Math.Abs(a - b) <= interval)
            {
                return true;
            }
            return false;
        }

        public static float Repeat(float a, float length)
        {
            return a - (float)Math.Floor(a / length) * length;
        }

        public static int Random(int min, int max)
        {
            return rnd.Next(min, max);
        }
        public static float Random(float min, float max)
        {
            return (float)(min + rnd.NextDouble() * (max - min));
        }
        public static float[] BubbleSort(float[] a)
        {
            int n = a.Length;
            float temp;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                }
            }
            return a;
        }
    }
}