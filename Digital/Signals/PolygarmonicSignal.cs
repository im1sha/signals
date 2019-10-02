using System;
using Signals.Signals;

namespace Signals
{
    public class PolygarmonicSignal : ISignal
    {
        private readonly Signal[] signals;
        private double AmplitudeSum { get; }


        public PolygarmonicSignal(params Signal[] signals)
        {
            this.signals = signals;
            AmplitudeSum = GetAmplitude();
        }

        public double GetSignalVolume(double time)
        {
            double value = 0;
            foreach (var signal in signals)
            {
                value += signal.GetSignalVolume(time);
            }

            return value;
        }

        public double GetSignalValue(double time)
        {
            return GetSignalVolume(time) / AmplitudeSum;
        }

        private double GetAmplitude()
        {
            double resultAmplitude = 0;
            foreach (var signal in signals)
            {
                resultAmplitude += signal.Amplitude;
            }

            return resultAmplitude;
        }
    }
}