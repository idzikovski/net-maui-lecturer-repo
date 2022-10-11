using Newtonsoft.Json;
using RealEstate.Api.Interfaces;
using RealEstate.Api.Models;

namespace RealEstate.Api.Services
{
    public class EstatesRepository : IRepository<Estate>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private List<Estate> _estates;

        public EstatesRepository(IWebHostEnvironment webHostEnvironment)
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

        public async Task<List<Estate>> GetAll()
        {
            return _estates;
        }

        public async Task<Estate> GetById(int id)
        {
            return await Task.FromResult(_estates.FirstOrDefault(x => x.Id == id));
        }

        public Task<Estate> Insert(Estate entity)
        {
            _estates.Add(entity);
            return Task.FromResult(entity);
        }

        public async Task<Estate> Update(Estate entity)
        {
            var estateToUpdate = _estates.FirstOrDefault(x => x.Id == entity.Id);

            estateToUpdate.EstateName = entity.EstateName;
            estateToUpdate.ContactPersonName = entity.ContactPersonName;
            estateToUpdate.ContactPersonPhone = entity.ContactPersonPhone;
            estateToUpdate.ContactPersonEmail = entity.ContactPersonEmail;
            estateToUpdate.Address = entity.Address;
            estateToUpdate.RoomNumber = entity.RoomNumber;
            estateToUpdate.BathroomNumber = entity.BathroomNumber;
            estateToUpdate.Area = entity.Area;
            estateToUpdate.Photo = entity.Photo;
            estateToUpdate.Photos = entity.Photos;

            return await Task.FromResult(estateToUpdate);
        }

        public Task<bool> Delete(int id)
        {
            var estateToDelete = _estates.FirstOrDefault(x => x.Id == id);

            if (estateToDelete != null)
            {
                _estates.Remove(estateToDelete);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}