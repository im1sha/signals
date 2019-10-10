using Signals;
using Signals.Signals;
using Sound;
using System;

namespace ConsoleTest
{
    class Program
    {
        private const int SampleRate = 44100;
        private const int Seconds = 10;

        static void Main(string[] args)
        {
            Data data1 = new Data(1, 2, 0, 0);
            Data data2 = new Data(1, 50, 0, 0.9);

            Signal signal1 = new SinusSignal(data1);
            Signal signal2 = new ImpulseSignal(data2);


            var values = Modulation.ApplyFM(signal1, signal2, SampleRate, Seconds);

            SoundGenerator soundGenerator = new SoundGenerator(SampleRate, Seconds, 
                $"MS {signal1.GetType()} A {data1.Amplitude} F {data1.Frequency} phi0 {data1.StartPhase} D {data1.DutyFactor}. " +
                $"CS {signal2.GetType()} A {data2.Amplitude} F {data2.Frequency} phi0 {data2.StartPhase} D {data2.DutyFactor}" 
            );

            soundGenerator.Generate(values, true);
        }
    }
}
