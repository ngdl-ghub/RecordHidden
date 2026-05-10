using Microsoft.Extensions.Logging;
using RecordHidden.Interfaces;

namespace RecordHidden
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
#if WINDOWS
builder.Services.AddSingleton<IAudioRecorderService, RecordHidden.Platforms.Windows.AudioRecorderService>();
#elif IOS
builder.Services.AddSingleton<IAudioRecorderService, RecordHidden.Platforms.iOS.AudioRecorderService>();
#endif
            return builder.Build();
        }
    }
}
