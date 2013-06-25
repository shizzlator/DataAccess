using System.Data;

namespace DataAccess.Interfaces
{
    public interface ITransactionManager
    {
        void Begin();
        bool TransactionInProgress { get; }
        IDbTransaction TransientTransaction { get; }
        void Commit();
        void Rollback();
        void RollbackAndDisposeConnection();
        void CommitAndDisposeConnection();
    }
}