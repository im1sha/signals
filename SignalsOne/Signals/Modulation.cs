﻿using Signals.Signals;
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
            double val;
            double multiplier = 
                2 * Math.PI * carrierSignal.Frequency // GetHarmonicSignalArgument with no start_phase divided by sampleRate
                / sampleRate;

            for (int n = 0; n < seconds * sampleRate; n++)
            {
                val = modulationSignal.GetVolume((double)n / sampleRate);

                phi += multiplier * (1 + val);

                result[n] = carrierSignal.ApplyFunction(phi);
            }

            return result;
        }
    }
}