using AVFoundation;
using Foundation;
using RecordHidden.Interfaces;

namespace RecordHidden.Platforms.iOS
{
    public class AudioRecorderService : IAudioRecorderService
    {
        AVAudioRecorder? recorder;
        AVAudioPlayer? player;
        NSUrl? audioFilePath;

        public void StartRecording()
        {
            var audioSession = AVAudioSession.SharedInstance();
            audioSession.SetCategory(AVAudioSessionCategory.PlayAndRecord);
            audioSession.SetActive(true);

            var settings = new AudioSettings
            {
                SampleRate = 44100,
                Format = AudioToolbox.AudioFormatType.LinearPCM,
                NumberChannels = 1,
                AudioQuality = AVAudioQuality.High
            };

            audioFilePath = NSUrl.FromFilename("recording.m4a");
            recorder = AVAudioRecorder.Create(audioFilePath, settings, out NSError? error);

            if (error == null)
            {
                recorder?.Record();
            }
        }

        public void StopRecording()
        {
            recorder?.Stop();
        }

        public void PlayRecording()
        {
            if (audioFilePath != null)
            {
                player = AVAudioPlayer.FromUrl(audioFilePath);
                player?.Play();
            }
        }

        public string? GetFilePath()
        {
            return audioFilePath?.Path;
        }
    }
}