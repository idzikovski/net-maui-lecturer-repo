namespace SandboxApp.MVVM;

public partial class FullNamePage : ContentPage
{
	public FullNamePage()
	{
		InitializeComponent();
		BindingContext = new FullNameViewModel();
	}

	private void TextChanged(object sender, TextChangedEventArgs e)
	{
		//FullName.Text = $"{FirstName.Text} {LastName.Text}";
	}
}