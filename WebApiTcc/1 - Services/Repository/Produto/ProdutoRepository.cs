using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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
                return dbConnection.Query<Services.Produto.Produto>("SELECT " +
                                                                    "p.* , " +
                                                                    "c.Nome as NomeCategoria " +
                                                                    "FROM [dbo].[Produto] p " +
                                                                    "INNER JOIN [dbo].[Categoria] c " +
                                                                    "ON p.IdCategoria = c.IdCategoria");
            }
        }

        public Services.Produto.Produto Post(Services.Produto.Produto produto)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO [dbo].[Produto] (Nome, Descricao, IdCategoria, Ativo)"
                                + " VALUES(@Nome, @Descricao, @IdCategoria, @Ativo)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, produto);

                return dbConnection.Query<Services.Produto.Produto>("SELECT TOP 1 * FROM [dbo].[Produto] ORDER BY IdProduto DESC ").FirstOrDefault();
            }
        }
    }
}
