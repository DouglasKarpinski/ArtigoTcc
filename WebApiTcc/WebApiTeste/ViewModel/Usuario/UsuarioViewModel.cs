namespace WebApiTcc.ViewModel.Usuario
{
    public class UsuarioViewModel
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public int IdGrupoEconomico { get; set; }
    }
}
