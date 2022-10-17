using RealEstate.Api.Models;

namespace RealEstate.Api.Interfaces
{
    public interface IEstatesService
    {
        Task<List<Estate>> GetEstates();

        Task<Estate> GetEstateById(long id);

        Task<bool> DeleteEstateById(long id);

        Task<Estate> Update(Estate estate);

        Task<Estate> Create(Estate estate);
    }
}
