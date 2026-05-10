using RecordHidden.Interfaces;

namespace RecordHidden
{
    public partial class MainPage : ContentPage
    {
        private readonly IAudioRecorderService _recorder;
        private int count = 0;
        public MainPage(IAudioRecorderService recorder)
        {
            InitializeComponent();
            _recorder = recorder;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;
            if (count == 1)
            {
                _recorder.StartRecording();
            }
            else if (count == 2)
            {
                _recorder.StopRecording();
            }
            else if (count == 3)
            {
                _recorder.PlayRecording();
                count = 0; // reset vòng lặp
            }
        }
        private void OnRecordClicked(object sender, EventArgs e)
        {
            // Tạm thời chỉ test, chưa viết logic
            StatusLabel.Text = "Record button clicked";
        }

        private void OnStopClicked(object sender, EventArgs e)
        {
            StatusLabel.Text = "Stop button clicked";
        }

        private void OnPlayClicked(object sender, EventArgs e)
        {
            StatusLabel.Text = "Play button clicked";
        }
    }
}
