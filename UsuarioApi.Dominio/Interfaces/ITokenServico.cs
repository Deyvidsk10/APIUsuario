
namespace UsuarioApi.Domain.Interfaces
{
    public interface ITokenServico
    {
        string GerarToken(Guid id, string email);
    }
}
