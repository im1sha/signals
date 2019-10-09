namespace Signals
{
    public class Data
    {
        public double Amplitude { get; }

        public double Frequency { get; }

        public double DutyFactor { get; } // скважность

        public double StartPhase { get; }

        public Data(double amplitude, double frequency, double startPhase, double dutyFactor)
        {
            Amplitude = amplitude;
            Frequency = frequency;
            DutyFactor = dutyFactor;
            StartPhase = startPhase;
        }
    }
}