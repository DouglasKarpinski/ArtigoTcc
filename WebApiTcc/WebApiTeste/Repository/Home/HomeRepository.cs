using System.Collections.Generic;
using System.Data;
using WebApiTcc.Helpers;
using WebApiTcc.Helpers.DataBaseInvoker;
using WebApiTcc.ViewModel.Home;
using WebApiTcc.ViewModel.Usuario;

namespace WebApiTcc.Repository.Home
{
    public class HomeRepository : IHomeRepository
    {
        private readonly IDatabaseInvoker _databaseInvoker;


        private enum Procedures
        {
            SP_SelecionaUsuario
        }
        public HomeRepository(IDatabaseInvoker databaseInvoker)
        {
            _databaseInvoker = databaseInvoker;
        }

        public HomeViewModel Get()
        {
            var lst = new List<UsuarioViewModel>();
            var home = new HomeViewModel();
            _databaseInvoker.BeginNewStatement(Procedures.SP_SelecionaUsuario);
            using (var reader = _databaseInvoker.ExecuteReader(CommandBehavior.Default))
                while (reader.Read())
                    lst.Add(new UsuarioViewModel(
                        reader.ReadAsInt("IdUsuario"),
                        reader.ReadAsString("Nome"),
                        reader.ReadAsString("Senha"),
                        reader.ReadAsBool("Ativo"),
                        reader.ReadAsInt("IdGrupoEconomico")
                        ));

            home.Usuario = lst;

            return home;
        }
    }
}
