using CommunityToolkit.Maui;
using RealEstate.Interfaces;
using RealEstate.Services;
using RealEstate.ViewModels;
using RealEstate.Views;

namespace RealEstate;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<LoginPage>();
		builder.Services.AddTransient<EstatesPage>();
		builder.Services.AddTransient<EstateDetails>();
		builder.Services.AddTransient<UpsertPage>();

		builder.Services.AddTransient<LoginViewModel>();
		builder.Services.AddTransient<EstatesViewModel>();
		builder.Services.AddTransient<EstateDetailsViewModel>();
		builder.Services.AddTransient<UpsertViewModel>();

		builder.Services.AddSingleton<IImageProvider, ImageProvider>();
		builder.Services.AddSingleton<IEstatesService, EstatesService>();
		builder.Services.AddSingleton<IRestService, RestService>();
		builder.Services.AddSingleton<Interfaces.IPreferences, PreferencesImp>();

		return builder.Build();
	}
}
