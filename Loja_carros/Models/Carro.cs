using System.ComponentModel.DataAnnotations;

namespace Loja_carros.Models
{
    public class Carro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Marca é obrigatória.")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Modelo é obrigatório.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Ano de fabricação é obrigatório.")]
        [Range(1886, 2100, ErrorMessage = "Por favor, insira um ano válido.")]
        public int AnoFabricacao { get; set; }

        [Required(ErrorMessage = "Ano do modelo é obrigatório.")]
        [Range(1886, 2100, ErrorMessage = "Por favor, insira um ano válido.")]
        public int AnoModelo { get; set; }

        [Required(ErrorMessage = "Chassi é obrigatório.")]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "O chassi deve ter 17 caracteres.")]
        public string Chassi { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "Preço deve ser um valor positivo.")]
        public float Preco { get; set; }

    }
}
