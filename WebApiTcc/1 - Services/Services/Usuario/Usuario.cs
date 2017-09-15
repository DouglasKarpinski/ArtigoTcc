namespace Data.Services.Usuario
{
    public class Usuario
    {
        public Usuario()
        {
        }

        public Usuario(int idUsuario, string nome, string senha, bool ativo, int idGrupoEconomico)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Senha = senha;
            Ativo = ativo;
            IdGrupoEconomico = idGrupoEconomico;
        }

        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public int IdGrupoEconomico { get; set; }
    }
}
