using RealEstate.ViewModels;

namespace RealEstate.Views;

public partial class UpsertPage : ContentPage
{
	public UpsertPage(UpsertViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}