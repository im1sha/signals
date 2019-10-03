namespace Signals
{
    public interface ISignal
    {
        double GetSignalVolume(double time);

        double GetSignalValue(double time);
    }
}