using System.Data;

namespace WebApiTcc.Helpers.DataBaseInvoker
{
    public static class DatabaseTransactionFacade
    {
        public static void CheckConnection(IDbConnection connection)
        {
            if (connection.State == ConnectionState.Broken || connection.State == ConnectionState.Closed)
                connection.Open();
        }

        public static IDbTransaction CheckTransaction(IDbConnection connection, IDbTransaction transaction)
        {
            transaction = connection.BeginTransaction();
            return transaction;
        }

        public static IDbTransaction CheckTransaction(IDbConnection connection, IDbTransaction transaction, IsolationLevel isolationLevel)
        {
            transaction = connection.BeginTransaction(isolationLevel);
            return transaction;
        }


        public static void CheckStatements(DatabaseCommand command)
        {
            command.ExecuteNonQuery();
        }

        public static void CommitTransaction(IDbTransaction transaction)
        {
            transaction?.Commit();
            transaction = null;
        }

        public static void RollBackTransaction(IDbTransaction transaction)
        {
            transaction?.Rollback();
            transaction = null;
        }

        public static void Finalize(IDbConnection connection)
        {
            connection.Close();
        }
    }
}
