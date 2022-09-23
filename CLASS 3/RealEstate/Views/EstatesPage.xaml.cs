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

	private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (collectionView.SelectedItem == null)
		{
			return;
		}

		var estate = collectionView.SelectedItem as Estate;

		Shell.Current.GoToAsync($"{nameof(EstateDetails)}?EstateId={estate.Id}");

		collectionView.SelectedItem = null;
    }
}