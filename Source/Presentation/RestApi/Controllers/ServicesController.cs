using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServicesController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _serviceRepository.Get());
        }

        [HttpGet("{id}", Name = "ServiceGet")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var service = await _serviceRepository.GetById(id);

                if (service == null) return NotFound();

                return Ok(service);
            }
            catch
            {
                
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Service service)
        {            
            try
            {
                await _serviceRepository.Add(service);
                var url = Url.Link("ServiceGet", new { id = service.Id });
                return Created(url, service);
            }
            catch(Exception e)
            {

            }

            return BadRequest();
        }

        [HttpPatch("{id}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Service service)
        {
            try
            {
                if (service.Id != id)
                    return BadRequest();

                var oldService = await _serviceRepository.GetById(id);
                if (oldService == null) return NotFound();

                oldService.Name = service.Name ?? oldService.Name;
                oldService.Description = service.Description ?? oldService.Description;

                await _serviceRepository.Update(oldService);
                return Ok(oldService);
            }
            catch
            {

            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var service = await _serviceRepository.GetById(id);
                if (service == null)
                    return NotFound();

                await _serviceRepository.Delete(service);

                return Ok();
            }
            catch
            {

            }

            return BadRequest();
        }
    }
}