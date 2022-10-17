namespace SandboxApp.Data;

public partial class RestClientView : ContentPage
{
	public RestClientView()
	{
		InitializeComponent();
		BindingContext = new RestClientViewModel();
	}
}