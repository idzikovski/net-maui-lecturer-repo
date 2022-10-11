using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Interfaces;
using RealEstate.Api.Models;
using RealEstate.Api.Services;

namespace RealEstate.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstatesController : ControllerBase
    {
        private readonly IEstatesService _estatesService;

        public EstatesController(IEstatesService estatesService)
        {
            _estatesService = estatesService;
        }

        [HttpGet]
        public async Task<IActionResult> Estates()
        {
            try
            {
                return Ok(await _estatesService.GetEstates());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Estates(long id)
        {
            try
            {
                return Ok(await _estatesService.GetEstateById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Estate estate)
        {
            try
            {
                return Ok(await _estatesService.Create(estate));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] Estate estate)
        {
            try
            {
                return Ok(await _estatesService.Update(estate));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _estatesService.DeleteEstateById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
