using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RealEstate.Interfaces;
using RealEstate.Models;

namespace RealEstate.ViewModels
{
    [QueryProperty(nameof(IsUpdate), nameof(IsUpdate))]
    [QueryProperty(nameof(EstateId), nameof(EstateId))]
    public partial class UpsertViewModel : Estate
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
                ActionIcon = IsUpdate ? "save" : "create";
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

        private void GetEstate(int value)
        {
            _estatesService.GetEstateById(EstateId).ContinueWith(InitView);
        }

        private void InitView(Task<Estate> task)
        {
            var estate = task.Result;

            MainThread.BeginInvokeOnMainThread(() =>
            {
                Id = estate.Id;
                EstateName = estate.EstateName;
                Address = estate.Address;
                Price = estate.Price;
                RoomNumber = estate.RoomNumber;
                BathroomNumber = estate.BathroomNumber;
                Area = estate.Area;
                ContactPersonName = estate.ContactPersonName;
                ContactPersonPhone = estate.ContactPersonPhone;
                ContactPersonEmail = estate.ContactPersonEmail;
            });
        }

        [RelayCommand]
        private async Task Upsert()
        {
            if (IsUpdate)
            {
                await _estatesService.Update(this);
            }
            else
            {
                await _estatesService.Create(this);
            }

            await Shell.Current.GoToAsync("..?Update=true");
        }
    }
}
