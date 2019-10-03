using System;

namespace Signals.Signals
{
    public abstract class Signal : ISignal
    {
        protected const double TwoPi = 2 * Math.PI;

        public double Amplitude { get; set; }

        public double Frequency { get; set; }

        public double StartPhase { get; set; }

        protected Signal(Data data)
        {
            this.Amplitude = data.Amplitude;
            this.Frequency = data.Frequency;
            this.StartPhase = data.StartPhase;
        }

        public double GetSignalVolume(double time) => Amplitude * GetSignalValue(time);

        public double GetSignalValue(double time) => GetValue(GetFormula(time));

        protected internal abstract double GetValue(double fi);

        protected internal double GetFormula(double x)
        {
            return TwoPi * Frequency * x + StartPhase;
        }
    }
}