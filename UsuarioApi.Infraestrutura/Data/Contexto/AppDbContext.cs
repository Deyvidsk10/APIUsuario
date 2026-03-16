using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using UsuarioApi.Domain.Entidades;

namespace UsuarioApi.Infrastructure.Data.Contexto;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opcoes) : base(opcoes) { }

    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder construtorModelo)
    {
        construtorModelo.Entity<Usuario>().HasIndex(u => u.Email).IsUnique();
        base.OnModelCreating(construtorModelo);
    }
}