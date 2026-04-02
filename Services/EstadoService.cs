public class EstadoService
{
    private readonly List<Estado> _estados = new();

    public EstadoService()
    {
        SeedData();
    }

    /// <summary>
    /// Dados iniciais para não começar vazio
    /// </summary>
    private void SeedData()
    {
        _estados.AddRange(new List<Estado>
        {
            // Região Norte
            new() { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Nome = "Acre", Sigla = "AC", Regiao = "Norte" },
            new() { Id = Guid.Parse("11111111-1111-1111-1111-111111111112"), Nome = "Amapá", Sigla = "AP", Regiao = "Norte" },
            new() { Id = Guid.Parse("11111111-1111-1111-1111-111111111113"), Nome = "Amazonas", Sigla = "AM", Regiao = "Norte" },
            new() { Id = Guid.Parse("11111111-1111-1111-1111-111111111114"), Nome = "Pará", Sigla = "PA", Regiao = "Norte" },
            new() { Id = Guid.Parse("11111111-1111-1111-1111-111111111115"), Nome = "Rondônia", Sigla = "RO", Regiao = "Norte" },
            new() { Id = Guid.Parse("11111111-1111-1111-1111-111111111116"), Nome = "Roraima", Sigla = "RR", Regiao = "Norte" },
            new() { Id = Guid.Parse("11111111-1111-1111-1111-111111111117"), Nome = "Tocantins", Sigla = "TO", Regiao = "Norte" },
            
            // Região Nordeste
            new() { Id = Guid.Parse("22222222-2222-2222-2222-222222222221"), Nome = "Alagoas", Sigla = "AL", Regiao = "Nordeste" },
            new() { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Nome = "Bahia", Sigla = "BA", Regiao = "Nordeste" },
            new() { Id = Guid.Parse("22222222-2222-2222-2222-222222222223"), Nome = "Ceará", Sigla = "CE", Regiao = "Nordeste" },
            new() { Id = Guid.Parse("22222222-2222-2222-2222-222222222224"), Nome = "Maranhão", Sigla = "MA", Regiao = "Nordeste" },
            new() { Id = Guid.Parse("22222222-2222-2222-2222-222222222225"), Nome = "Paraíba", Sigla = "PB", Regiao = "Nordeste" },
            new() { Id = Guid.Parse("22222222-2222-2222-2222-222222222226"), Nome = "Pernambuco", Sigla = "PE", Regiao = "Nordeste" },
            new() { Id = Guid.Parse("22222222-2222-2222-2222-222222222227"), Nome = "Piauí", Sigla = "PI", Regiao = "Nordeste" },
            new() { Id = Guid.Parse("22222222-2222-2222-2222-222222222228"), Nome = "Rio Grande do Norte", Sigla = "RN", Regiao = "Nordeste" },
            new() { Id = Guid.Parse("22222222-2222-2222-2222-222222222229"), Nome = "Sergipe", Sigla = "SE", Regiao = "Nordeste" },
            
            // Região Centro-Oeste
            new() { Id = Guid.Parse("33333333-3333-3333-3333-333333333331"), Nome = "Distrito Federal", Sigla = "DF", Regiao = "Centro-Oeste" },
            new() { Id = Guid.Parse("33333333-3333-3333-3333-333333333332"), Nome = "Goiás", Sigla = "GO", Regiao = "Centro-Oeste" },
            new() { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Nome = "Mato Grosso", Sigla = "MT", Regiao = "Centro-Oeste" },
            new() { Id = Guid.Parse("33333333-3333-3333-3333-333333333334"), Nome = "Mato Grosso do Sul", Sigla = "MS", Regiao = "Centro-Oeste" },
            
            // Região Sudeste
            new() { Id = Guid.Parse("44444444-4444-4444-4444-444444444441"), Nome = "Espírito Santo", Sigla = "ES", Regiao = "Sudeste" },
            new() { Id = Guid.Parse("44444444-4444-4444-4444-444444444442"), Nome = "Minas Gerais", Sigla = "MG", Regiao = "Sudeste" },
            new() { Id = Guid.Parse("44444444-4444-4444-4444-444444444443"), Nome = "Rio de Janeiro", Sigla = "RJ", Regiao = "Sudeste" },
            new() { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Nome = "São Paulo", Sigla = "SP", Regiao = "Sudeste" },
            
            // Região Sul
            new() { Id = Guid.Parse("55555555-5555-5555-5555-555555555551"), Nome = "Paraná", Sigla = "PR", Regiao = "Sul" },
            new() { Id = Guid.Parse("55555555-5555-5555-5555-555555555552"), Nome = "Rio Grande do Sul", Sigla = "RS", Regiao = "Sul" },
            new() { Id = Guid.Parse("55555555-5555-5555-5555-555555555553"), Nome = "Santa Catarina", Sigla = "SC", Regiao = "Sul" }
        });
    }

    // ── CRUD ──────────────────────────────────────────────

    public List<Estado> GetAll() => _estados;

    public Estado? GetById(Guid id) => _estados.FirstOrDefault(e => e.Id == id);

    public List<Estado> GetByRegiao(string regiao) =>
        _estados.Where(e => e.Regiao.Equals(regiao, StringComparison.OrdinalIgnoreCase)).ToList();

    public Estado Add(Estado estado)
    {
        estado.Id = Guid.NewGuid();
        _estados.Add(estado);
        return estado;
    }

    public Estado? Update(Guid id, Estado updated)
    {
        var estado = _estados.FirstOrDefault(e => e.Id == id);
        if (estado is null) return null;

        estado.Nome = updated.Nome;
        estado.Sigla = updated.Sigla;
        estado.Regiao = updated.Regiao;

        return estado;
    }

    public bool Delete(Guid id)
    {
        var estado = _estados.FirstOrDefault(e => e.Id == id);
        if (estado is null) return false;
        _estados.Remove(estado);
        return true;
    }
}