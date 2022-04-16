using System.Text.Json.Serialization;

namespace tcc.pos.puc.boasaude.domain.Models
{
    public class Associados
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public Guid IdPlano { get; set; }
        [JsonIgnore]
        public Guid IdEndereco { get; set; }
        public string Nome { get; set; }
        public string Cpf  { get; set; }
        public string Rg  { get; set; }
        public string NomeMae  { get; set; }
        public string NomePai  { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
