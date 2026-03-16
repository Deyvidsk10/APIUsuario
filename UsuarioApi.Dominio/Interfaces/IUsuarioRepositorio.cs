using UsuarioApi.Domain.Entidades;

namespace UsuarioApi.Domain.Interfaces;

public interface IUsuarioRepositorio
{
    /// <summary>
    /// Busca um usuário pelo e-mail para validação de duplicidade ou login.
    /// </summary>
    Task<Usuario?> ObterPorEmailAsync(string email);

    /// <summary>
    /// Busca um usuário pelo ID único.
    /// </summary>
    Task<Usuario?> ObterPorIdAsync(Guid id);

    /// <summary>
    /// Persiste um novo usuário no banco de dados.
    /// </summary>
    Task AdicionarAsync(Usuario usuario);

    /// <summary>
    /// Atualiza os dados de um usuário existente.
    /// </summary>
    Task AtualizarAsync(Usuario usuario);
    Task<IEnumerable<Usuario>> ObterTodosAsync();
}