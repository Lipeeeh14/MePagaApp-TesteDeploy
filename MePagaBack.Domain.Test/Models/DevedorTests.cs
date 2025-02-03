using MePagaBack.Domain.Helpers.ErrorMessages;
using MePagaBack.Domain.Models;

namespace MePagaBack.Domain.Test.Models;

public class DevedorTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void DeveFalharQuandoNomeForNuloOuVazio(string nome)
    {
        var error = ModelsErrorMessages.NomeErrorMessage;

        void action() => new Devedor(
            nome: nome,
            email: null,
            numeroTelefone: "11987654321");

        var exception = Assert.Throws<ArgumentNullException>(action);
        Assert.Equal(error, exception.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void DeveFalharQuandoTelefoneForNuloOuVazio(string numeroTelefone)
    {
        var error = ModelsErrorMessages.TelefoneErrorMessage;

        void action() => new Devedor(
            nome: "Teste", 
            email: null,
            numeroTelefone: numeroTelefone);

        var exception = Assert.Throws<ArgumentNullException>(action);
        Assert.Equal(error, exception.ParamName);
    }
}
