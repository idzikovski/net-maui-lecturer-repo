namespace RealEstate.Interfaces
{
    public interface IPreferences
    {
        T Get<T>(string key, T defaultValue);
        void Set<T>(string key, T value);
    }
}
