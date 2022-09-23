using Android.Locations;
using RealEstate.Interfaces;
using RealEstate.Models;

namespace RealEstate.Views;
[QueryProperty(nameof(EstateId), nameof(EstateId))]
public partial class EstateDetails : ContentPage
{
	private readonly IEstatesService _estatesService;

	public int EstateId { get; set; }

	public EstateDetails(IEstatesService estatesService)
	{
		InitializeComponent();
		_estatesService = estatesService;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		_estatesService.GetEstateById(EstateId).ContinueWith(InitView);
	}

	private void InitView(Task<Estate> task)
	{
		var estate = task.Result;

		MainThread.BeginInvokeOnMainThread(() =>
		{
			carouselView.ItemsSource = estate.Photos;
			EstateName.Text = estate.EstateName;
			Address.Text = estate.Address;
			Bedrooms.Text = $"{estate.RoomNumber} bedroom";
			Bathrooms.Text = $"{estate.BathroomNumber} bathrooms";
			Area.Text = $"{estate.Area}m²";
			Contact.Text = estate.ContactPersonName;
			Phone.Text = estate.ContactPersonPhone;
			Email.Text = estate.ContactPersonEmail;
		});
	}
}