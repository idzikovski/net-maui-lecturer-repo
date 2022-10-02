using Newtonsoft.Json;
using RealEstate.Interfaces;
using RealEstate.Models;

namespace RealEstate.Services
{
    public class LocalEstateService : IEstatesService
    {
        private readonly IImageProvider _imageProvider;
        private List<Estate> _estates = new List<Estate>();
        private long NextId => _estates.Max(x => x.Id) + 1;

        public LocalEstateService(IImageProvider imageProvider)
        {
            _imageProvider = imageProvider;
        }

        public async Task<List<Estate>> GetEstates()
        {
			try
			{
                if (!_estates.Any())
                {

                    using var stream = await FileSystem.OpenAppPackageFileAsync("estates.json");
                    using var reader = new StreamReader(stream);

                    var contents = reader.ReadToEnd();

                    _estates = AddImages(contents);
                }

                return _estates;
            }
			catch (Exception ex)
			{
                System.Diagnostics.Debug.WriteLine(ex);
                return null;
			}
        }

        public Task<Estate> GetEstateById(long id)
        {
            return Task.FromResult(_estates.FirstOrDefault(x => x.Id == id));
        }

        private List<Estate> AddImages(string contents)
        {
            var estates = JsonConvert.DeserializeObject<List<Estate>>(contents);

            foreach (var estate in estates)
            {
                estate.Photo = _imageProvider.GetImage();
                estate.Photos = _imageProvider.GetImages(5);
            }

            return estates;
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

        public Task<Estate> Create(Estate estate)
        {
            var id = NextId;

            estate.Id = id;
            _estates.Insert(0, estate);

            return Task.FromResult(_estates.FirstOrDefault(x=> x.Id == id));
        }
    }
}
