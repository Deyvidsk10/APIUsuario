namespace UsuarioApi.Domain.Entidades;

public class Usuario
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string SenhaHash { get; private set; }
    public bool Ativo { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public DateTime? DataAtualizacao { get; private set; }

 

    public Usuario(string nome, string email, string senhaHash)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Email = email;
        SenhaHash = senhaHash;
        Ativo = true;
        DataCriacao = DateTime.UtcNow;
    }

    public void AtualizarStatus(bool novoStatus)
    {
        if (Ativo != novoStatus)
        {
            Ativo = novoStatus;
            DataAtualizacao = DateTime.Now; 
        }
    }
  
}