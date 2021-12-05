using System.ComponentModel.DataAnnotations;

namespace SsrTodo.Common;

public class FutureDateAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null)
        {
            return true;
        }
        DateTime date = Convert.ToDateTime(value);
        return date > DateTime.Now;
    }
}