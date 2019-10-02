using System;
using Signals.Signals;

namespace Signals
{
    public static class Modulation
    {
        public static double[] Amplitude(Signal modulationSignal,
            Signal carrierSignal, int sampleRate, int seconds)
        {
            double[] result = new double[sampleRate * seconds];
            for (int n = 0; n < seconds * sampleRate; n++)
            {
                var time = (double) n / sampleRate;
                var modulationAmplitude = modulationSignal.GetSignalValue(time);

                result[n] = (modulationAmplitude /*+ carrierSignal.Amplitude*/) *
                            carrierSignal.GetSignalValue(time);
            }

            return result;
        }

        public static double[] Frequency(Signal modulationSignal,
            Signal carrierSignal, int sampleRate, int seconds)
        {
            double[] result = new double[sampleRate * seconds];
            double fi = 0;

            for (int n = 0; n < seconds * sampleRate; n++)
            {
                var time = (double) n / sampleRate;
                var lfo = modulationSignal.GetSignalVolume(time);

                fi += 2 * Math.PI * carrierSignal.Frequency * (1 + lfo) / sampleRate;

                result[n] = carrierSignal.GetValue(fi);
            }

            return result;
        }
    }
}