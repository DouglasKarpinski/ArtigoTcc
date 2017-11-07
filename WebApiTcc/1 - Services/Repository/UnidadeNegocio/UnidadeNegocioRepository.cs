using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using Data.Services.UnidadeNegocio;

namespace Data.Repository.UnidadeNegocio
{
    public class UnidadeNegocioRepository : IUnidadeNegocioRepository
    {
        private readonly UI _ui;

        public UnidadeNegocioRepository(UI ui)
        {
            _ui = ui;
        }

        public IDbConnection Connection => new SqlConnection(_ui.DataBase);

        public IEnumerable<Services.UnidadeNegocio.UnidadeNegocio> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Services.UnidadeNegocio.UnidadeNegocio>("SELECT " +
                                                                                  "u.* " +
                                                                                  "FROM [dbo].[UnidadeNegocio] u ");
            }
        }
    }
}
