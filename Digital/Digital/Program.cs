using Signals;
using Signals.Signals;
using Sound;

namespace Digital
{
    class Program
    {
        private const int SampleRate = 44100;
        private const int Seconds = 10;
        private const double SoundAmplitude = 1;

        static void Main(string[] args)
        {
            //Data data1 = new Data(2, 1, 0, 0.25);
            //Data data2 = new Data(1, 800, 0, 0.5);

            Data data1 = new Data(1, 2, 0.5, 0.5);
            Data data2 = new Data(1, 600, 0.5, 0.5);

            Signal signal1 = new SinusSignal(data1);
            Signal signal2 = new ImpulseSignal(data2);

            //ISignal amplitudeModulation = new AmplitudeModulationSignal(modulatorSignal, carrierSignal);



            //var values = Modulation.Amplitude(signal1, signal2, SampleRate, Seconds);
            var values = Modulation.Frequency(signal1, signal2, SampleRate, Seconds);

            SoundGenerator soundGenerator = new SoundGenerator(SampleRate, Seconds);
            soundGenerator.FileName = "polygarmonic";

            soundGenerator.Generate(values, true);

            //var signal = new PolygarmonicSignal(signal1, signal2);

            //soundGenerator.Generate(signal, false);


        }
    }
}
