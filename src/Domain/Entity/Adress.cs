using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entity
{
    public class Adress
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Description { get; set; }
        [JsonPropertyName("cep")]
        public string Cep { get; set; }
        [JsonPropertyName("logradouro")]
        public string Alley { get; set; }
        [JsonPropertyName("bairro")]
        public string Neighborhood { get; set; }
        [JsonPropertyName("complemento")]
        public string Complement { get; set; }
        [JsonPropertyName("uf")]
        public string Uf { get; set; }
        [JsonPropertyName("erro")]
        public string Number { get; set; }
        public bool IsCurrent { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public bool Erro { get; set; }
    }
}
