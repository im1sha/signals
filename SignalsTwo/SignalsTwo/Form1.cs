using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SignalsTwo
{
    //
    // x(n) = sin(2 * Math.PI * n / N)
    // N % 64 == 0 
    // n = {0 .. M}
    // M 
    public partial class Form1 : Form
    {
        private Series signal;
        private Series DataSer_1;
        private Series DataSer_2;
        private Series A_1;
        private Series A_2;
        private int K;
        private double phi;
        private readonly double[] phc = new double[15];

        public Form1()
        {
            InitializeComponent();
        }

        //private static double DiscreteFourierTransform(double[] signal, int j)
        //{
        //    double N = signal.Length;
        //    double Acj = 2 / N, Asj = 2 / N;
        //    double sumAcj = 0.0d, sumAsj = 0.0d;
        //    for (int i = 0; i < N - 1; i++)
        //    {
        //        sumAcj += signal[i] * Math.Cos(2 * Math.PI * i * j / N);
        //        sumAcj += signal[i] * Math.Sin(2 * Math.PI * i * j / N);
        //    }

        //    Acj *= sumAcj;
        //    Asj *= sumAsj;

        //    return Math.Sqrt(Math.Pow(Acj, 2) + Math.Pow(Asj, 2));
        //}

        private void BuildGraphWithoutPhi()
        {
            chart3.Series.Clear();
            chart4.Series.Clear();

            chart3.Legends.Clear();
            chart4.Legends.Clear();
            DataSer_1 = new Series
            {
                Name = "СКЗ1",
                ChartType = SeriesChartType.Spline,
                Color = Color.Blue,
            };
            DataSer_2 = new Series
            {
                Name = "СКЗ2",
                ChartType = SeriesChartType.Spline,
                Color = Color.BlueViolet,
            };
            signal = new Series
            {
                Name = "X",
                ChartType = SeriesChartType.Spline,
                Color = Color.OrangeRed
            };
            A_1 = new Series
            {
                Name = "A_1",
                ChartType = SeriesChartType.Spline,
                Color = Color.Black
            };
            A_2 = new Series
            {
                Name = "A_2",
                ChartType = SeriesChartType.Spline,
                Color = Color.YellowGreen
            };

            int N = int.Parse(comboBox1.Text);
            K = N / 4;

            // should be M = N - 1
            for (int M = K; M <= 2 * N; M++)
            {
                double rms_1 = 0, rms_2 = 0, acj = 0, asj = 0;
                for (int n = 0; n <= M; n++)
                {
                    double t = Math.Sin(2 * Math.PI * n / N);

                    rms_1 += Math.Pow(t, 2);
                    rms_2 += t;

                    acj += t * Math.Sin(2 * Math.PI * n / M);
                    asj += t * Math.Cos(2 * Math.PI * n / M);
                }
                acj = 2 * acj / M;
                asj = 2 * asj / M;

                signal.Points.AddXY(M, rms_2);
                DataSer_1.Points.AddXY(M, 0.707 - Math.Sqrt(rms_1 / (M + 1)));
                DataSer_2.Points.AddXY(M, 0.707 - (Math.Sqrt(rms_1 / (M + 1) - Math.Pow(rms_2 / (M + 1), 2))));
                A_1.Points.AddXY(M, 1 - Math.Sqrt(acj * acj + asj * asj));
            }
            chart3.ResetAutoValues();
            chart4.ResetAutoValues();

            chart3.Legends.Add(signal.Legend);
            chart4.Legends.Add(DataSer_1.Legend);
            chart3.Series.Add(signal);
            chart4.Series.Add(DataSer_1);
            chart4.Series.Add(DataSer_2);
            chart4.Series.Add(A_1);
            //chart4.Series.Add(A_2);
        }

        private void BuildGraph()
        {
            chart1.Series.Clear();
            chart2.Series.Clear();

            chart1.Legends.Clear();
            chart2.Legends.Clear();

            DataSer_1 = new Series
            {
                Name = "СКЗ1",
                ChartType = SeriesChartType.Spline,
                Color = Color.Blue
            };
            DataSer_2 = new Series
            {
                Name = "СКЗ2",
                ChartType = SeriesChartType.Spline,
                Color = Color.BlueViolet
            };
            signal = new Series
            {
                Name = "X",
                ChartType = SeriesChartType.Spline,
                Color = Color.OrangeRed
            };
            A_1 = new Series
            {
                Name = "A_1",
                ChartType = SeriesChartType.Spline,
                Color = Color.Black
            };
            A_2 = new Series
            {
                Name = "A_2",
                ChartType = SeriesChartType.Spline,
                Color = Color.YellowGreen
            };
            int N = int.Parse(comboBox1.Text);
            K = 3 * N / 4;
            phi = 120;
            for (int M = K; M <= 2 * N; M++)
            {
                double rms_1 = 0, rms_2 = 0, acj = 0, asj = 0;
                for (int n = 0; n <= M; n++)
                {
                    double t = Math.Sin(2 * Math.PI * n / N 
                        + phi / 180 * Math.PI);
                    rms_1 += Math.Pow(t, 2);
                    rms_2 += t;

                    acj += t * Math.Sin(2 * Math.PI * n / M);
                    asj += t * Math.Cos(2 * Math.PI * n / M);
                }

                acj = acj * 2 / M;
                asj = asj * 2 / M;

                signal.Points.AddXY(M, rms_2);
                DataSer_1.Points.AddXY(M, 0.707 - Math.Sqrt(rms_1 / (M + 1)));
                DataSer_2.Points.AddXY(M, 0.707 - (Math.Sqrt(rms_1 / (M + 1) - Math.Pow(rms_2 / (M + 1), 2))));
                A_1.Points.AddXY(M, 1 - Math.Sqrt(acj * acj + asj * asj));
                //A_2.Points.AddXY(M, 1 - 0.707 * (Math.Sqrt(rms_1 / (M + 1) - Math.Pow(rms_2 / (M + 1), 2))));
            }
            chart1.ResetAutoValues();
            chart2.ResetAutoValues();

            chart2.Legends.Add(DataSer_1.Legend);
            chart1.Legends.Add(signal.Legend);
            chart2.Series.Add(signal);
            chart1.Series.Add(DataSer_1);
            chart1.Series.Add(DataSer_2);
            chart1.Series.Add(A_1);
            //chart1.Series.Add(A_2);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            BuildGraph();
            BuildGraphWithoutPhi();
        }
    }
}
