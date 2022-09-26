using RealEstate.Interfaces;
using RealEstate.Models;
using System.Collections.ObjectModel;

namespace RealEstate.Views;

public partial class EstatesPage : ContentPage
{
	private ObservableCollection<Estate> _estates;
    private bool tapLocked;
    private readonly IEstatesService _estatesService;

    public EstatesPage(IEstatesService estatesService)
	{
		InitializeComponent();
		estatesService.GetEstates().ContinueWith(EstatesLoaded);
		_estatesService = estatesService;
	}

	private void EstatesLoaded(Task<List<Estate>> task)
	{
		MainThread.BeginInvokeOnMainThread(() =>
		{
			_estates = new ObservableCollection<Estate>(task.Result);
			collectionView.ItemsSource = _estates;
		});
	}

	private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (collectionView.SelectedItem == null || tapLocked)
		{
			return;
		}

		var estate = collectionView.SelectedItem as Estate;

		Shell.Current.GoToAsync($"{nameof(EstateDetails)}?EstateId={estate.Id}");

		collectionView.SelectedItem = null;
    }

	private void DeleteInvoked(object sender, EventArgs e)
	{
		var swipeItem = (SwipeItem)sender;
		var estate = (Estate)swipeItem.BindingContext;
		Task.Run(() => _estatesService.DeleteEstateById(estate.Id));
		_estates.Remove(estate);
	}

    private void EditInvoked(object sender, EventArgs e)
    {
    }

    private void SwipeView_SwipeStarted(object sender, SwipeStartedEventArgs e)
	{
		tapLocked = true;
	}

	private void SwipeView_SwipeEnded(object sender, SwipeEndedEventArgs e)
	{
		tapLocked = false;
        collectionView.SelectedItem = null;
    }
}