using UsuarioApi.Application.DTOs;
using UsuarioApi.Application.Seguranca;
using UsuarioApi.Domain.Entidades;
using UsuarioApi.Domain.Interfaces;

namespace UsuarioApi.Application.Servicos;

public class UsuarioServico : IUsuarioServico
{
    private readonly IUsuarioRepositorio _repositorio;
    private readonly ITokenServico _tokenServico;
    public UsuarioServico(IUsuarioRepositorio repositorio, ITokenServico tokenServico)
    {
        _repositorio = repositorio;
        _tokenServico = tokenServico;
    }

    public async Task<UsuarioResposta> RegistrarAsync(UsuarioRequisicao requisicao)
    {
      
        var usuarioExistente = await _repositorio.ObterPorEmailAsync(requisicao.Email);
        if (usuarioExistente != null)
        {
            throw new Exception("Este e-mail já está sendo utilizado por outra conta.");
        }

        var senhaHash = CriptografiaServico.GerarHash(requisicao.Senha);

        var novoUsuario = new Usuario(requisicao.Nome, requisicao.Email, senhaHash);

        await _repositorio.AdicionarAsync(novoUsuario);

        return MapearParaResposta(novoUsuario);
    }

    public async Task<IEnumerable<UsuarioResposta>> ListarTodosAsync()
    {
        var usuarios = await _repositorio.ObterTodosAsync();

        
        return usuarios.Select(u => MapearParaResposta(u));
    }

    public async Task<string> AutenticarAsync(string email, string senha)
    {
        var usuario = await _repositorio.ObterPorEmailAsync(email);

        if (usuario == null || !usuario.Ativo)
            throw new Exception("Usuário não encontrado ou conta inativa.");

        if (!CriptografiaServico.VerificarSenha(senha, usuario.SenhaHash))
            throw new Exception("E-mail ou senha incorretos.");

        return _tokenServico.GerarToken(usuario.Id, usuario.Email);
    }

    public async Task<UsuarioResposta> AtualizarStatusAsync(Guid id, bool ativo)
    {
        var usuario = await _repositorio.ObterPorIdAsync(id);
        if (usuario == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        usuario.AtualizarStatus(ativo);

        await _repositorio.AtualizarAsync(usuario);

        return MapearParaResposta(usuario);
    }

    /// <summary>
    /// Método privado para centralizar o mapeamento e garantir que o Hash nunca seja retornado.
    /// </summary>
    private UsuarioResposta MapearParaResposta(Usuario usuario)
    {
        return new UsuarioResposta
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email,
            Ativo = usuario.Ativo,
            DataCriacao = usuario.DataCriacao,
            DataAtualizacao = (DateTime)usuario.DataAtualizacao
        };
    }
}