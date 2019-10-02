using System;

namespace Signals.Signals
{
    public class TriangleSignal : Signal
    {
        protected static readonly double HALF_OF_PI = Math.PI / 2;

        public TriangleSignal(Data data) : base(data)
        {
        }

        protected internal override double ApplyFunction(double phi)
        {
            return Math.Asin(Math.Sin(phi)) / HALF_OF_PI;
        }
    }
}