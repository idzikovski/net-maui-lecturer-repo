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
        private readonly IRepository<Estate> _estatesRepository;

        public EstatesController(IRepository<Estate> estatesRepository)
        {
            _estatesRepository = estatesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Estates()
        {
            try
            {
                return Ok(await _estatesRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Estates(int id)
        {
            try
            {
                return Ok(await _estatesRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Estate estate)
        {
            try
            {
                return Ok(await _estatesRepository.Insert(estate));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPatch("update")]
        public async Task<IActionResult> Update([FromBody] Estate estate)
        {
            try
            {
                return Ok(await _estatesRepository.Update(estate));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("delete/{id?}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _estatesRepository.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
