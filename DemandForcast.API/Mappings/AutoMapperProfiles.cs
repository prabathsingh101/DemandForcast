using AutoMapper;
using DemandForcast.API.Models;
using DemandForcast.API.Models.DTO.Employee;
using DemandForcast.API.Models.DTO.Products;
using DemandForcast.API.Models.DTO.State;

namespace DemandForcast.API.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            //Product
            CreateMap<ProductModel, ProductDto>().ReverseMap();
            CreateMap<AddProductRequestDto, ProductModel>().ReverseMap();
            CreateMap<UpdateProductRequestDto, ProductModel>().ReverseMap();


            //Employee
            CreateMap<EmployeeModel, EmployeeDto>().ReverseMap();
            CreateMap<AddEmployeeRequestDto, EmployeeModel>().ReverseMap();
            CreateMap<UpdateEmployeeRequestDto, EmployeeModel>().ReverseMap();


            //State
            CreateMap<StateModel, StateDto>().ReverseMap();
            CreateMap<AddStateRequestDto, StateModel>().ReverseMap(); 
            CreateMap<UpdateStateRequestDto, StateModel>().ReverseMap();

        }
       
    }
}
