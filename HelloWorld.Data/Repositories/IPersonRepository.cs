using HelloWorld.Data.Entities;

namespace HelloWorld.Data.Repositories;

public interface IPersonRepository
{
    List<Person> GetPersonList();
    void AddPerson(Person person);
}
