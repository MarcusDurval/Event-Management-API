# Event-Management-API
API RESTful para gerenciamento de eventos e inscrições de participantes, desenvolvida com ASP.NET Core e arquitetura em camadas.

🚀 Funcionalidades
Cadastro de eventos
Cadastro de participantes
Inscrição de participantes em eventos
Controle de capacidade de eventos
Atualização e remoção de dados

🛠️ Tecnologias utilizadas
ASP.NET Core
Entity Framework Core
SQL Server
Swagger

🏗️ Arquitetura

O projeto segue o padrão de arquitetura em camadas:

Controllers → Responsáveis pelas requisições HTTP
Services → Contêm as regras de negócio
Repositories → Responsáveis pelo acesso aos dados
DTOs → Transferência de dados entre camadas

📌 Endpoints principais
Eventos
GET /api/events
GET /api/events/{id}
POST /api/events
PUT /api/events/{id}
DELETE /api/events/{id}

Participantes
GET /api/participant
POST /api/participant

Inscrições
POST /api/enrollment
PUT /api/enrollment/{id}
