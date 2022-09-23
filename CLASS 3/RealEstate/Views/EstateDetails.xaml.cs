namespace RealEstate.Views;

public partial class EstateDetails : ContentPage
{
	public EstateDetails()
	{
		InitializeComponent();
		carouselView.ItemsSource = new List<string> { "One", "Two", "Three", "Four" };
	}
}