using RealEstate.Models;

namespace RealEstate.Interfaces
{
    public interface IEstatesService
    {
        Task<List<Estate>> GetEstates();

        Task<Estate> GetEstateById(long id);

        Task<bool> DeleteEstateById(long id);
    }
}
