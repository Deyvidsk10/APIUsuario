 UsuarioAPI - Sistema de Gestão de Usuários
Este projeto é uma API REST desenvolvida em .NET 8 (ou 9) como parte de um teste técnico. A aplicação segue os princípios da Clean Architecture e implementa
autenticação segura via JWT.

 Tecnologias Utilizadas
C# / .NET 8/9

Entity Framework Core (Acesso a dados)

SQL Server (Banco de dados relacional)

JWT (JSON Web Token) (Autenticação e Autorização)

Swagger (OpenAPI) (Documentação da API)

BCrypt (Hash de senhas)

 Arquitetura do Projeto
O projeto foi dividido em camadas para garantir o desacoplamento e a testabilidade, conforme os requisitos solicitados:

Domain: Contém as entidades de negócio (Usuario), interfaces de repositório e interfaces de serviços de infraestrutura (como o Token). Não possui dependências externas.

Application: Responsável pelos casos de uso, DTOs (Requisicao/Resposta) e orquestração dos serviços.

Infrastructure: Implementação do acesso ao banco de dados (EF Core), Migrations e serviços de segurança (JWT/Hash).

API: Ponto de entrada da aplicação, contendo os Controllers e a configuração da Injeção de Dependência.

 Funcionalidades Principais
Cadastro de Usuários: Registro seguro com validação de e-mail único e criptografia de senha.

Autenticação: Login via e-mail/senha com geração de Token JWT.

Gestão de Status: Ativação e inativação de usuários (Soft Delete).

Proteção de Rotas: Apenas usuários autenticados e ativos podem acessar endpoints específicos.

 Como Executar o Projeto
Clonar o repositório:

Bash
git clone https://github.com//Deyvidsk10/APIUsuario.git
Configurar o Banco de Dados:
No arquivo appsettings.json do projeto API, ajuste a ConnectionStrings para o seu servidor local:

JSON
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=UsuarioDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
Executar as Migrations:
No Console do Gerenciador de Pacotes, execute:

Bash
Update-Database
Rodar a aplicação:
Pressione F5 no Visual Studio ou use o comando:

Bash
dotnet run --project UsuarioApi.API
📝 Endpoints Principais
POST /api/usuarios: Registra um novo usuário.

POST /api/usuarios/login: Autentica e retorna o token JWT.

PATCH /api/usuarios/{id}/status: Altera o status (Ativo/Inativo).

GET /api/usuarios: Lista todos os usuários (necessita Token).

Desenvolvido por [Deyvidsk10]
