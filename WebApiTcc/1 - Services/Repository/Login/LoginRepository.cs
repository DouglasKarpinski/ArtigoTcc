using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Data.Services.Login;

namespace Data.Repository.Login
{
    public class LoginRepository : ILoginRepository
    {
        private readonly UI _ui;

        public LoginRepository(UI ui)
        {
            _ui = ui;
        }

        public IDbConnection Connection => new SqlConnection(_ui.DataBase);

        public Usuario GetUser(string nome, string senha)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM [dbo].[Usuario]"
                                + "WHERE Nome = @Nome and Senha = @Senha";
                dbConnection.Open();
                return dbConnection.Query<Usuario>(sQuery, new { Nome = nome, Senha = senha })
                    .FirstOrDefault();
            }
        }
    }
}
