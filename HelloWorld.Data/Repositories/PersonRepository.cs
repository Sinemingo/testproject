using HelloWorld.Data.Entities;

namespace HelloWorld.Data.Repositories;

public class PersonRepository : IPersonRepository
{
    public List<Person> People { get; set; }

    public PersonRepository()
    {
        People = new List<Person>{ 
        new Person{
            Id=1,
            Name="Sinem",
            Age=31,
            IsDeleted=false,
        },
        new Person{
            Id=2,
            Name="Enes",
            Age=31,
            IsDeleted=false,
        },
        };
    }
    public void AddPerson(Person person)
    {
        People.Add(person);
    }

    public List<Person> GetPersonList()
    {
        return People;
    }
}
