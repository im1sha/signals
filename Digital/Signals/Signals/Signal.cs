using System;

namespace Signals.Signals
{
    public abstract class Signal : ISignal
    {
        protected const double TWO_PI = 2 * Math.PI;

        public double Amplitude { get; }

        public double Frequency { get; }

        public double StartPhase { get; }

        protected Signal(Data data)
        {
            Amplitude = data.Amplitude;
            Frequency = data.Frequency;
            StartPhase = data.StartPhase;
        }

        public double GetVolume(double time)
        {
            return Amplitude * GetNormalizedSignalValue(time);
        }

        public double GetNormalizedSignalValue(double time)
        {
            return ApplyFunction(GetHarmonicSignalArgument(time));
        }

        /// <returns>
        /// NoiseSignal, 
        /// SinusSignal,
        /// TriangleSignal: [-1, 1]
        /// 
        /// ImpulseSignal: [0, 1]
        /// </returns>
        protected internal abstract double ApplyFunction(double phi);

        /// <summary>
        /// Gets harmonic signal formula.
        /// </summary>
        /// <param name="x">
        /// Should be in bounds [0, 1]. 
        /// It's n / N, where n = [0 .. N-1].
        /// N is total amount of discrete values.
        /// </param>
        /// <returns>Calculated value for given discrete value.</returns>
        protected internal double GetHarmonicSignalArgument(double x)
        {
            return TWO_PI * Frequency * x + StartPhase;
        }
    }
}