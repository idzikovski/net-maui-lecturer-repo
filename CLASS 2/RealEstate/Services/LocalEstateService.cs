using Newtonsoft.Json;
using RealEstate.Interfaces;
using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services
{
    public class LocalEstateService : IEstatesService
    {
        public async Task<List<Estate>> GetEstates()
        {
			try
			{
                using var stream = await FileSystem.OpenAppPackageFileAsync("estates.json");
                using var reader = new StreamReader(stream);

                var contents = reader.ReadToEnd();

                return JsonConvert.DeserializeObject<List<Estate>>(contents);
            }
			catch (Exception ex)
			{
                return null;
			}
        }
    }
}
