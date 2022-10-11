namespace SandboxApp;

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

#if ANDROID && DEBUG
        Platforms.Android.DangerousAndroidMessageHandlerEmitter.Register();
        Platforms.Android.DangerousTrustProvider.Register();
#endif

        return builder.Build();
	}
}
