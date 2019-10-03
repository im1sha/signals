using NAudio.Wave;
using Signals;
using System;
using System.IO;
using System.Threading;

namespace Sound
{
    public class SoundGenerator
    {
        private const int MAX_VALUE = short.MaxValue;
        private const int BYTES_PER_SOUND = 2;
        private const int BITS_PER_SOUND = BYTES_PER_SOUND * 8;
        private const int CHANNELS = 1;

        private const string EXTENSION = "wav";

        public string FileName { get; }

        public int SampleRate { get; }

        public int Seconds { get; }

        public SoundGenerator(int sampleRate, int seconds, string fileName = "example")
        {
            SampleRate = sampleRate;
            Seconds = seconds;
            FileName = fileName;
        }

        public void Generate(ISignal signal, bool saveToFile = false)
        {
            var raw = new byte[SampleRate * Seconds * BYTES_PER_SOUND];

            for (int n = 0; n < SampleRate * Seconds; n++)
            {
                var x = (double)n / SampleRate;
                var sampleValue = signal.GetNormalizedSignalValue(x);
                var sample = (short)(sampleValue * MAX_VALUE);
                var bytes = BitConverter.GetBytes(sample);

                raw[n * 2] = bytes[0];
                raw[n * 2 + 1] = bytes[1];
            }

            Generate(raw, saveToFile);
        }

        public void Generate(double[] values, bool saveToFile = false)
        {
            var raw = new byte[SampleRate * Seconds * BYTES_PER_SOUND];

            for (int n = 0; n < values.Length; n++)
            {
                var sample = (short)(values[n] * MAX_VALUE);
                var bytes = BitConverter.GetBytes(sample);

                raw[n * 2] = bytes[0];
                raw[n * 2 + 1] = bytes[1];
            }

            Generate(raw, saveToFile);
        }

        private void Generate(byte[] rawBytes, bool saveToFile)
        {
            var ms = new MemoryStream(rawBytes);
            var rs = new RawSourceWaveStream(ms, new WaveFormat(SampleRate, BITS_PER_SOUND, CHANNELS));

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
                $"{Directory.GetCurrentDirectory()}\\{FileName}.{EXTENSION}", rs);
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