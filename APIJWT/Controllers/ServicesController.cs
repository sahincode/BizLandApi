using APIJWT.Business.DTOs.ServiceDTOs;
using APIJWT.Business.Services.Interfaces;
using APIJWT.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService  _service;
        private readonly IMapper _mapper;

        public ServicesController(IServiceService serviceService ,IMapper mapper)
        {
             _service = serviceService;
            this._mapper = mapper;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            if (id == null && id <= 0) return NotFound();
            ServiceGetDto serviceGetDto = null;


            try
            {
              Service  service = await  _service.GetByIdAsync(id);
               serviceGetDto = _mapper.Map<ServiceGetDto>(service);
                
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(serviceGetDto);
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            List<ServiceGetDto> serviceGetDtos = new List<ServiceGetDto>();
            IEnumerable<Service> services = await  _service.GetAll(null,null);
            foreach(Service service in services)
            {
                serviceGetDtos.Add(_mapper.Map<ServiceGetDto>(service));

            }
            return Ok(serviceGetDtos);
        }
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromForm] ServiceCreateDto  serviceCreateDto)
        {
            await  _service.CreateAsync( serviceCreateDto);

            return StatusCode(201, new { message = "Object yaradildi" });
        }
        [HttpPut("")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update(int ? id ,[FromForm] ServiceUpdateDto serviceUpdateDto)
        {
            if (id == null && id <= 0) return NotFound();

            try
            {
                await  _service.UpdateAsync(id, serviceUpdateDto);

            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null && id <= 0) return NotFound();

            try
            {
                await  _service.Delete(id);

            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
        [HttpPatch("ToggleDelete/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ToggleDelete(int id)
        {
            if (id == null && id <= 0) return NotFound();

            try
            {
                await  _service.ToggleDelete(id);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}
