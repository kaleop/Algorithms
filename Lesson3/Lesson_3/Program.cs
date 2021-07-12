using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace Lesson_3
{
    class Program
    {
        static void Main(string[] args)
        {

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

        }
    }

    public class BenchTest
    {

        public PointClass A = new PointClass(12.3, 21.4);
        public PointClass B = new PointClass(33.9, 26.7);

        public PointStruct C = new PointStruct(12.3, 21.4);
        public PointStruct D = new PointStruct(33.9, 26.7);

        public double GetLengthDouble(PointStruct a, PointStruct b)
        {
            double AC = a.DoubleX - b.DoubleX;
            double BC = a.DoubleY - b.DoubleY;
            return Math.Sqrt((AC * AC + BC * BC));
        }

        public float GetLengthFloat(PointStruct a, PointStruct b)
        {
            float AC = a.FloatX - b.FloatX;
            float BC = a.FloatY - b.FloatY;
            return (float)Math.Sqrt((AC * AC + BC * BC));
        }

        public double GetLengthDouble(PointClass a, PointClass b)
        {
            double AC = a.DoubleX - b.DoubleX;
            double BC = a.DoubleY - b.DoubleY;
            return Math.Sqrt((AC * AC + BC * BC));
        }

        public float GetLengthFloat(PointClass a, PointClass b)
        {
            float AC = a.FloatX - b.FloatX;
            float BC = a.FloatY - b.FloatY;
            return (float)Math.Sqrt((AC * AC + BC * BC));
        }

        [Benchmark]
        public void TestStructDouble()
        {
            GetLengthDouble(C, D);
        }

        [Benchmark]
        public void TestStructFloat()
        {
            GetLengthFloat(C, D);
        }

        [Benchmark]
        public void TestClassDouble()
        {
            GetLengthDouble(A, B);
        }

        [Benchmark]
        public void TestClassFloat()
        {
            GetLengthDouble(A, B);
        }
    }

    public struct PointStruct
    {
        public float FloatX { get; private set; } 
        public float FloatY { get; private set; }
        public double DoubleX { get; private set; }
        public double DoubleY { get; private set; }

        public PointStruct (double x, double y)
        {
            FloatX = (float)x;
            FloatY = (float)y;
            DoubleX = x;
            DoubleY = y;
        }
    }

    public class PointClass
    {
        public float FloatX { get; private set; }
        public float FloatY { get; private set; }
        public double DoubleX { get; private set; }
        public double DoubleY { get; private set; }

        public PointClass(double x, double y)
        {
            FloatX = (float)x;
            FloatY = (float)y;
            DoubleX = x;
            DoubleY = y;
        }
    }


}
