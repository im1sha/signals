using System;
using System.IO;
using System.Threading;
using NAudio.Wave;
using Signals;
using Signals.Signals;

namespace Sound
{
    public class SoundGenerator
    {
        private const int BytesPerSound = 2;
        private const int MaxValue = Int16.MaxValue;
        private const int Bits = BytesPerSound * 8 ;
        private const int Channels = 1;

        private const string Extension = "wav";

        public string FileName { get; set; } = "example";

        public int SampleRate { get; set; }

        public int Seconds { get; set; }

        public SoundGenerator(int sampleRate, int seconds)
        {
            SampleRate = sampleRate;
            Seconds = seconds;
        }

        public void Generate(ISignal signal, bool saveToFile = false)
        {
            var raw = new byte[SampleRate * Seconds * BytesPerSound];

            for (int n = 0; n < SampleRate * Seconds; n++)
            {
                var x = (double) n / SampleRate;
                var sampleValue = signal.GetNormalizedSignalValue(x);
                var sample = (short) (sampleValue * MaxValue);
                var bytes = BitConverter.GetBytes(sample);

                raw[n * 2] = bytes[0];
                raw[n * 2 + 1] = bytes[1];
            }

            var ms = new MemoryStream(raw);
            var rs =
                new RawSourceWaveStream(ms, new WaveFormat(SampleRate, Bits, Channels));

            if (saveToFile)
            {
                SaveToFile(rs);
            }
            else
            {
                PlayMusic(rs);
            }
        }

        public void Generate(double[] values, bool saveToFile = false)
        {
            var raw = new byte[SampleRate * Seconds * BytesPerSound];

            for (int n = 0; n < values.Length; n++)
            {
                var sample = (short)(values[n] * MaxValue);
                var bytes = BitConverter.GetBytes(sample);

                raw[n * 2] = bytes[0];
                raw[n * 2 + 1] = bytes[1];
            }

            var ms = new MemoryStream(raw);
            var rs =
                new RawSourceWaveStream(ms, new WaveFormat(SampleRate, Bits, Channels));

            if (saveToFile)
            {
                SaveToFile(rs);
            }
            else
            {
                PlayMusic(rs);
            }
        }

        private void SaveToFile(RawSourceWaveStream rs)
        {
            WaveFileWriter.CreateWaveFile(
                $"{Directory.GetCurrentDirectory()}\\{FileName}.{Extension}", rs);
        }

        private void PlayMusic(RawSourceWaveStream rs)
        {
            var wo = new WaveOutEvent();
            wo.Init(rs);
            wo.Play();
            while (wo.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(500);
            }
            wo.Dispose();
        }
    }
}