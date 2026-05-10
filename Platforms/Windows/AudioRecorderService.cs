using NAudio.Wave;
using RecordHidden.Interfaces;

namespace RecordHidden.Platforms.Windows
{
    public class AudioRecorderService : IAudioRecorderService
    {
        private WaveInEvent? waveIn;
        private WaveFileWriter? writer;
        private string outputFilePath = "recorded.wav";

        public void StartRecording()
        {
            waveIn = new WaveInEvent();
            waveIn.WaveFormat = new WaveFormat(44100, 1); // 44.1kHz, mono
            writer = new WaveFileWriter(outputFilePath, waveIn.WaveFormat);

            waveIn.DataAvailable += (s, a) =>
            {
                writer.Write(a.Buffer, 0, a.BytesRecorded);
            };

            waveIn.StartRecording();
        }

        public void StopRecording()
        {
            waveIn?.StopRecording();
            waveIn?.Dispose();
            writer?.Dispose();
        }

        public void PlayRecording()
        {
            using var audioFile = new AudioFileReader(outputFilePath);
            using var outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();

            // Chờ đến khi phát xong
            while (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
