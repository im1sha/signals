using Signals.Signals;
using System.Linq;

namespace Signals
{
    public class PolygarmonicSignal : ISignal
    {
        private readonly Signal[] _signals;
        private readonly double _amplitudesSum;

        public PolygarmonicSignal(params Signal[] signals)
        {
            _signals = signals;
            _amplitudesSum = GetAmplitudesSum(signals);
        }

        public double GetVolume(double time)
        {
            return _signals.Sum(s => s.GetVolume(time));
        }

        public double GetNormalizedSignalValue(double time)
        {
            return GetVolume(time) / _amplitudesSum;
        }

        private double GetAmplitudesSum(Signal[] signals)
        {
            return signals.Sum(s => s.Amplitude);
        }
    }
}