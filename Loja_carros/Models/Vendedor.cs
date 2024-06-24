using System.ComponentModel.DataAnnotations;

namespace Loja_carros.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data admissao")]
        [Required]
        public DateTime DataAdmissao { get; set; }

        [Required]
        public string Matricula { get; set; }

        [Required]
        public float Salario { get; set; }
    }
}
