using RealEstate.ViewModels;

namespace RealEstate.Views;

public partial class EstatesPage : ContentPage
{
	public EstatesPage(EstatesViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	private void SwipeView_SwipeStarted(object sender, SwipeStartedEventArgs e)
	{
		((EstatesViewModel)BindingContext).TapLocked = true;
	}

	private void SwipeView_SwipeEnded(object sender, SwipeEndedEventArgs e)
	{
		((EstatesViewModel)BindingContext).TapLocked = false;
		collectionView.SelectedItem = null;
	}
}