using RealEstate.Interfaces;
using RealEstate.Models;
using RealEstate.Services;

namespace RealEstate.Views;

public partial class EstatesPage : ContentPage
{
	public EstatesPage(IEstatesService estatesService)
	{
		InitializeComponent();
		estatesService.GetEstates().ContinueWith(EstatesLoaded);
	}

	private void EstatesLoaded(Task<List<Estate>> task)
	{
		MainThread.BeginInvokeOnMainThread(() =>
		{
			collectionView.ItemsSource = task.Result;
		});
	}
}