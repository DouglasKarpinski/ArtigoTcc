namespace Data.Services.Categoria
{
    public class Categoria
    {
        public Categoria()
        {
        }

        public Categoria(int idCategoria, string nome, string descricao, int idUnidadeNegocio, bool ativo, string nomeUnidadeNegocio)
        {
            IdCategoria = idCategoria;
            Nome = nome;
            Descricao = descricao;
            IdUnidadeNegocio = idUnidadeNegocio;
            Ativo = ativo;
            UnidadeNegocio = new UnidadeNegocio.UnidadeNegocio(nomeUnidadeNegocio);
        }

        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int IdUnidadeNegocio { get; set; }
        public bool Ativo { get; set; }

        public UnidadeNegocio.UnidadeNegocio UnidadeNegocio { get; set; }
        
    }

    
}
