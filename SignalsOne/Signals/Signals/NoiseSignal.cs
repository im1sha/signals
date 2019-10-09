using System;

namespace Signals.Signals
{
    public class NoiseSignal : Signal
    {
        private static readonly Random _random = new Random();
        private const double _minValue = -1;
        private const double _maxValue = 1;

        public NoiseSignal(Data data) : base(data)
        {
        }

        protected internal override double ApplyFunction(double phi)
        {
            return _random.NextDouble() * (_maxValue - _minValue) 
                + _minValue;
        }
    }
}