using BCrypt.Net;

namespace UsuarioApi.Application.Seguranca;

public static class CriptografiaServico
{
    public static string GerarHash(string senha) => BCrypt.Net.BCrypt.HashPassword(senha);
    public static bool VerificarSenha(string senha, string hash) => BCrypt.Net.BCrypt.Verify(senha, hash);
}