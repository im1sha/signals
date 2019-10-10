using Signals;
using Signals.Signals;
using Sound;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private double _amplitude1 = 1;
        public string Amplitude1
        {
            get => _amplitude1.ToString(APP_LOCALIZATION);
            set
            {
                if (!double.TryParse(value, out _))
                {
                    return;
                }
                _amplitude1 = Convert.ToDouble(value, APP_LOCALIZATION);
                OnPropertyChanged();
            }
        }

        private double _amplitude2 = 1;
        public string Amplitude2
        {
            get => _amplitude2.ToString(APP_LOCALIZATION);
            set
            {
                if (!double.TryParse(value, out _))
                {
                    return;
                }
                _amplitude2 = Convert.ToDouble(value, APP_LOCALIZATION);
                OnPropertyChanged();
            }
        }

        private double _frequency1 = 1;
        public string Frequency1
        {
            get => _frequency1.ToString(APP_LOCALIZATION);
            set
            {
                if (!double.TryParse(value, out _))
                {
                    return;
                }
                _frequency1 = Convert.ToDouble(value, APP_LOCALIZATION);
                OnPropertyChanged();
            }
        }

        private double _frequency2 = 2;
        public string Frequency2
        {
            get => _frequency2.ToString(APP_LOCALIZATION);
            set
            {
                if (!double.TryParse(value, out _))
                {
                    return;
                }
                _frequency2 = Convert.ToDouble(value, APP_LOCALIZATION);
                OnPropertyChanged();
            }
        }

        private double _initialPhase1 = 0;
        public string InitialPhase1
        {
            get => _initialPhase1.ToString(APP_LOCALIZATION);
            set
            {
                if (!double.TryParse(value, out _))
                {
                    return;
                }
                _initialPhase1 = Convert.ToDouble(value, APP_LOCALIZATION);
                OnPropertyChanged();
            }
        }

        private double _initialPhase2 = 0;
        public string InitialPhase2
        {
            get => _initialPhase2.ToString(APP_LOCALIZATION);
            set
            {
                if (!double.TryParse(value, out _))
                {
                    return;
                }
                _initialPhase2 = Convert.ToDouble(value, APP_LOCALIZATION);
                OnPropertyChanged();
            }
        }

        private double _dutyFactor1 = 0;
        public string DutyFactor1
        {
            get => _dutyFactor1.ToString(APP_LOCALIZATION);
            set
            {
                if (!double.TryParse(value, out _))
                {
                    return;
                }
                _dutyFactor1 = Convert.ToDouble(value, APP_LOCALIZATION);
                OnPropertyChanged();
            }
        }

        private double _dutyFactor2 = 0;
        public string DutyFactor2
        {
            get => _dutyFactor2.ToString(APP_LOCALIZATION);
            set
            {
                if (!double.TryParse(value, out _))
                {
                    return;
                }
                _dutyFactor2 = Convert.ToDouble(value, APP_LOCALIZATION);
                OnPropertyChanged();
            }
        }
        #endregion

        #region consts
        private const int SAMPLE_RATE = 44100;
        private const int SECONDS = 3;
        #endregion     

        #region commands

        private InteractCommand _runCommand;
        public InteractCommand RunCommand => _runCommand ??
            (_runCommand = new InteractCommand((o) =>
            {
                Data data1 = new Data(_amplitude1, _frequency1, _initialPhase1, _dutyFactor1);
                Data data2 = new Data(_amplitude2, _frequency2, _initialPhase2, _dutyFactor2);

                Signal signal1 = new SinusSignal(data1);
                Signal signal2 = new ImpulseSignal(data2);

                var values = Modulation.ApplyFM(signal1, signal2, SAMPLE_RATE, SECONDS);
                SoundGenerator soundGenerator = new SoundGenerator(SAMPLE_RATE, SECONDS,
                    $"MS {signal1.GetType()} A {data1.Amplitude} F {data1.Frequency} phi0 {data1.StartPhase} D {data1.DutyFactor}. " +
                    $"CS {signal2.GetType()} A {data2.Amplitude} F {data2.Frequency} phi0 {data2.StartPhase} D {data2.DutyFactor}"
                );

                soundGenerator.Generate(values, false);

            }));

        #endregion


        #region  comboboxes
        public ObservableCollection<string> Signals { get; set; } = new ObservableCollection<string>()
        {
            "Impulse",
            "Sinus",
            "Noise",
            "Sawtooth",
            "Triangle"
        };

        private string _selectedSignal1 = null;
        public string SelectedSignal1
        {
            get { return _selectedSignal1; }
            set
            {
                _selectedSignal1 = value;
                OnPropertyChanged();
            }
        }
       

        private string _selectedSignal2 = null;
        public string SelectedSignal2
        {
            get { return _selectedSignal2; }
            set
            {
                _selectedSignal2 = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<string> Actions { get; set; } = new ObservableCollection<string>()
        {
            "Single",
            "Poly",
            "FM",
            "AM",
        };

        private string _selectedAction = null;     
        public string SelectedAction
        {
            get { return _selectedAction; }
            set
            {
                _selectedAction = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
