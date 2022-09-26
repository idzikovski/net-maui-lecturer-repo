using RealEstate.ViewModels;
using RealEstate.Views;

namespace RealEstate;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(EstateDetails), typeof(EstateDetails));
	}

	private void LogoutClicked(object sender, EventArgs e)
	{
		Current.GoToAsync("//LoginPage");
		Preferences.Default.Set(LoginViewModel.IsLoggedInKey, false);
    }
}
