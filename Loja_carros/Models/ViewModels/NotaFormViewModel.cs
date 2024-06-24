namespace Loja_carros.Models.ViewModels
{
    public class NotaFormViewModel
    {
        public Nota Nota { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Carro> Carros { get; set; }
        public List<Vendedor> Vendedores { get; set; }
    }
}
