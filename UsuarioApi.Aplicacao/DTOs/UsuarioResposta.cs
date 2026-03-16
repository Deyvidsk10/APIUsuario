using System;
using System.Collections.Generic;
using System.Text;

namespace UsuarioApi.Application.DTOs
{
    public class UsuarioResposta
    {   
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
