using System.Data;

namespace Data.Repository.DataBaseInvoker
{
    public interface IDatabaseInvoker
    {
        void BeginNewTransaction();
        void BeginNewTransaction(IsolationLevel isolationLevel);
        void BeginNewStatement(object commandText);
        void BeginNewStatement(CommandType type, string commandText, int timeOut);
        void AddParameter(object parameter);
        void AddParameter(string parameterName, object value,
            ParameterDirection direction, int size);
        void AddParameter(string parameterName, object value,
            ParameterDirection direction = ParameterDirection.Input);
        void AddParameterReturn();
        T GetOutputParameter<T>();
        object GetOutputParameter(string parameterName);
        void ExecuteNonQuery();
        void SaveChanges();
        void RollbackTransaction();
        void CloseConnection();
        IDataReader ExecuteReader(CommandBehavior commandBehavior);
    }
}
