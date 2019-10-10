using Signals.Signals;
using System;

namespace Signals
{
    public static class Modulation
    {
        // 
        public static double[] ApplyAM(
            Signal modulationSignal,
            Signal carrierSignal,
            int sampleRate,
            int seconds)
        {
            double[] result = new double[sampleRate * seconds];
            double time;

            for (int n = 0; n < seconds * sampleRate; n++)
            {
                time = (double)n / sampleRate;

                result[n] = modulationSignal.GetNormalizedSignalValue(time)
                     * carrierSignal.GetNormalizedSignalValue(time);

                #region alternative
                //result[n] = ((modulationSignal.GetNormalizedSignalValue(time)
                //     * modulationSignal.Amplitude + carrierSignal.Amplitude)
                //     * carrierSignal.GetNormalizedSignalValue(time))
                //     / (modulationSignal.Amplitude + carrierSignal.Amplitude); // normalize to amplitude == 1   
                #endregion
            }

            return result;
        }

        public static double[] ApplyFM(
            Signal modulationSignal,
            Signal carrierSignal,
            int sampleRate,
            int seconds)
        {
            double[] result = new double[sampleRate * seconds];
            double phi = 0;
            double modulationPart;
            double carrierPart =
                2 * Math.PI * carrierSignal.Frequency // no start phase
                / sampleRate;
            double modulationIndex = carrierPart;

            #region alternative
            // if deviation is 50% of carrierSignal frequency
            // modulationIndex = carrierSignal.Amplitude / (2 * modulationSignal.Amplitude); 
            #endregion

            for (int n = 0; n < seconds * sampleRate; n++)
            {
                modulationPart = modulationSignal.GetVolume((double)n / sampleRate);

                phi += carrierPart + (modulationIndex * modulationPart);

                result[n] = carrierSignal.ApplyFunction(phi);
            }

            return result;
        }
    }
}