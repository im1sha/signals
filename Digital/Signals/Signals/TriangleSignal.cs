using System;

namespace Signals.Signals
{
    public class TriangleSignal : Signal
    {
        protected static readonly double HalfPi = Math.PI / 2;

        public TriangleSignal(Data data) : base(data)
        {
        }

        protected internal override double GetValue(double fi)
        {
            return Math.Asin(Math.Sin(fi)) / HalfPi;
        }
    }
}