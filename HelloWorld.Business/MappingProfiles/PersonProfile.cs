using AutoMapper;
using HelloWorld.Business.Dtos;
using HelloWorld.Entities;

namespace HelloWorld.Business.MappingProfiles;

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<Person, PersonDto>()
        .ForMember(destination => destination.Name, operation => operation.MapFrom(source => source.Name))
        .ForMember(destination => destination.Age, operation => operation.MapFrom(source => source.Age.ToString()));

        CreateMap<PersonDto, Person>()
        .ForMember(destination => destination.Name, operation => operation.MapFrom(source => source.Name))
        .ForMember(destination => destination.Age, operation => operation.MapFrom(source => Convert.ToInt32(source.Age)));
    }
}
