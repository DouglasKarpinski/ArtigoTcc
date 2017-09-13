using Data.Repository.Home;
using Data.Services.Home;

namespace WebApiTcc.Repository.Home
{
    public class HomeRepository : IHomeRepository
    {


        private enum Procedures
        {
            SP_SelecionaUsuario
        }
        

        //public HomeViewModel Get()
        //{
        //    var lst = new List<UsuarioViewModel>();
        //    var home = new HomeViewModel();
        //    _databaseInvoker.BeginNewStatement(Procedures.SP_SelecionaUsuario);
        //    using (var reader = _databaseInvoker.ExecuteReader(CommandBehavior.Default))
        //        while (reader.Read())
        //            lst.Add(new UsuarioViewModel(
        //                reader.ReadAsInt("IdUsuario"),
        //                reader.ReadAsString("Nome"),
        //                reader.ReadAsString("Senha"),
        //                reader.ReadAsBool("Ativo"),
        //                reader.ReadAsInt("IdGrupoEconomico")
        //                ));

        //    home.Usuario = lst;

        //    return home;
        //}
        public HomeViewModel Get()
        {
            throw new System.NotImplementedException();
        }
    }
}
