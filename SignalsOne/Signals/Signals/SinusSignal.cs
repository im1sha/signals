using System;

namespace Signals.Signals
{
    public class SinusSignal : Signal
    {
        public SinusSignal(Data data) : base(data)
        {
        }

        protected internal override double ApplyFunction(double phi)
        {
            return Math.Sin(phi);
        }
    }
}