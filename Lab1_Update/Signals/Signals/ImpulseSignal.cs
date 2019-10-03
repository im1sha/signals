using System;

namespace Signals.Signals
{
    public class ImpulseSignal : Signal
    {
        public double DutyFactor { get; set; }

        public ImpulseSignal(Data data) : base(data)
        {
            this.DutyFactor = data.DutyFactor;
        }

        protected internal override double GetValue(double fi)
        {
            var sin = Math.Sin(fi) + 1;

            return sin >= 2 - 2 * DutyFactor
                ? 1
                : 0;
            //: -1;

            //var sin = Math.Sin(GetFormula(time));

            //return Math.Sign(sin);
        }
    }
}