using System;

namespace Signals.Signals
{
    public class SinSignal : Signal
    {
        public SinSignal(Data data) : base(data)
        {
        }

        protected internal override double GetValue(double fi)
        {
            return Math.Sin(fi);
        }

    }
}