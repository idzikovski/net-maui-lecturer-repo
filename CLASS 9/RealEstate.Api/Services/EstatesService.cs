using Newtonsoft.Json;
using RealEstate.Api.Interfaces;
using RealEstate.Api.Models;

namespace RealEstate.Api.Services
{
    public class EstatesService : IEstatesService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private List<Estate> _estates;
        private long NextId => _estates.Max(x => x.Id) + 1;

        public EstatesService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            LoadEstates();
        }

        private void LoadEstates()
        {
            var rootPath = _webHostEnvironment.ContentRootPath;
            var fullPath = Path.Combine(rootPath, "Resources/estates.json");
            var estatesJson = File.ReadAllText(fullPath);
            _estates = JsonConvert.DeserializeObject<List<Estate>>(estatesJson);
        }

        public Task<Estate> Create(Estate estate)
        {
            estate.Id = NextId;
            _estates.Insert(0, estate);
            return Task.FromResult(estate);
        }

        public Task<bool> DeleteEstateById(long id)
        {
            var estate = _estates.FirstOrDefault(x => x.Id == id);

            if (estate == null)
            {
                return Task.FromResult(false);
            }

            _estates.Remove(estate);

            return Task.FromResult(true);
        }

        public Task<Estate> GetEstateById(long id)
        {
            return Task.FromResult(_estates.FirstOrDefault(x => x.Id == id));
        }

        public Task<List<Estate>> GetEstates()
        {
            return Task.FromResult(_estates);
        }

        public Task<Estate> Update(Estate estate)
        {
            var estateFromList = _estates.FirstOrDefault(x => x.Id == estate.Id);

            if (estateFromList == null)
            {
                return Task.FromResult(default(Estate));
            }

            estateFromList.EstateName = estate.EstateName;
            estateFromList.ContactPersonName = estate.ContactPersonName;
            estateFromList.ContactPersonPhone = estate.ContactPersonPhone;
            estateFromList.ContactPersonEmail = estate.ContactPersonEmail;
            estateFromList.Address = estate.Address;
            estateFromList.RoomNumber = estate.RoomNumber;
            estateFromList.BathroomNumber = estate.RoomNumber;
            estateFromList.Area = estate.Area;
            estateFromList.Price = estate.Price;

            return Task.FromResult(estateFromList);
        }
    }
}
