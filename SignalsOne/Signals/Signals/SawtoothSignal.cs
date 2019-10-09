using System;

namespace Signals.Signals
{
    public class SawtoothSignal : TriangleSignal
    {
        public SawtoothSignal(Data data) : base(data)
        {
        }

        protected internal override double ApplyFunction(double phi)
        {
            return Math.Atan(Math.Tan(phi / 2)) / HALF_OF_PI;
        }
    }
}
