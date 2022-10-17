using RealEstate.Interfaces;
using IPreferences = RealEstate.Interfaces.IPreferences;

namespace RealEstate.Services
{
    public class PreferencesImp : IPreferences
    {
        public T Get<T>(string key, T defaultValue)
        {
            return Preferences.Default.Get(key, defaultValue);
        }

        public void Set<T>(string key, T value)
        {
            Preferences.Default.Set(key, value);
        }
    }
}
