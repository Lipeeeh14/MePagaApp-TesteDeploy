using MePagaBack.Domain.Helpers.ErrorMessages;
using System.Text.RegularExpressions;

namespace MePagaBack.Domain.ValueObjects;

public class EmailValueObject
{
    public string Email { get; private set; }

    private readonly string EMAIL_REGEX = new("^\\S+@\\S+\\.\\S+$");

    public EmailValueObject(string email)
    {
        if (string.IsNullOrEmpty(email)) 
            throw new ArgumentNullException(ModelsErrorMessages.EmailErrorMessage);

        ValidarEmail(email);
        Email = email;
    }

    private void ValidarEmail(string email) 
    {
        Regex validateEmailRegex = new(EMAIL_REGEX);

        var isValid = validateEmailRegex.IsMatch(email);

        if (!isValid)
            throw new FormatException(ModelsErrorMessages.EmailErrorMessage);
    }
}
