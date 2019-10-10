using Signals;
using Signals.Signals;
using Sound;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;

namespace SoundUI.ViewModels
{
    internal class AppViewModel : INotifyPropertyChanged
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
                try
                {               
                    Data data1 = new Data(_amplitude1, _frequency1, _initialPhase1, _dutyFactor1);
                    Data data2 = new Data(_amplitude2, _frequency2, _initialPhase2, _dutyFactor2);

                    Signal signal1 = GetSignalByName(_selectedSignal1, data1);
                    Signal signal2 = GetSignalByName(_selectedSignal2, data2);

                    double[] values = new double[2];
                    switch (_selectedAction)
                    {
                        case "Single":
                            values = GetSignalValues(signal1);
                            break;
                        case "Poly":                            
                            values = GetSignalValues(new PolygarmonicSignal(signal1, signal2));                         
                            break;
                        case "FM":
                            values = Modulation.ApplyFM(signal1, signal2, SAMPLE_RATE, SECONDS);
                            break;
                        case "AM":
                            values = Modulation.ApplyAM(signal1, signal2, SAMPLE_RATE, SECONDS);
                            break;
                    }
               
                    new SoundGenerator(SAMPLE_RATE, SECONDS).Generate(values, false);
                }
                catch 
                {
                    // it will never appears
                    MessageBox.Show("Error");
                }
            }));

        private Signal GetSignalByName(string s, Data data)
        {
            switch (s)
            {
                case "Impulse": 
                    return new ImpulseSignal(data);
                case "Sinus": 
                    return new SinusSignal(data);
                case "Noise":
                    return new NoiseSignal(data);
                case "Sawtooth": 
                    return new SawtoothSignal(data);
                case "Triangle":
                    return new TriangleSignal(data);
                default:
                    throw new NotImplementedException();
            }
        }

        private double[] GetSignalValues(ISignal signal, int sampleRate = SAMPLE_RATE, int seconds = SECONDS) 
        {
            double[] result = new double[sampleRate * seconds];
            double time;

            for (int n = 0; n < seconds * sampleRate; n++)
            {
                time = (double)n / sampleRate;
                result[n] = signal.GetNormalizedSignalValue(time);
            }

            return result;
        }

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
            get => _selectedSignal1;
            set
            {
                _selectedSignal1 = value;
                OnPropertyChanged();
            }
        }


        private string _selectedSignal2 = null;
        public string SelectedSignal2
        {
            get => _selectedSignal2;
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
            get => _selectedAction;
            set
            {
                _selectedAction = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
