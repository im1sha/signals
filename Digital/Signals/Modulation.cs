using Signals.Signals;
using System;

namespace Signals
{
    public static class Modulation
    {
        public static double[] Amplitude(
            Signal modulationSignal,
            Signal carrierSignal, 
            int sampleRate,
            int seconds)
        {
            double[] result = new double[sampleRate * seconds];
            for (int n = 0; n < seconds * sampleRate; n++)
            {
                var time = (double)n / sampleRate;
                var modulationAmplitude = 
                    modulationSignal.GetNormalizedSignalValue(time);

                result[n] = (modulationAmplitude /*+ carrierSignal.Amplitude*/) 
                    * carrierSignal.GetNormalizedSignalValue(time);
            }

            return result;
        }

        public static double[] Frequency(
            Signal modulationSignal,
            Signal carrierSignal,
            int sampleRate, 
            int seconds)
        {
            double[] result = new double[sampleRate * seconds];
            double fi = 0;

            for (int n = 0; n < seconds * sampleRate; n++)
            {
                var time = (double)n / sampleRate;
                var lfo = modulationSignal.GetVolume(time);

                fi += 2 * Math.PI * carrierSignal.Frequency 
                    * (1 + lfo) / sampleRate;

                result[n] = carrierSignal.ApplyFunction(fi);
            }

            return result;
        }
    }
}