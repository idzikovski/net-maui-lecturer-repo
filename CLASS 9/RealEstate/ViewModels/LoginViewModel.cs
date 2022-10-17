using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RealEstate.Interfaces;

namespace RealEstate.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private const string FakePass = "123";
        public static readonly string IsLoggedInKey = "IsLoggedInKey";
        private readonly Interfaces.IPreferences _preferences;
        [ObservableProperty]
        private string _username;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private bool _loginErrorPresent;

        public LoginViewModel(Interfaces.IPreferences preferences)
        {
            _preferences = preferences;

            if (_preferences.Get(IsLoggedInKey, false))
            {
                Shell.Current.GoToAsync("//EstatesPage");
            }
        }

        [RelayCommand]
        public async Task Login()
        {
            if (!string.IsNullOrEmpty(Username) && Password == FakePass)
            {
                await Shell.Current.GoToAsync("//EstatesPage");
                _preferences.Set(IsLoggedInKey, true);
            }
            else
            {
                LoginErrorPresent = true;
            }
        }
    }
}
