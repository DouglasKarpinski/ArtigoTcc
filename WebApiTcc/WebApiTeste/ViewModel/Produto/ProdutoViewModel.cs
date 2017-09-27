namespace WebApiTcc.ViewModel.Produto
{
    public class ProdutoViewModel
    {
        public int IdProduto { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }
    }
}
