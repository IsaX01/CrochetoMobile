using Microsoft.Extensions.Logging;
using Microcharts.Maui;
using Crocheto_0._2.Services;
using Crocheto_0._2.Pages.Access;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;

namespace Crocheto_0._2
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
                    fonts.AddFont("Brands-Regular-400.otf", "FAB");
                    fonts.AddFont("Free-Regular-400.otf", "FAR");
                    fonts.AddFont("Free-Solid-900.otf", "FAS");
                })
                .UseMicrocharts();

            builder.Services.AddSingleton(typeof(IFingerprint), CrossFingerprint.Current);

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
