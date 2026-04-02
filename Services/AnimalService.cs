public class AnimalService
{
    private readonly List<Animal> _animais = new();

    public AnimalService()
    {
        SeedData();
    }

    /// <summary>
    /// Dados iniciais para não começar vazio
    /// </summary>
    private void SeedData()
    {
        _animais.AddRange(new List<Animal>
        {
            // Região Norte
            new()
            {
                Id = Guid.NewGuid(),
                Nome = "Boto-cor-de-rosa",
                NomeCientifico = "Inia geoffrensis",
                Descricao = "Golfinho de água doce endêmico da Bacia Amazônica",
                UrlImagem = "https://example.com/boto-cor-de-rosa.jpg",
                EstadoId = Guid.Parse("11111111-1111-1111-1111-111111111113") // AM
            },
            new()
            {
                Id = Guid.NewGuid(),
                Nome = "Pirarucu",
                NomeCientifico = "Arapaima gigas",
                Descricao = "Um dos maiores peixes de água doce do mundo, encontrado na Amazônia",
                UrlImagem = "https://example.com/pirarucu.jpg",
                EstadoId = Guid.Parse("11111111-1111-1111-1111-111111111114") // PA
            },
            
            // Região Nordeste
            new()
            {
                Id = Guid.NewGuid(),
                Nome = "Ararinha-azul",
                NomeCientifico = "Cyanopsitta spixii",
                Descricao = "Ave endêmica da Caatinga, extinta na natureza e símbolo da conservação",
                UrlImagem = "https://example.com/ararinha-azul.jpg",
                EstadoId = Guid.Parse("22222222-2222-2222-2222-222222222222") // BA
            },
            new()
            {
                Id = Guid.NewGuid(),
                Nome = "Soldadinho-do-araripe",
                NomeCientifico = "Antilophia bokermanni",
                Descricao = "Ave endêmica da Chapada do Araripe, criticamente ameaçada",
                UrlImagem = "https://example.com/soldadinho-do-araripe.jpg",
                EstadoId = Guid.Parse("22222222-2222-2222-2222-222222222223") // CE
            },
            
            // Região Centro-Oeste
            new()
            {
                Id = Guid.NewGuid(),
                Nome = "Onça-pintada",
                NomeCientifico = "Panthera onca",
                Descricao = "Maior felino das Américas, símbolo do Pantanal",
                UrlImagem = "https://example.com/onca-pintada.jpg",
                EstadoId = Guid.Parse("33333333-3333-3333-3333-333333333334") // MS
            },
            new()
            {
                Id = Guid.NewGuid(),
                Nome = "Arara-azul-grande",
                NomeCientifico = "Anodorhynchus hyacinthinus",
                Descricao = "Maior arara do mundo, símbolo do Pantanal e do Cerrado",
                UrlImagem = "https://example.com/arara-azul-grande.jpg",
                EstadoId = Guid.Parse("33333333-3333-3333-3333-333333333333") // MT
            },
            
            // Região Sudeste
            new()
            {
                Id = Guid.NewGuid(),
                Nome = "Mico-leão-dourado",
                NomeCientifico = "Leontopithecus rosalia",
                Descricao = "Primata símbolo da conservação brasileira, encontrado na Mata Atlântica fluminense",
                UrlImagem = "https://example.com/mico-leao-dourado.jpg",
                EstadoId = Guid.Parse("44444444-4444-4444-4444-444444444443") // RJ
            },
            new()
            {
                Id = Guid.NewGuid(),
                Nome = "Mico-leão-preto",
                NomeCientifico = "Leontopithecus chrysopygus",
                Descricao = "Primata endêmico da Mata Atlântica paulista, criticamente ameaçado de extinção",
                UrlImagem = "https://example.com/mico-leao-preto.jpg",
                EstadoId = Guid.Parse("44444444-4444-4444-4444-444444444444") // SP
            },
            
            // Região Sul
            new()
            {
                Id = Guid.NewGuid(),
                Nome = "Gralha-azul",
                NomeCientifico = "Cyanocorax caeruleus",
                Descricao = "Ave símbolo do estado de Santa Catarina, conhecida por sua plumagem azul vibrante",
                UrlImagem = "https://example.com/gralha-azul.jpg",
                EstadoId = Guid.Parse("55555555-5555-5555-5555-555555555553") // SC
            },
            new()
            {
                Id = Guid.NewGuid(),
                Nome = "Bugio-ruivo",
                NomeCientifico = "Alouatta guariba clamitans",
                Descricao = "Primata endêmico da Mata Atlântica do sul do Brasil",
                UrlImagem = "https://example.com/bugio-ruivo.jpg",
                EstadoId = Guid.Parse("55555555-5555-5555-5555-555555555552") // RS
            }
        });
    }

    // ── CRUD ──────────────────────────────────────────────

    public List<Animal> GetAll() => _animais;

    public Animal? GetById(Guid id) => _animais.FirstOrDefault(a => a.Id == id);

    public List<Animal> GetByEstadoId(Guid estadoId) =>
        _animais.Where(a => a.EstadoId == estadoId).ToList();

    public Animal Add(Animal animal)
    {
        animal.Id = Guid.NewGuid();
        _animais.Add(animal);
        return animal;
    }

    public Animal? Update(Guid id, Animal updated)
    {
        var animal = _animais.FirstOrDefault(a => a.Id == id);
        if (animal is null) return null;

        animal.Nome = updated.Nome;
        animal.NomeCientifico = updated.NomeCientifico;
        animal.Descricao = updated.Descricao;
        animal.UrlImagem = updated.UrlImagem;
        animal.EstadoId = updated.EstadoId;

        return animal;
    }

    public bool Delete(Guid id)
    {
        var animal = _animais.FirstOrDefault(a => a.Id == id);
        if (animal is null) return false;
        _animais.Remove(animal);
        return true;
    }
}