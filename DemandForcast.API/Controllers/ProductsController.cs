using AutoMapper;
using DemandForcast.API.Models;
using DemandForcast.API.Models.DTO.Products;
using DemandForcast.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemandForcast.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductsController(IProductRepository productRepository, 
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get domain model data
            var productDomainModel = await productRepository.GetAllAsync();

            //map to dto from domain model
            return Ok(mapper.Map<List<ProductDto>>(productDomainModel));
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddProductRequestDto addProductRequestDto)
        {
            //DTO map to product domain model
            var productDomainModel = mapper.Map<ProductModel>(addProductRequestDto);

            //use domain model to create product
            productDomainModel = await productRepository.CreateAsync(productDomainModel);

            //back to return domain model to dto
            var productDto = mapper.Map<ProductDto>(productDomainModel);

            return CreatedAtAction(nameof(GetById), new { productDto.Id }, productDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        //[Authorize(Roles = "Reader, Writer")]
        public async Task<ActionResult> GetById(Guid id)
        {
            //get product domain from database
            var productDomainModel = await productRepository.GetByIdAsync(id);

            //check existing data from domain model
            if (productDomainModel == null)
                return BadRequest();
            else
                //map domain model to dto
                return Ok(mapper.Map<ProductDto>(productDomainModel));

        }


        [HttpDelete]
        [Route("{id:guid}")]
        //[Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            //delete from domain model
            var deleteProductDomainModel = await productRepository.DeleteAsync(id);

            if (deleteProductDomainModel == null)
            {
                return BadRequest();
            }

            //map domain model to dto
            return Ok(mapper.Map<ProductDto>(deleteProductDomainModel));
        }

        [HttpPut]
        [Route("{id:guid}")]
        //[Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductRequestDto updateProductRequestDto)
        {
            //map dto to product domain model
            var productDomainModel = mapper.Map<ProductModel>(updateProductRequestDto);

            //delete domain model from database
            productDomainModel = await productRepository.UpdateAsync(id, productDomainModel);

            if (productDomainModel == null)
            {
                return NotFound();
            }

            //map product domain model to dto for client or user
            return Ok(mapper.Map<ProductDto>(productDomainModel));
        }
    }
}
