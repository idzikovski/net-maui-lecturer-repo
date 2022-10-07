using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RealEstate.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private const string FakePass = "123";
        public static readonly string IsLoggedInKey = "IsLoggedInKey";

        [ObservableProperty]
        private string _username;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private bool _loginErrorPresent;

        public LoginViewModel()
        {
            if (Preferences.Default.Get(IsLoggedInKey, false))
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
                Preferences.Default.Set(IsLoggedInKey, true);
            }
            else
            {
                LoginErrorPresent = true;
            }
        }
    }
}
