using Newtonsoft.Json;
using RealEstate.Interfaces;
using RealEstate.Models;

namespace RealEstate.Services
{
    public class LocalEstateService : IEstatesService
    {
        private readonly IImageProvider _imageProvider;
        private List<Estate> _estates = new List<Estate>();

        public LocalEstateService(IImageProvider imageProvider)
        {
            _imageProvider = imageProvider;
        }

        public async Task<List<Estate>> GetEstates()
        {
			try
			{
                using var stream = await FileSystem.OpenAppPackageFileAsync("estates.json");
                using var reader = new StreamReader(stream);

                var contents = reader.ReadToEnd();

                _estates = AddImages(contents);
                return _estates;
            }
			catch (Exception ex)
			{
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
    }
}
