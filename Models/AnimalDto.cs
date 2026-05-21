public class AnimalDto
{
    public string Nome { get; set; } = string.Empty;
    public string NomeCientifico { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string UrlImagem { get; set; } = string.Empty;
    public string UrlVideo { get; set; } = string.Empty;
    public string EstadoId { get; set; } = string.Empty;

    public Animal ToAnimal()
    {
        return new Animal
        {
            Nome = this.Nome,
            NomeCientifico = this.NomeCientifico,
            Descricao = this.Descricao,
            UrlImagem = this.UrlImagem,
            UrlVideo = this.UrlVideo,
            EstadoId = Guid.Parse(this.EstadoId)
        };
    }
}