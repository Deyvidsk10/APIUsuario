using Microsoft.EntityFrameworkCore;
using UsuarioApi.Application.Servicos;
using UsuarioApi.Domain.Interfaces;
using UsuarioApi.Infrastructure.Data.Contexto;
using UsuarioApi.Infrastructure.Data.Repositorios;
using UsuarioApi.Infrastructure.Security.Tokens;

var construtor = WebApplication.CreateBuilder(args);

// Configuração do Banco de Dados
construtor.Services.AddDbContext<AppDbContext>(opcoes =>
    opcoes.UseSqlServer(construtor.Configuration.GetConnectionString("ConexaoPadrao")));

// Injeção de Dependência
construtor.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
construtor.Services.AddScoped<IUsuarioServico, UsuarioServico>();
construtor.Services.AddScoped<ITokenServico, TokenServico>();
construtor.Services.AddControllers();
construtor.Services.AddEndpointsApiExplorer();
construtor.Services.AddSwaggerGen();

var aplicativo = construtor.Build();
     

if (aplicativo.Environment.IsDevelopment())
{
    aplicativo.UseSwagger();
    aplicativo.UseSwaggerUI();
}

aplicativo.UseAuthorization();
aplicativo.MapControllers();
aplicativo.Run();