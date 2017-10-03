using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Data.Services.Estacao;

namespace Data.Repository.Estacao
{
    public class EstacaoRepository : IEstacaoRepository
    {
        private readonly UI _ui;

        public EstacaoRepository(UI ui)
        {
            _ui = ui;
        }

        public IDbConnection Connection => new SqlConnection(_ui.DataBase);

        public IEnumerable<Services.Estacao.Estacao> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT " +
                                "e.IdEstacao, " +
                                "e.Nome, " +
                                "e.Descricao, " +
                                "e.IdProduto, " +
                                "e.Ativo, " +
                                "p.Nome as NomeProduto " +
                                "FROM [dbo].[Estacao] e " +
                                "INNER JOIN [dbo].[Produto] p " +
                                "ON e.IdProduto = p.IdProduto ";
                dbConnection.Open();
                return dbConnection.Query<Services.Estacao.Estacao>(sQuery);
            }
        }

        public Services.Estacao.Estacao Post(Services.Estacao.Estacao estacao)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO [dbo].[Estacao] (Nome, Descricao, IdProduto, Ativo)"
                                + " VALUES(@Nome, @Descricao, @IdProduto, @Ativo)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, estacao);

                return dbConnection.Query<Services.Estacao.Estacao>("SELECT TOP 1 * FROM [dbo].[Estacao] ORDER BY IdEstacao DESC ").FirstOrDefault();
            }
        }

        public Services.Estacao.Estacao GetById(int idEstacao)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM [dbo].[Estacao]"
                                + "WHERE IdEstacao = @IdEstacao";
                dbConnection.Open();
                return dbConnection.Query<Services.Estacao.Estacao>(sQuery, new { IdEstacao = idEstacao })
                    .FirstOrDefault();
            }
        }

        public Services.Estacao.Estacao Put(Services.Estacao.Estacao estacao)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE [dbo].[Estacao]"
                                + " SET Nome = @Nome, " +
                                "Descricao = @Descricao, " +
                                "IdProduto = @IdProduto, " +
                                "Ativo = @Ativo " +
                                "WHERE IdEstacao = @IdEstacao";

                dbConnection.Open();
                dbConnection.Execute(sQuery, estacao);

                return estacao;
            }
        }

        public void Delete(int idEstacao)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM [dbo].[Estacao] WHERE IdEstacao = @IdEstacao";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { IdEstacao = idEstacao });
            }
        }
    }
}
