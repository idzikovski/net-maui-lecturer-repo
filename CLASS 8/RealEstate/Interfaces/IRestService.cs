namespace RealEstate.Interfaces
{
    public interface IRestService
    {
        Task<string> GetAsync(string route);

        Task<string> PostAsync(string route, object body);

        Task<string> PatchAsync(string route, object body);

        Task<string> DeleteAsync(string route);

        //Task<T> Get<T>(string route);

        //Task<T> Post<T>(string route);
    }
}
