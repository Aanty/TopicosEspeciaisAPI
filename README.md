# TopicosEspeciaisAPI

Uma API REST completa desenvolvida em .NET 9 com Minimal APIs, focada no gerenciamento de fauna brasileira, estados e sistema de quadro Kanban.

## 🚀 Tecnologias

- **.NET 9.0** - Framework principal
- **Minimal APIs** - Arquitetura moderna e performática
- **Swagger/OpenAPI** - Documentação automática
- **Docker** - Containerização
- **C#** - Linguagem de programação

## 📋 Funcionalidades

### 🐾 Módulo Animais
- **CRUD completo** para fauna brasileira
- **10 animais pré-cadastrados** representando cada região do Brasil
- **Relacionamento** com estados brasileiros
- **Validações robustas** com mensagens detalhadas
- **Filtros** por estado

### 🗺️ Módulo Estados
- **CRUD completo** para estados brasileiros
- **27 estados pré-cadastrados** (26 estados + DF)
- **Organização por região** (Norte, Nordeste, Centro-Oeste, Sudeste, Sul)
- **Filtros** por região
- **Endpoint debug** para desenvolvimento

### 📋 Módulo Cards (Scrum Board)
- **Sistema Kanban completo** com 5 status: Backlog, ToDo, Doing, Testing, Done
- **Prioridades**: Low, Medium, High, Urgent
- **Funcionalidade especial**: mover cards entre colunas
- **Timestamps automáticos** (criação/atualização)
- **5 cards de exemplo** simulando projeto real

## 🛠️ Instalação e Execução

### Pré-requisitos
- .NET 9.0 SDK
- Docker (opcional)

### Executando localmente

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/TopicosEspeciaisAPI.git

# Navegue até o diretório
cd TopicosEspeciaisAPI

# Restaure as dependências
dotnet restore

# Execute a aplicação
dotnet run
```

A API estará disponível em:
- **HTTP**: http://localhost:5085
- **HTTPS**: https://localhost:7208
- **Swagger**: http://localhost:5085/swagger

### Executando com Docker

```bash
# Build da imagem
docker build -t topicosespeciaisapi .

# Execute o container
docker run -p 8080:80 topicosespeciaisapi
```

A API estará disponível em: http://localhost:8080

## 📚 Documentação da API

### Endpoints Principais

#### 🐾 Animais
```
GET    /api/animais                    # Lista todos os animais
GET    /api/animais/{id}               # Busca animal por ID
GET    /api/animais/estado/{estadoId}  # Lista animais por estado
POST   /api/animais                    # Cria novo animal
PUT    /api/animais/{id}               # Atualiza animal
DELETE /api/animais/{id}               # Remove animal
```

#### 🗺️ Estados
```
GET    /api/estados                    # Lista todos os estados
GET    /api/estados/{id}               # Busca estado por ID
GET    /api/estados/regiao/{regiao}    # Lista estados por região
GET    /api/estados/debug              # Informações para debug
POST   /api/estados                    # Cria novo estado
PUT    /api/estados/{id}               # Atualiza estado
DELETE /api/estados/{id}               # Remove estado
```

#### 📋 Cards
```
GET    /api/cards                      # Lista todos os cards
GET    /api/cards/{id}                 # Busca card por ID
GET    /api/cards/status/{status}      # Lista cards por status
POST   /api/cards                      # Cria novo card
PUT    /api/cards/{id}                 # Atualiza card
PATCH  /api/cards/{id}/move            # Move card entre colunas
DELETE /api/cards/{id}                 # Remove card
```

### Exemplos de Uso

#### Criar um novo animal
```json
POST /api/animais
{
  "Nome": "Jaguar",
  "NomeCientifico": "Panthera onca",
  "Descricao": "Maior felino das Américas",
  "UrlImagem": "https://example.com/jaguar.jpg",
  "EstadoId": "33333333-3333-3333-3333-333333333333"
}
```

#### Mover um card
```json
PATCH /api/cards/{id}/move
{
  "Status": "Doing"
}
```

## 🏗️ Estrutura do Projeto

```
TopicosEspeciaisAPI/
├── Models/
│   ├── Animal.cs           # Entidade Animal
│   ├── AnimalDto.cs        # DTO para entrada de dados
│   ├── Estado.cs           # Entidade Estado
│   └── Card.cs             # Entidade Card
├── Services/
│   ├── AnimalService.cs    # Lógica de negócio - Animais
│   ├── EstadoService.cs    # Lógica de negócio - Estados
│   └── CardService.cs      # Lógica de negócio - Cards
├── Program.cs              # Configuração e endpoints
├── Dockerfile              # Configuração Docker
└── README.md               # Este arquivo
```

## 🌟 Características Técnicas

- **Arquitetura limpa** com separação de responsabilidades
- **Injeção de dependência** nativa do .NET
- **CORS configurado** para integração com frontend
- **Validações robustas** com tratamento de erros
- **Dados em memória** com seed data automático
- **Documentação automática** via Swagger
- **Containerização** com Docker multi-stage

## 🐾 Animais Pré-cadastrados

| Região | Animal | Nome Científico |
|--------|--------|-----------------|
| Norte | Boto-cor-de-rosa | *Inia geoffrensis* |
| Norte | Pirarucu | *Arapaima gigas* |
| Nordeste | Ararinha-azul | *Cyanopsitta spixii* |
| Nordeste | Soldadinho-do-araripe | *Antilophia bokermanni* |
| Centro-Oeste | Onça-pintada | *Panthera onca* |
| Centro-Oeste | Arara-azul-grande | *Anodorhynchus hyacinthinus* |
| Sudeste | Mico-leão-dourado | *Leontopithecus rosalia* |
| Sudeste | Mico-leão-preto | *Leontopithecus chrysopygus* |
| Sul | Gralha-azul | *Cyanocorax caeruleus* |
| Sul | Bugio-ruivo | *Alouatta guariba clamitans* |

## 🤝 Contribuição

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## 👨‍💻 Autor

Desenvolvido como parte da disciplina de Tópicos Especiais em Desenvolvimento de Software.

---

⭐ Se este projeto te ajudou, considere dar uma estrela no repositório!