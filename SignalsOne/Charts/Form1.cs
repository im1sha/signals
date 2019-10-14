using Signals;
using Signals.Signals;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Charts
{
    public partial class Form1 : Form
    {
        private const int SAMPLE_RATE = 1000;
        private const int SECONDS = 2;
        private const bool IS_AM = false;

        private readonly Data DATA_1;
        private readonly Data DATA_2;

        private ISignal _signal;

        public Form1()
        {
            InitializeComponent();
            ConfigureAxis(chart1.ChartAreas[0].AxisX);
            ConfigureAxis(chart1.ChartAreas[0].AxisY);


            DATA_1 = new Data(100, 1000, 0, 0.125);
            DATA_2 = new Data(2, 10, 0, 0.5);
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

            for (int n = 0; n < SAMPLE_RATE * SECONDS; n++)
            {
                x = (double)n / SAMPLE_RATE;
                func = _signal.GetVolume(x);

                chart1.Series[0].Points.AddXY(x, func);
            }
        }

        public void DrawChartByValues(double[] values)
        {
            chart1.Series[0].Points.Clear();

            for (int n = 0; n < SAMPLE_RATE * SECONDS; n++)
            {
                var x = (double)n / SAMPLE_RATE;

                chart1.Series[0].Points.AddXY(x, values[n]);
            }
        }


        public void ChooseSignal(int x)
        {
            switch (x)
            {
                case 0:
                    _signal = new SinusSignal(DATA_1);
                    break;
                case 1:
                    _signal = new ImpulseSignal(DATA_1);
                    break;
                case 2:
                    _signal = new TriangleSignal(DATA_1);
                    break;
                case 3:
                    _signal = new SawtoothSignal(DATA_1);
                    break;
                case 4:
                    _signal = new NoiseSignal(DATA_1);
                    break;
                case 5:
                    _signal = new PolygarmonicSignal(
                        new SinusSignal(DATA_1),
                        new SinusSignal(DATA_2));
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
                        new SinusSignal(DATA_1),
                        new SinusSignal(DATA_2));
                    break;
                case 2:
                    values = GetModulationSignal(
                        new TriangleSignal(DATA_1),
                        new SinusSignal(DATA_2));
                    break;
                case 3:
                    values = GetModulationSignal(
                        new SinusSignal(DATA_1),
                        new ImpulseSignal(DATA_2));
                    break;
                case 4:
                    values = GetModulationSignal(
                        new TriangleSignal(DATA_1),
                        new ImpulseSignal(DATA_2));
                    break;
                #region test section 
                case 5:
                    values = GetModulationSignal(
                          new SinusSignal(new Data(1, 2, 0, 0)),
                          new ImpulseSignal(new Data(1, 2, 0, 0.25)));
                    break;
                case 6:
                    values = GetModulationSignal(
                          new SinusSignal(new Data(1, 2, 0, 0)),
                          new ImpulseSignal(new Data(1, 2, 0, 0.5)));
                    break;
                #endregion
                default:
                    values = new double[1];
                    break;
            }

            DrawChartByValues(values);
        }

        public double[] GetModulationSignal(Signal modulatorSignal,
            Signal carrierSignal)
        {
            if (IS_AM)
            {
#pragma warning disable CS0162 // Unreachable code detected
                return Modulation.ApplyAM(modulatorSignal,
                    carrierSignal, SAMPLE_RATE, SECONDS);
#pragma warning restore CS0162 // Unreachable code detected                 
            }
            else
            {
#pragma warning disable CS0162 // Unreachable code detected
                return Modulation.ApplyFM(modulatorSignal,
                    carrierSignal, SAMPLE_RATE, SECONDS);
#pragma warning restore CS0162 // Unreachable code detected
            }
        }

        #region test buttons

        private void buttonTest1_Click_1(object sender, EventArgs e)
        {
            ChooseModulationSignal(5);
        }

        private void buttonTest2_Click_1(object sender, EventArgs e)
        {
            ChooseModulationSignal(6);
        }

        #endregion

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
