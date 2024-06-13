using AutoMapper;
using DemandForcast.API.Models;
using DemandForcast.API.Models.DTO.Employee;
using DemandForcast.API.Models.DTO.Products;
using DemandForcast.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemandForcast.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles ="Writer")]
        public async Task<IActionResult> Create([FromBody] AddEmployeeRequestDto addEmployeeRequestDto)
        {
            var employeeDomailModel = mapper.Map<EmployeeModel>(addEmployeeRequestDto);

            //save

            employeeDomailModel = await employeeRepository.CreateAsync(employeeDomailModel);

            var employeeDto = mapper.Map<EmployeeDto>(employeeDomailModel);

            return CreatedAtAction(nameof(GetById), new { employeeDto.Id }, employeeDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById(Guid id)
        {
            //get product domain from database
            var employeeDomainModel = await employeeRepository.GetByIdAsync(id);

            //check existing data from domain model
            if (employeeDomainModel == null)
                return BadRequest();
            else
                //map domain model to dto
                return Ok(mapper.Map<EmployeeDto>(employeeDomainModel));
        }

        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            //get domain model data
            var employeeDomainModel = await employeeRepository.GetAllAsync();

            //map to dto from domain model
            return Ok(mapper.Map<List<EmployeeDto>>(employeeDomainModel));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var existEmployeeDomain= await employeeRepository.DeleteAsync(id);

            if (existEmployeeDomain == null)
                return BadRequest();
            return Ok(mapper.Map<EmployeeDto>(existEmployeeDomain));
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateEmployeeRequestDto updateEmployeeRequestDto )
        {
            var employeeDomainModel = mapper.Map<EmployeeModel>(updateEmployeeRequestDto);

            employeeDomainModel= await employeeRepository.UpdateAsync(id, employeeDomainModel);

            if(employeeDomainModel == null) 
                return BadRequest();
            return Ok(mapper.Map<EmployeeDto>(employeeDomainModel));
        }

    }
}
