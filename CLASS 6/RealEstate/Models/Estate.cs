using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace RealEstate.Models
{
    public partial class Estate : ObservableObject
    {
        [ObservableProperty]
        private long _id;

        [ObservableProperty]
        private string _estateName;

        [ObservableProperty]
        private string _contactPersonName;

        [ObservableProperty]
        private string _contactPersonPhone;

        [ObservableProperty]
        private string _contactPersonEmail;

        [ObservableProperty]
        private string _address;

        [ObservableProperty]
        private int _roomNumber;

        [ObservableProperty]
        private int _bathroomNumber;

        [ObservableProperty]
        private int _area;

        [ObservableProperty]
        private int _price;

        [ObservableProperty]
        private string _photo;

        [ObservableProperty]
        private List<string> _photos;
    }
}
