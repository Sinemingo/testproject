using HelloWorld.Business.Dtos;

namespace HelloWorld.Business.Services.Abstract;

public interface IPersonService
{
    List<PersonDto> GetPersonList();
    void AddPerson(PersonDto personDto);

    PersonDto GetPersonById(int id);
    bool DeletePersonById(int id);
}
