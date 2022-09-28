using CommunityToolkit.Mvvm.ComponentModel;
using RealEstate.Interfaces;
using RealEstate.Models;

namespace RealEstate.ViewModels
{
    [QueryProperty(nameof(IsUpdate), nameof(IsUpdate))]
    [QueryProperty(nameof(EstateId), nameof(EstateId))]
    public partial class UpsertViewModel : ObservableObject
    {
        private readonly IEstatesService _estatesService;

        public UpsertViewModel(IEstatesService estatesService)
        {
            _estatesService = estatesService;
        }

        private bool _isUpdate;
        public bool IsUpdate
        {
            get => _isUpdate;
            set
            {
                _isUpdate = value;
            }
        }

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
        private string _actionIcon;

        [ObservableProperty]
        private string _estateName;

        [ObservableProperty]
        private string _address;

        [ObservableProperty]
        private int _price;

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

        private void GetEstate(int value)
        {
            _estatesService.GetEstateById(EstateId).ContinueWith(InitView);
        }

        private void InitView(Task<Estate> task)
        {
            var estate = task.Result;

            MainThread.BeginInvokeOnMainThread(() =>
            {
                EstateName = estate.EstateName;
                Address = estate.Address;
                Price = estate.Price;
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
