using System;

namespace Signals.Signals
{
    public class ImpulseSignal : Signal
    {
        public double DutyFactor { get; }

        public ImpulseSignal(Data data) : base(data)
        {
            DutyFactor = data.DutyFactor;
        }

        protected internal override double ApplyFunction(double phi)
        {
            // 
            return Math.Sin(phi) + 1 >= 2 * (1 - DutyFactor)
                ? 1
                : 0;
        }
    }
}