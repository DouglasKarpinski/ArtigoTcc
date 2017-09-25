using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;

namespace Data.Repository.Produto
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly UI _ui;

        public ProdutoRepository(UI ui)
        {
            _ui = ui;
        }

        public IDbConnection Connection => new SqlConnection(_ui.DataBase);

        public IEnumerable<Services.Produto.Produto> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Services.Produto.Produto>("SELECT * FROM [dbo].[Produto]");
            }
        }
    }
}
