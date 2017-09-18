namespace WebApiTcc.ViewModel.Categoria
{
    public class CategoriaViewModel
    {
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int IdUnidadeNegocio { get; set; }
        public bool Ativo { get; set; }
    }
}
