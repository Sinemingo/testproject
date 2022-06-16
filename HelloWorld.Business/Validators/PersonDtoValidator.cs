using FluentValidation;
using FluentValidation.Results;
using HelloWorld.Business.Dtos;

namespace HelloWorld.Business.Validators;
public class PersonDtoValidator : AbstractValidator<PersonDto>
{
    public PersonDtoValidator()
    {
        RuleFor(c => c.Name).NotNull().NotEmpty().MinimumLength(3);
        RuleFor(a => a.Age).NotNull().NotEmpty();

        RuleFor(x => x).Custom((model, context) =>
        {
            if (Convert.ToInt32(model.Age)<3)
            {
                context.AddFailure(new ValidationFailure("Age","Age must be greater than 2!"));
            }
        });

        RuleForEach(x => x.AgeList)
              .SetValidator(x => new PersonDtoAgeValidator());
    }
}
