var builder = WebApplication.CreateBuilder(args);

// ── Serviços ──────────────────────────────────────────
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<CardService>();
builder.Services.AddSingleton<EstadoService>();
builder.Services.AddSingleton<AnimalService>();

// ── Configuração JSON ─────────────────────────────────
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null; // Mantém nomes originais
    options.SerializerOptions.WriteIndented = true;
});

// ── CORS (permite o frontend se conectar) ─────────────
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// ── Middlewares ────────────────────────────────────────
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();

// ── Endpoints ─────────────────────────────────────────

// GET /api/cards → Retorna todos os cards
app.MapGet("/api/cards", (CardService svc) =>
{
    return Results.Ok(svc.GetAll());
})
.WithName("GetAllCards")
.WithTags("Cards");

// GET /api/cards/{id} → Retorna um card pelo ID
app.MapGet("/api/cards/{id:guid}", (Guid id, CardService svc) =>
{
    var card = svc.GetById(id);
    return card is not null ? Results.Ok(card) : Results.NotFound();
})
.WithName("GetCardById")
.WithTags("Cards");

// GET /api/cards/status/{status} → Retorna cards filtrados por status
app.MapGet("/api/cards/status/{status}", (string status, CardService svc) =>
{
    var cards = svc.GetByStatus(status);
    return Results.Ok(cards);
})
.WithName("GetCardsByStatus")
.WithTags("Cards");

// POST /api/cards → Cria um novo card
app.MapPost("/api/cards", (Card card, CardService svc) =>
{
    var created = svc.Add(card);
    return Results.Created($"/api/cards/{created.Id}", created);
})
.WithName("CreateCard")
.WithTags("Cards");

// PUT /api/cards/{id} → Atualiza um card existente
app.MapPut("/api/cards/{id:guid}", (Guid id, Card updated, CardService svc) =>
{
    var card = svc.Update(id, updated);
    return card is not null ? Results.Ok(card) : Results.NotFound();
})
.WithName("UpdateCard")
.WithTags("Cards");

// PATCH /api/cards/{id}/move → Move um card para outra coluna
app.MapPatch("/api/cards/{id:guid}/move", (Guid id, MoveRequest request, CardService svc) =>
{
    // Status válidos
    string[] validStatuses = { "Backlog", "ToDo", "Doing", "Testing", "Done" };

    if (!validStatuses.Contains(request.Status, StringComparer.OrdinalIgnoreCase))
    {
        return Results.BadRequest(new
        {
            error = "Status inválido",
            validStatuses
        });
    }

    var card = svc.MoveCard(id, request.Status);
    return card is not null ? Results.Ok(card) : Results.NotFound();
})
.WithName("MoveCard")
.WithTags("Cards");

// DELETE /api/cards/{id} → Remove um card
app.MapDelete("/api/cards/{id:guid}", (Guid id, CardService svc) =>
{
    return svc.Delete(id) ? Results.NoContent() : Results.NotFound();
})
.WithName("DeleteCard")
.WithTags("Cards");

// ── Endpoints Estados ─────────────────────────────────

// GET /api/estados → Retorna todos os estados
app.MapGet("/api/estados", (EstadoService svc) =>
{
    return Results.Ok(svc.GetAll());
})
.WithName("GetAllEstados")
.WithTags("Estados");

// GET /api/estados/{id} → Retorna um estado pelo ID
app.MapGet("/api/estados/{id:guid}", (Guid id, EstadoService svc) =>
{
    var estado = svc.GetById(id);
    return estado is not null ? Results.Ok(estado) : Results.NotFound();
})
.WithName("GetEstadoById")
.WithTags("Estados");

// GET /api/estados/regiao/{regiao} → Retorna estados filtrados por região
app.MapGet("/api/estados/regiao/{regiao}", (string regiao, EstadoService svc) =>
{
    var estados = svc.GetByRegiao(regiao);
    return Results.Ok(estados);
})
.WithName("GetEstadosByRegiao")
.WithTags("Estados");

// POST /api/estados → Cria um novo estado
app.MapPost("/api/estados", (Estado estado, EstadoService svc) =>
{
    // Validações básicas
    if (string.IsNullOrWhiteSpace(estado.Nome))
        return Results.BadRequest(new { error = "Nome é obrigatório" });
    
    if (string.IsNullOrWhiteSpace(estado.Sigla) || estado.Sigla.Length != 2)
        return Results.BadRequest(new { error = "Sigla deve ter exatamente 2 caracteres" });

    var created = svc.Add(estado);
    return Results.Created($"/api/estados/{created.Id}", created);
})
.WithName("CreateEstado")
.WithTags("Estados");

// PUT /api/estados/{id} → Atualiza um estado existente
app.MapPut("/api/estados/{id:guid}", (Guid id, Estado updated, EstadoService svc) =>
{
    // Validações básicas
    if (string.IsNullOrWhiteSpace(updated.Nome))
        return Results.BadRequest(new { error = "Nome é obrigatório" });
    
    if (string.IsNullOrWhiteSpace(updated.Sigla) || updated.Sigla.Length != 2)
        return Results.BadRequest(new { error = "Sigla deve ter exatamente 2 caracteres" });

    var estado = svc.Update(id, updated);
    return estado is not null ? Results.Ok(estado) : Results.NotFound();
})
.WithName("UpdateEstado")
.WithTags("Estados");

// DELETE /api/estados/{id} → Remove um estado
app.MapDelete("/api/estados/{id:guid}", (Guid id, EstadoService svc) =>
{
    return svc.Delete(id) ? Results.NoContent() : Results.NotFound();
})
.WithName("DeleteEstado")
.WithTags("Estados");

// ── Endpoints Animais ──────────────────────────────────

// GET /api/animais → Retorna todos os animais
app.MapGet("/api/animais", (AnimalService svc) =>
{
    return Results.Ok(svc.GetAll());
})
.WithName("GetAllAnimais")
.WithTags("Animais");

// GET /api/animais/{id} → Retorna um animal pelo ID
app.MapGet("/api/animais/{id:guid}", (Guid id, AnimalService svc) =>
{
    var animal = svc.GetById(id);
    return animal is not null ? Results.Ok(animal) : Results.NotFound();
})
.WithName("GetAnimalById")
.WithTags("Animais");

// GET /api/estados/{estadoId}/animais → Retorna animais de um estado
app.MapGet("/api/estados/{estadoId:guid}/animais", (Guid estadoId, AnimalService svc) =>
{
    var animais = svc.GetByEstadoId(estadoId);
    return Results.Ok(animais);
})
.WithName("GetAnimaisByEstado")
.WithTags("Animais");

// POST /api/animais → Cria um novo animal
app.MapPost("/api/animais", (AnimalDto animalDto, AnimalService animalSvc, EstadoService estadoSvc) =>
{
    // Validações básicas
    if (string.IsNullOrWhiteSpace(animalDto.Nome))
        return Results.BadRequest(new { error = "Nome é obrigatório" });
    
    if (string.IsNullOrWhiteSpace(animalDto.EstadoId) || !Guid.TryParse(animalDto.EstadoId, out var estadoGuid))
        return Results.BadRequest(new { error = "EstadoId deve ser um GUID válido" });
    
    // Verifica se o estado existe
    var estado = estadoSvc.GetById(estadoGuid);
    if (estado is null)
        return Results.BadRequest(new { error = "EstadoId deve existir" });

    var animal = animalDto.ToAnimal();
    var created = animalSvc.Add(animal);
    return Results.Created($"/api/animais/{created.Id}", created);
})
.WithName("CreateAnimal")
.WithTags("Animais");

// PUT /api/animais/{id} → Atualiza um animal existente
app.MapPut("/api/animais/{id:guid}", (Guid id, AnimalDto animalDto, AnimalService animalSvc, EstadoService estadoSvc) =>
{
    // Validações básicas
    if (string.IsNullOrWhiteSpace(animalDto.Nome))
        return Results.BadRequest(new { error = "Nome é obrigatório" });
    
    if (string.IsNullOrWhiteSpace(animalDto.EstadoId) || !Guid.TryParse(animalDto.EstadoId, out var estadoGuid))
        return Results.BadRequest(new { error = "EstadoId deve ser um GUID válido" });
    
    // Verifica se o estado existe
    var estado = estadoSvc.GetById(estadoGuid);
    if (estado is null)
        return Results.BadRequest(new { error = "EstadoId deve existir" });

    var updated = animalDto.ToAnimal();
    var animal = animalSvc.Update(id, updated);
    return animal is not null ? Results.Ok(animal) : Results.NotFound();
})
.WithName("UpdateAnimal")
.WithTags("Animais");

// DELETE /api/animais/{id} → Remove um animal
app.MapDelete("/api/animais/{id:guid}", (Guid id, AnimalService svc) =>
{
    return svc.Delete(id) ? Results.NoContent() : Results.NotFound();
})
.WithName("DeleteAnimal")
.WithTags("Animais");

app.Run();

// ── Records auxiliares ────────────────────────────────
// Record usado para receber o novo status no endpoint de mover card
public record MoveRequest(string Status);