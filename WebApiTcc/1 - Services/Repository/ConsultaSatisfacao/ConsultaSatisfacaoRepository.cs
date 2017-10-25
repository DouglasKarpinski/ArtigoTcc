using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Data.Services.ConsultaSatisfacao;

namespace Data.Repository.ConsultaSatisfacao
{
    public class ConsultaSatisfacaoRepository : IConsultaSatisfacaoRepository
    {
        private readonly UI _ui;

        public ConsultaSatisfacaoRepository(UI ui)
        {
            _ui = ui;
        }

        public IDbConnection Connection => new SqlConnection(_ui.DataBase);

        public IEnumerable<Services.ConsultaSatisfacao.ConsultaSatisfacao> Get(int idEstacao, DateTime? dataInicial, DateTime? dataFinal)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM [dbo].[ProdutoEstacaoImagem]"
                                + "WHERE IdEstacao = @IdEstacao "
                                + "AND DataCadastro >= @DataInicial "
                                + "AND DataCadastro <= @DataFinal";
                dbConnection.Open();
                return dbConnection.Query<Services.ConsultaSatisfacao.ConsultaSatisfacao>(sQuery, new { IdEstacao = idEstacao, DataInicial = dataInicial, DataFinal = dataFinal });
            }
        }
    }
}
