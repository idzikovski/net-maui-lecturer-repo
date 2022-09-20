using RealEstate.Interfaces;
using RealEstate.Models;
using RealEstate.Services;

namespace RealEstate.Views;

public partial class EstatesPage : ContentPage
{
	public EstatesPage()
	{
		InitializeComponent();

		var service = new LocalEstateService();
		service.GetEstates().ContinueWith(EstatesLoaded);
	}

	private void EstatesLoaded(Task<List<Estate>> task)
	{
		MainThread.BeginInvokeOnMainThread(() =>
		{
			var estates = task.Result;
			var imageProvider = new ImageProvider();

			foreach (var item in estates)
			{
				item.Photo = imageProvider.GetImage();
			}

			collectionView.ItemsSource = estates;
		});
	}
}