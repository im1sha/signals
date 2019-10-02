using System;

namespace Signals.Signals
{
    public class NoiseSignal : Signal
    {
        private static readonly Random Random = new Random();
        private const double MinValue = -1;
        private const double MaxValue = 1;

        public NoiseSignal(Data data) : base(data)
        {
        }

        protected internal override double GetValue(double fi)
        {
            return Random.NextDouble() * (MaxValue - MinValue) + MinValue;
        }
    }
}