using CommunityToolkit.Mvvm.ComponentModel;
using RealEstate.Interfaces;
using RealEstate.Models;

namespace RealEstate.ViewModels
{
    [QueryProperty(nameof(EstateId), nameof(EstateId))]
    public partial class EstateDetailsViewModel : ObservableObject
    {
        private readonly IEstatesService _estatesService;

        private int _estateId;
        public int EstateId
        {
            get => _estateId;
            set
            {
                _estateId = value;
                GetEstate(value);
            }
        }

        [ObservableProperty]
        private List<string> _photos;

        [ObservableProperty]
        private string _photo;

        [ObservableProperty]
        private string _estateName;

        [ObservableProperty]
        private string _address;

        [ObservableProperty]
        private int _bedrooms;

        [ObservableProperty]
        private int _bathrooms;

        [ObservableProperty]
        private int _area;

        [ObservableProperty]
        private string _contactPersonName;

        [ObservableProperty]
        private string _contactPersonPhone;

        [ObservableProperty]
        private string _contactPersonEmail;

        public EstateDetailsViewModel(IEstatesService estatesService)
        {
            _estatesService = estatesService;
        }

        private void GetEstate(int value)
        {
            _estatesService.GetEstateById(EstateId).ContinueWith(InitView);
        }

        private void InitView(Task<Estate> task)
        {
            var estate = task.Result;

            MainThread.BeginInvokeOnMainThread(() =>
            {
                Photos = estate.Photos;
                Photo = estate.Photo;
                EstateName = estate.EstateName;
                Address = estate.Address;
                Bedrooms = estate.RoomNumber;
                Bathrooms = estate.BathroomNumber;
                Area = estate.Area;
                ContactPersonName = estate.ContactPersonName;
                ContactPersonPhone = estate.ContactPersonPhone;
                ContactPersonEmail = estate.ContactPersonEmail;
            });
        }
    }
}
