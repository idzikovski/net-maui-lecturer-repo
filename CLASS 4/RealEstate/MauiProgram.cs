using RealEstate.Interfaces;
using RealEstate.Services;
using RealEstate.Views;

namespace RealEstate;

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

		builder.Services.AddSingleton<LoginPage>();
		builder.Services.AddTransient<EstatesPage>();
		builder.Services.AddTransient<EstateDetails>();

		builder.Services.AddSingleton<IImageProvider, ImageProvider>();
		builder.Services.AddSingleton<IEstatesService, LocalEstateService>();

		return builder.Build();
	}
}
