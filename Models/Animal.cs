public class Animal
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string NomeCientifico { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string UrlImagem { get; set; } = string.Empty;
    public string UrlVideo { get; set; } = string.Empty;
    public Guid EstadoId { get; set; }
}