using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Interfaces
{
    public interface IEstatesService
    {
        Task<List<Estate>> GetEstates();

        Task<Estate> GetEstateById(int id);
    }
}
