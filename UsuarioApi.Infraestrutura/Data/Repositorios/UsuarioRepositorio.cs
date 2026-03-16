using Microsoft.EntityFrameworkCore;
using UsuarioApi.Domain.Entidades;
using UsuarioApi.Domain.Interfaces;
using UsuarioApi.Infrastructure.Data.Contexto;

namespace UsuarioApi.Infrastructure.Data.Repositorios;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly AppDbContext _contexto;

    public UsuarioRepositorio(AppDbContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<Usuario?> ObterPorEmailAsync(string email)
    {
        return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<Usuario?> ObterPorIdAsync(Guid id)
    {
        return await _contexto.Usuarios.FindAsync(id);
    }

    public async Task<IEnumerable<Usuario>> ObterTodosAsync()
    {
        return await _contexto.Usuarios.ToListAsync();
    }

    public async Task AdicionarAsync(Usuario usuario)
    {
        await _contexto.Usuarios.AddAsync(usuario);
        await _contexto.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Usuario usuario)
    {
        _contexto.Usuarios.Update(usuario);
        await _contexto.SaveChangesAsync();
    }
}