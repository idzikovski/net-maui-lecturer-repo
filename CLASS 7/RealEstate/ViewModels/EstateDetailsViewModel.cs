using CommunityToolkit.Mvvm.ComponentModel;
using RealEstate.Interfaces;
using RealEstate.Models;

namespace RealEstate.ViewModels
{
    
    [QueryProperty(nameof(EstateId), nameof(EstateId))]
    public partial class EstateDetailsViewModel : Estate
    {
        private readonly IEstatesService _estatesService;

        private int _estateId;
        public int EstateId
        {
            get => _estateId;
            set
            {
                _estateId = value;
                GetEstate();
            }
        }

        public EstateDetailsViewModel(IEstatesService estatesService)
        {
            _estatesService = estatesService;
        }

        private void GetEstate()
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
                RoomNumber = estate.RoomNumber;
                BathroomNumber = estate.BathroomNumber;
                Area = estate.Area;
                ContactPersonName = estate.ContactPersonName;
                ContactPersonPhone = estate.ContactPersonPhone;
                ContactPersonEmail = estate.ContactPersonEmail;
            });
        }
    }
}
