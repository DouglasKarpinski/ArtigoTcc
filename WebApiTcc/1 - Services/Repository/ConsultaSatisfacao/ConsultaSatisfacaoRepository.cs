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
                                + "AND ((DataCadastro >= @DataInicial) OR @DataInicial IS NULL) "
                                + "AND ((DataCadastro <= @DataFinal) OR @DataFinal IS NULL)";
                dbConnection.Open();
                return dbConnection.Query<Services.ConsultaSatisfacao.ConsultaSatisfacao>(sQuery, new { IdEstacao = idEstacao, DataInicial = dataInicial, DataFinal = dataFinal });
            }
        }

        public ProdutoEstacaoImagem Post(int idEstacao, DateTime dataCadastro)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO [dbo].[ProdutoEstacaoImagem] (IdEstacao, DataCadastro)"
                                + " VALUES(@IdEstacao, @DataCadastro)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new {IdEstacao = idEstacao, DataCadastro = dataCadastro});

                return dbConnection.Query<ProdutoEstacaoImagem>("SELECT TOP 1 * FROM [dbo].[ProdutoEstacaoImagem] ORDER BY IdProdutoEstacaoImagem DESC ").FirstOrDefault();
            }
        }
    }
}
