using Dapper;
using Data.Services.Usuario;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data.Repository.Home
{
    public class HomeRepository : IHomeRepository
    {

        private readonly UI _ui;

        private string connectionString;


        public HomeRepository(UI ui)
        {
            _ui = ui;
        }

        public HomeRepository()
        {
            connectionString =_ui.DataBase;
        }
        public IDbConnection Connection => new SqlConnection(connectionString);

        public IEnumerable<Usuario> GetBd()
        {

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Usuario>("SELECT * FROM [dbo].[Usuario]");
            }



        }
    }
}

