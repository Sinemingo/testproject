using FluentValidation;
using HelloWorld.Business.Dtos;

namespace HelloWorld.Business.Validators;
public class PersonDtoAgeValidator :AbstractValidator<PersonDtoAge>
{
    public PersonDtoAgeValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan(0);
    }
}
