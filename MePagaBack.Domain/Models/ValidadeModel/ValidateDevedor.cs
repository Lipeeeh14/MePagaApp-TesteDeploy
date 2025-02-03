using MePagaBack.Domain.Helpers.ErrorMessages;

namespace MePagaBack.Domain.Models.ValidadeModel;

public static class ValidateDevedor
{
    public static void Validar(this Devedor devedor) 
    {
        devedor.ValidarNome();
        devedor.ValidarTelefone();
    }

    private static void ValidarNome(this Devedor devedor) 
    {
        if (string.IsNullOrEmpty(devedor.Nome)) 
        {
            throw new ArgumentNullException(ModelsErrorMessages.NomeErrorMessage);
        }
    }

    private static void ValidarTelefone(this Devedor devedor)
    {
        if (string.IsNullOrEmpty(devedor.NumeroTelefone))
        {
            throw new ArgumentNullException(ModelsErrorMessages.TelefoneErrorMessage);
        }
    }
}
