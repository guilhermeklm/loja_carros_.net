using NuGet.Protocol.Plugins;
using System.ComponentModel.DataAnnotations;

namespace Loja_carros.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de nascimento")]
        [Required]
        public DateTime DataNascimento { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(11), MaxLength(13)]
        public string Telefone { get; set; }

        [Required]
        [Display(Name = "Endereco (Rua com numero)")]
        public string Endereco { get; set; }

        [Required]
        [MinLength(11), MaxLength(11)]
        public string Cpf { get; set; }

        public List<Nota> Notas { get; set; }
            = new List<Nota>();
    }
}
