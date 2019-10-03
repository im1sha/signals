namespace Signals
{
    public class Data
    {
        public double Amplitude { get; set; }

        public double Frequency { get; set; }

        public double DutyFactor { get; set; }

        public double StartPhase { get; set; }

        public Data(double amplitude, double frequency, double startPhase, double dutyFactor)
        {
            Amplitude = amplitude;
            Frequency = frequency;
            DutyFactor = dutyFactor;
            StartPhase = startPhase;
        }
    }
}