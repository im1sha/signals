using System;

namespace Signals.Signals
{
    public class SawtoothSignal : TriangleSignal
    {
        public SawtoothSignal(Data data) : base(data)
        {
        }

        protected internal override double GetValue(double fi)
        {
            var phase = fi / 2;

            return Math.Atan(Math.Tan(phase)) / HalfPi;
        }
    }
}