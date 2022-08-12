using HelloWorld.Business.CustomValidators;

namespace HelloWorld.Business.Dtos;

public class PersonDto
{
    [NotContainSpecialWord("Enes",ErrorMessage ="Enes kelimesini içermemelidir.")]
    public string Name { get; set; }
    public string Age { get; set; }

    public List<PersonDtoAge> AgeList { get; set; }=new List<PersonDtoAge>
    {
        new PersonDtoAge
        {
            Id = 1
        },
         new PersonDtoAge
        {
            Id = 2
        },
          new PersonDtoAge
        {
            Id = 5
        },
    };
    
}

public class PersonDtoAge
{
    public int Id { get; set; }
}
