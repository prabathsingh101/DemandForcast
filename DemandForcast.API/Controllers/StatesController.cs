using AutoMapper;
using DemandForcast.API.Models.DTO.Employee;
using DemandForcast.API.Models.DTO.State;
using DemandForcast.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemandForcast.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IStateRepository stateRepository;
        private readonly IMapper mapper;

        public StatesController(IStateRepository stateRepository, IMapper mapper)
        {
            this.stateRepository = stateRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task< IActionResult> GetAll() {
            
            var statesDomainModel= await stateRepository.GetAllAsync();

            return Ok(mapper.Map<List<StateDto>>(statesDomainModel));
        }
    }
}
