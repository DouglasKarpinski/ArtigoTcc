namespace WebApiTcc.ViewModel.Usuario
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(int id, string nome, string senha, bool ativo, int idGrupoEconomico)
        {
            Id = id;
            Nome = nome;
            Senha = senha;
            Ativo = ativo;
            IdGrupoEconomico = idGrupoEconomico;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public int IdGrupoEconomico { get; set; }
    }
}
