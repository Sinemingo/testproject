using AutoMapper;
using FluentValidation;
using HelloWorld.Business.Dtos;
using HelloWorld.Business.Extensions;
using HelloWorld.Data.Entities;
using HelloWorld.Data.Repositories;

namespace HelloWorld.Business.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<PersonDto> _personDtoValidator;
    public PersonService(IPersonRepository personRepository, IMapper mapper, IValidator<PersonDto> personDtoValidator)
    {
        _mapper = mapper;
        _personDtoValidator = personDtoValidator;
        _personRepository = personRepository;
    }
    public void AddPerson(PersonDto personDto)
    {
        var validationResult = _personDtoValidator.Validate(personDto);
        if (validationResult.IsValid)
        {
            var personEntity = _mapper.Map<Person>(personDto);
            _personRepository.AddPerson(personEntity);
        }
    }

    public List<PersonDto> GetPersonList()
    {
        var personEntities = _personRepository.GetPersonList();
        var personDtos = _mapper.Map<List<PersonDto>>(personEntities);
        int personDtoCount = personDtos.GeneratePersonCount();
        return personDtos.AddOneDummyRecord();
    }

}
