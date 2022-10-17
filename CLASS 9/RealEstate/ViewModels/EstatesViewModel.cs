using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RealEstate.Interfaces;
using RealEstate.Models;
using RealEstate.Views;
using System.Collections.ObjectModel;

namespace RealEstate.ViewModels
{
    [QueryProperty(nameof(Update), nameof(Update))]
    public partial class EstatesViewModel : ObservableObject
    {
        public bool TapLocked { get; set; }
        private readonly IEstatesService _estatesService;

        private bool _update;
        public bool Update
        {
            get => _update;
            set
            {
                _update = value;
                LoadData();
            }
        }

        [ObservableProperty]
        private ObservableCollection<Estate> _estates;

        [ObservableProperty]
        private Estate _selectedItem;

        public EstatesViewModel(IEstatesService estatesService)
        {
            _estatesService = estatesService;
            LoadData();
        }

        private void LoadData()
        {
            _estatesService.GetEstates().ContinueWith(LoadEstates);
        }

        private void LoadEstates(Task<List<Estate>> task)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Estates = new ObservableCollection<Estate>(task.Result);
            });
        }

        [RelayCommand]
        private async Task SelectionChanged()
        {
            if (SelectedItem == null || TapLocked)
            {
                return;
            }

            var id = SelectedItem.Id;
            SelectedItem = null;

            await Shell.Current.GoToAsync($"{nameof(EstateDetails)}?EstateId={id}");
        }

        [RelayCommand]
        private void Edit(Estate estate)
        {
            Shell.Current.GoToAsync($"{nameof(UpsertPage)}?EstateId={estate.Id}&IsUpdate=true");
        }

        [RelayCommand]
        private async Task Delete(Estate estate)
        {
            await _estatesService.DeleteEstateById(estate.Id);
            _estates.Remove(estate);
        }

        [RelayCommand]
        private void Create()
        {
            Shell.Current.GoToAsync(nameof(UpsertPage));
        }
    }
}
