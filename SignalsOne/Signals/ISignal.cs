namespace Signals
{
    public interface ISignal
    {
        double GetVolume(double time);

        double GetNormalizedSignalValue(double time);
    }
}