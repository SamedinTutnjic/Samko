using Microsoft.Extensions.Logging;
using BoredActivityApp.Services;
using BoredActivityApp.ViewModels;

namespace BoredActivityApp
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

            // Registracija API servisa i ViewModel-a
            builder.Services.AddSingleton<IApiService, ApiService>();
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<DetailViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}