using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                                "e.IdCategoria, " +
                                "e.Nome, " +
                                "e.Descricao, " +
                                "e.IdUnidadeNegocio, " +
                                "e.Ativo, " +
                                "p.Nome as NomeUnidadeNegocio " +
                                "FROM [dbo].[Estacao] e " +
                                "INNER JOIN [dbo].[Produto] p " +
                                "ON e.IdProduto = p.IdProduto ";
                dbConnection.Open();
                return dbConnection.Query<Services.Estacao.Estacao>(sQuery);
            }
        }
    }
}
