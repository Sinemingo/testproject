using HelloWorld.Entities;

namespace HelloWorld.Data.Abstract;

public interface IPersonRepository
{
    List<Person> GetPersonList();
    void AddPerson(Person person);
    Person GetPersonById(int id);
    bool DeletePersonById(int id);
}
