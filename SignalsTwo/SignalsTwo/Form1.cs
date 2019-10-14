using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SignalsTwo
{
    public partial class Form1 : Form
    {
        #region const 
        private const double ROOT_OF_2_DIVIDED_BY_2
            = 0.707; //Math.Sqrt(2) / 2;

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region view
        private static void ClearCharts(params Chart[] charts)
        {
            foreach (var item in charts)
            {
                item.Series.Clear();
                item.Legends.Clear();
            }
        }

        private static Series CreateSeries(string str, Color col)
        {
            return new Series
            {
                Name = str,
                ChartType = SeriesChartType.Spline,
                Color = col,
            };
        }

        private static void Draw(params (Chart Chart,
            string Legend,
            IEnumerable<Series> SeriesCollection)[] charts)
        {
            foreach (var item in charts)
            {
                item.Chart.ResetAutoValues();
                item.Chart.Legends.Add(item.Legend);
                foreach (var series in item.SeriesCollection)
                {
                    item.Chart.Series.Add(series);
                }
            }
        }

        #endregion

        #region model 
        private static double GetSinusSignal(int i, int N, double phase = 0.0)
        {
            return Math.Sin(2 * Math.PI * i / N + phase);
        }

        private static double GetCosinusSignal(int i, int N, double phase = 0.0)
        {
            return Math.Cos(2 * Math.PI * i / N + phase);
        }
        #endregion

        private void Core(Chart rootMeanSquareDeltaChart1,
            Chart rootMeanSquareDeltaChart2,
            Chart amplitudesDeltaChart,
            IEnumerable<int> N,
            IEnumerable<int> K,
            double phi = 0)
        {
            if (N.Count() != K.Count() || K.Count() != 2)
            {
                throw new ArgumentException();
            }

            int total = N.Count();
            double[] widthMultipliers = new[] { N.ElementAt(1) / (double)N.ElementAt(0), 1.0 };

            ClearCharts(rootMeanSquareDeltaChart1, rootMeanSquareDeltaChart2, amplitudesDeltaChart);

            IList<Series> amplitudesDeltaCollection = Enumerable.Range(0, total)
                .Select(i => CreateSeries($"delta A {i+1}", i % 2 == 0 ? Color.Navy : Color.Red)).ToList();

            IList<Series> rootMeanSquareDeltaCollection1 = Enumerable.Range(0, total)
                .Select(i => CreateSeries($"delta RMS1 {i+1}", i % 2 == 0 ? Color.Navy : Color.Red)).ToList();

            IList<Series> rootMeanSquareDeltaCollection2 = Enumerable.Range(0, total)
                .Select(i => CreateSeries($"delta RMS2 {i+1}", i % 2 == 0 ? Color.Navy : Color.Red)).ToList();

            for (int j = 0; j < total; j++)
            {
                for (int M = K.ElementAt(j); M < 2 * N.ElementAt(j); M++)
                {
                    double rms1 = 0;
                    double rms2 = 0;
                    double cosPartOfAmplitude = 0;
                    double sinPartOfAmplitude = 0;

                    for (int i = 0; i < M; i++)
                    {
                        double x = GetSinusSignal(i, N.ElementAt(j), phi);
                        rms1 += Math.Pow(x, 2);
                        rms2 += x;
                        cosPartOfAmplitude += x * GetCosinusSignal(i, M);
                        sinPartOfAmplitude += x * GetSinusSignal(i, M);
                    }
                    cosPartOfAmplitude = 2 * cosPartOfAmplitude / M;
                    sinPartOfAmplitude = 2 * sinPartOfAmplitude / M;

                    rootMeanSquareDeltaCollection1.ElementAt(j).Points.AddXY(
                        M * widthMultipliers.ElementAt(j),
                        ROOT_OF_2_DIVIDED_BY_2 - Math.Sqrt(
                            rms1 / (M + 1))); ;

                    rootMeanSquareDeltaCollection2.ElementAt(j).Points.AddXY(
                        M * widthMultipliers.ElementAt(j),
                        ROOT_OF_2_DIVIDED_BY_2 - Math.Sqrt(
                            rms1 / (M + 1) - Math.Pow(rms2 / (M + 1), 2)));

                    amplitudesDeltaCollection.ElementAt(j).Points.AddXY(
                        M * widthMultipliers.ElementAt(j),
                        1 - Math.Sqrt(
                            cosPartOfAmplitude * cosPartOfAmplitude
                            + sinPartOfAmplitude * sinPartOfAmplitude));
                }
            }
            Draw(
                (amplitudesDeltaChart,
                amplitudesDeltaCollection.ElementAt(0).Legend,
                amplitudesDeltaCollection)
                ,
                (rootMeanSquareDeltaChart2,
                rootMeanSquareDeltaCollection2.ElementAt(0).Legend,
                rootMeanSquareDeltaCollection2)
                ,
                (rootMeanSquareDeltaChart1,
                rootMeanSquareDeltaCollection1.ElementAt(0).Legend,
                rootMeanSquareDeltaCollection1));
        }

        private void Execute(object sender, EventArgs e)
        {
            int N2 = int.Parse(selectN2.Text);
            int N1 = int.Parse(selectN1.Text);
            double phi = double.Parse(selectPhi.Text);

            int k1 = 3 * N1 / 4;
            int k2 = 3 * N2 / 4;

            Core(rootMeanSquareDeltaChart1,
                rootMeanSquareDeltaChart2,
                amplitudesDeltaChart,
                new[] { N1, N2 },
                new[] { k1, k2 },
                phi / 180 * Math.PI);
        }
    }
}
