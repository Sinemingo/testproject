using HelloWorld.Business.Dtos;

namespace HelloWorld.Business.Extensions;

public static class PersonDtoExtension
{
    public static List<PersonDto> AddOneDummyRecord(this List<PersonDto> personList)
    {
        personList.Add(new PersonDto
        {
            Name="Yeni",
            Age="43"
        });
        return personList;
    }

    public static int GeneratePersonCount(this List<PersonDto> personList)
    {
        return personList.Count();
    }
}
