namespace RealEstate.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//EstatesPage");
	}
}