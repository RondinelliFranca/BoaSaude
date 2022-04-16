using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace tcc.pos.puc.boasaude.domain.Models;

public class Plano
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public Guid IdTipoPlano { get; set; }
    public Guid IdSituacaoPlano { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public bool Individual { get; set; }
    public bool Odonto { get; set; }
}