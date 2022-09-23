using Newtonsoft.Json;
using RealEstate.Interfaces;
using RealEstate.Models;

namespace RealEstate.Services
{
    public class LocalEstateService : IEstatesService
    {
        private readonly IImageProvider _imageProvider;

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

                return PrepareContent(contents);
            }
			catch (Exception ex)
			{
                return null;
			}
        }

        private List<Estate> PrepareContent(string contents)
        {
            var estates = JsonConvert.DeserializeObject<List<Estate>>(contents);

            foreach (var estate in estates)
            {
                estate.Photo = _imageProvider.GetImage();
            }

            return estates;
        }
    }
}
