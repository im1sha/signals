using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SoundUI.ViewModels
{
    class AppViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged 

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        #endregion

        #region localization

        private static readonly CultureInfo APP_LOCALIZATION = new CultureInfo("en-US");

        #endregion

        #region input 

        private double _input1 = 0.5;
        public string Input1
        {
            get => _input1.ToString(APP_LOCALIZATION);
            set
            {
                if (!double.TryParse(value, out _))
                {
                    return;
                }
                _input1 = Convert.ToDouble(value, APP_LOCALIZATION);
                OnPropertyChanged();
            }
        }

        #endregion

        #region commands

        private InteractCommand _runCommand;
        public InteractCommand RunCommand => _runCommand ??
            (_runCommand = new InteractCommand((o) =>
            {
               
            }));

        #endregion


        //private const int SampleRate = 44100;
        //private const int Seconds = 10;

        //static void Main(string[] args)
        //{
        //    Data data1 = new Data(1, 2, 0, 0);
        //    Data data2 = new Data(1, 50, 0, 0.9);

        //    Signal signal1 = new SinusSignal(data1);
        //    Signal signal2 = new ImpulseSignal(data2);


        //    var values = Modulation.ApplyFM(signal1, signal2, SampleRate, Seconds);

        //    SoundGenerator soundGenerator = new SoundGenerator(SampleRate, Seconds,
        //        $"MS {signal1.GetType()} A {data1.Amplitude} F {data1.Frequency} phi0 {data1.StartPhase} D {data1.DutyFactor}. " +
        //        $"CS {signal2.GetType()} A {data2.Amplitude} F {data2.Frequency} phi0 {data2.StartPhase} D {data2.DutyFactor}"
        //    );

        //    soundGenerator.Generate(values, true);
        //}
    }
}
