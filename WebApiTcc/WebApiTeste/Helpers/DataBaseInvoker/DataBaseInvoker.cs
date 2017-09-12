using System;
using System.Collections.Generic;
using System.Data;

namespace WebApiTcc.Helpers.DataBaseInvoker
{
    public class DatabaseInvoker : IDatabaseInvoker
    {
        protected IDbConnection _connection { get; }
        private IDbTransaction _transaction { get; set; }

        protected DatabaseCommand _databaseCommand { get; private set; }
        protected List<DatabaseCommand> _databaseCommands { get; }

        public DatabaseInvoker(IDbConnection dbConnection)
        {
            _connection = dbConnection;
        }

        public void BeginNewTransaction()
        {
            DatabaseTransactionFacade.CheckConnection(_connection);
            _transaction = DatabaseTransactionFacade.CheckTransaction(_connection, _transaction);
        }

        public void BeginNewTransaction(IsolationLevel isolationLevel)
        {
            DatabaseTransactionFacade.CheckConnection(_connection);
            _transaction = DatabaseTransactionFacade.CheckTransaction(_connection, _transaction, isolationLevel);
        }

        public void BeginNewStatement(object commandText)
        {
            var dbCommand = _connection.CreateCommand();
            _databaseCommand = new DatabaseCommand(dbCommand);
            _databaseCommand.BeginNewStatement(CommandType.StoredProcedure, commandText.ToString(), 10, _transaction);
        }

        public void BeginNewStatement(CommandType type, string commandText, int timeOut)
        {
            var dbCommand = _connection.CreateCommand();
            _databaseCommand = new DatabaseCommand(dbCommand);
            _databaseCommand.BeginNewStatement(type, commandText, timeOut, _transaction);
        }

        public void AddParameter(object parameter)
        {
            _databaseCommand.AddParameter(parameter);
        }

        public void AddParameter(string parameterName, object value,
            ParameterDirection direction, int size)
        {
            _databaseCommand.AddParameter(
                parameterName, value, direction, size);
        }

        public void AddParameter(string parameterName, object value,
            ParameterDirection direction = ParameterDirection.Input)
        {
            _databaseCommand.AddParameter(
                parameterName, value, direction);
        }

        public void AddParameterReturn()
        {
            _databaseCommand.AddParameter("@RETURN_VALUE", null, ParameterDirection.ReturnValue);
        }

        public T GetOutputParameter<T>()
        {
            return (T)_databaseCommand.GetOutputParameter("@RETURN_VALUE").Value;
        }

        public object GetOutputParameter(string parameterName)
        {
            return _databaseCommand.GetOutputParameter(parameterName).Value;
        }

        public void ExecuteNonQuery()
        {
            DatabaseTransactionFacade.CheckConnection(_connection);
            DatabaseTransactionFacade.CheckStatements(_databaseCommand);
        }

        public void SaveChanges()
        {
            try
            {
                DatabaseTransactionFacade.CommitTransaction(_transaction);
            }
            catch (Exception ex)
            {
                DatabaseTransactionFacade.RollBackTransaction(_transaction);
                throw;
            }
            finally
            {
                DatabaseTransactionFacade.Finalize(_connection);
            }
        }

        public void RollbackTransaction()
        {
            DatabaseTransactionFacade.RollBackTransaction(_transaction);
            DatabaseTransactionFacade.Finalize(_connection);
        }

        public IDataReader ExecuteReader(CommandBehavior commandBehavior)
        {
            DatabaseTransactionFacade.CheckConnection(_connection);
            return _databaseCommand.ExecuteReader(commandBehavior);
        }

        public void CloseConnection()
        {
            DatabaseTransactionFacade.Finalize(_connection);
        }


    }
}
