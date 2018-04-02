
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class NameValidator : ValidationAttribute
{
    public override bool IsValid(object o)
    {
        //Write whatever logic you want because this is custom validator
        return Regex.IsMatch(o.ToString(), "[a-zA-Z]+");
    }
}
