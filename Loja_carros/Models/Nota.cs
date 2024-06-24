using System.ComponentModel.DataAnnotations;

namespace Loja_carros.Models
{
    public class Nota
    {
        public int Id { get; set; }
        
        [Required]
        public string Numero { get; set; }

        [Display(Name = "Data de emissao")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DataEmissao { get; set; }

        [Required]
        [Display(Name = "Garantia (em meses)")]
        public int Garantia { get; set; }

        [Required]
        [Display(Name = "Valor da renda")]
        public float ValorRenda { get; set; }

        [Required]
        [Display(Name = "Nome Comprador")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Required]
        [Display(Name = "Nome vendedor")]
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }

        [Required]
        [Display(Name = "Nome Carro")]
        public int CarroId { get; set; }
        public Carro Carro { get; set; }
    }
}
