using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Signals;
//using Signals.Modulation;
using Signals.Signals;

namespace UI
{
    public partial class Form1 : Form
    {
        private const int SampleRate = 1000;
        private const int Seconds = 2;
        private const bool IsAmplitude = false;

        private readonly Data data1;
        private readonly Data data2;

        private ISignal signal;

        public Form1()
        {
            InitializeComponent();
            ConfigureAxis(chart1.ChartAreas[0].AxisX);
            ConfigureAxis(chart1.ChartAreas[0].AxisY);


            data1 = new Data(2, 2, 0, 0.5);
            data2 = new Data(1, 10, 0, 0.5);
        }

        private void ConfigureAxis(Axis axis)
        {
            //axis.IsMarginVisible = false;
            //axis.LineWidth = 2;
            axis.Crossing = 0;
            //axis.Minimum = -1;
        }


        private void CreateChartFunction()
        {
            chart1.Series[0].Points.Clear();
            double x, func;

            for (int n = 0; n < SampleRate * Seconds; n++)
            {
                x = (double)n / SampleRate;
                func = signal.GetVolume(x);

                chart1.Series[0].Points.AddXY(x, func);
            }
        }

        public void DrawChartByValues(double[] values)
        {
            chart1.Series[0].Points.Clear();

            for (int n = 0; n < SampleRate * Seconds; n++)
            {
                var x = (double) n / SampleRate;

                chart1.Series[0].Points.AddXY(x, values[n]);
            }
        }


        public void ChooseSignal(int x)
        {
            switch (x)
            {
                case 0:
                    signal = new SinusSignal(data1);
                    break;
                case 1:
                    signal = new ImpulseSignal(data1);
                    break;
                case 2:
                    signal = new TriangleSignal(data1);
                    break;
                case 3:
                    signal = new SawtoothSignal(data1);
                    break;
                case 4:
                    signal = new NoiseSignal(data1);
                    break;
                case 5: 
                    signal = new PolygarmonicSignal(
                        new SinusSignal(data1), 
                        new SinusSignal(data2));
                    break;
            }
            CreateChartFunction();
        }

        public void ChooseModulationSignal(int x)
        {
            double[] values;
            switch (x)
            {
                case 1:
                    values = GetModulationSignal(
                        new SinusSignal(data1), 
                        new SinusSignal(data2));
                    break;
                case 2:
                    values = GetModulationSignal(
                        new TriangleSignal(data1), 
                        new SinusSignal(data2));
                    break;
                case 3:
                    values = GetModulationSignal(
                        new SinusSignal(data1), 
                        new ImpulseSignal(data2));
                    break;
                case 4:
                    values = GetModulationSignal(
                        new TriangleSignal(data1), 
                        new ImpulseSignal(data2));
                    break;
                default:
                    values = new double[1];
                    break;
            }

            DrawChartByValues(values);
        }

        public double[] GetModulationSignal(Signal modulatorSignal,
            Signal carrierSignal)
        {
            if (IsAmplitude)
            {
#pragma warning disable CS0162 // Unreachable code detected
                return Modulation.Amplitude(modulatorSignal, 
                    carrierSignal, SampleRate, Seconds);
#pragma warning restore CS0162 // Unreachable code detected                 
            }
            else
            {
                return Modulation.Frequency(modulatorSignal,
                    carrierSignal, SampleRate, Seconds);
            }
        }

        #region Buttons

        private void Button1_Click(object sender, EventArgs e)
        {
            ChooseSignal(0);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ChooseSignal(1);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ChooseSignal(2);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ChooseSignal(3);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            ChooseSignal(4);
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            ChooseSignal(5);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            ChooseModulationSignal(1);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            ChooseModulationSignal(2);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            ChooseModulationSignal(3);
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            ChooseModulationSignal(4);

        }

        #endregion
    }
}
