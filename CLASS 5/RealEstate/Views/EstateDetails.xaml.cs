using RealEstate.Interfaces;
using RealEstate.ViewModels;

namespace RealEstate.Views;

public partial class EstateDetails : ContentPage
{
	public EstateDetails(EstateDetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}