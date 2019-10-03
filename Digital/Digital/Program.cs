using Signals;
using Signals.Signals;
using Sound;

namespace Digital
{
    class Program
    {
        private const int SAMPLE_RATE = 44100;
        private const int SECONDS = 10;

        static void Main(string[] args)
        {
            //Data data1 = new Data(2, 1, 0, 0.25);
            //Data data2 = new Data(1, 800, 0, 0.5);

            Data data1 = new Data(1, 2, 0.5, 0.5);
            Data data2 = new Data(1, 600, 0.5, 0.5);

            Signal signal1 = new SinusSignal(data1);
            Signal signal2 = new ImpulseSignal(data2);


            //var values = Modulation.ApplyAM(signal1, signal2, SAMPLE_RATE, SECONDS);
            var values = Modulation.ApplyFM(signal1, signal2, SAMPLE_RATE, SECONDS);

            SoundGenerator soundGenerator = new SoundGenerator(SAMPLE_RATE, SECONDS, "polygarmonic");

            soundGenerator.Generate(values, true);

            //var signal = new PolygarmonicSignal(signal1, signal2);

            //soundGenerator.Generate(signal, false);
        }
    }
}
