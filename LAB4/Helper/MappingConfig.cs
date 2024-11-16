using AutoMapper;
using LAB4.Models;
using LAB4.Models.DTO;
using LAB4.Models.DTO.Create;
using LAB4.Models.DTO.Update;

namespace LAB4.Helper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Client, ClientCreateDTO>().ReverseMap();
            CreateMap<Client, ClientUpdateDTO>().ReverseMap();

            CreateMap<Policy, PolicyDTO>().ReverseMap();
            CreateMap<Policy, PolicyCreateDTO>().ReverseMap();
            CreateMap<Policy, PolicyUpdateDTO>().ReverseMap();
        }
    }
}
