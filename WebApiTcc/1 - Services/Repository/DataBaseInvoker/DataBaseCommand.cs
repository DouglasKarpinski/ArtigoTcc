using System.Data;

namespace Data.Repository.DataBaseInvoker
{
    public sealed class DatabaseCommand
    {
        private IDbCommand _command { get; }

        public DatabaseCommand(IDbCommand dbCommand)
        {
            _command = dbCommand;
        }

        public void BeginNewStatement(CommandType commandType, string commandText, int commandTimeout, IDbTransaction transaction)
        {
            _command.CommandType = commandType;
            _command.CommandText = commandText;
            _command.CommandTimeout = commandTimeout;
            _command.Transaction = transaction;
            _command.Parameters.Clear();
        }

        public void AddParameter(object parameter)
        {
            _command.Parameters.Add(parameter);
        }

        public void AddParameter(string parameterName, object value,
            ParameterDirection direction, int size)
        {
            var parameter = _command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = value;
            parameter.Direction = direction;
            parameter.Size = size;
            _command.Parameters.Add(parameter);
        }

        public void AddParameter(string parameterName, object value,
            ParameterDirection direction)
        {
            var parameter = _command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = value;
            parameter.Direction = direction;
            _command.Parameters.Add(parameter);
        }

        public void ExecuteNonQuery()
        {
            _command.ExecuteNonQuery();
        }

        public IDataReader ExecuteReader(CommandBehavior commandBehavior)
        {
            return _command.ExecuteReader(commandBehavior);
        }

        public IDataParameter GetOutputParameter(string parameterName)
        {
            return (IDataParameter)_command.Parameters[parameterName];
        }
    }
}
