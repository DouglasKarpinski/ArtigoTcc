using Data.Repository.Home;
using Data.Services.Home;
using System;
using System.Data.SqlClient;

namespace WebApiTcc.Repository.Home
{
    public class HomeRepository : IHomeRepository
    {
        //cleyton ferrari  

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

        public void GetBd()
        {

            SqlConnection conection = new SqlConnection(@"Server=SQLSERVER;Data Source=analisesatisfacao.database.windows.net;Integrated Security=SSPI;Initial Catalog=TCC Database;User ID=administrador;Password=Adm123**;Trusted_Connection=False;Encrypt=True;Integrated Security=False");
            //"Server=$SQLSERVER;Database=$SQLDB;Authentication=Active Directory Integrated;Encrypt=True;TrustServerCertificate=False;"
            conection.Open();

            /*teste no banco*/

            string strquery = "SELECT * FROM [dbo].[Usuario]";
            SqlCommand cmdCommandSelect = new SqlCommand(strquery, conection);
            SqlDataReader dados = cmdCommandSelect.ExecuteReader();

            while (dados.Read())
            {
                Console.WriteLine($"id:{dados["IdUsuario"]}, Nome{dados["Nome"]},Senha{dados["Senha"]}, Ativo{dados["Ativo"]}, IdGrupoEconomico{dados["IdGrupoEconomico"]}");
            }
        }
    }
}
