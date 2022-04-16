using System.Text.Json.Serialization;

namespace tcc.pos.puc.boasaude.domain.Models;

public class Endereco
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public Guid IdTipoEndereco { get; set; }
    public string Lougradouro { get; set; }
    public string Numero { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Cep { get; set; }
}