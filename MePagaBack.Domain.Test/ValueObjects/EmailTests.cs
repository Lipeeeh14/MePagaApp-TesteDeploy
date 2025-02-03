using MePagaBack.Domain.Helpers.ErrorMessages;
using MePagaBack.Domain.ValueObjects;

namespace MePagaBack.Domain.Test.ValueObjects;

public class EmailTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void DeveFalharQuandoEmailForNuloOuVazio(string email)
    {
        var error = ModelsErrorMessages.EmailErrorMessage;

        void action() => new EmailValueObject(email);

        var exception = Assert.Throws<ArgumentNullException>(action);
        Assert.Equal(error, exception.ParamName);
    }

    [Fact]
    public void DeveFalharQuandoEmailForInvalido()
    {
        var email = "testeemailinvalido";
        var error = "E-mail inválido.";

        void action() => new EmailValueObject(email);

        var exception = Assert.Throws<FormatException>(action);
        Assert.Contains(error, exception.Message);
    }

    [Fact]
    public void DevePassarQuandoEmailForValido()
    {
        var email = "teste@email.com";

        var emailVO = new EmailValueObject(email);

        Assert.NotNull(emailVO);
    }
}