using Newtonsoft.Json;
using RealEstate.Interfaces;
using RealEstate.Models;

namespace RealEstate.Services
{
    public class EstatesService : IEstatesService
    {
        private const string EstatesRoute = "estates";
        private readonly IRestService _restService;

        public EstatesService(IRestService restService)
        {
            _restService = restService;
        }

        public async Task<Estate> Create(EstateDto estate)
        {
            return JsonConvert.DeserializeObject<Estate>(await _restService.PostAsync("estates", estate));
        }

        public async Task<bool> DeleteEstateById(long id)
        {
            return JsonConvert.DeserializeObject<bool>(await _restService.DeleteAsync($"{EstatesRoute}/{id}"));
        }

        public async Task<Estate> GetEstateById(long id)
        {
            return JsonConvert.DeserializeObject<Estate>(await _restService.GetAsync($"{EstatesRoute}/{id}"));
        }

        public async Task<List<Estate>> GetEstates()
        {
            return JsonConvert.DeserializeObject<List<Estate>>(await _restService.GetAsync(EstatesRoute));
        }

        public async Task<Estate> Update(EstateDto estate)
        {
            return JsonConvert.DeserializeObject<Estate>(await _restService.PatchAsync(EstatesRoute, estate));
        }
    }
}
