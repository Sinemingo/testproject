using HelloWorld.Business.Dtos;

namespace HelloWorld.Business.Services;

public interface IPersonService
{    
    List<PersonDto> GetPersonList();
    void AddPerson(PersonDto personDto);
}
