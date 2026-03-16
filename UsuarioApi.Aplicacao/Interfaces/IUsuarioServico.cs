using UsuarioApi.Application.DTOs;

namespace UsuarioApi.Domain.Interfaces;

public interface IUsuarioServico
{
    Task<UsuarioResposta> RegistrarAsync(UsuarioRequisicao requisicao);
    Task<string> AutenticarAsync(string email, string senha);
    Task<UsuarioResposta> AtualizarStatusAsync(Guid id, bool ativo);

    Task<IEnumerable<UsuarioResposta>> ListarTodosAsync();
}