using System;
using System.Collections.Generic;
using System.Text;

namespace RecordHidden.Interfaces
{
    public interface IAudioRecorderService
    {
        void StartRecording();
        void StopRecording();
        void PlayRecording();
    }
}
