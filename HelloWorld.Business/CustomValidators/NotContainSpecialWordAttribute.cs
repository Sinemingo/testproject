using System.ComponentModel.DataAnnotations;

namespace HelloWorld.Business.CustomValidators;

public class NotContainSpecialWordAttribute:ValidationAttribute
{
    private string SpecialWord { get; set; }
    public NotContainSpecialWordAttribute(string specialWord)
    {
        SpecialWord = specialWord;
    }

    public override bool IsValid(object value)
    {
        string propValue = value as string;
        if (!string.IsNullOrEmpty(propValue))
        {
            return !propValue.Contains(SpecialWord);
           
        }
        return false;
    }

}
